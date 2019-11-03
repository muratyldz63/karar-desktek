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
    public partial class OGR_BİLGİ : Form
    {
        public OGR_BİLGİ()
        {
            InitializeComponent();
        }
        MySqlConnection baglan = new MySqlConnection("Server=localhost;  database=emre_test; uid=root; password=;");
        DataTable tablo = new DataTable();
        private void OGR_BİLGİ_Load(object sender, EventArgs e)
        {
          
            GOSTER();

        }
        public void GOSTER()
        {
            baglan.Open();
            tablo.Clear();
            MySqlDataAdapter apb = new MySqlDataAdapter("select * from OGR_BİLGİ", baglan);
            apb.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglan.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

            baglan.Open();
            DataTable tbl = new DataTable();
            string  cumle;
            tbl.Clear();
            cumle = "Select * from OGR_BİLGİ where ad_soyad like '%" + textBox4.Text + "%'";
            MySqlDataAdapter adptr = new MySqlDataAdapter(cumle, baglan);
            adptr.Fill(tbl);
            baglan.Close();
            dataGridView1.DataSource = tbl; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
        using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM ogr_bilgi WHERE tc='" + textBox5.Text + "'", baglan))
        {
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            baglan.Close();
            if (count< 1)
            {

                baglan.Open();
                MySqlCommand kmt = new MySqlCommand("insert into ogr_bilgi(ad_soyad,tc,sinif,d_tarihi,k_tarihi,telefon) values('" + textBox1.Text + "','" + textBox5.Text + "','" + textBox3.Text + "','" + dateTimePicker1.Value + "','" + dateTimePicker2.Value + "','" + textBox2.Text + "')", baglan);
                kmt.ExecuteNonQuery();
                baglan.Close();
                GOSTER();
            }
            else
            {
                MessageBox.Show("BU TC KİMLİK ZATEN KAYITLI");
            }


          

        }
        }

        private void button2_Click(object sender, EventArgs e)
        {


            baglan.Open();
            MySqlCommand kmt = new MySqlCommand("update ogr_bilgi set ad_soyad='" + textBox1.Text + "',tc='" + textBox5.Text + "', sinif='" + textBox3.Text + "', telefon='" + textBox2.Text + "', d_tarihi='" + dateTimePicker2.Value + "', k_tarihi='" + dateTimePicker1.Value + "' where ogr_id=" + id + "", baglan);
            kmt.ExecuteNonQuery();
            baglan.Close();
            GOSTER();






           
        }

        
            string id;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secili = dataGridView1.SelectedCells[0].RowIndex;
            id = dataGridView1.Rows[secili].Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.Rows[secili].Cells["ad_soyad"].Value.ToString();
                textBox5.Text = dataGridView1.Rows[secili].Cells["tc"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[secili].Cells["telefon"].Value.ToString();    
                textBox3.Text = dataGridView1.Rows[secili].Cells["sinif"].Value.ToString();
                dateTimePicker1.Text = dataGridView1.Rows[secili].Cells["k_tarihi"].Value.ToString();
                dateTimePicker2.Text = dataGridView1.Rows[secili].Cells["d_tarihi"].Value.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            MySqlCommand kmt = new MySqlCommand("delete from ogr_bilgi where ogr_id=" + id + "", baglan);
            kmt.ExecuteNonQuery();
            baglan.Close();
            GOSTER();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 ac = new Form1();
            ac.Show();
            this.Hide();
        }
        
    }
}
