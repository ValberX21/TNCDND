using System;

class Program
{
    public static void Main(string[] args)
    {
        int finalizaProgram = 1;

        while (finalizaProgram == 1) 
        {
            Console.Write("Digite o salario para aumento ou zero para fechar: ");

            decimal salUsuario = Decimal.Parse(Console.ReadLine());

            if (salUsuario == 0)
            {
                finalizaProgram = 0;

            }
            else if (salUsuario > 0 && salUsuario <= 280)
            {
                aumento(salUsuario, 20);
            }
            else if (salUsuario > 280 && salUsuario < 700)
            {
                aumento(salUsuario, 15);
            }
            else if (salUsuario > 700 && salUsuario < 1500)
            {
                aumento(salUsuario, 10);
            }
            else if (salUsuario > 1500)
            {
                aumento(salUsuario, 5200);
            }                        
        }

        Console.WriteLine("Preciona qualquer tecla NO TECLADO para fechar essa tela...");
        Console.ReadKey();

    }

    public static decimal aumento(decimal salUsuario, decimal porcentagem)
    {
        decimal valorAumento = (salUsuario * (porcentagem / 100));
        decimal novoSalario = salUsuario + (salUsuario * (porcentagem / 100));

        Console.WriteLine($"Salario antes do reajuste: {salUsuario.ToString("F2")}");
        Console.WriteLine($"Percentual de aumento aplicado: {porcentagem.ToString("F2")}%");
        Console.WriteLine($"Valor do aumento: {valorAumento.ToString("F2")}");
        Console.WriteLine($"O novo salario, apos o aumento: {novoSalario.ToString("F2")}");

        return salUsuario + (salUsuario * (porcentagem / 100));
    }

}
