using System;
using MicroondasDigital.Core;

namespace MicroondasDigital.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem-vindo ao Micro-ondas Digital!");

            var microondas = new Microondas();
            bool continuar = true;

            do
            {
                Console.WriteLine("\nEscolha uma opção:");
                Console.WriteLine("1 - Iniciar aquecimento");
                Console.WriteLine("2 - Iniciar aquecimento rápido");
                Console.WriteLine("3 - Acrescentar tempo durante aquecimento");
                Console.WriteLine("4 - Pausar ou cancelar aquecimento");
                Console.WriteLine("5 - Iniciar programa pré-definido");
                Console.WriteLine("6 - Sair");

                int opcao;
                if (int.TryParse(Console.ReadLine(), out opcao))
                {
                    switch (opcao)
                    {
                        case 1:
                            Console.WriteLine("Digite o tempo (segundos):");
                            var tempoInput = Console.ReadLine();
                            if (tempoInput != null && int.TryParse(tempoInput, out int tempo))
                            {
                                Console.WriteLine("Digite a potência (1 a 10):");
                                var potenciaInput = Console.ReadLine();
                                if (potenciaInput != null && int.TryParse(potenciaInput, out int potencia))
                                {
                                    try
                                    {
                                        microondas.IniciarAquecimento(tempo, potencia);
                                    }
                                    catch (ArgumentException ex)
                                    {
                                        Console.WriteLine($"Erro: {ex.Message}");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Potência inválida. Tente novamente.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Tempo inválido. Tente novamente.");
                            }
                            break;

                        case 2:
                            try
                            {
                                microondas.IniciarAquecimentoRapido();
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine($"Erro: {ex.Message}");
                            }
                            break;

                        case 3:
                            try
                            {
                                microondas.AcrescentarTempo();
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine($"Erro: {ex.Message}");
                            }
                            break;

                        case 4:
                            microondas.PausarOuCanclearAquecimento();
                            break;

                        case 5:
                            Console.WriteLine("Escolha um programa pré-definido:");
                            Console.WriteLine("1 - Pipoca");
                            Console.WriteLine("2 - Leite");
                            Console.WriteLine("3 - Carnes de boi");
                            Console.WriteLine("4 - Frango");
                            Console.WriteLine("5 - Feijão");

                            if (int.TryParse(Console.ReadLine(), out int programaOpcao))
                            {
                                ProgramaAquecimento programaSelecionado = null;
                                switch (programaOpcao)
                                {
                                    case 1:
                                        programaSelecionado = ProgramasPreDefinidos.Pipoca;
                                        break;
                                    case 2:
                                        programaSelecionado = ProgramasPreDefinidos.Leite;
                                        break;
                                    case 3:
                                        programaSelecionado = ProgramasPreDefinidos.CarnesDeBoi;
                                        break;
                                    case 4:
                                        programaSelecionado = ProgramasPreDefinidos.Frango;
                                        break;
                                    case 5:
                                        programaSelecionado = ProgramasPreDefinidos.Feijao;
                                        break;
                                    default:
                                        Console.WriteLine("Programa inválido. Tente novamente.");
                                        break;
                                }

                                if (programaSelecionado != null)
                                {
                                    microondas.IniciarProgramaPreDefinido(programaSelecionado);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Opção inválida. Tente novamente.");
                            }
                            break;

                        case 6:
                            continuar = false;
                            break;

                        default:
                            Console.WriteLine("Opção inválida. Tente novamente.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opção inválida. Tente novamente.");
                }

            } while (continuar);

            Console.WriteLine("Programa encerrado.");
        }
    }
}
