using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace eczane
{
    public partial class kayit : Form
    {
        public kayit()
        {
            InitializeComponent();
        }
        OleDbConnection Fiydan = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=" + Application.StartupPath + "\\eczaci.accdb");

        private void kayitlistele()
        {
            try
            {
                Fiydan.Open();
                OleDbDataAdapter listele = new OleDbDataAdapter("select * from ilac ", Fiydan);
                DataSet ds = new DataSet();
                listele.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                Fiydan.Close();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
                Fiydan.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 anasayfa = new Form1();
            anasayfa.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Fiydan.Open();
                OleDbCommand ekle = new OleDbCommand("insert into ilac(siraNo,ilacKodu,ilacAd,sonKullanmaTarihi,barkodNo,fiyat,adet,uretimFirmasi,kullanimSekli,resim) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','"+ textBox5.Text + "','" + textBox6.Text + "','"+ textBox7.Text + "','"+ textBox8.Text + "','"+ textBox9.Text + "','"+ textBox10.Text + "')", Fiydan);
                ekle.ExecuteNonQuery();
                MessageBox.Show("ilaç eklendi");
                Fiydan.Close();
                kayitlistele();

            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
                Fiydan.Close();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            textBox10.Text = openFileDialog1.FileName;
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
        }

        private void kayit_Load(object sender, EventArgs e)
        {
            kayitlistele();
        }
    }
}
