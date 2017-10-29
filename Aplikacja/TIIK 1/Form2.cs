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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.Text = "Wykres liczby wystąpień";
            
        }
        
        public void Wyswietl(string [,] tab)
        {
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                if (Convert.ToInt32(tab[i, 1]) > 0)
                {
                    this.chart2.Series["Liczba wystąpień"].Points.AddXY(tab[i, 0], tab[i, 1]);
                }
            }
        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }
    }
}

