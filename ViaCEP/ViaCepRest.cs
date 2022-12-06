using RestSharp;

namespace ViaCEP
{
    public class ViaCepRest
    {

        public static string GetCep(string cep)
        {
            try
            {
                var client = new RestClient($"https://viacep.com.br");

                var request = new RestRequest($"/ws/{cep}/json/", Method.Get);

                var response = client.Get(request);

                return response.Content;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

    }
}
