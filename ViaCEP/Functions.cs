using RestSharp;

namespace ViaCEP
{
    public class Functions
    {

        public static void CreateFile(string nameFile, string valueFile)
        {
            try
            {
                var directory = Path.Combine(Directory.GetCurrentDirectory(), "Cep pesquisado");

                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                var file = Path.Combine(directory, nameFile);

                if (!Directory.Exists(file))
                {
                    File.Create(file).Dispose();

                    using (TextWriter tw = new StreamWriter(file))
                    {
                        tw.WriteLine(valueFile);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }




    }
}
