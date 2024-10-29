using System.Xml.Serialization;

namespace models
{
    [XmlRoot("Avsnitt")]
    public class Avsnitt
    {
        [XmlElement("Titel")]
        public string Titel { get; set; }

        [XmlElement("URL")]
        public string URL { get; set; }

        [XmlElement("Beskrivning")]
        public string Beskrivning { get; set; }

        public Avsnitt() { } //Konstruktor för XML-serialization

        public Avsnitt(string titel, string url, string beskrivning)
        {
            Titel = titel;
            URL = url;
            Beskrivning = beskrivning;
        }
    }
}