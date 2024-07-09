using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading;
using MicroondasDigital.Core.Interfaces;

namespace MicroondasDigital.Core
{
    public class Microondas : IMicroondas
    {
        private bool aquecendo;
        private int tempoRestante;
        private int potenciaAtual;
        private string caractereAquecimento;

        private readonly string caminhoArquivoJson = "programasCustomizados.json";
        private List<ProgramaAquecimento> programasCustomizados;

        public Microondas()
        {
            aquecendo = false;
            tempoRestante = 0;
            potenciaAtual = 10; // potência padrão
            caractereAquecimento = ".";
            programasCustomizados = new List<ProgramaAquecimento>();
            CarregarProgramasCustomizados();
        }

        public void IniciarAquecimento(int tempoSegundos, int potencia)
        {
            if (tempoSegundos < 1)
            {
                throw new ArgumentException("Tempo deve ser maior que 1 segundo.");
            }

            if (potencia < 1 || potencia > 10)
            {
                throw new ArgumentException("Potência deve ser entre 1 e 10.");
            }

            if (aquecendo)
            {
                Console.WriteLine("Já existe um aquecimento em andamento.");
                return;
            }

            aquecendo = true;
            tempoRestante = tempoSegundos;
            potenciaAtual = potencia;

            if (tempoRestante >= 60 && tempoRestante < 100)
            {
                int minutos = tempoRestante / 60;
                int segundos = tempoRestante % 60;
                Console.WriteLine($"Aquecimento iniciado por {minutos}:{segundos:D2} minutos, potência {potenciaAtual}.");
            }
            else
            {
                Console.WriteLine($"Aquecimento iniciado por {tempoRestante} segundos, potência {potenciaAtual}.");
            }

            Thread thread = new Thread(ProcessarAquecimento);
            thread.Start();
        }

        public void PausarOuCanclearAquecimento()
        {
            if (!aquecendo)
            {
                Console.WriteLine("Não há aquecimento em andamento para pausar ou cancelar.");
                return;
            }

            aquecendo = false;
            tempoRestante = 0;
            potenciaAtual = 0;

            Console.WriteLine("Aquecimento pausado ou cancelado.");
        }

        public void IniciarAquecimentoRapido()
        {
            IniciarAquecimento(30, 10); // aquecimento rápido com 30 segundos e potência máxima
        }

        public void AcrescentarTempo()
        {
            if (!aquecendo)
            {
                Console.WriteLine("Não há aquecimento em andamento para acrescentar tempo.");
                return;
            }

            tempoRestante += 30;
            Console.WriteLine($"Tempo acrescentado. Novo tempo restante: {tempoRestante} segundos.");
        }

        public void IniciarProgramaPreDefinido(ProgramaAquecimento programa)
        {
            caractereAquecimento = programa.CaractereAquecimento;
            IniciarAquecimento(programa.Tempo, programa.Potencia);
        }

        private void ProcessarAquecimento()
        {
            while (tempoRestante > 0 && aquecendo)
            {
                Console.Write(caractereAquecimento);
                Thread.Sleep(potenciaAtual * 100); // simula o aquecimento com base na potência
                tempoRestante--;
            }

            if (aquecendo)
            {
                Console.WriteLine("\nAquecimento concluído.");
                aquecendo = false;
            }
        }

        public void AdicionarProgramaCustomizado(ProgramaAquecimento programa)
        {
            if (string.IsNullOrWhiteSpace(programa.Nome) || string.IsNullOrWhiteSpace(programa.Alimento) || programa.Tempo <= 0 || programa.Potencia < 1 || programa.Potencia > 10)
            {
                throw new ArgumentException("Informações do programa inválidas.");
            }

            if (programa.CaractereAquecimento == "." || ProgramasPreDefinidos.ObterTodosProgramas().Exists(p => p.CaractereAquecimento == programa.CaractereAquecimento) || programasCustomizados.Exists(p => p.CaractereAquecimento == programa.CaractereAquecimento))
            {
                throw new ArgumentException("Caractere de aquecimento inválido ou duplicado.");
            }

            programasCustomizados.Add(programa);
            SalvarProgramasCustomizados();
        }

        private void CarregarProgramasCustomizados()
        {
            if (File.Exists(caminhoArquivoJson))
            {
                string json = File.ReadAllText(caminhoArquivoJson);
                programasCustomizados = JsonSerializer.Deserialize<List<ProgramaAquecimento>>(json) ?? new List<ProgramaAquecimento>();
            }
        }

        private void SalvarProgramasCustomizados()
        {
            string json = JsonSerializer.Serialize(programasCustomizados, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(caminhoArquivoJson, json);
        }

        public List<ProgramaAquecimento> ObterProgramasCustomizados()
        {
            return programasCustomizados;
        }
    }
}
