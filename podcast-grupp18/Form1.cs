using business;
using dataAccess;
using models;
using System.Text.RegularExpressions;
using utilities;
using System.Linq;

namespace podcast_grupp18
{
    public partial class Form1 : Form
    {
        private PodcastController podcastController;
        private PodcastRepository podcastRepository;
        private IPodcastService podcastService;

        public Form1()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(KolumnRader);
            this.Load += new System.EventHandler(Form1_Load);
            lvwPodcastDetaljer.SelectedIndexChanged += lvwPodcastDetaljer_SelectedIndexChanged;
            podcastController = new PodcastController();
            podcastRepository = new PodcastRepository();
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            LaddaKategorier();
            filtreraKategori.SelectedIndexChanged += filtreraKategori_SelectedIndexChanged;


        }

        public Form1(IPodcastService podcastService)
        {
            this.podcastService = podcastService;
        }


        private void KolumnRader(object sender, EventArgs e)
        {
            int totalWidth = lvwPodcastDetaljer.ClientSize.Width;

            int columnWidth = totalWidth / 5; //5 kolumn

            lvwPodcastDetaljer.Columns.Add("Antal avsnitt", columnWidth);
            lvwPodcastDetaljer.Columns.Add("Namn", columnWidth);
            lvwPodcastDetaljer.Columns.Add("Titel", columnWidth);
            lvwPodcastDetaljer.Columns.Add("Frekvens", columnWidth);
            lvwPodcastDetaljer.Columns.Add("Kategori", columnWidth);

            //för avsnitt
            lvwAvsnitt.Columns.Add("Avsnitt", lvwAvsnitt.ClientSize.Width);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadPodcasts();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            podcastRepository.SparaKategorierTillFil(); 
        }


        private void LoadPodcasts()
        {
            lvwPodcastDetaljer.Items.Clear();
            var podcasts = podcastRepository.HamtaAllaPodcast();

            foreach (var podcast in podcasts)
            {
                var podcastItem = new ListViewItem(podcast.HamtaAvsnitt().Count().ToString());
                podcastItem.SubItems.Add(podcast.Namn);
                podcastItem.SubItems.Add(podcast.Titel);
                podcastItem.SubItems.Add(""); // lägg till frekvens
                podcastItem.SubItems.Add(podcast.Kategori);

                podcastItem.Tag = podcast;
                lvwPodcastDetaljer.Items.Add(podcastItem);
            }
        }
        
