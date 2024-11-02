using models;
using dataAccess;
using interfaces;
using System.Xml;
using System.ServiceModel.Syndication;
using System.Text.RegularExpressions;

namespace business
{
    public class PodcastController : IPodcastService
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private readonly PodcastRepository podcastRepository;
        public PodcastController()
        {
            podcastRepository = new PodcastRepository();
        }

        public async Task<Podcast> HamtaPodcastFranRSSAsync(string URL)
        {
            if (!utilities.Validator.IsValidUrl(URL))
            {
                throw new ArgumentException("Ogiltig URL.");
            }

            try
            {
                // hämtar RSS-flödet som en sträng
                string xmlContent = await httpClient.GetStringAsync(URL);

                using (var stringReader = new StringReader(xmlContent))
                using (XmlReader xmlReader = XmlReader.Create(stringReader))
                {
                    SyndicationFeed podcastFlode = SyndicationFeed.Load(xmlReader);

                    // kontrollera att flödet och dess titel finns
                    if (podcastFlode == null || string.IsNullOrEmpty(podcastFlode.Title?.Text))
                    {
                        throw new Exception("Flödet kunde inte läsas eller har ingen titel.");
                    }

                    // skapar en ny podcast med titel och URL
                    Podcast enPodcast = new Podcast(podcastFlode.Title.Text, URL);

                        foreach (SyndicationItem item in podcastFlode.Items)
                        {
                            string avsnittTitel = item.Title.Text;
                            string? avsnittUrl = item.Links.FirstOrDefault()?.Uri.ToString();
                            string avsnittBeskrivning = item.Summary.Text;

                        if (!string.IsNullOrEmpty(avsnittTitel) && !string.IsNullOrEmpty(avsnittUrl) && !string.IsNullOrEmpty(avsnittBeskrivning))
                            {
                                enPodcast.AddAvsnitt(avsnittTitel, avsnittUrl, avsnittBeskrivning); // lägger till avsnitt t podcast
                            }
                        }
                    return enPodcast;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Fel vid hämtning: {ex.Message}", ex);
            }
        }

        public async Task AddPodcastAsync(string url, string kategori, string titel)
        {
            if (!utilities.Validator.IsValidUrl(url))
            {
                throw new ArgumentException("Ogiltig URL.");
            }

            // Fetch the podcast from the RSS feed
            Podcast podcast = await HamtaPodcastFranRSSAsync(url);

            // Check if the podcast and its episodes have been fetched
            if (podcast == null || !podcast.HamtaAvsnitt().Any())
            {
                throw new Exception("Podcasten kunde inte laddas.");
            }

            // Set the podcast name and category
            podcast.Kategori = kategori;
            podcast.Titel = titel;

            // Add the podcast to the repository
            podcastRepository.LaggTillPodcast(podcast);
        }


        public List<Podcast> HamtaAllaPodcast()
        {
            return podcastRepository.HamtaAllaPodcast();
        }

        public void SparaKategorierTillFil()
        {
            podcastRepository.SparaKategorierTillFil();
        }

        public List<string> HamtaAllaKategorier()
        {
            return podcastRepository.HamtaAllaKategorier();
        }

        public void LaggTillKategori(string kategori)
        {
            podcastRepository.LaggTillKategori(kategori);
        }

        public void TaBortKategori(string kategori)
        {
            podcastRepository.TaBortKategori(kategori);
        }

        public void AndraKategori(int index, string nyKategori)
        {
            podcastRepository.AndraKategori(index, nyKategori);
        }

        public void TaBortPodcast(Podcast podcast)
        {
            podcastRepository.TaBortPodcast(podcast);
        }

        public string TaBortHtmlTags(string input)
        {
            return Regex.Replace(input, "<.*?>", string.Empty);
        }
    }
}
