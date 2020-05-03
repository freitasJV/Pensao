using System;
using System.Collections.Concurrent;
using System.IO;

namespace Pensao
{
    class Program
    {
        /// <summary>
        /// Este exemplo leva em consideração uma pensão
        /// com 10 quartos para serem alugados.
        /// </summary>
        /// <param name="args"></param>

        static void Main(string[] args)
        {
            try
            {
                int qtdeQuartos = 10, qtdeAlugados = 0;
                bool fim = false;

                Locatario[] quartos = new Locatario[qtdeQuartos];

                while (qtdeQuartos - qtdeAlugados > 0 && !fim)
                {
                    Console.WriteLine($"Quantos quartos deseja alugar? no momento temos {qtdeQuartos - qtdeAlugados} vagas");
                    int qtde = int.Parse(Console.ReadLine());

                    if (qtde > qtdeQuartos - qtdeAlugados || qtde <= 0)
                        Console.WriteLine("Quantidade inválida");
                    else
                    {
                        for (int i = 1; i <= qtde; i++)
                        {
                            Console.WriteLine($"Digite o nome do {i}º Locatário: ");
                            string nome = Console.ReadLine();
                            Console.WriteLine($"Digite o email do {i}º Locatário: ");
                            string email = Console.ReadLine();
                            Console.WriteLine($"Digite o quarto escolhido de 0 a {qtdeQuartos - 1}: ");
                            int numero = int.Parse(Console.ReadLine());

                            while (numero < 0 | numero >= qtdeQuartos)
                            {
                                Console.WriteLine($"Digite um quarto de 0 a {qtdeQuartos - 1}: ");
                                numero = int.Parse(Console.ReadLine());
                            }

                            while (quartos[numero] != null)
                            {
                                Console.WriteLine("Quarto indisponível, escolha outro quarto: ");
                                numero = int.Parse(Console.ReadLine());
                            }

                            quartos[numero] = new Locatario
                            {
                                Nome = nome,
                                Email = email
                            };
                        }
                        qtdeAlugados += qtde;
                    }

                    Console.WriteLine("Deseja finalizar o programa? Em caso positivo digite sim e pressione enter, caso contrário pressione enter");
                    string final = Console.ReadLine().ToLower();

                    if (final.Equals("sim"))
                        fim = true;
                }

                Console.WriteLine("Quartos Ocupados: ");
                for (int i = 0; i < qtdeQuartos; i++)
                {
                    if (quartos[i] != null)
                    {
                        Console.WriteLine($"{i}: {quartos[i]}");
                    }
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Erro de formatação: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro inesperado: {e.Message}");
            }
        }
    }
}
