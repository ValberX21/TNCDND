
using System.ComponentModel.DataAnnotations;

class Program
{

    public static void Main(string[] args)
    {
 

        int finalizaProgram = 1;


        while (finalizaProgram == 1)
        {
            Console.WriteLine("Informe a compra do cliente");
            Console.WriteLine("Digite o tipo da carne (1 - Filé Duplo, 2 - Alcatra, 3 - Picanha): ");

            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int carnes))
            {
                Console.WriteLine("Entrada inválida. Digite um número entre 1 e 3 ou 0 para sair.");
                continue;
            }

            if (carnes == 0)
            {
                finalizaProgram = 0;
            }
            else
            {
                Console.WriteLine("Digite a quantidade em Kg: ");

                string? kilos = Console.ReadLine();

                if (!int.TryParse(kilos, out int kilosCarne))
                {
                    Console.WriteLine("Entrada inválida. Digite um número acima de zero");
                    continue;
                }

                if (kilosCarne == 0)
                {
                    finalizaProgram = 0;
                }

                Console.WriteLine("Digite o tipo de pagamentoo (1 - Cartão Tabajara, 2 - Outro): 1");

                string? metodoPagamento = Console.ReadLine();

                if (!int.TryParse(metodoPagamento, out int medPagmento))
                {
                    Console.WriteLine("Entrada inválida. Digite o codigo 1 ou 2");
                    continue;
                }

                if (medPagmento == 0)
                {
                    finalizaProgram = 0;
                }

                validaDados(carnes, kilosCarne, medPagmento);
            }
        }

        Console.WriteLine(" ");
        Console.WriteLine("Programa finalizado!");
        Console.WriteLine(" ");
    }


    public static void validaDados(int carne, int kilosCarne, int medPagmento)
    {
        decimal preco = 0;

        switch (carne)
        {
            case 1:
                preco = kilosCarne <= 5 ? 4.90m : 5.80m;
                geraCupomFiscal(carne, preco, kilosCarne, medPagmento);
                break;

            case 2:
                preco = kilosCarne <= 5 ? 5.90m : 6.80m;
                geraCupomFiscal(carne, preco, kilosCarne, medPagmento);
                break;

            case 3:
                preco = kilosCarne <= 5 ? 6.90m : 7.80m;
                geraCupomFiscal(carne, preco, kilosCarne, medPagmento);
                break;
        }
    }

    public static void geraCupomFiscal(int codigoCarne, decimal preco, int kilosCarne, int medPagmento)
    {
        Dictionary<int, string> listCarnes = new Dictionary<int, string>
        {
            {1, "Filé Duplo"},
            {2, "Alcatra"},
            {3, "Picanha"}
        };

        Dictionary<int, string> tiposPagamento = new Dictionary<int, string>
        {
            {1, "Cartão Tabajara"},
            {2, "Outro"}
        };

        Console.WriteLine("Gerando cupom fiscal...");

        Thread.Sleep(3000);

        decimal precoTotal = preco * kilosCarne;
        decimal desconto = 0;

        if (medPagmento == 1)
        {
            desconto = precoTotal * 0.05m;
            precoTotal -= desconto;
        }

        Console.WriteLine("-----------------------");
        Console.WriteLine($"Tipo da carne - {listCarnes.FirstOrDefault(x => x.Key == codigoCarne).Value}");
        Console.WriteLine($"Quantidade - {kilosCarne} Kilos");
        Console.WriteLine($"Tipo de pagamento: {tiposPagamento[medPagmento]}{(medPagmento == 1 ? $" (Desconto de {desconto.ToString("F2")})" : "")}");
        Console.WriteLine($"Preço Total - R$ {precoTotal.ToString("F2")}");
        Console.WriteLine("-----------------------");

    }
}