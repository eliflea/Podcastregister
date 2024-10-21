using dataAccess;
using models;
using System.Xml;
using System.ServiceModel.Syndication;

namespace business
{
    public class PodcastController
    {
        private PodcastRepository podcastRepository;

        public PodcastController()
        {
            podcastRepository = new PodcastRepository();
        }

        // Hämta podcastavsnitt från podcastRepository
        public List<Podcast> HamtaAllaPodcast()
        {
            return podcastRepository.HamtaAllaPodcast();
        }

        //Hämta och sparar podcastavsnitt från 1 RSS-flöde till repositoryn
        public void HamtaPodcastFranRSS(string URL)
        {
            XmlReader XMLlasare = XmlReader.Create(URL);
            SyndicationFeed podcastFlode = SyndicationFeed.Load(XMLlasare);

            foreach (SyndicationItem item in podcastFlode.Items)
            {
                Podcast enPodcast = new Podcast(avsnitt: item.Title.Text)
                {
                    Avsnitt = item.Title.Text
                };

                podcastRepository.LaggTillPodcast(enPodcast); //Sparar podcast
            }
        }
    }
}
