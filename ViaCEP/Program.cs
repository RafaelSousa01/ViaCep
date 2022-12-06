using RestSharp;
using System.IO;
using ViaCEP;

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
                string viaCep = ViaCepRest.GetCep(cep);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(viaCep);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Functions.CreateFile($"{cep}.json", viaCep);
                  
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