using System.Xml.Serialization;
using models;

namespace dataAccess
{
    public class PodcastRepository
    {
        private List<Podcast> PodcastLista;
        private readonly string FilePath = "data.xml";

        public PodcastRepository()
        {
            PodcastLista = LaddaFranFil();
        }
        public void LaggTillPodcast(Podcast podcast)
        {

            if (PodcastLista.Any(p => p.URL == podcast.URL))
            {
                throw new Exception("Angiven podcast finns redan.");
            }
            else
            {
                PodcastLista.Add(podcast);
                SparaTillFil();
            }
        }

        public List<Podcast> HamtaAllaPodcast()
        {
            return PodcastLista;
        }

        private void SparaTillFil()
        {
            var serializer = new XmlSerializer(typeof(List<Podcast>));
            using (var writer = new StreamWriter(FilePath))
            {
                serializer.Serialize(writer, PodcastLista);
            }
        }

        private List<Podcast> LaddaFranFil()
        {
            if (!File.Exists(FilePath))
            {
                return new List<Podcast>();
            }

            var serializer = new XmlSerializer(typeof(List<Podcast>));
            using (var reader = new StreamReader(FilePath))
            {
                return (List<Podcast>)serializer.Deserialize(reader);
            }
        }
    }
}

