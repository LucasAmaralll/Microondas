using System;
using System.Linq;
using MicroondasDigital.Core;

namespace MicroondasDigital.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Microondas microondas = new Microondas();
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("\nEscolha uma opção:");
                Console.WriteLine("1 - Iniciar Aquecimento");
                Console.WriteLine("2 - Iniciar Aquecimento Rápido");
                Console.WriteLine("3 - Pausar/Cancelar Aquecimento");
                Console.WriteLine("4 - Acrescentar Tempo");
                Console.WriteLine("5 - Iniciar Programa Pré-definido");
                Console.WriteLine("6 - Adicionar Programa Customizado");
                Console.WriteLine("7 - Sair");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.WriteLine("Informe o tempo em segundos:");
                        int tempo = int.Parse(Console.ReadLine());

                        Console.WriteLine("Informe a potência (1 a 10):");
                        int potencia = int.Parse(Console.ReadLine());

                        try
                        {
                            microondas.IniciarAquecimento(tempo, potencia);
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case "2":
                        microondas.IniciarAquecimentoRapido();
                        break;

                    case "3":
                        microondas.PausarOuCanclearAquecimento();
                        break;

                    case "4":
                        microondas.AcrescentarTempo();
                        break;

                    case "5":
                        var programas = ProgramasPreDefinidos.ObterTodosProgramas();
                        Console.WriteLine("Escolha um programa pré-definido:");

                        for (int i = 0; i < programas.Count; i++)
                        {
                            Console.WriteLine($"{i + 1} - {programas[i].Nome}");
                        }

                        int programaEscolhido = int.Parse(Console.ReadLine()) - 1;

                        if (programaEscolhido >= 0 && programaEscolhido < programas.Count)
                        {
                            microondas.IniciarProgramaPreDefinido(programas[programaEscolhido]);
                        }
                        else
                        {
                            Console.WriteLine("Programa inválido.");
                        }
                        break;

                    case "6":
                        ProgramaAquecimento programaCustomizado = new ProgramaAquecimento();

                        Console.WriteLine("Informe o nome do programa:");
                        programaCustomizado.Nome = Console.ReadLine();

                        Console.WriteLine("Informe o tipo de alimento:");
                        programaCustomizado.Alimento = Console.ReadLine();

                        Console.WriteLine("Informe o tempo em segundos:");
                        programaCustomizado.Tempo = int.Parse(Console.ReadLine());

                        Console.WriteLine("Informe a potência (1 a 10):");
                        programaCustomizado.Potencia = int.Parse(Console.ReadLine());

                        Console.WriteLine("Informe o caractere de aquecimento (não pode ser ponto e deve ser único):");
                        programaCustomizado.CaractereAquecimento = Console.ReadLine();

                        Console.WriteLine("Informe as instruções:");
                        programaCustomizado.Instrucoes = Console.ReadLine();

                        try
                        {
                            microondas.AdicionarProgramaCustomizado(programaCustomizado);
                            Console.WriteLine("Programa customizado adicionado com sucesso.");
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case "7":
                        continuar = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }
    }
}
