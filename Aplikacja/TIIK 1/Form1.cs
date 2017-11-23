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
        string[,] tablicaZnakow = new string[0, 4];

        // przypisywanie alfabetu do tablicy znakow, pierwszy element tablicy litera z alfabetu, drugi element wypelnianie zerem
        void zerujTablice()
        {
            tablicaZnakow = new string[0, 4];
        }

        string[,] EnlargeArray(string[,] original)
        {
            string[,] newArray = new string[original.GetLength(0) + 1, 4];

            for (int i = 0; i < original.GetLength(0); i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    newArray[i, j] = original[i, j];
                }
            }
            return newArray;
        }

        // obliczanie wystapien poszczegolnych liter w tekscie
        void podzielNaZnaki(string tekst)
        {
            bool isFound = false;
            for(int i = 0; i<tekst.Length;i++)
            {
                isFound = false;
                for (int j = 0; j < tablicaZnakow.GetLength(0); j++)
                {
                    if (tekst[i].ToString() == tablicaZnakow[j, 0])
                    {
                        int wystapienia = Convert.ToInt32(tablicaZnakow[j, 1]);
                        tablicaZnakow[j, 1] = (wystapienia + 1).ToString();
                        isFound = true;
                        break;
                    }
                }
                if(isFound == false)
                {
                    tablicaZnakow = EnlargeArray(tablicaZnakow);
                    tablicaZnakow[tablicaZnakow.GetLength(0) - 1, 0] = tekst[i].ToString();
                    tablicaZnakow[tablicaZnakow.GetLength(0) - 1, 1] = "1";
                    tablicaZnakow[tablicaZnakow.GetLength(0) - 1, 2] = "0";
                    tablicaZnakow[tablicaZnakow.GetLength(0) - 1, 3] = "0";
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

        private void obliczEntropieBinarna()
        {
            double H_S = 0.0;
            //H(S) = sum(P(si) * I(si))
            for (int i = 0; i < tablicaZnakow.GetLength(0); i++)
            {
                if (Double.Parse(tablicaZnakow[i, 2]) > 0)
                {
                    H_S += Double.Parse(tablicaZnakow[i, 2]) * Double.Parse(tablicaZnakow[i, 3]);
                }
            }
            label4.Text = H_S.ToString("F6");
        }
        private void zapiszDoPliku(string path, int column)
        {
            //textBox1.Text = "Znaki: " + (znaki.Length-Convert.ToInt32(tablicaZnakow[66,1])); //znaki bez spacji
            //Save results to file
            /*tablicaZnakow[i, 0] = alfabet[i];
            tablicaZnakow[i, 1];//liczba
            tablicaZnakow[i, 2];//prawdopodobientswo
            tablicaZnakow[i, 3];//ilosc informacji*/
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path))
            {
                for (int i = 0; i < tablicaZnakow.GetLength(0); i++)
                {
                    file.WriteLine(tablicaZnakow[i, column]);
                }
            }
        }
        private void buttonWczytajplik_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                listView1.Items.Clear();
                zerujTablice();
                System.IO.StreamReader sr = new
                   System.IO.StreamReader(openFileDialog1.FileName, Encoding.GetEncoding("Windows-1250"));
                String znaki = sr.ReadToEnd();
                MessageBox.Show("Plik wczytano pomyślnie", "Informacja");
                sr.Close();

                int dlugoscCiaguZnakow = znaki.Length;
                
                podzielNaZnaki(znaki);
                obliczPrawdopodobienstwo(dlugoscCiaguZnakow);
                obliczIloscInformacji();
                obliczEntropieBinarna();

                wypelnijListe();
                label2.Text = dlugoscCiaguZnakow.ToString();

                string path = "..\\..\\..\\..\\wyniki\\";
                //Utworzenie folderu o nazwie pliku
                string dirName = System.IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                string dirPath = path + dirName;
                System.IO.Directory.CreateDirectory(dirPath);
                //Zapis wynikow do pliku
                zapiszDoPliku(dirPath + "\\alfabet.txt", 0);//alfabet
                zapiszDoPliku(dirPath + "\\liczbaWystapien.txt", 1);//liczba wystapien
                zapiszDoPliku(dirPath + "\\prawdopodobienstwo.txt", 2);//prawdopodobienstwo
                zapiszDoPliku(dirPath + "\\iloscInformacji.txt", 3);//ilosc informacji

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            bool result = form2.Wyswietl(tablicaZnakow);
            if (result == true)
            {
                form2.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            bool result = form3.Wyswietl(tablicaZnakow);
            if (result == true)
            {
                form3.Show();
            }
        }
    }
}
