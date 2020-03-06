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
            var weburl = args[0];
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(weburl);

            if (response.IsSuccessStatusCode)
            {
                var htmlContent = await response.Content.ReadAsStringAsync();

                var regex = new Regex("[a-z]+[a-z0-9-]*@[a-z0-9-]\\.[a-z]+", RegexOptions.IgnoreCase);
                var emailAddress = regex.Matches(htmlContent);
                foreach (var match in emailAddress)
                {
                    Console.WriteLine(match.ToString());
                }
            }


            Console.WriteLine("All Email from the Webpages are Listed");
        }
    }
}
