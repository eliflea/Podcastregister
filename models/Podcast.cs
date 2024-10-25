﻿using System.Xml.Serialization;

namespace models
{
    public class Podcast
    {
        [XmlArray("AvsnittLista")]
        [XmlArrayItem("Avsnitt")]
        public List<Avsnitt> AvsnittLista { get; set; } // podcast-titlar
        
        public string Namn { get; set; } // podcastnamn
        public string URL { get; set; } // Podcast URL
        public string Kategori { get; set; }
        public string? Titel { get; set; }


        public Podcast() // För XML-seralisering
        {
            AvsnittLista = new List<Avsnitt>();
        }
        public Podcast(string namn, string url)
        {
            Namn = namn;
            URL = url;
            AvsnittLista = new List<Avsnitt>();
        }

        // titel-lista lägg till
        public void AddAvsnitt(string titel, string url)
        {
            AvsnittLista.Add(new Avsnitt(titel, url));
        }

        public List<string> HamtaAvsnittTitlar()
        {
            return AvsnittLista.Select(a => a.Titel).ToList();
        }

        // hämta url baserat på titel
        public string HamtaAvsnittUrl(string titel)
        {
            var episode = AvsnittLista.FirstOrDefault(e => e.Titel == titel);
            return episode?.URL;
        }
        public IReadOnlyList<Avsnitt> HamtaAvsnitt()
        {
            return AvsnittLista.AsReadOnly();
        }
    }
}
