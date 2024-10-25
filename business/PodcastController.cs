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
    public class PodcastController
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private PodcastRepository podcastRepository;

        public PodcastController()
        {
            podcastRepository = new PodcastRepository();
        }

        public async Task<Podcast> HamtaPodcastFranRSSAsync(string URL)
        {
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

                    // Itererar igenom avsnitt i RSS-flödet och lägger till dem i podcasten
                    foreach (SyndicationItem item in podcastFlode.Items)
                    {
                        string avsnittTitel = item.Title?.Text;
                        string avsnittUrl = item.Links.FirstOrDefault()?.Uri.ToString();

                        if (!string.IsNullOrEmpty(avsnittTitel) && !string.IsNullOrEmpty(avsnittUrl))
                        {
                            enPodcast.AddAvsnitt(avsnittTitel, avsnittUrl); // Lägger till avsnitt
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


        /*//Hämta och sparar podcastavsnitt från 1 RSS-flöde till repositoryn
       public Podcast HamtaPodcastFranRSS(string URL)
       {
           XmlReader XMLlasare = XmlReader.Create(URL);
           SyndicationFeed podcastFlode = SyndicationFeed.Load(XMLlasare);

           Podcast enPodcast = new Podcast(podcastFlode.Title.Text, URL); // podcastnamn

           foreach (SyndicationItem item in podcastFlode.Items)
           {
               string episodeTitle = item.Title.Text;
               string episodeUrl = item.Links.FirstOrDefault()?.Uri.ToString();

               if (!string.IsNullOrEmpty(episodeTitle) && !string.IsNullOrEmpty(episodeUrl))
               {
                   enPodcast.AddAvsnitt(episodeTitle, episodeUrl); // Add episode to podcast
               }
           }
           podcastRepository.LaggTillPodcast(enPodcast); //Sparar podcast

           return enPodcast;
       }
       */
    

