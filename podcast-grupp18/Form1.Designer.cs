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
            filtreraKategori = new ComboBox();
            btnLaggTill = new Button();
            btnAndraFlode = new Button();
            btnAterstall = new Button();
            taBortFlode = new Button();
            kategoriTextBox = new TextBox();
            label3 = new Label();
            läggTillKategori = new Button();
            ändraKategori = new Button();
            taBortKategori = new Button();
            txtURL = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            listBoxKategori = new ListBox();
            lvwPodcastDetaljer = new ListView();
            lvwAvsnitt = new ListView();
            lbBeskrivning = new TextBox();
            btnSpara = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(254, 148);
            textBox1.Margin = new Padding(4, 5, 4, 5);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(334, 27);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(254, 123);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(53, 20);
            label1.TabIndex = 1;
            label1.Text = "Namn ";
            label1.Click += label1_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(254, 185);
            comboBox1.Margin = new Padding(4, 5, 4, 5);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(160, 28);
            comboBox1.TabIndex = 2;
            comboBox1.Text = "Frekvens/tid";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(428, 185);
            comboBox2.Margin = new Padding(4, 5, 4, 5);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(160, 28);
            comboBox2.TabIndex = 3;
            comboBox2.Text = "Kategori";
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // filtreraKategori
            // 
            filtreraKategori.FormattingEnabled = true;
            filtreraKategori.Location = new Point(438, 87);
            filtreraKategori.Margin = new Padding(2, 3, 2, 3);
            filtreraKategori.Name = "filtreraKategori";
            filtreraKategori.Size = new Size(150, 28);
            filtreraKategori.TabIndex = 4;
            filtreraKategori.Text = "Filtrera...";
            // 
            // btnLaggTill
            // 
            btnLaggTill.Location = new Point(258, 275);
            btnLaggTill.Margin = new Padding(4, 5, 4, 5);
            btnLaggTill.Name = "btnLaggTill";
            btnLaggTill.Size = new Size(100, 35);
            btnLaggTill.TabIndex = 5;
            btnLaggTill.Text = "Lägg till";
            btnLaggTill.UseVisualStyleBackColor = true;
            btnLaggTill.Click += button1_Click;
            // 
            // btnAndraFlode
            // 
            btnAndraFlode.Location = new Point(482, 277);
            btnAndraFlode.Margin = new Padding(2, 3, 2, 3);
            btnAndraFlode.Name = "btnAndraFlode";
            btnAndraFlode.Size = new Size(98, 32);
            btnAndraFlode.TabIndex = 6;
            btnAndraFlode.Text = "Ändra";
            btnAndraFlode.UseVisualStyleBackColor = true;
            btnAndraFlode.Click += btnAndraFlode_Click;
            // 
            // btnAterstall
            // 
            btnAterstall.Location = new Point(598, 86);
            btnAterstall.Margin = new Padding(2, 3, 2, 3);
            btnAterstall.Name = "btnAterstall";
            btnAterstall.Size = new Size(82, 28);
            btnAterstall.TabIndex = 7;
            btnAterstall.Text = "Återställ";
            btnAterstall.UseVisualStyleBackColor = true;
            btnAterstall.Click += btnAterstall_Click;
            // 
            // taBortFlode
            // 
            taBortFlode.Location = new Point(376, 276);
            taBortFlode.Margin = new Padding(4, 5, 4, 5);
            taBortFlode.Name = "taBortFlode";
            taBortFlode.Size = new Size(100, 35);
            taBortFlode.TabIndex = 8;
            taBortFlode.Text = "Ta bort";
            taBortFlode.UseCompatibleTextRendering = true;
            taBortFlode.UseVisualStyleBackColor = true;
            taBortFlode.Click += taBortFlode_Click;
            // 
            // kategoriTextBox
            // 
            kategoriTextBox.Location = new Point(1197, 285);
            kategoriTextBox.Margin = new Padding(4, 5, 4, 5);
            kategoriTextBox.Name = "kategoriTextBox";
            kategoriTextBox.Size = new Size(132, 27);
            kategoriTextBox.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1197, 260);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(66, 20);
            label3.TabIndex = 15;
            label3.Text = "Kategori";
            label3.Click += label3_Click;
            // 
            // läggTillKategori
            // 
            läggTillKategori.Location = new Point(1197, 494);
            läggTillKategori.Margin = new Padding(4, 5, 4, 5);
            läggTillKategori.Name = "läggTillKategori";
            läggTillKategori.Size = new Size(363, 27);
            läggTillKategori.TabIndex = 16;
            läggTillKategori.Text = "Lägg till";
            läggTillKategori.UseVisualStyleBackColor = true;
            läggTillKategori.Click += läggTillKategori_Click_1;
            // 
            // ändraKategori
            // 
            ändraKategori.Location = new Point(1197, 531);
            ändraKategori.Margin = new Padding(4, 5, 4, 5);
            ändraKategori.Name = "ändraKategori";
            ändraKategori.Size = new Size(363, 29);
            ändraKategori.TabIndex = 17;
            ändraKategori.Text = "Ändra";
            ändraKategori.UseVisualStyleBackColor = true;
            ändraKategori.Click += ändraKategori_Click;
            // 
            // taBortKategori
            // 
            taBortKategori.Location = new Point(1197, 570);
            taBortKategori.Margin = new Padding(4, 5, 4, 5);
            taBortKategori.Name = "taBortKategori";
            taBortKategori.Size = new Size(363, 35);
            taBortKategori.TabIndex = 18;
            taBortKategori.Text = "Ta bort";
            taBortKategori.UseVisualStyleBackColor = true;
            taBortKategori.Click += taBortKategori_Click;
            // 
            // txtURL
            // 
            txtURL.Location = new Point(258, 239);
            txtURL.Margin = new Padding(4, 5, 4, 5);
            txtURL.Name = "txtURL";
            txtURL.Size = new Size(334, 27);
            txtURL.TabIndex = 20;
            txtURL.TextChanged += textBox3_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(254, 218);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(38, 20);
            label4.TabIndex = 21;
            label4.Text = "URL:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(197, 1044);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(165, 20);
            label5.TabIndex = 23;
            label5.Text = "senaste nedladdningen:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(958, 40);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(60, 20);
            label6.TabIndex = 24;
            label6.Text = "Podcast";
            // 
            // listBoxKategori
            // 
            listBoxKategori.FormattingEnabled = true;
            listBoxKategori.Location = new Point(1197, 321);
            listBoxKategori.Margin = new Padding(2, 4, 2, 4);
            listBoxKategori.Name = "listBoxKategori";
            listBoxKategori.Size = new Size(363, 164);
            listBoxKategori.TabIndex = 25;
            listBoxKategori.SelectedIndexChanged += listBoxKategori_SelectedIndexChanged;
            // 
            // lvwPodcastDetaljer
            // 
            lvwPodcastDetaljer.FullRowSelect = true;
            lvwPodcastDetaljer.GridLines = true;
            lvwPodcastDetaljer.Location = new Point(239, 317);
            lvwPodcastDetaljer.Margin = new Padding(2);
            lvwPodcastDetaljer.Name = "lvwPodcastDetaljer";
            lvwPodcastDetaljer.Size = new Size(456, 688);
            lvwPodcastDetaljer.TabIndex = 26;
            lvwPodcastDetaljer.UseCompatibleStateImageBehavior = false;
            lvwPodcastDetaljer.View = View.Details;
            lvwPodcastDetaljer.SelectedIndexChanged += lvwPodcastDetaljer_SelectedIndexChanged;
            // 
            // lvwAvsnitt
            // 
            lvwAvsnitt.FullRowSelect = true;
            lvwAvsnitt.GridLines = true;
            lvwAvsnitt.Location = new Point(718, 321);
            lvwAvsnitt.Margin = new Padding(2);
            lvwAvsnitt.Name = "lvwAvsnitt";
            lvwAvsnitt.Size = new Size(456, 407);
            lvwAvsnitt.TabIndex = 27;
            lvwAvsnitt.UseCompatibleStateImageBehavior = false;
            lvwAvsnitt.View = View.Details;
            lvwAvsnitt.SelectedIndexChanged += lvwAvsnitt_SelectedIndexChanged;
            // 
            // lbBeskrivning
            // 
            lbBeskrivning.Location = new Point(718, 742);
            lbBeskrivning.Margin = new Padding(2);
            lbBeskrivning.Multiline = true;
            lbBeskrivning.Name = "lbBeskrivning";
            lbBeskrivning.ScrollBars = ScrollBars.Vertical;
            lbBeskrivning.Size = new Size(456, 263);
            lbBeskrivning.TabIndex = 28;
            // 
            // btnSpara
            // 
            btnSpara.Location = new Point(585, 277);
            btnSpara.Name = "btnSpara";
            btnSpara.Size = new Size(95, 30);
            btnSpara.TabIndex = 29;
            btnSpara.Text = "Spara";
            btnSpara.UseVisualStyleBackColor = true;
            btnSpara.Click += btnSpara_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(912, 291);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 30;
            label2.Text = "Avsnitt";
            label2.Click += label2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1823, 1037);
            Controls.Add(label2);
            Controls.Add(btnSpara);
            Controls.Add(lbBeskrivning);
            Controls.Add(lvwAvsnitt);
            Controls.Add(lvwPodcastDetaljer);
            Controls.Add(listBoxKategori);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtURL);
            Controls.Add(taBortKategori);
            Controls.Add(ändraKategori);
            Controls.Add(läggTillKategori);
            Controls.Add(label3);
            Controls.Add(kategoriTextBox);
            Controls.Add(taBortFlode);
            Controls.Add(btnAterstall);
            Controls.Add(btnAndraFlode);
            Controls.Add(btnLaggTill);
            Controls.Add(filtreraKategori);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load_1;
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
        private System.Windows.Forms.ComboBox filtreraKategori;
        private System.Windows.Forms.Button btnLaggTill;
        private System.Windows.Forms.Button btnAndraFlode;
        private System.Windows.Forms.Button btnAterstall;
        private System.Windows.Forms.Button taBortFlode;
        private System.Windows.Forms.TextBox kategoriTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button läggTillKategori;
        private System.Windows.Forms.Button ändraKategori;
        private System.Windows.Forms.Button taBortKategori;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox listBoxKategori;
        private ListView lvwPodcastDetaljer;
        private ListView lvwAvsnitt;
        private TextBox lbBeskrivning;
        private Button btnSpara;
        private Label label2;
    }
}

