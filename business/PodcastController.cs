using dataAccess;
using models;
using System.Xml;
using System.ServiceModel.Syndication;

namespace business
{
    public class PodcastController : IPodcastService
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private PodcastRepository podcastRepository;

        public PodcastController()
        {
            podcastRepository = new PodcastRepository();
        }

        public async Task<Podcast> HamtaPodcastFranRSSAsync(string URL)
        //Hämta och sparar podcastavsnitt från 1 RSS-flöde till repositoryn
        {
            if (!utilities.Validator.IsValidUrl(URL))
            {
                throw new ArgumentException("Ogiltig URL.");
            }

            try
                {
                    // hämtar RSS-flödet som en string
                    string xmlContent = await httpClient.GetStringAsync(URL);

                    using (var stringReader = new StringReader(xmlContent))
                    using (XmlReader xmlReader = XmlReader.Create(stringReader))
                    {
                        SyndicationFeed podcastFlode = SyndicationFeed.Load(xmlReader);
                        Podcast enPodcast = new Podcast(podcastFlode.Title.Text, URL); // podcastnamn

                        foreach (SyndicationItem item in podcastFlode.Items)
                        {
                            string avsnittTitel = item.Title.Text;
                            string avsnittUrl = item.Links.FirstOrDefault()?.Uri.ToString();
                            string avsnittBeskrivning = item.Summary.Text;

                        if (!string.IsNullOrEmpty(avsnittTitel) && !string.IsNullOrEmpty(avsnittUrl) && !string.IsNullOrEmpty(avsnittBeskrivning))
                            {
                                enPodcast.AddAvsnitt(avsnittTitel, avsnittUrl, avsnittBeskrivning); // lägger till avsnitt t podcast
                            }
                        }

                        podcastRepository.LaggTillPodcast(enPodcast); // sparar podcast
                        return enPodcast;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Fel vid hämtning: {ex.Message}", ex);

            }
        }

        public List<Podcast> HamtaAllaPodcast()
        {
            return podcastRepository.HamtaAllaPodcast();
        }
    }
}
