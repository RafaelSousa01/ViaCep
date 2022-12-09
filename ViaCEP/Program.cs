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

                Console.WriteLine("Para realizar outra busca digite 'b'\n \n Deseja encerrar a busca? Digite 'e' ");
                char encerraBusca = char.Parse(Console.ReadLine());
                if (encerraBusca == 'e' || encerraBusca == 'E')
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
        try
        {
            Console.Clear();
            Console.WriteLine("Busca encerrada!");
            Console.WriteLine();
            Console.WriteLine("Deseja que os CEPs pesquisados seja enviado por e-mail? Digite 's'. \n Ou pressione qualquer tecla para sair.");

            char envioEmail = char.Parse(Console.ReadLine());

            if (envioEmail == 's' || envioEmail == 'S')
            {
                Console.Write("Digite seu nome: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                string username = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.Write("Digite o email para envio: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                string mailTo = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                Functions.SendEmail(username, mailTo);
                Console.WriteLine();
                Console.WriteLine("Email enviado com sucesso!\n\n Pressione qualquer tecla para sair.");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}