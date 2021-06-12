using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace ConsoleApplication7.crawler
{
    public class VnexpressCrawler : Crawler
    {
        public Article CrawlDetail(string url)
        {
            try
            {
                var htmlWeb = new HtmlWeb();
                var htmlDocument = htmlWeb.Load(url);
                var titleNode = htmlDocument.DocumentNode.SelectSingleNode("//h1[contains(@class, 'title-detail')]");
                var title = titleNode.InnerText;
                var contentNode =
                    htmlDocument.DocumentNode.SelectSingleNode("//article[contains(@class, 'fck_detail')]");
                var content = contentNode.InnerHtml;
                var imageNode = htmlDocument.DocumentNode.SelectSingleNode("//picture/img");
                var image = imageNode.Attributes["src"].Value;
                var article = new Article
                {
                    Title = title,
                    Content = content,
                    Image = image,
                    Url = url
                };
                return article;
            }
            catch (Exception e)
            {
                Console.WriteLine();
                return null;
            }
        }

        public List<string> GetListLink(string urlToGetListLink)
        {
            var listlink = new List<string>();
            var htmlWeb = new HtmlWeb();
            var htmlDocument = htmlWeb.Load(urlToGetListLink);
            var listNodeA = htmlDocument.DocumentNode.SelectNodes("//h3[contains(@class, 'title-news')]/a");
            for (int i = 0; i < listNodeA.Count; i++)
            {
                var link = listNodeA.ElementAt(i).Attributes["href"].Value;
                listlink.Add(link);
            }

            return listlink;
        }
    }
}