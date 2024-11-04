using System.Xml.Serialization;
using models;
using interfaces;

namespace dataAccess
{
    public class PodcastRepository : IPodcastRepository
    {
        private List<Podcast> PodcastLista { get; }
        private readonly string FilePath;
        private List<string> KategoriLista { get; }
        private readonly string KategoriFilePath;

        public PodcastRepository()
        {
            // sätta sökvägar till XML-filerna
            FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"dataAccess\data.xml");
            KategoriFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"dataAccess\kategorier.xml");

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

        public List<string> HamtaAllaKategorier() => KategoriLista;

        public void SparaKategorierTillFil()
        {
            // Kontrollera om KategoriFilePath är korrekt definierad
            if (string.IsNullOrEmpty(KategoriFilePath))
            {
                throw new InvalidOperationException("KategoriFilePath är inte korrekt inställd.");
            }

            
            string? directoryPath = Path.GetDirectoryName(KategoriFilePath);
            if (!string.IsNullOrEmpty(directoryPath) && !Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
          

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
                var result = serializer.Deserialize(reader) as List<string>;
                return result ?? new List<string>();
            }
        }

        public void AndraKategori(int index, string nyKategori)
        {
            if (index < 0 || index >= KategoriLista.Count)
            {
                throw new ArgumentOutOfRangeException("Indexet är utanför intervallet.");
            }

            KategoriLista[index] = nyKategori;
            SparaKategorierTillFil();
        }

        public void LaggTillPodcast(Podcast podcast)

        {
            if (PodcastLista.Any(p => p.URL == podcast.URL))
            {
                throw new Exception("Angiven podcast finns redan.");
            }

            PodcastLista.Add(podcast);
            SparaTillFil();
        }

        //METODÖVERLAGRING EXEMPEL
        public void AddPodcast(string name, string category)
        {
            //Lägger till en podcast med namn och kategori
        }

        public void AddPodcast(string name, string category, int episodeCount)
        {
            //Lägger till en podcast med namn, kategori och antal avsnitt
        }

        public void AddPodcast(Podcast podcast)
        {
            //Lägger till en podcast via en Podcast-objektparameter
        }

        public List<Podcast> HamtaAllaPodcast() => PodcastLista;

        private void SparaTillFil()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Podcast>));
            using (FileStream fs = new FileStream(FilePath, FileMode.Create))
            {
                serializer.Serialize(fs, PodcastLista);
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
                var result = serializer.Deserialize(reader) as List<Podcast>;
                return result ?? new List<Podcast>();
            }
        }

        public void TaBortPodcast(Podcast podcast)
        {

            // Kontrollera om podcasten finns i listan baserat på URL
            var podcastToRemove = PodcastLista.FirstOrDefault(p => p.URL == podcast.URL);
            if (podcastToRemove == null)
            {
                throw new Exception("Podcasten finns inte i listan.");
            }

            PodcastLista.Remove(podcastToRemove);
            SparaTillFil();
        }

        public void UppdateraPodcast(string url, Podcast uppdateradPodcast)
        {
            var podcast = PodcastLista.FirstOrDefault(p => p.URL == url);
            if (podcast != null)
            {
                
                podcast.Kategori = uppdateradPodcast.Kategori;
                podcast.Titel = uppdateradPodcast.Namn;
               
                SparaTillFil();
            }
            else
            {
                throw new Exception("Podcasten kunde inte hittas i listan.");
            }
        }
    }
}