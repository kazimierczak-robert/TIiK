using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TIIK_1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.Text = "Wykres ilości informacji";
        }

        public void Wyswietl(string[,] tab)
        {
            double p = 0.1D;
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                p = Double.Parse(tab[i, 3]);
                if (Convert.ToInt32(tab[i, 1]) > 0)
                {
                    this.chart1.Series["Ilosc informacji"].Points.AddXY(tab[i, 0], p);
                }
            }
        }
    }
}
