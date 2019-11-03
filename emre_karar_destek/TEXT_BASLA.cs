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
    public partial class TEXT_BASLA : Form
    {
        public TEXT_BASLA()
        {
           yukle();
            InitializeComponent();
        }
        string dogru="0";
        string cevap="0";
        int kid;
       int k1=0, k2=0, k3=0, k4=0, k5 = 0;
      

        MySqlConnection baglan = new MySqlConnection("Server=localhost;  database=emre_test; uid=root; password=;");
        DataTable tablo = new DataTable();
        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            MySqlCommand kmt = new MySqlCommand("select * from ogr_bilgi where tc='" + textBox1.Text + "'", baglan);
            MySqlDataReader rd = kmt.ExecuteReader();
            if (rd.Read())
            {
                groupBox1.Visible = true;
                label4.Visible = true;
                label5.Visible = true;

                label2.Text = rd["ad_soyad"].ToString();
                label3.Text = rd["tc"].ToString();
                groupBox2.Visible = false;
            }
            else
            {
                MessageBox.Show("Lutfen Testi Başlatmak İçin Dogru TC Yazınız!!..");
            }
            baglan.Close();


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void TEXT_BASLA_Load(object sender, EventArgs e)
        {

        }

        int a = -1;
        sonuc ac = new sonuc();
        public void puanHesaplama()
        {
            if (dogru == cevap)
            {
                if (kid == 1)
                {
                    baglan.Open();
                    using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM sorular where kat_id=1", baglan))
                    {
                       int cccount = Convert.ToInt32(cmd.ExecuteScalar());
                       k1 = k1 + (20 / cccount);


                    }

                    baglan.Close();
                }






                if (kid == 2)
                {
                    baglan.Open();
                    using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM sorular where kat_id=2", baglan))
                    {
                        int countt = Convert.ToInt32(cmd.ExecuteScalar());
                        k2 = k2 + (20 / countt);



                    }

                    baglan.Close();
                }









                if (kid == 3)
                {
                    baglan.Open();
                    using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM sorular where kat_id=3", baglan))
                    {
                        int ccount = Convert.ToInt32(cmd.ExecuteScalar());
                        k3 = k3 + (20 / ccount);



                    }

                    baglan.Close();
                }








                if (kid == 4)
                {
                    baglan.Open();
                    using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM sorular where kat_id=4", baglan))
                    {
                        int couunt = Convert.ToInt32(cmd.ExecuteScalar());
                        k4 = k4 + (20 / couunt);



                    }

                    baglan.Close();
                }








                if (kid ==5)
                {
                    baglan.Open();
                    using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM sorular where kat_id=5", baglan))
                    {
                        int couent = Convert.ToInt32(cmd.ExecuteScalar());
                        k5 = k5 + (20 / couent);



                    }

                    baglan.Close();
                }
            }
        
        }
        private void button6_Click(object sender, EventArgs e)
        {

            puanHesaplama();

          /*  if (dogru == cevap)
            {
                if (kid == 1)
                {
                    k1 = k1 + 20;
                   

                }
                if (kid == 2)
                {
                    k2 = k2 + 20;
                  
                }
                if (kid == 3)
                {
                    k3 = k3 + 20;
                
                }
                if (kid == 4)
                {
                    k4 = k4 + 20;
                   
                }
                if (kid == 5)
                {
                    k5 = k5 + 20;
                    
                }

            }*/
        
















            button5.BackColor = Color.DarkKhaki;
            button3.BackColor = Color.DarkKhaki;
            button2.BackColor = Color.DarkKhaki;
            button4.BackColor = Color.DarkKhaki;

            button5.Enabled = true;
            button4.Enabled = true;
            button3.Enabled = true;
            button2.Enabled = true;
          
            a++;
            button6.Text = "İLERİ";
           
            if (a != count)
            {
                baglan.Open();
                MySqlCommand komut = new MySqlCommand("select * from sorular where soru_id='" + dizi[a] + "'", baglan);
                MySqlDataReader rd = komut.ExecuteReader();

                if (rd.Read())
                {

                    textBox2.Text = rd["soru"].ToString();
                    button5.Text = rd["a"].ToString();
                    button3.Text = rd["b"].ToString();
                    button2.Text = rd["c"].ToString();
                    dogru = rd["dogru"].ToString();
                    button4.Text = rd["d"].ToString();
                    kid =(int) rd["kat_id"];


                }
                baglan.Close();

            }
            else
            {
                a = -1;
                
                ac.Show();
                int puan = k1 + k2 + k3 + k4 + k5;
                ac.label16.Text = puan.ToString();
                ac.label5.Text = k5.ToString();
                ac.label1.Text = k1.ToString();
                ac.label2.Text = k2.ToString();
                ac.label4.Text = k4.ToString();
                ac.label3.Text = k3.ToString();

                ac.label14.Text = label2.Text;
                ac.label12.Text = label3.Text;
                this.Hide();
            }
          


           















/*
            for (int j = 0; j < count; j++)
            {
                listBox1.Items.Add(dizi[j]);
            }*/




           
            }
        int[] dizi;
        int count;
    
        public void yukle()
        {


             baglan.Open();

             using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM sorular", baglan))
             {
                  count = Convert.ToInt32(cmd.ExecuteScalar());
                  dizi = new int[count];
                 int deger=0;
                 baglan.Close();
                 for (int i = 1; i < 500; i++)
                 {
                     baglan.Open();
                     MySqlCommand komut = new MySqlCommand("select * from sorular where soru_id='" + i + "'", baglan);
                     MySqlDataReader rd = komut.ExecuteReader();

                     if (rd.Read())
                     {

                         dizi[deger] =(int) rd["soru_id"];
                         deger++;



                     }
                     baglan.Close();
                   
                 }
                
                
             }
          


        }

        private void button5_Click(object sender, EventArgs e)
        {
            cevap = button5.Text;
            button5.BackColor = Color.Yellow;


        
            button3.BackColor = Color.DarkKhaki;
            button2.BackColor = Color.DarkKhaki;
            button4.BackColor = Color.DarkKhaki;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            cevap = button3.Text;
            button3.BackColor = Color.Yellow;
            button5.BackColor = Color.DarkKhaki;
          
            button2.BackColor = Color.DarkKhaki;
            button4.BackColor = Color.DarkKhaki;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cevap = button2.Text;
            button2.BackColor = Color.Yellow;
            button5.BackColor = Color.DarkKhaki;
            button3.BackColor = Color.DarkKhaki;
    
            button4.BackColor = Color.DarkKhaki;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            cevap = button4.Text;
            button4.BackColor = Color.Yellow;
            button5.BackColor = Color.DarkKhaki;
            button3.BackColor = Color.DarkKhaki;
            button2.BackColor = Color.DarkKhaki;
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 ac = new Form1();
            ac.Show();
            this.Hide();
        }
    }
}
