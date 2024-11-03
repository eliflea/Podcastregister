using models;

namespace interfaces
{
    public interface IPodcastRepository
    {
        void LaggTillPodcast(Podcast podcast);
        List<Podcast> HamtaAllaPodcast();
        void SparaKategorierTillFil();
        List<string> HamtaAllaKategorier();
        void LaggTillKategori(string kategori);
        void TaBortKategori(string kategori);
        void AndraKategori(int index, string nyKategori);
        void TaBortPodcast(Podcast podcast);
        void UppdateraPodcast(string url, Podcast uppdateradPodcast);
    }
}
