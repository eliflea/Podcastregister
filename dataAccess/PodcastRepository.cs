using System.Xml.Linq;
using System.Xml.Serialization;
using models;

namespace dataAccess
{
    public class PodcastRepository
    {
        private List<Podcast> PodcastLista;
        private readonly string FilePath = "data.xml";
        private List<string> KategoriLista;
        private readonly string KategoriFilePath = "kategorier.xml";


        public PodcastRepository()
        {
            PodcastLista = LaddaFranFil();
            KategoriLista = LaddaKategorierFranFil();


        }
        public void LaggTillKategori(string kategori)
        {
            if (!KategoriLista.Contains(kategori))
            {
                KategoriLista.Add(kategori);
                SparaKategorierTillFil();
            }
            else
            {
                throw new Exception("Kategorin finns redan.");
            }
        }

        public void TaBortKategori(string kategori)
        {
            if (KategoriLista.Contains(kategori))
            {
                KategoriLista.Remove(kategori);
                SparaKategorierTillFil();
            }
            else
            {
                throw new Exception("Kategorin finns inte.");
            }
        }


        public List<string> HamtaAllaKategorier()
        {
            return KategoriLista;
        }

        public void SparaKategorierTillFil()
        {
            var serializer = new XmlSerializer(typeof(List<string>));
            using (var writer = new StreamWriter(KategoriFilePath))
            {
                serializer.Serialize(writer, KategoriLista);
            }
        }


        private List<string> LaddaKategorierFranFil()
        {
            if (!File.Exists(KategoriFilePath))
            {
                return new List<string>();
            }

            var serializer = new XmlSerializer(typeof(List<string>));
            using (var reader = new StreamReader(KategoriFilePath))
            {
                return (List<string>)serializer.Deserialize(reader);
            }
        }

        public void AndraKategori(int index, string nyKategori)
        {
            if (index < 0 || index >= KategoriLista.Count)
            {
                throw new ArgumentOutOfRangeException("Indexet är utanför intervallet.");
            }

            KategoriLista[index] = nyKategori; // Uppdatera kategorin
            SparaKategorierTillFil(); // Spara den uppdaterade listan
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

        public void TaBortPodcast(Podcast podcast)
        {
            if (PodcastLista.Remove(podcast)) // Försök att ta bort podcasten
            {
                SparaTillFil(); // Spara den uppdaterade listan till XML
            }
            else
            {
                throw new Exception("Podcasten kunde inte hittas.");
            }
        }
       

    }
}

