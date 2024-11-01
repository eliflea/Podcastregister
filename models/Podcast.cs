using System.Xml.Serialization;

namespace models
{
    [XmlRoot("Podcast")]
    public class Podcast
    {
        public string valtNamn;

        [XmlArray("AvsnittLista")]
        [XmlArrayItem("Avsnitt")]
        public List<Avsnitt> AvsnittLista { get; set; } // podcast-titlar

        [XmlElement("Namn")]
        public string Namn { get; set; } // podcastnamn

        [XmlElement("URL")]
        public string URL { get; set; } // Podcast URL

        [XmlElement("Kategori")]
        public string Kategori { get; set; }

        [XmlElement("Titel")]
        public string Titel { get; set; }


        public Podcast() // För XML-seralisering
        {
            AvsnittLista = new List<Avsnitt>();
        }
        public Podcast(string namn, string url)
        {
            Namn = namn;
            URL = url;
            AvsnittLista = new List<Avsnitt>();
        }

        // titel-lista lägg till
        public void AddAvsnitt(string titel, string url, string beskrivning)
        {
            AvsnittLista.Add(new Avsnitt(titel, url, beskrivning));
        }
        public List<string> HamtaAvsnittTitlar()
        {
            return AvsnittLista.Select(a => a.Titel).ToList();
        }

        public List<string> HamtaAvsnittBeskrivningar()
        {
            return AvsnittLista.Select(a => a.Beskrivning).ToList();
        }

        // hämta url baserat på titel
        public string HamtaAvsnittUrl(string titel)
        {
            var episode = AvsnittLista.FirstOrDefault(e => e.Titel == titel);
            return episode?.URL;
        }

        public IReadOnlyList<Avsnitt> HamtaAvsnitt()
        {
            return AvsnittLista.AsReadOnly();
        }
    }
}
