using models;

namespace dataAccess
{
    public class PodcastRepository
    {
        private List<Podcast> podcastLista = new List<Podcast>();

        public void LaggTillPodcast(Podcast podcast)
        {
            podcastLista.Add(podcast);
        }

        public List<Podcast> HamtaAllaPodcast()
        {
            return podcastLista;
        }
    }
}

