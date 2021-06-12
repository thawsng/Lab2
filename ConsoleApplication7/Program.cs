using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApplication7.crawler;
using HtmlAgilityPack;

namespace ConsoleApplication7
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var list = new List<string>();
            var web = new HtmlWeb();
            var doc = web.Load("https://vnexpress.net/giai-tri");
            var listNodes = doc.DocumentNode.SelectNodes("//h3[contains(@class, 'title-new')]/a");
            for (int i = 0; i < listNodes.Count; i++)
            { 
                var link = listNodes.ElementAt(i).Attributes["href"].Value;
                list.Add(link);
            }

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
                var document = web.Load(list[i]);
                var doctitle = document.DocumentNode.SelectSingleNode("//h1[contains(@class, 'title-detail')]");
                Console.WriteLine(doctitle.InnerText);
            }
        }
    }
}