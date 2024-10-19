using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace podcast_grupp18
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
        {
            //podcast pod = new podcast();
            //pod.Namn = textBox1.Text;
            //pod.URL = textBox3.Text;
            //pod.Kategori = comboBox2.Text;

            //pod.Serialize("PodcastSpara.xml");
        


        }

       


        private void läggTillKategori_Click_1(object sender, EventArgs e)
        {
            listBoxKategori.Items.Add(kategoriTextBox.Text);

            kategoriTextBox.Clear();

        }

        private void taBortKategori_Click(object sender, EventArgs e)
        {
            listBoxKategori.Items.Remove(listBoxKategori.SelectedItem);
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
    }
}
