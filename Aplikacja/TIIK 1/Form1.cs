using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using System.Windows.Forms.DataVisualization.Charting;

namespace TIIK_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.Head‌​erSize);//for proper look
            this.Text = "Aplikacja TIIK";
        }

        // tablica przechowujaca wystapienia poszczegolnych liter
        string[,] tablicaZnakow = new string[85, 4];

        // tablica przechowujaca znaki ktore sa brane pod uwage przy zliczaniu, 85 elementow (0-84)
                        //   0   1   2   3   4   5   6   7   8   9   10  11  12  13  14  15  16  17  18  19  20  21  22  23  24  25  26  27  28  29  30  31  32
        string[] alfabet = {"a","ą","b","c","ć","d","e","ę","f","g","h","i","j","k","l","ł","m","n","o","ó","q","p","r","s","ś","t","u","w","x","y","z","ż","ź",
                            "A","Ą","B","C","Ć","D","E","Ę","F","G","H","I","J","K","L","Ł","M","N","O","Ó","Q","P","R","S","Ś","T","U","W","X","Y","Z","Ż","Ź"," ",".",",","?","!","(",")","-",";",":","[","]","{","}","'","`","%","&","\""};
                                                                                                                                                             //  66 (spacja)

        // przypisywanie alfabetu do tablicy znakow, pierwszy element tablicy litera z alfabetu, drugi element wypelnianie zerem
        void zerujTablice()
        {
            for (int i = 0; i < tablicaZnakow.GetLength(0); i++)
            {
                tablicaZnakow[i, 0] = alfabet[i];
                tablicaZnakow[i, 1] = "0";
                tablicaZnakow[i, 2] = "0";
                tablicaZnakow[i, 3] = "0";//ilosc informacji
            }
        }

        // obliczanie wystapien poszczegolnych liter w tekscie
        void podzielNaZnaki(string tekst)
        {
            for(int i = 0; i<tekst.Length;i++)
            {
                for (int j = 0; j < tablicaZnakow.GetLength(0);j++)
                {
                    if (tekst[i].ToString() == tablicaZnakow[j, 0])
                    {
                        int wystapienia = Convert.ToInt32(tablicaZnakow[j, 1]);
                        tablicaZnakow[j, 1] = (wystapienia + 1).ToString();
                        break;
                    }
                }
            }
        }

        void obliczPrawdopodobienstwo(int dlugosc)
        {
            for(int i =0;i<tablicaZnakow.GetLength(0);i++)
            {
                double prawdop = (double)Convert.ToInt32(tablicaZnakow[i, 1]) / (double)dlugosc;

                tablicaZnakow[i, 2] = prawdop.ToString("F6"); ;
            }
        }

        // wypelnianie listy tablica znakow
        void wypelnijListe()
        {
            for (int i = 0; i < tablicaZnakow.GetLength(0); i++)
            {
                if (Convert.ToInt32(tablicaZnakow[i, 1]) > 0)
                {

                    ListViewItem item = new ListViewItem(tablicaZnakow[i, 0]);
                    item.SubItems.Add(tablicaZnakow[i, 1]);
                    item.SubItems.Add(tablicaZnakow[i, 2]);
                    item.SubItems.Add(tablicaZnakow[i, 3]);//ilosc informacji

                    listView1.Items.Add(item);

                    // uzupełnianie wykresu
                    this.chart1.Series["Wystapienia"].Points.AddXY(tablicaZnakow[i, 0], tablicaZnakow[i, 1]);
                }
                
            }

        }
        private void obliczIloscInformacji()
        {
            double I_E = 0.0D;
            double P_E = 0.0D;
            //wzor 1.: I(E) = log2(1/P(E)) [b]
            for (int i = 0; i < tablicaZnakow.GetLength(0); i++)
            {
                P_E = Double.Parse(tablicaZnakow[i, 2]);
                //Check if 0
                if (P_E == 0) continue;
                //Math.Log(number, base)
                I_E = Math.Log(1 / P_E, 2);
                //Add to listView
                tablicaZnakow[i, 3] = I_E.ToString("F6");
            }
        }
      
        private void buttonWczytajplik_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            zerujTablice();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new
                   System.IO.StreamReader(openFileDialog1.FileName, Encoding.GetEncoding("Windows-1250"));
                String znaki = sr.ReadToEnd();
                MessageBox.Show("Plik wczytano pomyślnie.");
                sr.Close();

                int dlugoscCiaguZnakow = znaki.Length;
                
                podzielNaZnaki(znaki);
                obliczPrawdopodobienstwo(dlugoscCiaguZnakow);
                obliczIloscInformacji();

                wypelnijListe();
                label2.Text = (dlugoscCiaguZnakow - Convert.ToInt32(tablicaZnakow[66, 1])).ToString();
                //textBox1.Text = "Znaki: " + (znaki.Length-Convert.ToInt32(tablicaZnakow[66,1])); //znaki bez spacji
            }
            
        }

 
    }
}
