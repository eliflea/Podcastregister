﻿using models;
using interfaces;
using System.Text.RegularExpressions;

namespace podcast_grupp18
{
    public partial class Form1 : Form
    {
        private readonly IPodcastService podcastService;

        public Form1(IPodcastService podcastService)
        {
            InitializeComponent();
            this.podcastService = podcastService;

            Load += KolumnRader;
            Load += Form1_Load;
            lvwPodcastDetaljer.SelectedIndexChanged += lvwPodcastDetaljer_SelectedIndexChanged;
            FormClosing += Form1_FormClosing;
            LaddaKategorier();
            filtreraKategori.SelectedIndexChanged += filtreraKategori_SelectedIndexChanged;
        }

        private void KolumnRader(object? sender, EventArgs e)
        {
            int totalWidth = lvwPodcastDetaljer.ClientSize.Width;
            int columnWidth = totalWidth / 4;

            string[] columns = { "Antal avsnitt", "Namn", "Titel", "Kategori" };
            foreach (var column in columns)
            {
                lvwPodcastDetaljer.Columns.Add(column, columnWidth);
            }

            lvwAvsnitt.Columns.Add("Avsnitt", lvwAvsnitt.ClientSize.Width);
        }

        private void Form1_Load(object? sender, EventArgs e) => LoadPodcasts();

        private void Form1_FormClosing(object? sender, FormClosingEventArgs e) => podcastService.SparaKategorierTillFil();