        private void LaddaKategorier()
        {
            var kategorier = podcastRepository.HamtaAllaKategorier();
            foreach (var kategori in kategorier)
            {
                listBoxKategori.Items.Add(kategori);
                comboBox2.Items.Add(kategori);
                filtreraKategori.Items.Add(kategori);
            }
        }
       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        //Lägger till podcastflöde (ansykront anrop)
        {
            string url = txtURL.Text.Trim();
            string podcastNamn = textBox1.Text.Trim();
            string kategori = comboBox2.SelectedItem?.ToString() ?? "";

            if (!Validator.IsValidUrl(url))
            {
                MessageBox.Show("Vänligen ange en giltig URL.");
                return;
            }

            if (string.IsNullOrWhiteSpace(url))
            {
                MessageBox.Show("Vänligen ange en giltig URL!");
                return;
            }
            if (string.IsNullOrWhiteSpace(podcastNamn))
            {
                MessageBox.Show("Vänligen ange ett namn för podcasten.");
                return;
            }
            if (string.IsNullOrWhiteSpace(kategori))
            {
                MessageBox.Show("Vänligen välj en kategori.");
                return;
            }

            try
            {
                // Hämta podcast från RSS asynkront
                Podcast podcast = await podcastController.HamtaPodcastFranRSSAsync(url);

                // kontrollera om podcasten och dess avsnitt har hämtats
                if (podcast == null || !podcast.HamtaAvsnitt().Any())
                {
                    MessageBox.Show("Podcasten kunde inte laddas eller innehåller inga avsnitt.", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string valtNamn = podcastNamn;
                podcast.Kategori = kategori;

                int antalAvsnitt = podcast.HamtaAvsnitt().Count;
                ListViewItem podcastItem = new ListViewItem(antalAvsnitt.ToString());
                podcastItem.SubItems.Add(valtNamn); // Namn från textBox1
                podcastItem.SubItems.Add(podcast.Namn); // podcastnamn
                podcastItem.SubItems.Add("");
                podcastItem.SubItems.Add(podcast.Kategori);

                podcastItem.Tag = podcast;
                lvwPodcastDetaljer.Items.Add(podcastItem);

                txtURL.Clear();
                textBox1.Clear();
                comboBox2.SelectedIndex = -1;

                podcastRepository.LaggTillPodcast(podcast);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ett fel uppstod: " + ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void läggTillKategori_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(kategoriTextBox.Text))
            {
                try
                {
                    podcastRepository.LaggTillKategori(kategoriTextBox.Text);
                    listBoxKategori.Items.Add(kategoriTextBox.Text);
                    comboBox2.Items.Add(kategoriTextBox.Text);
                    filtreraKategori.Items.Add(kategoriTextBox.Text);
                    kategoriTextBox.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Vänligen ange en kategori.");
            }
        }

        private void taBortKategori_Click(object sender, EventArgs e)
        { 

            if (listBoxKategori.SelectedItem != null)

            {
                string valdKategori = listBoxKategori.SelectedItem.ToString();

                // Bekräfta raderingen
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
                        podcastRepository.TaBortKategori(valdKategori);
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

        private void ändraKategori_Click(object sender, EventArgs e)
        {  
            // Kontrollera om något objekt är valt
            if (listBoxKategori.SelectedItem != null)
            {
                // Hämta den valda indexen
                int selectedIndex = listBoxKategori.SelectedIndex;

                // Uppdatera den valda kategorin med texten från kategoriTextBox
                string nyKategori = kategoriTextBox.Text.Trim();

                if (string.IsNullOrWhiteSpace(nyKategori))
                {
                    MessageBox.Show("Vänligen ange en giltig kategori.");
                    return;
                }

                // Anropa metoden i PodcastRepository för att ändra kategorin
                try
                {
                    podcastRepository.AndraKategori(selectedIndex, nyKategori); // Uppdatera kategorin
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ett fel uppstod: {ex.Message}", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Uppdatera listan
                listBoxKategori.Items[selectedIndex] = nyKategori;
                comboBox2.Items[selectedIndex] = nyKategori;
                filtreraKategori.Items[selectedIndex] = nyKategori;

                // Rensa textboxen
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
        
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lvwPodcastDetaljer_SelectedIndexChanged(object sender, EventArgs e)
        //Visar avsnitt för vald podcast (om man klickar på en rad)
        {
            if (lvwPodcastDetaljer.SelectedItems.Count > 0)
            {
                Podcast valdPodcast = lvwPodcastDetaljer.SelectedItems[0].Tag as Podcast;

                if (valdPodcast != null)
                {
                    DisplayEpisodes(valdPodcast);
                }
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
                Podcast valdPodcast = lvwPodcastDetaljer.SelectedItems[0].Tag as Podcast;

                // Bekräfta raderingen
                DialogResult result = MessageBox.Show(
                    $"Är du säker på att du vill ta bort podcasten '{valdPodcast.Namn}'?",
                    "Bekräfta borttagning",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                // Om användaren klickar på "Ja"
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        podcastRepository.TaBortPodcast(valdPodcast); // Ta bort podcasten från repository
                        lvwPodcastDetaljer.Items.Remove(lvwPodcastDetaljer.SelectedItems[0]); // Ta bort från ListView
                        lvwAvsnitt.Items.Clear(); // Rensa avsnitt

                        // Reload the list to ensure it's up-to-date
                        LoadPodcasts();

                        MessageBox.Show($"Podcasten '{valdPodcast.Namn}' har tagits bort.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ett fel uppstod: {ex.Message}", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Avsnitt valtAvsnitt = lvwAvsnitt.SelectedItems[0].Tag as Avsnitt;

                if (valtAvsnitt != null)
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
                string renDescription = TaBortHtmlTags(avsnitt.Beskrivning);
                lbBeskrivning.Text = renDescription;
            }
            else
            {
                MessageBox.Show("Ingen beskrivning hittades!");
            }
        }

        private string TaBortHtmlTags(string input)
        {
            return System.Text.RegularExpressions.Regex.Replace(input, "<.*?>", string.Empty);
        }

        private void btnAndraFlode_Click(object sender, EventArgs e)
        {
            if (lvwPodcastDetaljer.SelectedItems.Count > 0)
            {
                // Hämta vald podcast
                Podcast valdPodcast = lvwPodcastDetaljer.SelectedItems[0].Tag as Podcast;

                if (valdPodcast != null)
                {
                    // Fyll i fälten med aktuell information
                    textBox1.Text = valdPodcast.Namn; // Sätt namnet
                    comboBox2.SelectedItem = valdPodcast.Kategori; // Sätt kategorin

                    // Gör textBox1 och comboBox2 synliga (om de inte är det)
                    textBox1.Visible = true;
                    comboBox2.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Vänligen välj en podcast att ändra.");
            }
        }

        private void btnSpara_Click(object sender, EventArgs e)
        {
            if (lvwPodcastDetaljer.SelectedItems.Count > 0)
            {
                Podcast valdPodcast = lvwPodcastDetaljer.SelectedItems[0].Tag as Podcast;

                if (valdPodcast != null)
                {
                    // Spara ändringar i namn
                    string nyttNamn = textBox1.Text.Trim();
                    if (!string.IsNullOrWhiteSpace(nyttNamn))
                    {
                        valdPodcast.Namn = nyttNamn; // Uppdatera podcastens namn
                        lvwPodcastDetaljer.SelectedItems[0].SubItems[1].Text = nyttNamn; // Uppdatera ListView
                    }

                    // Spara ändringar i kategori
                    string nyKategori = comboBox2.SelectedItem?.ToString() ?? "";
                    if (!string.IsNullOrWhiteSpace(nyKategori))
                    {
                        valdPodcast.Kategori = nyKategori; // Uppdatera podcastens kategori
                        lvwPodcastDetaljer.SelectedItems[0].SubItems[4].Text = nyKategori; // Uppdatera ListView
                    }

                    MessageBox.Show("Ändringar sparades.");
                }
            }
            else
            {
                MessageBox.Show("Vänligen välj en podcast att spara ändringar för.");
            }

        }

        private void filtreraKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valdKategori = filtreraKategori.SelectedItem?.ToString();
            FiltreraPodcaster(valdKategori);
        }

        private void FiltreraPodcaster(string kategori)
        {
            lvwPodcastDetaljer.Items.Clear(); // Tömmer ListView

            var podcasts = podcastRepository.HamtaAllaPodcast();

            foreach (var podcast in podcasts)
            {
                if (string.IsNullOrEmpty(kategori) || podcast.Kategori == kategori)
                {
                    int antalAvsnitt = podcast.HamtaAvsnitt().Count;
                    ListViewItem podcastItem = new ListViewItem(antalAvsnitt.ToString());
                    podcastItem.SubItems.Add(podcast.Namn);
                    podcastItem.SubItems.Add(podcast.Titel ?? "Ingen titel");
                    podcastItem.SubItems.Add("Frekvens"); // Lägg till om du har frekvens
                    podcastItem.SubItems.Add(podcast.Kategori);
                    podcastItem.Tag = podcast;

                    lvwPodcastDetaljer.Items.Add(podcastItem);
                }
            }
        }

        private void btnAterstall_Click(object sender, EventArgs e)
        {
            filtreraKategori.SelectedIndex = -1; // Avmarkera vald kategori i comboBox

            // Ladda om alla podcasts
            LoadPodcasts();
        }
    }
}

         
    


