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
            lbBeskrivning2 = new ListBox();
            label5 = new Label();
            label6 = new Label();
            listBoxKategori = new ListBox();
            lvwPodcastDetaljer = new ListView();
            lvwAvsnitt = new ListView();
            lbBeskrivning = new TextBox();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(188, 288);
            textBox1.Margin = new Padding(6, 8, 6, 8);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(540, 39);
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
            comboBox2.Location = new Point(491, 413);
            comboBox2.Margin = new Padding(6, 8, 6, 8);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(258, 40);
            comboBox2.TabIndex = 3;
            comboBox2.Text = "Kategori";
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // filtreraKategori
            // 
            filtreraKategori.FormattingEnabled = true;
            filtreraKategori.Location = new Point(543, 180);
            filtreraKategori.Margin = new Padding(4, 5, 4, 5);
            filtreraKategori.Name = "filtreraKategori";
            filtreraKategori.Size = new Size(160, 28);
            filtreraKategori.TabIndex = 4;
            filtreraKategori.Text = "Filtrera...";
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
            // btnAndraFlode
            // 
            btnAndraFlode.Location = new Point(651, 254);
            btnAndraFlode.Margin = new Padding(4, 5, 4, 5);
            btnAndraFlode.Name = "btnAndraFlode";
            btnAndraFlode.Size = new Size(100, 35);
            btnAndraFlode.TabIndex = 6;
            btnAndraFlode.Text = "Ändra";
            btnAndraFlode.UseVisualStyleBackColor = true;
            btnAndraFlode.Click += btnAndraFlode_Click;
            // 
            // btnAterstall
            // 
            btnAterstall.Location = new Point(723, 176);
            btnAterstall.Margin = new Padding(4, 5, 4, 5);
            btnAterstall.Name = "btnAterstall";
            btnAterstall.Size = new Size(100, 35);
            btnAterstall.TabIndex = 7;
            btnAterstall.Text = "Återställ";
            btnAterstall.UseVisualStyleBackColor = true;
            btnAterstall.Click += btnAterstall_Click;
            // 
            // taBortFlode
            // 
            taBortFlode.Location = new Point(1199, 406);
            taBortFlode.Margin = new Padding(6, 8, 6, 8);
            taBortFlode.Name = "taBortFlode";
            taBortFlode.Size = new Size(162, 56);
            taBortFlode.TabIndex = 8;
            taBortFlode.Text = "Ta bort";
            taBortFlode.UseCompatibleTextRendering = true;
            taBortFlode.UseVisualStyleBackColor = true;
            taBortFlode.Click += taBortFlode_Click;
            // 
            // kategoriTextBox
            // 
            kategoriTextBox.Location = new Point(1833, 438);
            kategoriTextBox.Margin = new Padding(6, 8, 6, 8);
            kategoriTextBox.Name = "kategoriTextBox";
            kategoriTextBox.Size = new Size(212, 39);
            kategoriTextBox.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1841, 398);
            label3.Margin = new Padding(6, 0, 6, 0);
            label3.Name = "label3";
            label3.Size = new Size(103, 32);
            label3.TabIndex = 15;
            label3.Text = "Kategori";
            label3.Click += label3_Click;
            // 
            // läggTillKategori
            // 
            läggTillKategori.Location = new Point(1841, 507);
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
            ändraKategori.Location = new Point(2036, 507);
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
            taBortKategori.Location = new Point(2237, 507);
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
            txtURL.Location = new Point(938, 483);
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
            // lbBeskrivning2
            // 
            lbBeskrivning2.FormattingEnabled = true;
            lbBeskrivning2.Location = new Point(1833, 1204);
            lbBeskrivning2.Margin = new Padding(6, 8, 6, 8);
            lbBeskrivning2.Name = "lbBeskrivning2";
            lbBeskrivning2.ScrollAlwaysVisible = true;
            lbBeskrivning2.Size = new Size(587, 420);
            lbBeskrivning2.TabIndex = 22;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(320, 1671);
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
            listBoxKategori.Location = new Point(1833, 569);
            listBoxKategori.Margin = new Padding(3, 6, 3, 6);
            listBoxKategori.Name = "listBoxKategori";
            listBoxKategori.Size = new Size(587, 612);
            listBoxKategori.TabIndex = 25;
            listBoxKategori.SelectedIndexChanged += listBoxKategori_SelectedIndexChanged;
            // 
            // lvwPodcastDetaljer
            // 
            lvwPodcastDetaljer.FullRowSelect = true;
            lvwPodcastDetaljer.GridLines = true;
            lvwPodcastDetaljer.Location = new Point(202, 550);
            lvwPodcastDetaljer.Name = "lvwPodcastDetaljer";
            lvwPodcastDetaljer.Size = new Size(738, 1098);
            lvwPodcastDetaljer.TabIndex = 26;
            lvwPodcastDetaljer.UseCompatibleStateImageBehavior = false;
            lvwPodcastDetaljer.View = View.Details;
            lvwPodcastDetaljer.SelectedIndexChanged += lvwPodcastDetaljer_SelectedIndexChanged;
            // 
            // lvwAvsnitt
            // 
            lvwAvsnitt.FullRowSelect = true;
            lvwAvsnitt.GridLines = true;
            lvwAvsnitt.Location = new Point(1001, 550);
            lvwAvsnitt.Name = "lvwAvsnitt";
            lvwAvsnitt.Size = new Size(738, 1098);
            lvwAvsnitt.TabIndex = 27;
            lvwAvsnitt.UseCompatibleStateImageBehavior = false;
            lvwAvsnitt.View = View.Details;
            lvwAvsnitt.SelectedIndexChanged += lvwAvsnitt_SelectedIndexChanged;
            // 
            // lbBeskrivning
            // 
            lbBeskrivning.Location = new Point(1449, 1142);
            lbBeskrivning.Multiline = true;
            lbBeskrivning.Name = "lbBeskrivning";
            lbBeskrivning.Size = new Size(337, 436);
            lbBeskrivning.TabIndex = 28;
            // 
            // btnSpara
            // 
            btnSpara.Location = new Point(765, 254);
            btnSpara.Name = "btnSpara";
            btnSpara.Size = new Size(94, 29);
            btnSpara.TabIndex = 28;
            btnSpara.Text = "Spara";
            btnSpara.UseVisualStyleBackColor = true;
            btnSpara.Click += btnSpara_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(2883, 1759);
            Controls.Add(lbBeskrivning);
            Controls.Add(lvwAvsnitt);
            Controls.Add(lvwPodcastDetaljer);
            Controls.Add(listBoxKategori);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(lbBeskrivning2);
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
            Margin = new Padding(6, 8, 6, 8);
            Name = "Form1";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
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
        private System.Windows.Forms.ListBox lbBeskrivning2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox listBoxKategori;
        private ListView lvwPodcastDetaljer;
        private ListView lvwAvsnitt;
        private TextBox lbBeskrivning;
        private TextBox TaBortHtmlTags;
    }
}

