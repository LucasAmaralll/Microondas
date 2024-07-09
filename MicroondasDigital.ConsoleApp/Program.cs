using System;

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
                Console.WriteLine("5 - Sair");

                int opcao;
                if (int.TryParse(Console.ReadLine(), out opcao))
                {
                    switch (opcao)
                    {
                        case 1:
                            Console.WriteLine("Digite o tempo (segundos):");
                            int tempo = int.Parse(Console.ReadLine());

                            Console.WriteLine("Digite a potência (1 a 10):");
                            int potencia = int.Parse(Console.ReadLine());

                            try
                            {
                                microondas.IniciarAquecimento(tempo, potencia);
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine($"Erro: {ex.Message}");
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
