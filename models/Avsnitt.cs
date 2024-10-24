namespace models
{
    public class Avsnitt
    {
        public string Titel { get; set; }
        public string URL { get; set; }

        public Avsnitt() { } //Konstruktor för XML-serialization

        public Avsnitt(string titel, string url)
        {
            Titel = titel;
            URL = url;
        }
    }
}