using System;
using System.Globalization;
using System.Runtime.ConstrainedExecution;
using RestSharp;

internal class Program
{
    private static void Main(string[] args)
    {
        bool menu = true;

        while (menu)
        {
            Console.WriteLine("----------BUSCA DE ENDEREÇO------------");
            Console.WriteLine("Você sabe seu CEP? Se sim, digite 's'. ");
            Console.WriteLine("Digite 'n' para caso não saber seu CEP");
            char escolha1 = char.Parse(Console.ReadLine());

            var client = new RestClient($"https://viacep.com.br");

            if (escolha1 == 's')
            {
                Console.WriteLine("Digite um CEP valido:");

                string cep = Console.ReadLine();

                var request = new RestRequest($"/ws/{cep}/json/", Method.Get);

                var response = client.Get(request);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(response.Content);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.WriteLine("Digite a UF (Obrigatório): ");
                string uf = Console.ReadLine();
                Console.WriteLine("Digite a Cidade (Obrigatório): ");
                string cidade = Console.ReadLine();
                Console.WriteLine("Digite o endereço: \n (Pode ser o endereço completo ou apenas um nome que lembrar)");
                string endereço = Console.ReadLine();

                var request = new RestRequest($"/ws/{uf}/{cidade}/{endereço}/json/", Method.Get);

                var response = client.Get(request);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(response.Content);
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("Deseja encerrar o programa? Digite 's' \n Para realizar outra busca digite 'n'");
            char encerraPrograma = char.Parse(Console.ReadLine());
            if (encerraPrograma == 's')
            {
                break;
            }
            Console.Clear();
        }
        Console.WriteLine("Programa encerrado!");

        Console.ReadLine();
    }
}