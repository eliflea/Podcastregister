using models;
using interfaces;
using utilities;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

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
            //metod för att lägga till podcast
            string url = txtURL.Text.Trim();
            string kategori = comboBox2.SelectedItem?.ToString() ?? "";
            string titel = textBox1.Text.Trim();

            try
            {
                if (ValideraFalt(url, kategori, titel))
                {
                    await podcastService.AddPodcastAsync(url, kategori, titel);
                    var nyPodcast = await podcastService.HamtaPodcastFranRSSAsync(url);
                    if (nyPodcast != null)
                    {
                        LaggTillPodcastsListView(nyPodcast, kategori);
                    }

                    txtURL.Clear();
                    textBox1.Clear();
                    comboBox2.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ett fel uppstod: " + ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValideraFalt(string url, string kategori, string titel)
        {
            if (!utilities.Validator.IsValidUrl(url))
            {
                MessageBox.Show("URL: Vänligen ange giltig URL.", "Ogiltig URL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false; 
            }

            if (!utilities.Validator.IsNotEmpty(url))
            {
                MessageBox.Show("URL-fältet får inte vara tomt.", "Tom URL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false; 
            }

            if (!utilities.Validator.IsNotEmpty(kategori))
            {
                MessageBox.Show("Vänligen välj en giltig kategori.", "Ogiltig kategori", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false; 
            }

            if (!utilities.Validator.IsNotEmpty(titel))
            {
                MessageBox.Show("Namn får inte vara tomt.", "Tom titel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false; 
            }
            return true; 
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
                string? valdKategori = listBoxKategori.SelectedItem.ToString();

                if (valdKategori != null)
                {
                    DialogResult result = MessageBox.Show(
                        $"Är du säker på att du vill ta bort kategorin '{valdKategori}'?",
                        "Bekräfta borttagning",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            // Kontrollera om någon podcast använder kategorin
                            var affectedPodcasts = podcastService.HamtaAllaPodcast()
                                .Where(p => p.Kategori == valdKategori).ToList();

                            if (affectedPodcasts.Any())
                            {
                                // Fråga användaren om att välja en ny kategori
                                string nyKategori = comboBox2.SelectedItem?.ToString() ?? "";

                                // Om ingen ny kategori är vald, visa ett meddelande
                                if (string.IsNullOrWhiteSpace(nyKategori))
                                {
                                    MessageBox.Show("Vänligen ändra kategorin i poddcast listan först.", "Ingen ny kategori vald", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                // Uppdatera podcasts med den nya kategorin
                                foreach (var podcast in affectedPodcasts)
                                {
                                    podcast.Kategori = nyKategori;
                                    podcastService.UppdateraPodcast(podcast.URL, podcast);
                                }
                            }

                            // Ta bort kategorin
                            podcastService.TaBortKategori(valdKategori);
                            listBoxKategori.Items.Remove(valdKategori);
                            comboBox2.Items.Remove(valdKategori);
                            filtreraKategori.Items.Remove(valdKategori);

                            // Ladda om podcasts
                            LoadPodcasts();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ett fel uppstod: {ex.Message}");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vänligen välj en kategori att ta bort.");
                }
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
                FillPodcastDetails(selectedPodcast);
            }
            else
            {
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

            ListViewItem? item = lvwPodcastDetaljer.Items
                .Cast<ListViewItem>()
                .FirstOrDefault(i => (i.Tag as Podcast)?.URL == selectedPodcast.URL);

            if (item != null && item.SubItems.Count > 3)
            {
                textBox1.Text = item.SubItems[1].Text; 
                string kategori = item.SubItems[3].Text; 

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

         
    


