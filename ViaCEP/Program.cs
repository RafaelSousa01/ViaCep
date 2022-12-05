using RestSharp;
using System.IO;


internal class Program
{
    public static void Main(string[] args)
    {
        bool menu = true;

        while (menu)
        {
            Console.WriteLine("----------BUSCA DE ENDEREÇO------------");
            try
            {
                Console.Write("Digite um CEP válido: ");
                string cep = Console.ReadLine();
                Console.WriteLine();

                var client = new RestClient($"https://viacep.com.br");

                var request = new RestRequest($"/ws/{cep}/json/", Method.Get);

                var response = client.Get(request);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(response.Content);
                Console.ForegroundColor = ConsoleColor.White;

                string targetPath = $@"C:\Users\rafae\Documents\AJD\TreinoAPI\APIViaCep\CepPesquisado\{cep}.json";
                File.WriteAllText(targetPath, response.Content);
                Console.WriteLine();
                Console.WriteLine("Deseja encerrar o programa? Digite 's' \n Para realizar outra busca digite 'n'");
                char encerraPrograma = char.Parse(Console.ReadLine());
                if (encerraPrograma == 's')
                {
                    break;
                }
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Digite um valor com 8 digitos! Pressione Enter para continuar");
                Console.ReadLine();
            }
        }
        Console.WriteLine("Programa encerrado!");
    }
}