using dataAccess;
using models;
using System.Xml;
using System.ServiceModel.Syndication;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace business
{
    public class PodcastController : IPodcastService
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private PodcastRepository podcastRepository;

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
                // Hämtar RSS-flödet som en sträng
                string xmlContent = await httpClient.GetStringAsync(URL);

                using (var stringReader = new StringReader(xmlContent))
                using (XmlReader xmlReader = XmlReader.Create(stringReader))
                {
                    SyndicationFeed podcastFlode = SyndicationFeed.Load(xmlReader);

                    // Kontrollera att flödet och dess titel finns
                    if (podcastFlode == null || string.IsNullOrEmpty(podcastFlode.Title?.Text))
                    {
                        throw new Exception("Flödet kunde inte läsas eller har ingen titel.");
                    }

                    // Skapar en ny Podcast med titel och URL
                    Podcast enPodcast = new Podcast(podcastFlode.Title.Text, URL);

                        foreach (SyndicationItem item in podcastFlode.Items)
                        {
                            string avsnittTitel = item.Title.Text;
                            string avsnittUrl = item.Links.FirstOrDefault()?.Uri.ToString();
                            string avsnittBeskrivning = item.Summary.Text;

                        if (!string.IsNullOrEmpty(avsnittTitel) && !string.IsNullOrEmpty(avsnittUrl) && !string.IsNullOrEmpty(avsnittBeskrivning))
                            {
                                enPodcast.AddAvsnitt(avsnittTitel, avsnittUrl, avsnittBeskrivning); // lägger till avsnitt t podcast
                            }
                        }

                    // Lägger till podcasten i repository
                    podcastRepository.LaggTillPodcast(enPodcast);
                    return enPodcast;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Fel vid hämtning: {ex.Message}", ex);
            }
        }

        public List<Podcast> HamtaAllaPodcast()
        {
            return podcastRepository.HamtaAllaPodcast();
        }
    }
}
