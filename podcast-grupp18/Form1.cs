using System;
using System.Windows.Forms;
using business;
using models;

namespace podcast_grupp18
{
    public partial class Form1 : Form
    {
        private PodcastController podcastController;
        public Form1()
        {
            InitializeComponent();
            podcastController = new PodcastController();
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
        //Lägg till podcast - ska ändras senare
        {
            string rssLank = txtURL.Text;
            podcastController.HamtaPodcastFranRSS(rssLank);

            dataGridView2.Columns.Clear();
            dataGridView2.DataSource = podcastController.HamtaAllaPodcast();
            dataGridView2.Columns["Avsnitt"].HeaderText = "Avsnitt";
        }

        private void läggTillKategori_Click_1(object sender, EventArgs e)
        {


            listBoxKategori.Items.Add(kategoriTextBox.Text);

            comboBox2.Items.Add(kategoriTextBox.Text);

            kategoriTextBox.Clear();

        }

        private void taBortKategori_Click(object sender, EventArgs e)
        {

            if (listBoxKategori.SelectedItem != null)

            {
                string valdKategori = listBoxKategori.SelectedItem.ToString();

                listBoxKategori.Items.Remove(valdKategori);

                comboBox2.Items.Remove(valdKategori);

                kategoriTextBox.Clear();
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
    }
}
