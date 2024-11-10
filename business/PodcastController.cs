using models;
using interfaces;
using System.ServiceModel.Syndication;
using System.Text.RegularExpressions;
using utilities;
using System.Web;

namespace business
{
    public class PodcastController : IPodcastService
    {
        private readonly IPodcastRepository podcastRepository;

        public PodcastController(IPodcastRepository podcastRepository)
        {
            this.podcastRepository = podcastRepository;
        }

        public async Task<Podcast> HamtaPodcastFranRSSAsync(string URL)
        {
                try
                {
                    SyndicationFeed podcastFeed = await Rss.FetchaRssFeedAsync(URL); 

                    if (podcastFeed == null || string.IsNullOrEmpty(podcastFeed.Title?.Text))
                    {
                        throw new CustomException("Podcast kunde inte hämtas.");
                    }

                    var podcast = new Podcast(podcastFeed.Title.Text, URL);

                    foreach (SyndicationItem item in podcastFeed.Items)
                    {
                        var title = item.Title?.Text ?? "Inget namn"; 
                        var episodeUrl = item.Links.FirstOrDefault()?.Uri.ToString();
                        var description = item.Summary?.Text ?? "Ingen beskrivning";

                    if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(episodeUrl) && !string.IsNullOrEmpty(description))
                        {
                            podcast.AddAvsnitt(title, episodeUrl, description);
                        }
                    }

                    return podcast;
                }
                catch (CustomException ex)
                {
                    throw new CustomException($"Fel vid hämtning: {ex.Message}", ex);
                }
            }

            public async Task AddPodcastAsync(string url, string kategori, string titel)
        {
            if (!utilities.Validator.IsValidUrl(url))
            {
                throw new CustomException("Ogiltig URL.");
            }

            Podcast podcast = await HamtaPodcastFranRSSAsync(url);

            if (podcast == null || !podcast.HamtaAvsnitt().Any())
            {
                throw new CustomException("Podcasten kunde inte laddas.");
            }

            podcast.Kategori = kategori;
            podcast.Titel = titel;

            podcastRepository.LaggTillPodcast(podcast);
        }

        public List<Podcast> HamtaAllaPodcast() => podcastRepository.HamtaAllaPodcast();
        public void SparaKategorierTillFil() => podcastRepository.SparaKategorierTillFil();
        public List<string> HamtaAllaKategorier() => podcastRepository.HamtaAllaKategorier();
        public void LaggTillKategori(string kategori) => podcastRepository.LaggTillKategori(kategori);
        public void TaBortKategori(string kategori) => podcastRepository.TaBortKategori(kategori);
        public void AndraKategori(int index, string nyKategori) => podcastRepository.AndraKategori(index, nyKategori);
        public void UppdateraPodcast(string url, Podcast uppdateradPodcast) => podcastRepository.UppdateraPodcast(url, uppdateradPodcast);
        public void TaBortPodcast(Podcast podcast) => podcastRepository.TaBortPodcast(podcast);
        public string TaBortHtmlTags(string input) => HttpUtility.HtmlDecode(Regex.Replace(input, "<.*?>", string.Empty));
    }
}
