using _2_PesquisaSO;
using System.Collections.Generic;

class Program
{
    public static void Main(string[] args)
    {
        int finalizaProgram = 1;

        List<string> sistemasOperacionais = 
            ["1- Windows Server",
             "2- Unix",
             "3- Linux",
             "4- Netware",
             "5- Mac OS",
             "6- Outro"
             ];

        int votosSO1 = 0;
        int votosSO2 = 0;
        int votosSO3 = 0;
        int votosSO4 = 0;
        int votosSO5 = 0;
        int votosSO6 = 0;

        int totalVotosPesquisa = 0;

        while (finalizaProgram == 1)
        {
            Console.Write("Qual o melhor Sistema Operacional para uso em servidores?\n");
            Console.Write("As possíveis respostas são:\n");

            foreach (string os in sistemasOperacionais)
            {
                Console.Write(os + "\n");
            }

            Console.WriteLine("Manda seu voto ai: ");

            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int sistemaSelecionado))
            {
                Console.WriteLine("Entrada inválida. Digite um número entre 1 e 6 ou 0 para sair.");
                continue; 
            }

            if (sistemaSelecionado == 0)
            {
                if (totalVotosPesquisa == 0)
                {
                    Console.WriteLine("Nenhum valor foi informado para esquisa, informe pelo menos 1 voto !");
                }
                else
                {
                    finalizaProgram = 0;
                }
            }
            else if (sistemaSelecionado > 6)
            {
                Console.WriteLine("Por favor informe um numero dentre 1 a 6 conforme a lista ou zero para finalizar");
            }
            else
            {
                totalVotosPesquisa += 1;

                switch (sistemaSelecionado)
                {
                    case 1:
                        votosSO1 += 1;
                        break;

                    case 2:
                        votosSO2 += 1;
                        break;

                    case 3:
                        votosSO3 += 1;
                        break;

                    case 4:
                        votosSO4 += 1;
                        break;

                    case 5:
                        votosSO5 += 1;
                        break;

                    case 6:
                        votosSO6 += 1;
                        break;
                }
            }           
        }

        if(totalVotosPesquisa > 0)
        {
            List<DtPesquisa> sistemas = new List<DtPesquisa>
            {
                new DtPesquisa { OS = "Windows Server", Votos = votosSO1, Porcentagem = (votosSO1 * 100)/ totalVotosPesquisa },
                new DtPesquisa { OS = "Unix"          , Votos = votosSO2, Porcentagem = (votosSO2 * 100)/ totalVotosPesquisa },
                new DtPesquisa { OS = "Linux"         , Votos = votosSO3, Porcentagem = (votosSO3 * 100)/ totalVotosPesquisa },
                new DtPesquisa { OS = "Netware"       , Votos = votosSO4, Porcentagem = (votosSO4 * 100)/ totalVotosPesquisa },
                new DtPesquisa { OS = "Mac OS"        , Votos = votosSO5, Porcentagem = (votosSO5 * 100)/ totalVotosPesquisa },
                new DtPesquisa { OS = "Outro"         , Votos = votosSO6, Porcentagem = (votosSO6 * 100)/ totalVotosPesquisa }
            };

            calculaResultadoPesquisa(sistemas, totalVotosPesquisa);
        }
    }
    
    public static void calculaResultadoPesquisa(List<DtPesquisa> sistemas, int totalVotos)
    {

        Console.WriteLine();
        Console.WriteLine("Sistema Operacional   Votos   %");
        Console.WriteLine("--------------------  -----  ---");

        DtPesquisa maisVotado = sistemas[0];

        foreach (var item in sistemas)
        {
            Console.WriteLine($"{item.OS,-20}  {item.Votos,5}  {item.Porcentagem,3}%");

            if (item.Votos > maisVotado.Votos)
            {
                maisVotado = item;
            }
        }

        Console.WriteLine("--------------------  -----  ---");
        Console.WriteLine($"Total                {totalVotos,5}");

        Console.WriteLine($"\nO Sistema Operacional mais votado foi o {maisVotado.OS}, com {maisVotado.Votos} votos, correspondendo a {maisVotado.Porcentagem}% dos votos.");
    }
}