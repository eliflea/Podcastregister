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

        //Hämta och sparar podcastavsnitt från 1 RSS-flöde till repositoryn
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
    }
}
