using business;
using dataAccess;
using models;

namespace podcast_grupp18
{
    public partial class Form1 : Form
    {
        private PodcastController podcastController;
        private PodcastRepository podcastRepository;

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
            // Spara kategorier vid stängning
            podcastRepository.SparaKategorierTillFil(); // Anropa metoden direkt från podcastRepository
        }
       

        private void LoadPodcasts()
        {
            var podcasts = podcastRepository.HamtaAllaPodcast();
            foreach (var podcast in podcasts)
                if (podcasts.Any())
            {
                int antalAvsnitt = podcast.HamtaAvsnitt().Count;
                ListViewItem podcastItem = new ListViewItem(antalAvsnitt.ToString());
                podcastItem.SubItems.Add(string.Empty);  // 2 KOLUMN för framtida använde
                podcastItem.SubItems.Add(podcast.Namn);
                podcastItem.Tag = podcast; //lägger podcasten i en tag... används för att kunna se specifika avsnitt
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
            string podcastNamn = textBox1.Text.Trim(); // Hämtar podcastnamnet från textBox1
            string kategori = comboBox2.SelectedItem?.ToString() ?? ""; // Hämtar vald kategori från comboBox2

            // Kontrollera om URL och namn är ifyllt
            if (string.IsNullOrWhiteSpace(url))
            {
                MessageBox.Show("Vänligen ange giltig URL!");
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
                Podcast podcast = await podcastController.HamtaPodcastFranRSSAsync(url);

                if (podcast == null || !podcast.HamtaAvsnitt().Any())
                {
                    MessageBox.Show("Podcasten kunde ej hittas!");
                    return;
                }

                // Uppdatera podcastens namn och kategori med användarens input
                podcast.Namn = podcastNamn;
                podcast.Kategori = kategori;

                // Skapa ListViewItem och fyll kolumnerna
                int antalAvsnitt = podcast.HamtaAvsnitt().Count;
                ListViewItem podcastItem = new ListViewItem(antalAvsnitt.ToString()); // Antal avsnitt
                podcastItem.SubItems.Add(podcast.Namn);      // Namn från textBox1
                podcastItem.SubItems.Add(podcast.Titel ?? "Ingen titel");   // Titel från podcast, hantera om den är null
                podcastItem.SubItems.Add("Frekvens"); // Här kan du lägga till frekvens om det finns en variabel för det
                podcastItem.SubItems.Add(podcast.Kategori);   // Kategori från comboBox2

                podcastItem.Tag = podcast; // Lagrar podcasten som en tagg för att senare hämta avsnitt
                lvwPodcastDetaljer.Items.Add(podcastItem);

                // Rensa inmatningsfälten efter tillägg
                txtURL.Clear();
                textBox1.Clear();
                comboBox2.SelectedIndex = -1; // Rensa vald kategori

                // Lägg till podcasten i podcastRepository
                podcastRepository.LaggTillPodcast(podcast);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ett fel uppstod: {ex.Message}", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

          // Fetch episode titles
         var avsnittTitlar = podcast.HamtaAvsnittTitlar();

            if (avsnittTitlar == null || !avsnittTitlar.Any())
            {
                if (lvwAvsnitt.Items.Count == 0)
                {
                    MessageBox.Show("Inga avsnitt hittades!");
                }
            }
            else
          {
                int avsnittNummer = 1;

                foreach (var avsnittTitel in avsnittTitlar)
             {
                    var listViewItem = new ListViewItem($"{avsnittNummer}. {avsnittTitel}"); 
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
    }
}

