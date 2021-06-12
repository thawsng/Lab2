using System.Collections.Generic;

namespace ConsoleApplication7
{
    public interface Crawler
    {
        Article CrawlDetail(string url);
        
        List<string> GetListLink(string listUrl);
    }
}