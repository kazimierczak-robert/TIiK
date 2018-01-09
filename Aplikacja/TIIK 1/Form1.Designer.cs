namespace TIIK_1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonWczytajplik = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Znak = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Wystapienia = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Prawdopodobienstwo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IloscInformacji = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.GBTextAnalysing = new System.Windows.Forms.GroupBox();
            this.GBFileOperation = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.BZdekompresuj = new System.Windows.Forms.Button();
            this.BSkompresuj = new System.Windows.Forms.Button();
            this.GBTextAnalysing.SuspendLayout();
            this.GBFileOperation.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonWczytajplik
            // 
            this.buttonWczytajplik.BackColor = System.Drawing.Color.SandyBrown;
            this.buttonWczytajplik.FlatAppearance.BorderColor = System.Drawing.Color.Peru;
            this.buttonWczytajplik.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonWczytajplik.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonWczytajplik.Location = new System.Drawing.Point(14, 21);
            this.buttonWczytajplik.Name = "buttonWczytajplik";
            this.buttonWczytajplik.Size = new System.Drawing.Size(137, 35);
            this.buttonWczytajplik.TabIndex = 0;
            this.buttonWczytajplik.Text = "Wczytaj plik do analizy";
            this.buttonWczytajplik.UseVisualStyleBackColor = false;
            this.buttonWczytajplik.Click += new System.EventHandler(this.buttonWczytajplik_Click);
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.Window;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Znak,
            this.Wystapienia,
            this.Prawdopodobienstwo,
            this.IloscInformacji});
            this.listView1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(13, 30);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(423, 259);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Znak
            // 
            this.Znak.Text = "Znak";
            this.Znak.Width = 52;
            // 
            // Wystapienia
            // 
            this.Wystapienia.Text = "Liczba wystąpień";
            this.Wystapienia.Width = 98;
            // 
            // Prawdopodobienstwo
            // 
            this.Prawdopodobienstwo.Text = "Prawdopodobieństwo";
            this.Prawdopodobienstwo.Width = 120;
            // 
            // IloscInformacji
            // 
            this.IloscInformacji.Text = "Ilość informacji [bitów]";
            this.IloscInformacji.Width = 127;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.RestoreDirectory = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(10, 301);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Liczba znaków:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(97, 301);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(10, 316);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Entropia binarna:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(97, 316);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "0";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button1.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(299, 297);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 36);
            this.button1.TabIndex = 9;
            this.button1.Text = "Wykres liczby wystąpień";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button2.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.Location = new System.Drawing.Point(156, 297);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(137, 36);
            this.button2.TabIndex = 10;
            this.button2.Text = "Wykres ilości informacji";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // GBTextAnalysing
            // 
            this.GBTextAnalysing.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.GBTextAnalysing.Controls.Add(this.label1);
            this.GBTextAnalysing.Controls.Add(this.button2);
            this.GBTextAnalysing.Controls.Add(this.label2);
            this.GBTextAnalysing.Controls.Add(this.button1);
            this.GBTextAnalysing.Controls.Add(this.label3);
            this.GBTextAnalysing.Controls.Add(this.listView1);
            this.GBTextAnalysing.Controls.Add(this.label4);
            this.GBTextAnalysing.Location = new System.Drawing.Point(10, 8);
            this.GBTextAnalysing.Name = "GBTextAnalysing";
            this.GBTextAnalysing.Size = new System.Drawing.Size(449, 344);
            this.GBTextAnalysing.TabIndex = 11;
            this.GBTextAnalysing.TabStop = false;
            this.GBTextAnalysing.Text = "Analiza tekstu";
            // 
            // GBFileOperation
            // 
            this.GBFileOperation.Controls.Add(this.progressBar1);
            this.GBFileOperation.Controls.Add(this.BZdekompresuj);
            this.GBFileOperation.Controls.Add(this.BSkompresuj);
            this.GBFileOperation.Controls.Add(this.buttonWczytajplik);
            this.GBFileOperation.Location = new System.Drawing.Point(10, 358);
            this.GBFileOperation.Name = "GBFileOperation";
            this.GBFileOperation.Size = new System.Drawing.Size(450, 95);
            this.GBFileOperation.TabIndex = 12;
            this.GBFileOperation.TabStop = false;
            this.GBFileOperation.Text = "Operacje na pliku";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(14, 62);
            this.progressBar1.Maximum = 1000;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(423, 23);
            this.progressBar1.TabIndex = 13;
            // 
            // BZdekompresuj
            // 
            this.BZdekompresuj.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.BZdekompresuj.FlatAppearance.BorderColor = System.Drawing.Color.OliveDrab;
            this.BZdekompresuj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BZdekompresuj.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BZdekompresuj.Location = new System.Drawing.Point(300, 21);
            this.BZdekompresuj.Name = "BZdekompresuj";
            this.BZdekompresuj.Size = new System.Drawing.Size(137, 35);
            this.BZdekompresuj.TabIndex = 2;
            this.BZdekompresuj.Text = "Zdekompresuj plik";
            this.BZdekompresuj.UseVisualStyleBackColor = false;
            this.BZdekompresuj.Click += new System.EventHandler(this.BZdekompresuj_Click);
            // 
            // BSkompresuj
            // 
            this.BSkompresuj.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.BSkompresuj.FlatAppearance.BorderColor = System.Drawing.Color.OliveDrab;
            this.BSkompresuj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BSkompresuj.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BSkompresuj.Location = new System.Drawing.Point(157, 21);
            this.BSkompresuj.Name = "BSkompresuj";
            this.BSkompresuj.Size = new System.Drawing.Size(137, 35);
            this.BSkompresuj.TabIndex = 1;
            this.BSkompresuj.Text = "Skompresuj plik";
            this.BSkompresuj.UseVisualStyleBackColor = false;
            this.BSkompresuj.Click += new System.EventHandler(this.BSkompresuj_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(467, 464);
            this.Controls.Add(this.GBFileOperation);
            this.Controls.Add(this.GBTextAnalysing);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.GBTextAnalysing.ResumeLayout(false);
            this.GBTextAnalysing.PerformLayout();
            this.GBFileOperation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonWczytajplik;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Znak;
        private System.Windows.Forms.ColumnHeader Wystapienia;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader Prawdopodobienstwo;
        private System.Windows.Forms.ColumnHeader IloscInformacji;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox GBTextAnalysing;
        private System.Windows.Forms.GroupBox GBFileOperation;
        private System.Windows.Forms.Button BZdekompresuj;
        private System.Windows.Forms.Button BSkompresuj;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

