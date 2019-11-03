using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace emre_karar_destek
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            OGR_BİLGİ AC = new OGR_BİLGİ();
            AC.Show();
            this.Hide();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            TEXT_BASLA AC = new TEXT_BASLA();
            AC.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sorular ac = new sorular();
            ac.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            tablo ac = new tablo();
            ac.Show();
            this.Hide();
        }
    }
}
