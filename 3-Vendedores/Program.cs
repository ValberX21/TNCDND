using System.Collections.Generic;

class Program
{
    public static void Main(string[] args)
    {     
        int finalizaProgram = 1;

        int[] contadores = new int[9];

        while (finalizaProgram == 1)
        {
            Console.Write("Digite o valor das vendas do vendedor (ou 0 para sair): ");
            
            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int sistemaSelecionado))
            {
                Console.WriteLine("Entrada inválida. Digite um número entre 1 e 6 ou 0 para sair.");
                continue; 
            }

            if (sistemaSelecionado == 0)
            {
                finalizaProgram = 0;
            }
            else
            {
                if (decimal.TryParse(input, out decimal vendas))
                {
                    decimal salario = 200 + (vendas * 0.09m);
                    int posicao = (int)((salario - 200) / 100);
                    if (posicao > 8)
                        posicao = 8;

                    contadores[posicao]++;
                }
                else
                {
                    Console.WriteLine("Valor inválido. Tente novamente.");
                }
            }
        }

        Console.WriteLine("\nDistribuição de salários:");
        for (int i = 0; i < contadores.Length; i++)
        {
            if (i == 8)
            {
                Console.WriteLine($"$1000 ou mais: {contadores[i]} vendedor(es)");
            }      
            else
            {
                Console.WriteLine($"${200 + i * 100} - ${299 + i * 100}: {contadores[i]} vendedor(es)");
            }
        }
    }
}