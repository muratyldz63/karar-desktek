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
    public partial class grafik : Form
    {
        public grafik()
        {
            InitializeComponent();
        }
        MySqlConnection baglan = new MySqlConnection("Server=localhost;  database=emre_test; uid=root; password=;");
        DataTable tablo = new DataTable();
        private void grafik_Load(object sender, EventArgs e)
        {
            GOSTER();
            chart1.Titles.Add("CEVAP");

        }
        public void GOSTER()
        {
            baglan.Open();
            tablo.Clear();
            MySqlDataAdapter apb = new MySqlDataAdapter("select *  from OGR_BİLGİ", baglan);
            apb.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglan.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            baglan.Open();
            DataTable tbl = new DataTable();
            string cumle;
            tbl.Clear();
            cumle = "Select * from OGR_BİLGİ where ad_soyad like '%" + textBox1.Text + "%'";
            MySqlDataAdapter adptr = new MySqlDataAdapter(cumle, baglan);
            adptr.Fill(tbl);
            baglan.Close();
            dataGridView1.DataSource = tbl; 
        }
        string id,k1,k2,k3,k4,k5;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secili = dataGridView1.SelectedCells[0].RowIndex;
            id = dataGridView1.Rows[secili].Cells[0].Value.ToString();
            k1= dataGridView1.Rows[secili].Cells["k1"].Value.ToString();
           k2= dataGridView1.Rows[secili].Cells["k2"].Value.ToString();
            k3 = dataGridView1.Rows[secili].Cells["k3"].Value.ToString();
            k5 = dataGridView1.Rows[secili].Cells["k5"].Value.ToString();
           k4 = dataGridView1.Rows[secili].Cells["k4"].Value.ToString();


         this.chart1.Series.Clear();
         this.chart1.Series.Add("ogrenci");


           chart1.Series["ogrenci"].Points.AddXY("Genel Kultur", k1);
           chart1.Series["ogrenci"].Points.AddXY("Temel Bilgisayar", k2);
           chart1.Series["ogrenci"].Points.AddXY("Matematik", k3);
           chart1.Series["ogrenci"].Points.AddXY("Yazılım", k4);
           chart1.Series["ogrenci"].Points.AddXY("Psikoloji", k5);
           //chart 8title  
           





           
        }
    }
}
