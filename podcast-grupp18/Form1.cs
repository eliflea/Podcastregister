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
            lvwPodcastDetaljer.SelectedIndexChanged += lvwPodcastDetaljer_SelectedIndexChanged;
            podcastController = new PodcastController();
            podcastRepository = new PodcastRepository();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        //Lägger till podcastflöde
        {
            string url = txtURL.Text.Trim();

            if (string.IsNullOrWhiteSpace(url))
            {
                MessageBox.Show("Vänligen ange giltig URL!");
                return;
            }
            try
            {
                Podcast podcast = podcastController.HamtaPodcastFranRSS(url);
                if (podcast == null || !podcast.AvsnittLista.Any())
                {
                    MessageBox.Show("Podcasten kunde ej hittas!");
                    return;
                }

                // podcastnamn och antal avsnitt
                int antalAvsnitt = podcast.AvsnittLista.Count;
                ListViewItem podcastItem = new ListViewItem(antalAvsnitt.ToString());
                podcastItem.SubItems.Add(string.Empty);  // 2 KOLUMN för framtida använde
                podcastItem.SubItems.Add(podcast.Namn);

                podcastItem.Tag = podcast; //lägger podcasten i en tag... används för att kunna se specifika avsnitt
                lvwPodcastDetaljer.Items.Add(podcastItem);
                txtURL.Clear();
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
                else
                {
                    MessageBox.Show("Ingen avsnitt hittades!");
                }
            }
        }

        private void DisplayEpisodes(Podcast podcast)
            //Visar avsnitt för varje podcast
        {
            lvwAvsnitt.Items.Clear();

            // Fetchar avsnittstitlar
            var avsnittTitlar = podcast.HamtaAvsnittTitlar();

            if (avsnittTitlar != null && avsnittTitlar.Any())
            {
                foreach (var avsnittTitel in avsnittTitlar)
                {
                    lvwAvsnitt.Items.Add(new ListViewItem(avsnittTitel)); 
                }
            }
            else
            {
                MessageBox.Show("Inga avsnitt hittades!"); 
            }
        }
    }
}
