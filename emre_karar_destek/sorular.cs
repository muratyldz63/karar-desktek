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
    public partial class sorular : Form
    {
        public sorular()
        {
            InitializeComponent();
        }
        public void temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

            textBox5.Clear();
            textBox6.Clear();
        }
        MySqlConnection baglan = new MySqlConnection("Server=localhost;  database=emre_test; uid=root; password=;");
        DataTable tablo = new DataTable();
        DataTable tabloo = new DataTable();
        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();


            MySqlCommand kmt = new MySqlCommand("insert into sorular(soru,a,b,c,d,dogru,kat_id) values('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "' ,'" + textBox4.Text + "','" + textBox5.Text + "', '" + textBox6.Text + "', '" + comboBox1.SelectedValue + "')", baglan);
            kmt.ExecuteNonQuery();
            baglan.Close();
            timer1.Start();
        }
        public void goster()
        {
           

            baglan.Open();
            tabloo.Clear();
            MySqlDataAdapter apb = new MySqlDataAdapter("select s.soru_id,s.soru,s.a,s.b,s.c,s.d,s.dogru,k.ad from sorular s join kategoriler k  on s.kat_id=k.kategori_id", baglan);
            apb.Fill(tabloo);
            dataGridView1.DataSource = tabloo;
            baglan.Close();
        }
        private void sorular_Load(object sender, EventArgs e)
        {
            goster();


            baglan.Open();
            tablo.Clear();
            MySqlDataAdapter apb = new MySqlDataAdapter("select * from kategoriler", baglan);
            apb.Fill(tablo);
            comboBox1.DataSource = tablo;
            baglan.Close();





            comboBox1.DisplayMember = "ad";
            comboBox1.ValueMember = "kategori_id";

            dataGridView1.Columns["soru_id"].Visible = false;
          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            button1.Enabled = false;

            if (progressBar1.Value==99)
            {
                progressBar1.Value = 9;
                progressBar1.Visible = false;
                timer1.Stop();
                temizle();
                button1.Enabled = true;
                MessageBox.Show("İŞLEM  BAŞARILI");
                goster();

            }
            else
            {
               
                progressBar1.Value += 10;
                
            }
          
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 ac = new Form1();
            ac.Show();
            this.Hide();
        }

     string id;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secili = dataGridView1.SelectedCells[0].RowIndex;
            id = dataGridView1.Rows[secili].Cells["soru_id"].Value.ToString();
            textBox1.Text = dataGridView1.Rows[secili].Cells["soru"].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secili].Cells["a"].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secili].Cells["b"].Value.ToString();
            textBox4.Text = dataGridView1.Rows[secili].Cells["c"].Value.ToString();
            textBox5.Text = dataGridView1.Rows[secili].Cells["d"].Value.ToString();
            textBox6.Text = dataGridView1.Rows[secili].Cells["dogru"].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[secili].Cells["ad"].Value.ToString();

           

           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglan.Open();


            MySqlCommand kmt = new MySqlCommand("DELETE from sorular where soru_id='"+id+"'", baglan);
            kmt.ExecuteNonQuery();
            baglan.Close();

            timer1.Start();
         

        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            MySqlCommand kmt = new MySqlCommand("UPDATE   sorular SET soru='" + textBox1.Text + "', a='" + textBox2.Text + "', b='" + textBox3.Text + "', c='" + textBox4.Text + "',  d='" + textBox5.Text + "',  dogru='" + textBox6.Text + "',  kat_id='" + comboBox1.SelectedValue + "'  where soru_id='" + id + "'", baglan);
            kmt.ExecuteNonQuery();
            baglan.Close();

            timer1.Start();
        }
    }
}
