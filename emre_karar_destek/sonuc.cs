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
    public partial class sonuc : Form
    {
        public sonuc()
        {
            InitializeComponent();
        }

        private void sonuc_Load(object sender, EventArgs e)
        {
            
          

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 ac = new Form1();
            ac.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection baglan = new MySqlConnection("Server=localhost;  database=emre_test; uid=root; password=;");


            baglan.Open();
            MySqlCommand kmt = new MySqlCommand("update ogr_bilgi set k1='" + label1.Text + "',k2='" + label2.Text + "', k3='" + label3.Text + "', k4='" + label4.Text + "', k5='" + label5.Text+ "', puan='" + label16.Text + "' where tc=" + label12.Text + "", baglan);
            kmt.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("kayıt başarılı");
            Form1 ac = new Form1();
            ac.Show();
            this.Hide();
            
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}
