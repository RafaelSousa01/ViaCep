using MimeKit;
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
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public static void SendEmail(string username, string mailTo)
        {
            try
            {
                var directory = Path.Combine(Directory.GetCurrentDirectory(), "Cep pesquisado");

                var files = Directory.GetFiles(directory, "*.json");

                string textMail = "";

                foreach (var file in files)
                {
                    using (StreamReader sr = new StreamReader($"{file}"))
                    {
                        string textJson = sr.ReadToEnd();
                        textMail += $"{textJson}\n\n";
                    }
                }

                var mail = new MimeMessage();
                mail.From.Add(new MailboxAddress("ViaCEP App", "")); //inserir e-mail remetente
                mail.To.Add(new MailboxAddress(username, mailTo));
                mail.Subject = "CEP PESQUISADO";
                mail.Body = new TextPart(MimeKit.Text.TextFormat.Text)
                {
                    Text = textMail
                };

                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect("smtp.office365.com", 587, false); //Servidor Hotmail
                    client.Authenticate("", ""); //EnderecoEmailHotmail , Senha
                    client.Send(mail);
                    client.Disconnect(true);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
