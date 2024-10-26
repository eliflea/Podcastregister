using business;
using dataAccess;
using models;
using utilities;

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
        private void LoadPodcasts()
        {
            var podcasts = podcastRepository.HamtaAllaPodcast();
            foreach (var podcast in podcasts)
            {
                int antalAvsnitt = podcast.HamtaAvsnitt().Count;
                ListViewItem podcastItem = new ListViewItem(antalAvsnitt.ToString());
                podcastItem.SubItems.Add(string.Empty);  // 2 KOLUMN för framtida använde
                podcastItem.SubItems.Add(podcast.Namn);
                podcastItem.Tag = podcast; //lägger podcasten i en tag... används för att kunna se specifika avsnitt
                lvwPodcastDetaljer.Items.Add(podcastItem);
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

            if (Validator.IsValidUrl(url))
            {
                try
                {
                    Podcast podcast = await podcastController.HamtaPodcastFranRSSAsync(url);

                    int antalAvsnitt = podcast.HamtaAvsnitt().Count;
                    ListViewItem podcastItem = new ListViewItem(antalAvsnitt.ToString());
                    podcastItem.SubItems.Add(string.Empty);
                    podcastItem.SubItems.Add(podcast.Namn);

                    podcastItem.Tag = podcast;
                    lvwPodcastDetaljer.Items.Add(podcastItem);

                    txtURL.Clear();

                    podcastRepository.LaggTillPodcast(podcast);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ett fel uppstod: " + ex.Message, "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vänligen ange en giltig URL.");
            }
        }

        private void läggTillKategori_Click_1(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(kategoriTextBox.Text))

            {
                listBoxKategori.Items.Add(kategoriTextBox.Text);

                comboBox2.Items.Add(kategoriTextBox.Text);

                kategoriTextBox.Clear();

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
                    listBoxKategori.Items.Remove(valdKategori);

                    comboBox2.Items.Remove(valdKategori);

                    kategoriTextBox.Clear();
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
                listBoxKategori.Items[selectedIndex] = kategoriTextBox.Text;

                comboBox2.Items[selectedIndex] = kategoriTextBox.Text;

                // Rensa textboxen om du vill
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

            // Fetch avsnitt titlar
            var avsnittLista = podcast.HamtaAvsnitt();

            if (avsnittLista == null || !avsnittLista.Any())
            {
                if (lvwAvsnitt.Items.Count == 0)
                {
                    MessageBox.Show("Inga avsnitt hittades!");
                }
            }
            else
            {
                int avsnittNummer = 1;

                foreach (var avsnitt in avsnittLista)
                {
                    var listViewItem = new ListViewItem($"{avsnittNummer}. {avsnitt.Titel}");
                    listViewItem.Tag = avsnitt; // Tilldela Avsnitt-objektet till Tag
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
                    lvwPodcastDetaljer.Items.Remove(lvwPodcastDetaljer.SelectedItems[0]);
                    lvwAvsnitt.Items.Clear();
                    MessageBox.Show($"Podcasten '{valdPodcast.Namn}' har tagits bort.");
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
            lbBeskrivning2.Items.Clear();

            if (!string.IsNullOrWhiteSpace(avsnitt.Beskrivning))
            {
                string cleanDescription = TaBortHtmlTags(avsnitt.Beskrivning);
                lbBeskrivning2.Items.Add(cleanDescription);
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
    }
}

