using System;

namespace podcast_grupp18
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            label1 = new Label();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            comboBox3 = new ComboBox();
            btnLaggTill = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label2 = new Label();
            kategoriTextBox = new TextBox();
            dataGridView1 = new DataGridView();
            dataGridView2 = new DataGridView();
            label3 = new Label();
            läggTillKategori = new Button();
            ändraKategori = new Button();
            taBortKategori = new Button();
            txtURL = new TextBox();
            label4 = new Label();
            listBox1 = new ListBox();
            label5 = new Label();
            label6 = new Label();
            listBoxKategori = new ListBox();
            lvwPodcastDetaljer = new ListView();
            lvwAvsnitt = new ListView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(188, 288);
            textBox1.Margin = new Padding(6, 8, 6, 8);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(541, 39);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(182, 248);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(86, 32);
            label1.TabIndex = 1;
            label1.Text = "Namn ";
            label1.Click += label1_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(188, 413);
            comboBox1.Margin = new Padding(6, 8, 6, 8);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(258, 40);
            comboBox1.TabIndex = 2;
            comboBox1.Text = "Frekvens/tid";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(490, 413);
            comboBox2.Margin = new Padding(6, 8, 6, 8);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(258, 40);
            comboBox2.TabIndex = 3;
            comboBox2.Text = "Kategori";
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(882, 288);
            comboBox3.Margin = new Padding(6, 8, 6, 8);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(258, 40);
            comboBox3.TabIndex = 4;
            comboBox3.Text = "Kategori";
            // 
            // btnLaggTill
            // 
            btnLaggTill.Location = new Point(817, 408);
            btnLaggTill.Margin = new Padding(6, 8, 6, 8);
            btnLaggTill.Name = "btnLaggTill";
            btnLaggTill.Size = new Size(162, 56);
            btnLaggTill.TabIndex = 5;
            btnLaggTill.Text = "Lägg till";
            btnLaggTill.UseVisualStyleBackColor = true;
            btnLaggTill.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(992, 408);
            button2.Margin = new Padding(6, 8, 6, 8);
            button2.Name = "button2";
            button2.Size = new Size(162, 56);
            button2.TabIndex = 6;
            button2.Text = "Ändra";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(1200, 334);
            button3.Margin = new Padding(6, 8, 6, 8);
            button3.Name = "button3";
            button3.Size = new Size(162, 56);
            button3.TabIndex = 7;
            button3.Text = "Återställ";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(1200, 406);
            button4.Margin = new Padding(6, 8, 6, 8);
            button4.Name = "button4";
            button4.Size = new Size(162, 56);
            button4.TabIndex = 8;
            button4.Text = "Ta bort";
            button4.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1506, 424);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(87, 32);
            label2.TabIndex = 9;
            label2.Text = "Avsnitt";
            // 
            // kategoriTextBox
            // 
            kategoriTextBox.Location = new Point(2162, 416);
            kategoriTextBox.Margin = new Padding(6, 8, 6, 8);
            kategoriTextBox.Name = "kategoriTextBox";
            kategoriTextBox.Size = new Size(212, 39);
            kategoriTextBox.TabIndex = 12;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.Window;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(188, 548);
            dataGridView1.Margin = new Padding(6, 8, 6, 8);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.Size = new Size(847, 1098);
            dataGridView1.TabIndex = 13;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(1140, 548);
            dataGridView2.Margin = new Padding(6, 8, 6, 8);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 82;
            dataGridView2.Size = new Size(847, 1098);
            dataGridView2.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(2156, 334);
            label3.Margin = new Padding(6, 0, 6, 0);
            label3.Name = "label3";
            label3.Size = new Size(103, 32);
            label3.TabIndex = 15;
            label3.Text = "Kategori";
            label3.Click += label3_Click;
            // 
            // läggTillKategori
            // 
            läggTillKategori.Location = new Point(2093, 480);
            läggTillKategori.Margin = new Padding(6, 8, 6, 8);
            läggTillKategori.Name = "läggTillKategori";
            läggTillKategori.Size = new Size(162, 56);
            läggTillKategori.TabIndex = 16;
            läggTillKategori.Text = "Lägg till";
            läggTillKategori.UseVisualStyleBackColor = true;
            läggTillKategori.Click += läggTillKategori_Click_1;
            // 
            // ändraKategori
            // 
            ändraKategori.Location = new Point(2268, 480);
            ändraKategori.Margin = new Padding(6, 8, 6, 8);
            ändraKategori.Name = "ändraKategori";
            ändraKategori.Size = new Size(162, 56);
            ändraKategori.TabIndex = 17;
            ändraKategori.Text = "Ändra";
            ändraKategori.UseVisualStyleBackColor = true;
            ändraKategori.Click += ändraKategori_Click;
            // 
            // taBortKategori
            // 
            taBortKategori.Location = new Point(2444, 480);
            taBortKategori.Margin = new Padding(6, 8, 6, 8);
            taBortKategori.Name = "taBortKategori";
            taBortKategori.Size = new Size(162, 56);
            taBortKategori.TabIndex = 18;
            taBortKategori.Text = "Ta bort";
            taBortKategori.UseVisualStyleBackColor = true;
            taBortKategori.Click += taBortKategori_Click;
            // 
            // txtURL
            // 
            txtURL.Location = new Point(938, 484);
            txtURL.Margin = new Padding(6, 8, 6, 8);
            txtURL.Name = "txtURL";
            txtURL.Size = new Size(212, 39);
            txtURL.TabIndex = 20;
            txtURL.TextChanged += textBox3_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(842, 488);
            label4.Margin = new Padding(6, 0, 6, 0);
            label4.Name = "label4";
            label4.Size = new Size(60, 32);
            label4.TabIndex = 21;
            label4.Text = "URL:";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(2058, 1213);
            listBox1.Margin = new Padding(6, 8, 6, 8);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(587, 420);
            listBox1.TabIndex = 22;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(423, 1710);
            label5.Margin = new Padding(6, 0, 6, 0);
            label5.Name = "label5";
            label5.Size = new Size(268, 32);
            label5.TabIndex = 23;
            label5.Text = "senaste nedladdningen:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1194, 131);
            label6.Margin = new Padding(6, 0, 6, 0);
            label6.Name = "label6";
            label6.Size = new Size(95, 32);
            label6.TabIndex = 24;
            label6.Text = "Podcast";
            // 
            // listBoxKategori
            // 
            listBoxKategori.FormattingEnabled = true;
            listBoxKategori.Location = new Point(2058, 550);
            listBoxKategori.Margin = new Padding(4, 6, 4, 6);
            listBoxKategori.Name = "listBoxKategori";
            listBoxKategori.Size = new Size(587, 612);
            listBoxKategori.TabIndex = 25;
            listBoxKategori.SelectedIndexChanged += listBoxKategori_SelectedIndexChanged;
            // 
            // lvwPodcastDetaljer
            // 
            lvwPodcastDetaljer.FullRowSelect = true;
            lvwPodcastDetaljer.GridLines = true;
            lvwPodcastDetaljer.Location = new Point(703, 548);
            lvwPodcastDetaljer.Name = "lvwPodcastDetaljer";
            lvwPodcastDetaljer.Size = new Size(846, 1098);
            lvwPodcastDetaljer.TabIndex = 26;
            lvwPodcastDetaljer.UseCompatibleStateImageBehavior = false;
            lvwPodcastDetaljer.View = View.Details;
            lvwPodcastDetaljer.SelectedIndexChanged += lvwPodcastDetaljer_SelectedIndexChanged;
            // 
            // lvwAvsnitt
            // 
            lvwAvsnitt.FullRowSelect = true;
            lvwAvsnitt.GridLines = true;
            lvwAvsnitt.Location = new Point(1323, 550);
            lvwAvsnitt.Name = "lvwAvsnitt";
            lvwAvsnitt.Size = new Size(846, 1098);
            lvwAvsnitt.TabIndex = 27;
            lvwAvsnitt.UseCompatibleStateImageBehavior = false;
            lvwAvsnitt.View = View.Details;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(2773, 1759);
            Controls.Add(lvwAvsnitt);
            Controls.Add(lvwPodcastDetaljer);
            Controls.Add(listBoxKategori);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(listBox1);
            Controls.Add(label4);
            Controls.Add(txtURL);
            Controls.Add(taBortKategori);
            Controls.Add(ändraKategori);
            Controls.Add(läggTillKategori);
            Controls.Add(label3);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Controls.Add(kategoriTextBox);
            Controls.Add(label2);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(btnLaggTill);
            Controls.Add(comboBox3);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(6, 8, 6, 8);
            Name = "Form1";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Button btnLaggTill;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox kategoriTextBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button läggTillKategori;
        private System.Windows.Forms.Button ändraKategori;
        private System.Windows.Forms.Button taBortKategori;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox listBoxKategori;
        private ListView lvwPodcastDetaljer;
        private ListView lvwAvsnitt;
    }
}

