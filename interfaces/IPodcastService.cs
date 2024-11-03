using models;

namespace interfaces
{
    public interface IPodcastService
    {
        Task<Podcast> HamtaPodcastFranRSSAsync(string URL);
        Task AddPodcastAsync(string url, string kategori, string titel);
        List<Podcast> HamtaAllaPodcast();
        void SparaKategorierTillFil();
        List<string> HamtaAllaKategorier();
        void LaggTillKategori(string kategori);
        void TaBortKategori(string kategori);
        void AndraKategori(int index, string nyKategori);
        void TaBortPodcast(Podcast podcast);
        string TaBortHtmlTags(string input);
        void UppdateraPodcast(string uRL, Podcast podcast);
    }

}
