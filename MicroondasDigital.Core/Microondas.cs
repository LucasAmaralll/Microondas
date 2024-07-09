using System;
using System.Threading;


namespace MicroondasDigital.Core
{
    public class Microondas : IMicroondas
    {
        private bool aquecendo;
        private int tempoRestante;
        private int potenciaAtual;

        public Microondas()
        {
            aquecendo = false;
            tempoRestante = 0;
            potenciaAtual = 10; // potência padrão
        }

        public void IniciarAquecimento(int tempoSegundos, int potencia)
        {
            if (tempoSegundos < 1 || tempoSegundos > 120)
            {
                throw new ArgumentException("Tempo deve ser entre 1 segundo e 2 minutos.");
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

            Console.WriteLine($"Aquecimento iniciado por {tempoRestante} segundos, potência {potenciaAtual}.");
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

        private void ProcessarAquecimento()
        {
            while (tempoRestante > 0 && aquecendo)
            {
                Console.Write(". ");
                Thread.Sleep(potenciaAtual * 100); // simula o aquecimento com base na potência
                tempoRestante--;
            }

            if (aquecendo)
            {
                Console.WriteLine("\nAquecimento concluído.");
                aquecendo = false;
            }
        }
    }
}
