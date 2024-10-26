using models;

namespace business
{
    public interface IPodcastService
    {
        Task<Podcast> HamtaPodcastFranRSSAsync(string URL);
        List<Podcast> HamtaAllaPodcast();
    }
}
