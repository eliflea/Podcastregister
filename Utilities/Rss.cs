using System.Net.Http;
using System.ServiceModel.Syndication;
using System.Xml;

namespace utilities
{
    public static class Rss
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public static async Task<SyndicationFeed> FetchaRssFeedAsync(string url)
        {
            string xmlContent = await httpClient.GetStringAsync(url);

            using (var stringReader = new StringReader(xmlContent))
            using (XmlReader xmlReader = XmlReader.Create(stringReader))
            {
                return SyndicationFeed.Load(xmlReader);
            }
        }
    }
}
