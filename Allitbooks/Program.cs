using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Allitbooks
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Logger
            var loggerFactory = new LoggerFactory().AddConsole();
            var logger = loggerFactory.CreateLogger(typeof(Program));

            //Configuration
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json");
            var config = builder.Build();
            var site = config.GetSection("Site").Value;

            //logger.LogInformation(site);

            var html = HTTPUtil.GetHtml(site);
            //HtmlDocument doc = new HtmlDocument();
            //HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = new HtmlDocument();
            //logger.LogInformation(html);
            doc.LoadHtml(html);

            //XPath 语法
            HtmlNodeCollection categoryNodes = doc.DocumentNode.SelectNodes("//h3/a[@class='titlelnk']");
            IEnumerable<string> category = categoryNodes.Select(x=>x.Attributes["href"].Value + "  " + x.InnerText).ToList();

            foreach (var item in category)
            {
                logger.LogInformation(item);
            }

            Console.ReadLine();
        }
    }


    /// <summary>
    /// Send Http Request
    /// </summary>
    public class HTTPUtil
    {
        public static readonly HttpClient Client = new HttpClient();

        public static string GetHtml(string url)
        {
            try
            {
                //Http Request
                System.Net.WebRequest request = WebRequest.Create(url);
                var response = request.GetResponse();
                Stream stream = response.GetResponseStream();
                using (StreamReader reader = new StreamReader(stream))
                {

                    var html = reader.ReadToEnd();
                    stream.Close();
                    response.Close();
                    return html;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }


}
