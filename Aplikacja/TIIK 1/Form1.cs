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
using System.Diagnostics;

namespace TIIK_1
{
    public partial class Form1 : Form
    {
        Encoding encoding = Encoding.GetEncoding("Windows-1250");
        string appPath = Path.GetDirectoryName(Application.ExecutablePath);

        public Form1()
        {
            InitializeComponent();
            //listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.Head‌​erSize);//for proper look
            this.Text = "Aplikacja TIiK";
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
            for (int i = 0; i < tekst.Length; i++)
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
                if (isFound == false)
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
            for (int i = 0; i < tablicaZnakow.GetLength(0); i++)
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
            if (Directory.Exists("..\\..\\..\\..\\pliki testowe"))
            {
                string fileDir = "";
                var splittedPath = appPath.Split('\\');
                for (int i = 0; i < splittedPath.Count() - 4; i++)
                {
                    fileDir += splittedPath[i] + "\\";
                }
                fileDir += "pliki testowe";
                openFileDialog1.InitialDirectory = fileDir;
            }
            else
            {
                openFileDialog1.InitialDirectory = appPath;
            }

            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                listView1.Items.Clear();
                zerujTablice();
                System.IO.StreamReader sr = new
                   System.IO.StreamReader(openFileDialog1.FileName, Encoding.GetEncoding("Windows-1250"));
                String znaki = sr.ReadToEnd();
                FileStream fs;
                MessageBox.Show("Plik wczytano pomyślnie", "Informacja");
                GBTextAnalysing.Text = "Analiza tekstu: " + openFileDialog1.SafeFileName.ToString();
                sr.Close();

                int dlugoscCiaguZnakow = znaki.Length;

                podzielNaZnaki(znaki);
                obliczPrawdopodobienstwo(dlugoscCiaguZnakow);
                obliczIloscInformacji();
                obliczEntropieBinarna();

                wypelnijListe();
                label2.Text = dlugoscCiaguZnakow.ToString();

                //string path = "..\\..\\..\\..\\wyniki\\";
                //Utworzenie folderu o nazwie pliku
                //string dirName = System.IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                //string dirPath = path + dirName;
                //System.IO.Directory.CreateDirectory(dirPath);
                //Zapis wynikow do pliku
                //zapiszDoPliku(dirPath + "\\alfabet.txt", 0);//alfabet
                //zapiszDoPliku(dirPath + "\\liczbaWystapien.txt", 1);//liczba wystapien
                //zapiszDoPliku(dirPath + "\\prawdopodobienstwo.txt", 2);//prawdopodobienstwo
                //zapiszDoPliku(dirPath + "\\iloscInformacji.txt", 3);//ilosc informacji

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

        private void BSkompresuj_Click(object sender, EventArgs e)
        {
            long start, end;
            int z;

            if(Directory.Exists("..\\..\\..\\..\\pliki testowe"))
            {
                string fileDir = "";
                var splittedPath = appPath.Split('\\');
                for (int i = 0; i < splittedPath.Count()-4; i++)
                {
                    fileDir += splittedPath[i] + "\\";
                }
                fileDir += "pliki testowe";
                openFileDialog1.InitialDirectory = fileDir;
            }
            else
            {
                openFileDialog1.InitialDirectory = appPath;
            }

            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                BSkompresuj.Enabled = false;
                De_Koder koder = new De_Koder();
                FileStream we, wy;
                bool[] uzyte = new bool[256];
                byte marker = 0;
                we = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.ReadWrite);
                //Stworz folder na pliki skompresowane
                string path = "..\\..\\..\\..\\Skompresowane\\";
                System.IO.Directory.CreateDirectory(path);
                //Pobierz nazwe pliku bez rozszerzenia
                string fileName = System.IO.Path.GetFileName(openFileDialog1.FileName);
                //Dodaj <Compressed>
                //fileNameWithoutExt += "Compressed";
                //Utworz plik
                path = "..\\..\\..\\..\\Skompresowane\\" + fileName;
                wy = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);

                start = 0;
                progressBar1.Value = 0;


                for (; ; )
                {
                    z = we.ReadByte();//fgetc(we);
                    if (we.Position == we.Length/*feof(we)*/)
                    {
                        break;
                    }
                    uzyte[z] = true;
                    if (koder.Wszystkie(uzyte, ref marker) == true)
                    {
                        uzyte = Enumerable.Repeat(false, uzyte.Length).ToArray();
                        //memset(uzyte, 0, sizeof(uzyte));
                        end = we.Position;// ftell(we);
                        koder.Koduj(start, end, wy, marker, we, progressBar1);
                        start = end;
                    }
                }
               
                koder.Koduj(start, we.Position/*ftell(we)*/, wy, marker, we, progressBar1);
                we.Close();
                wy.Close();
                BSkompresuj.Enabled = true;
                if (File.Exists(path))
                {
                    Process.Start("explorer.exe", "/select, " + path);
                }       
                //_fcloseall();
            }
        }


        private void BZdekompresuj_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            if (Directory.Exists("..\\..\\..\\..\\Skompresowane"))
            {
                string fileDir = "";
                var splittedPath = appPath.Split('\\');
                for (int i = 0; i < splittedPath.Count() - 4; i++)
                {
                    fileDir += splittedPath[i] + "\\";
                }
                fileDir += "Skompresowane";
                openFileDialog1.InitialDirectory = fileDir;
            }
            else
            {
                openFileDialog1.InitialDirectory = appPath;
            }
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                De_Koder koder = new De_Koder();
                FileStream we, wy;
                string path = "..\\..\\..\\..\\Zdekompresowane\\";
                we = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.ReadWrite);        
                System.IO.Directory.CreateDirectory(path);
                //Pobierz nazwe pliku bez rozszerzenia
                string fileName = System.IO.Path.GetFileName(openFileDialog1.FileName);
                //Dodaj <Compressed>
                //fileNameWithoutExt += "Decompressed";
                //Utworz plik
                path = "..\\..\\..\\..\\Zdekompresowane\\" + fileName;
                wy = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);

                long i, dl;
                int z, wzor, j, il, marker;
                byte[] dlBytes = new byte[8];
                for (; ; )
                {
                    we.Read(dlBytes, 0, 8);
                    dl = BitConverter.ToInt64(dlBytes, 0);
                    //dl = we.ReadByte();
                    if (we.Position == we.Length/*feof(we)*/)
                    {
                        break;
                    }
                    //fread(&dl, sizeof(dl), 1, we);
                    marker = we.ReadByte();//fgetc(we);
                    for (i = 0; i < dl;)
                    {
                        z = we.ReadByte();
                        i++;

                        if (z == marker)
                        {
                            il = we.ReadByte();
                            wzor = we.ReadByte();
                            i += 2;
                            for (j = 0; j < il; j++)
                            {
                                wy.WriteByte(Convert.ToByte(wzor));// fputc(wzor, wy);
                            }
                        }
                        else
                        {
                            wy.WriteByte(Convert.ToByte(z));//fputc(z, wy);
                        }
                        progressBar1.Value = Convert.ToInt32((((double)we.Position / (double)we.Length) * 1000));
                        Application.DoEvents();
                    }
                }
                we.Close();
                wy.Close();
                if (File.Exists(path))
                {
                    Process.Start("explorer.exe", "/select, " + path);
                }
            }
        }
    }
}
