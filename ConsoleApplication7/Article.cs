namespace ConsoleApplication7
{
    public class Article
    {
            public string Url { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }
            public string Image { get; set; }
            public override string ToString()
            {
                return $"Url: {Url}, Title: {Title}, Content: {Content}, Image: {Image}";
            }

            public string ToShortString()
            {
                return $"Url: {Url}.\nTitle: {Title}";
            }
    }
}