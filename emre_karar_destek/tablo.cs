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
    public partial class tablo : Form
    {
        public tablo()
        {
            InitializeComponent();
            ogrenci();
        }
        int k1, k2, k3, k4, k5;
        MySqlConnection baglan = new MySqlConnection("Server=localhost;  database=emre_test; uid=root; password=;");
        private void tablo_Load(object sender, EventArgs e)
        {

            baglan.Open();
            using (var cmd = new MySqlCommand("SELECT SUM(k5) FROM ogr_bilgi", baglan))
            {
                k5 = Convert.ToInt32(cmd.ExecuteScalar());


            }
            baglan.Close();



            baglan.Open();
            using (var cmd = new MySqlCommand("SELECT SUM(k1) FROM ogr_bilgi", baglan))
            {
                k1 = Convert.ToInt32(cmd.ExecuteScalar());


            }
            baglan.Close();


            baglan.Open();
            using (var cmd = new MySqlCommand("SELECT SUM(k2) FROM ogr_bilgi", baglan))
            {
                k2 = Convert.ToInt32(cmd.ExecuteScalar());


            }
            baglan.Close();


            baglan.Open();
            using (var cmd = new MySqlCommand("SELECT SUM(k3) FROM ogr_bilgi", baglan))
            {
                k3 = Convert.ToInt32(cmd.ExecuteScalar());


            }
            baglan.Close();





            baglan.Open();
            using (var cmd = new MySqlCommand("SELECT SUM(k4) FROM ogr_bilgi", baglan))
            {
                k4 = Convert.ToInt32(cmd.ExecuteScalar());


            }
            baglan.Close();





            //AddXY value in chart1 in series named as Salary  
            chart1.Series["GENEL"].Points.AddXY("Genel Kultur", k1);
            chart1.Series["GENEL"].Points.AddXY("Temel Bilgisayar", k2);
            chart1.Series["GENEL"].Points.AddXY("Matematik", k3);
            chart1.Series["GENEL"].Points.AddXY("Yazılım", k4);
            chart1.Series["GENEL"].Points.AddXY("Psikoloji", k5);
            //chart 8title  
            chart1.Titles.Add("SORU GRAFİĞİ");
        }
        int id = 1;
        public void ogrenci()
        {
        a:
            baglan.Open();

            using (var cmd = new MySqlCommand("SELECT max(ogr_id) FROM OGR_BİLGİ", baglan))
            {
                int COUNT = Convert.ToInt32(cmd.ExecuteScalar());
                baglan.Close();
                if (id <= COUNT)
                {



           
                    baglan.Open();


                    using (var cmdd = new MySqlCommand("SELECT COUNT(*) FROM OGR_BİLGİ where ogr_id='" + id + "'", baglan))
                    {
                        int COUNnT = Convert.ToInt32(cmdd.ExecuteScalar());
                        baglan.Close();
                        if (COUNnT == 1)
                        {
                            baglan.Open();
                            MySqlCommand kmt = new MySqlCommand("select * from OGR_BİLGİ where ogr_id='" + id + "'", baglan);
                            MySqlDataReader oku = kmt.ExecuteReader();

                            if (oku.Read())
                            {
                                chart2.Series["Ogrenci"].Points.AddXY(oku["ad_soyad"], oku["puan"]);

                               
                            }
                            baglan.Close();

                            id++;
                            goto a;

                        }
                        else
                        {
                            id++;
                            goto a;
                        }

                    }


                }





                chart2.Titles.Add("BAŞARILI GRAFİĞİ");


            }








        }
    }
}
