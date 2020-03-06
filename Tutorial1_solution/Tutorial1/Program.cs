using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net.Http;

namespace Tutorial1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var weburl = args.Length > 0 ? args[0] : throw new ArgumentNullException();

            //  if (weburl == null) { throw new ArgumentException("Url cannot be null"); }

            // var x = weburl ?? throw new ArgumentException("Website url is null !!");

            try
            {

                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(weburl);

                if (response.IsSuccessStatusCode)
                {
                    var htmlContent = await response.Content.ReadAsStringAsync();

                    var regex = new Regex("[a-z]+[a-z0-9-]*@[a-z0-9-]+\\.[a-z]+", RegexOptions.IgnoreCase);
                    var emailAddress = regex.Matches(htmlContent);
                    foreach (var match in emailAddress)
                    {
                        Console.WriteLine(match.ToString());
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error while downloading the page");
            }


            
        }
    }
}
