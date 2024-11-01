using System.Collections.Generic;
using System.Xml.Serialization;
using models;

namespace dataAccess
{
    public class PodcastRepository
    {
        private List<Podcast> PodcastLista;
        private readonly string FilePath;
        private List<string> KategoriLista;
        private readonly string KategoriFilePath;

        public PodcastRepository()
        {
            string relativePodcastPath = @"C:\Users\leyla\OneDrive\Skrivbord\podcast-grupp18\dataAccess\data.xml"; 
            string relativeKategoriPath = @"C:\Users\leyla\OneDrive\Skrivbord\podcast-grupp18\dataAccess\kategorier.xml";

            FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePodcastPath);
            KategoriFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativeKategoriPath);
       
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
            /*if (PodcastLista.Any(p => p.URL == podcast.URL))
            {
                throw new Exception("Angiven podcast finns redan.");
            }*/

            PodcastLista.Add(podcast);
            SparaTillFil();
        }

        public List<Podcast> HamtaAllaPodcast()
        {
            return PodcastLista;
        }

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
                return (List<Podcast>)serializer.Deserialize(reader);
            }
        }

        public void TaBortPodcast(Podcast podcast)
        {

            if (PodcastLista.Contains(podcast))
            {
                PodcastLista.Remove(podcast);
                SparaTillFil();
            }
            else
            {
                throw new Exception("Podcasten finns inte i listan.");
            }
        }

    }
}

