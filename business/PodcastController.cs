using dataAccess;
using models;
using System.Xml;
using System.ServiceModel.Syndication;

namespace business
{
    public class PodcastController
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

                            if (!string.IsNullOrEmpty(avsnittTitel) && !string.IsNullOrEmpty(avsnittUrl))
                            {
                                enPodcast.AddAvsnitt(avsnittTitel, avsnittUrl); // lägger till avsnitt t podcast
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

        /*//Hämta och sparar podcastavsnitt från 1 RSS-flöde till repositoryn
       public Podcast HamtaPodcastFranRSS(string URL)
       {
           XmlReader XMLlasare = XmlReader.Create(URL);
           SyndicationFeed podcastFlode = SyndicationFeed.Load(XMLlasare);

           Podcast enPodcast = new Podcast(podcastFlode.Title.Text, URL); // podcastnamn

           foreach (SyndicationItem item in podcastFlode.Items)
           {
               string episodeTitle = item.Title.Text;
               string episodeUrl = item.Links.FirstOrDefault()?.Uri.ToString();

               if (!string.IsNullOrEmpty(episodeTitle) && !string.IsNullOrEmpty(episodeUrl))
               {
                   enPodcast.AddAvsnitt(episodeTitle, episodeUrl); // Add episode to podcast
               }
           }
           podcastRepository.LaggTillPodcast(enPodcast); //Sparar podcast

           return enPodcast;
       }
       */
    }
}
