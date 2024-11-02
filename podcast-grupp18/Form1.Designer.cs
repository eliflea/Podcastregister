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
            textBox1.Location = new Point(318, 185);
            textBox1.Margin = new Padding(5, 6, 5, 6);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(416, 31);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(318, 154);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(65, 25);
            label1.TabIndex = 1;
            label1.Text = "Namn ";
            label1.Click += label1_Click;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(318, 231);
            comboBox2.Margin = new Padding(5, 6, 5, 6);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(416, 33);
            comboBox2.TabIndex = 3;
            comboBox2.Text = "Kategori";
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // filtreraKategori
            // 
            filtreraKategori.FormattingEnabled = true;
            filtreraKategori.Location = new Point(898, 183);
            filtreraKategori.Margin = new Padding(2, 4, 2, 4);
            filtreraKategori.Name = "filtreraKategori";
            filtreraKategori.Size = new Size(186, 33);
            filtreraKategori.TabIndex = 4;
            filtreraKategori.Text = "Filtrera...";
            // 
            // btnLaggTill
            // 
            btnLaggTill.Location = new Point(318, 347);
            btnLaggTill.Margin = new Padding(5, 6, 5, 6);
            btnLaggTill.Name = "btnLaggTill";
            btnLaggTill.Size = new Size(129, 37);
            btnLaggTill.TabIndex = 5;
            btnLaggTill.Text = "Lägg till";
            btnLaggTill.UseVisualStyleBackColor = true;
            btnLaggTill.Click += button1_Click;
            // 
            // btnAndraFlode
            // 
            btnAndraFlode.Location = new Point(588, 347);
            btnAndraFlode.Margin = new Padding(2, 4, 2, 4);
            btnAndraFlode.Name = "btnAndraFlode";
            btnAndraFlode.Size = new Size(120, 39);
            btnAndraFlode.TabIndex = 6;
            btnAndraFlode.Text = "Ändra";
            btnAndraFlode.UseVisualStyleBackColor = true;
            btnAndraFlode.Click += btnAndraFlode_Click;
            // 
            // btnAterstall
            // 
            btnAterstall.Location = new Point(898, 231);
            btnAterstall.Margin = new Padding(2, 4, 2, 4);
            btnAterstall.Name = "btnAterstall";
            btnAterstall.Size = new Size(102, 35);
            btnAterstall.TabIndex = 7;
            btnAterstall.Text = "Återställ";
            btnAterstall.UseVisualStyleBackColor = true;
            btnAterstall.Click += btnAterstall_Click;
            // 
            // taBortFlode
            // 
            taBortFlode.Location = new Point(457, 347);
            taBortFlode.Margin = new Padding(5, 6, 5, 6);
            taBortFlode.Name = "taBortFlode";
            taBortFlode.Size = new Size(124, 37);
            taBortFlode.TabIndex = 8;
            taBortFlode.Text = "Ta bort";
            taBortFlode.UseCompatibleTextRendering = true;
            taBortFlode.UseVisualStyleBackColor = true;
            taBortFlode.Click += taBortFlode_Click;
            // 
            // kategoriTextBox
            // 
            kategoriTextBox.Location = new Point(1496, 356);
            kategoriTextBox.Margin = new Padding(5, 6, 5, 6);
            kategoriTextBox.Name = "kategoriTextBox";
            kategoriTextBox.Size = new Size(164, 31);
            kategoriTextBox.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1496, 325);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(78, 25);
            label3.TabIndex = 15;
            label3.Text = "Kategori";
            label3.Click += label3_Click;
            // 
            // läggTillKategori
            // 
            läggTillKategori.Location = new Point(1496, 618);
            läggTillKategori.Margin = new Padding(5, 6, 5, 6);
            läggTillKategori.Name = "läggTillKategori";
            läggTillKategori.Size = new Size(454, 34);
            läggTillKategori.TabIndex = 16;
            läggTillKategori.Text = "Lägg till";
            läggTillKategori.UseVisualStyleBackColor = true;
            läggTillKategori.Click += läggTillKategori_Click_1;
            // 
            // ändraKategori
            // 
            ändraKategori.Location = new Point(1496, 664);
            ändraKategori.Margin = new Padding(5, 6, 5, 6);
            ändraKategori.Name = "ändraKategori";
            ändraKategori.Size = new Size(454, 36);
            ändraKategori.TabIndex = 17;
            ändraKategori.Text = "Ändra";
            ändraKategori.UseVisualStyleBackColor = true;
            ändraKategori.Click += ändraKategori_Click;
            // 
            // taBortKategori
            // 
            taBortKategori.Location = new Point(1496, 712);
            taBortKategori.Margin = new Padding(5, 6, 5, 6);
            taBortKategori.Name = "taBortKategori";
            taBortKategori.Size = new Size(454, 44);
            taBortKategori.TabIndex = 18;
            taBortKategori.Text = "Ta bort";
            taBortKategori.UseVisualStyleBackColor = true;
            taBortKategori.Click += taBortKategori_Click;
            // 
            // txtURL
            // 
            txtURL.Location = new Point(318, 299);
            txtURL.Margin = new Padding(5, 6, 5, 6);
            txtURL.Name = "txtURL";
            txtURL.Size = new Size(420, 31);
            txtURL.TabIndex = 20;
            txtURL.TextChanged += textBox3_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(318, 272);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(47, 25);
            label4.TabIndex = 21;
            label4.Text = "URL:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(246, 1305);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(199, 25);
            label5.TabIndex = 23;
            label5.Text = "senaste nedladdningen:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Ebrima", 22F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(1087, 47);
            label6.Margin = new Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new Size(187, 60);
            label6.TabIndex = 24;
            label6.Text = "Podcast";
            // 
            // listBoxKategori
            // 
            listBoxKategori.FormattingEnabled = true;
            listBoxKategori.ItemHeight = 25;
            listBoxKategori.Location = new Point(1496, 401);
            listBoxKategori.Margin = new Padding(2, 5, 2, 5);
            listBoxKategori.Name = "listBoxKategori";
            listBoxKategori.Size = new Size(453, 204);
            listBoxKategori.TabIndex = 25;
            listBoxKategori.SelectedIndexChanged += listBoxKategori_SelectedIndexChanged;
            // 
            // lvwPodcastDetaljer
            // 
            lvwPodcastDetaljer.FullRowSelect = true;
            lvwPodcastDetaljer.GridLines = true;
            lvwPodcastDetaljer.Location = new Point(284, 401);
            lvwPodcastDetaljer.Margin = new Padding(2);
            lvwPodcastDetaljer.Name = "lvwPodcastDetaljer";
            lvwPodcastDetaljer.Size = new Size(590, 854);
            lvwPodcastDetaljer.TabIndex = 26;
            lvwPodcastDetaljer.UseCompatibleStateImageBehavior = false;
            lvwPodcastDetaljer.View = View.Details;
            lvwPodcastDetaljer.SelectedIndexChanged += lvwPodcastDetaljer_SelectedIndexChanged;
            // 
            // lvwAvsnitt
            // 
            lvwAvsnitt.FullRowSelect = true;
            lvwAvsnitt.GridLines = true;
            lvwAvsnitt.Location = new Point(898, 401);
            lvwAvsnitt.Margin = new Padding(2);
            lvwAvsnitt.Name = "lvwAvsnitt";
            lvwAvsnitt.Size = new Size(569, 508);
            lvwAvsnitt.TabIndex = 27;
            lvwAvsnitt.UseCompatibleStateImageBehavior = false;
            lvwAvsnitt.View = View.Details;
            lvwAvsnitt.SelectedIndexChanged += lvwAvsnitt_SelectedIndexChanged;
            // 
            // lbBeskrivning
            // 
            lbBeskrivning.Location = new Point(898, 928);
            lbBeskrivning.Margin = new Padding(2);
            lbBeskrivning.Multiline = true;
            lbBeskrivning.Name = "lbBeskrivning";
            lbBeskrivning.ScrollBars = ScrollBars.Vertical;
            lbBeskrivning.Size = new Size(569, 328);
            lbBeskrivning.TabIndex = 28;
            // 
            // btnSpara
            // 
            btnSpara.Location = new Point(714, 347);
            btnSpara.Margin = new Padding(4);
            btnSpara.Name = "btnSpara";
            btnSpara.Size = new Size(119, 37);
            btnSpara.TabIndex = 29;
            btnSpara.Text = "Spara";
            btnSpara.UseVisualStyleBackColor = true;
            btnSpara.Click += btnSpara_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1140, 364);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(67, 25);
            label2.TabIndex = 30;
            label2.Text = "Avsnitt";
            label2.Click += label2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1924, 1050);
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
            Controls.Add(label1);
            Controls.Add(textBox1);
            Margin = new Padding(5, 6, 5, 6);
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