        private void LaddaKategorier()
        {
            var kategorier = podcastService.HamtaAllaKategorier();
            foreach (var kategori in kategorier)
            {
                listBoxKategori.Items.Add(kategori);
                comboBox2.Items.Add(kategori);
                filtreraKategori.Items.Add(kategori);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string url = txtURL.Text.Trim();
            string kategori = comboBox2.SelectedItem?.ToString() ?? "";
            string titel = textBox1.Text.Trim();

            try
            {
                await podcastService.AddPodcastAsync(url, kategori, titel);
                var nyPodcast = await podcastService.HamtaPodcastFranRSSAsync(url);
                if (nyPodcast != null)
                {
                    LaggTillPodcastsListView(nyPodcast, kategori);
                }

                // Tar bort texten i rutorna
                txtURL.Clear();
                textBox1.Clear();
                comboBox2.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ett fel uppstod: " + ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LaggTillPodcastsListView(Podcast nyPodcast, string kategori)
        {
            var podcastItem = new ListViewItem(nyPodcast.HamtaAvsnitt().Count.ToString())
            {
                Tag = nyPodcast
            };
            podcastItem.SubItems.Add(textBox1.Text.Trim());
            podcastItem.SubItems.Add(nyPodcast.Namn);
            podcastItem.SubItems.Add(kategori);
            lvwPodcastDetaljer.Items.Add(podcastItem);
            lvwPodcastDetaljer.Refresh();
        }

        private void LoadPodcasts()
        {
            lvwPodcastDetaljer.Items.Clear();
            var podcasts = podcastService.HamtaAllaPodcast();

            foreach (var podcast in podcasts)
            {
                var podcastItem = new ListViewItem(podcast.HamtaAvsnitt().Count().ToString());
                podcastItem.SubItems.Add(podcast.Titel);
                podcastItem.SubItems.Add(podcast.Namn);
                podcastItem.SubItems.Add(podcast.Kategori);

                podcastItem.Tag = podcast;
                lvwPodcastDetaljer.Items.Add(podcastItem);
            }
        }
        private void läggTillKategori_Click_1(object sender, EventArgs e)
        {

            string nyKategori = kategoriTextBox.Text.Trim();

            // Kontrollera om kategorin är giltig
            if (!utilities.Validator.IsValidCategory(nyKategori))
            {
                MessageBox.Show("Vänligen ange en giltig kategori (minst 3 tecken).");
                return;
            }

            // Kontrollera om kategorin är unik
            var existingCategories = listBoxKategori.Items.Cast<string>();
            if (!utilities.Validator.IsUniqueCategory(nyKategori, existingCategories))
            {
                MessageBox.Show("Kategorin finns redan.");
                return;
            }

            try
            {
                
                podcastService.LaggTillKategori(nyKategori);
                listBoxKategori.Items.Add(nyKategori);
                comboBox2.Items.Add(nyKategori);
                filtreraKategori.Items.Add(nyKategori);
                kategoriTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void taBortKategori_Click(object sender, EventArgs e)
        {
            if (listBoxKategori.SelectedItem != null)
            {
                string? valdKategori = listBoxKategori.SelectedItem?.ToString();

                if (valdKategori != null)
                {
                   
                    DialogResult result = MessageBox.Show(
                        $"Är du säker på att du vill ta bort kategorin '{valdKategori}'?",
                        "Bekräfta borttagning",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    // Om användaren klickar på "Ja"
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            podcastService.TaBortKategori(valdKategori);
                            listBoxKategori.Items.Remove(valdKategori);
                            comboBox2.Items.Remove(valdKategori);
                            filtreraKategori.Items.Remove(valdKategori);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vänligen välj en kategori att ta bort.");
                }
            }
            else
            {
                MessageBox.Show("Vänligen välj en kategori att ta bort.");
            }
        }

        private void ändraKategori_Click(object sender, EventArgs e)
        {

            // Kontrollera om något objekt är valt
            if (listBoxKategori.SelectedItem != null)
            {
                
                int selectedIndex = listBoxKategori.SelectedIndex;
                
                string nyKategori = kategoriTextBox.Text.Trim();

                if (!utilities.Validator.IsValidCategory(nyKategori))
                {
                    MessageBox.Show("Vänligen ange en giltig kategori (minst 3 tecken).");
                    return;
                }

                var existingCategories = listBoxKategori.Items.Cast<string>();
                if (!utilities.Validator.IsUniqueCategory(nyKategori, existingCategories))
                {
                    MessageBox.Show("Kategorin finns redan.");
                    return;
                }

                
                try
                {
                    podcastService.AndraKategori(selectedIndex, nyKategori); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ett fel uppstod: {ex.Message}", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                
                listBoxKategori.Items[selectedIndex] = nyKategori;
                comboBox2.Items[selectedIndex] = nyKategori;
                filtreraKategori.Items[selectedIndex] = nyKategori;

                
                kategoriTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Vänligen välj en kategori att ändra.");
           } 
        }

        private void listBoxKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxKategori.SelectedItem != null)
            {
                kategoriTextBox.Text = listBoxKategori.SelectedItem.ToString();
            } 
        }
        
     

        private void lvwPodcastDetaljer_SelectedIndexChanged(object? sender, EventArgs e)
        {
            //Visar avsnitt för vald podcast (om man klickar på en rad)
            if (lvwPodcastDetaljer.SelectedItems.Count > 0 && lvwPodcastDetaljer.SelectedItems[0].Tag is Podcast valdPodcast)
            {
                DisplayEpisodes(valdPodcast);
            }
        }

        private void DisplayEpisodes(Podcast podcast)
        {
            lvwAvsnitt.Items.Clear();

            var avsnittLista = podcast.HamtaAvsnitt();

            if (avsnittLista == null || !avsnittLista.Any())
            {
                MessageBox.Show("Inga avsnitt hittades!");
            }
            else
            {
                // linq reverse
                var reversedList = avsnittLista.AsEnumerable().Reverse().ToList();
                int avsnittNummer = 1;

                foreach (var avsnitt in reversedList)
                {
                    string utanNummer = Regex.Replace(avsnitt.Titel, @"^\d+\.\s*", string.Empty).Trim();

                    var listViewItem = new ListViewItem($"{avsnittNummer}. {utanNummer}"); 
                    listViewItem.Tag = avsnitt;
                    lvwAvsnitt.Items.Add(listViewItem);

                    avsnittNummer++;
                }
            }
        }

        private void taBortFlode_Click(object sender, EventArgs e)
        {
            if (lvwPodcastDetaljer.SelectedItems.Count > 0)
            {
                // Hämta den valda podcasten
                if (lvwPodcastDetaljer.SelectedItems[0].Tag is Podcast valdPodcast)
                {
                    
                    DialogResult result = MessageBox.Show(
                        $"Är du säker på att du vill ta bort podcasten '{valdPodcast.Namn}'?",
                        "Bekräfta borttagning",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            podcastService.TaBortPodcast(valdPodcast); 
                            lvwPodcastDetaljer.Items.Remove(lvwPodcastDetaljer.SelectedItems[0]); 
                            lvwAvsnitt.Items.Clear();
                            lbBeskrivning.Clear();

                            LoadPodcasts();
                            MessageBox.Show($"Podcasten '{valdPodcast.Namn}' har tagits bort.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ett fel uppstod: {ex.Message}", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vänligen välj en podcast att ta bort.");
            }
        }

        private void lvwAvsnitt_SelectedIndexChanged(object sender, EventArgs e)
        //Visar beskrivning för vald avsnitt (om man klickar på en rad)
        {
            if (lvwAvsnitt.SelectedItems.Count > 0)
            {
                if (lvwAvsnitt.SelectedItems[0].Tag is Avsnitt valtAvsnitt)
                {
                    DisplayBeskrivning(valtAvsnitt);
                }
            }
        }

        private void DisplayBeskrivning(Avsnitt avsnitt)
        {
            lbBeskrivning.Text = string.Empty;

            if (!string.IsNullOrWhiteSpace(avsnitt.Beskrivning))
            {
                string renDescription = podcastService.TaBortHtmlTags(avsnitt.Beskrivning);
                lbBeskrivning.Text = renDescription;
            }
            else
            {
                MessageBox.Show("Ingen beskrivning hittades!");
            }
        }

        private void btnAndraFlode_Click(object sender, EventArgs e)
        {
            if (lvwPodcastDetaljer.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vänligen välj en podcast att ändra.");
                return;
            }

            ListViewItem selectedItem = lvwPodcastDetaljer.SelectedItems[0];
            Podcast? selectedPodcast = selectedItem.Tag as Podcast;

            if (selectedPodcast != null)
            {
                // Använd den överlagrade metoden som tar en Podcast som parameter
                FillPodcastDetails(selectedPodcast);
            }
            else
            {
                // Om Tag inte är en Podcast, använd metoden som tar en ListViewItem
                FillPodcastDetails(selectedItem);
            }
        }

        // Metodöverlagring för att fylla i detaljer

        private void FillPodcastDetails(ListViewItem selectedItem)
        {
            if (selectedItem == null)
            {
                MessageBox.Show("Vänligen välj en giltig podcast.");
                return;
            }

            textBox1.Text = selectedItem.SubItems[1].Text; // Namn
            comboBox2.SelectedItem = selectedItem.SubItems[3].Text; // Kategori
        }

        private void FillPodcastDetails(Podcast selectedPodcast)
        {
            if (selectedPodcast == null)
            {
                MessageBox.Show("Vänligen välj en giltig podcast.");
                return;
            }

            // Försök att hitta motsvarande ListViewItem baserat på podcastens URL
            ListViewItem? item = lvwPodcastDetaljer.Items
                .Cast<ListViewItem>()
                .FirstOrDefault(i => (i.Tag as Podcast)?.URL == selectedPodcast.URL);

            if (item != null && item.SubItems.Count > 3)
            {
                textBox1.Text = item.SubItems[1].Text; // Namn
                string kategori = item.SubItems[3].Text; // Kategori

                // Om kategorin finns i combobox, välj den. Annars, lägg till och välj den.
                int categoryIndex = comboBox2.Items.IndexOf(kategori);
                if (categoryIndex >= 0)
                {
                    comboBox2.SelectedIndex = categoryIndex;
                }
                else
                {
                    comboBox2.Items.Add(kategori);
                    comboBox2.SelectedItem = kategori;
                }
            }
            else
            {
                MessageBox.Show("Podcastdetaljerna kunde inte fyllas i. Kontrollera att alla data finns.");
            }
        }



        private void btnSpara_Click_1(object sender, EventArgs e)
        {
            if (lvwPodcastDetaljer.SelectedItems.Count > 0)
            {
                if (lvwPodcastDetaljer.SelectedItems[0].Tag is Podcast valdPodcast)
                {
                    string nyttNamn = textBox1.Text.Trim();
                    string nyKategori = comboBox2.SelectedItem?.ToString() ?? "";

                    
                    if (!string.IsNullOrWhiteSpace(nyttNamn)) valdPodcast.Namn = nyttNamn;
                    if (!string.IsNullOrWhiteSpace(nyKategori)) valdPodcast.Kategori = nyKategori;

                    
                    podcastService.UppdateraPodcast(valdPodcast.URL, valdPodcast);

                    // Uppdatera ListView med nya värden
                    lvwPodcastDetaljer.SelectedItems[0].SubItems[1].Text = nyttNamn;
                    lvwPodcastDetaljer.SelectedItems[0].SubItems[3].Text = nyKategori; 

                    MessageBox.Show("Ändringar sparades.");
                }
            }
            else
            {
                MessageBox.Show("Vänligen välj en podcast att spara ändringar för.");
            }
        }

        private void filtreraKategori_SelectedIndexChanged(object? sender, EventArgs e)
        {
            string? valdKategori = filtreraKategori.SelectedItem?.ToString();
            FiltreraPodcaster(valdKategori ?? string.Empty);
        }

        private void FiltreraPodcaster(string kategori)
        {
             lvwPodcastDetaljer.Items.Clear(); 

    var podcasts = podcastService.HamtaAllaPodcast()
                    .Where(p => string.IsNullOrEmpty(kategori) || p.Kategori == kategori);

    foreach (var podcast in podcasts)
    {
        int antalAvsnitt = podcast.HamtaAvsnitt().Count;
        ListViewItem podcastItem = new ListViewItem(antalAvsnitt.ToString())
        {
            Tag = podcast
        };
        podcastItem.SubItems.Add(podcast.Namn);
        podcastItem.SubItems.Add(podcast.Titel ?? "Ingen titel");
        podcastItem.SubItems.Add(podcast.Kategori);

        lvwPodcastDetaljer.Items.Add(podcastItem);
    }
        }

        private void btnAterstall_Click(object sender, EventArgs e)
        {
            filtreraKategori.SelectedIndex = -1; 
            LoadPodcasts();
        }

       
    }
}

         
    


