using System.Xml.Serialization;

namespace models
{
    [XmlRoot("Avsnitt")]
    public class Avsnitt
    {
        [XmlElement("Titel")]
        public string Titel { get; set; } = string.Empty;

        [XmlElement("URL")]
        public string URL { get; set; } = string.Empty;

        [XmlElement("Beskrivning")]
        public string Beskrivning { get; set; } = string.Empty;

        public Avsnitt() { } //Konstruktor för XML-serialization

        public Avsnitt(string titel, string url, string beskrivning)
        {
            Titel = titel;
            URL = url;
            Beskrivning = beskrivning;
        }
    }
}