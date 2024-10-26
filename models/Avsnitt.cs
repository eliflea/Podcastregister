namespace models
{
    public class Avsnitt
    {
        public string Titel { get; set; }
        public string URL { get; set; }
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