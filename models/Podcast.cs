namespace models
{
    public class Podcast
    {
        public string Avsnitt { get; set; } //URL i RSS-flödet

       public Podcast(string avsnitt)
        {
            Avsnitt = avsnitt;
        }
    }
}
