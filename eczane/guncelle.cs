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
    public partial class guncelle : Form
    {
        public guncelle()
        {
            InitializeComponent();
        }
        OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=" + Application.StartupPath + "\\eczaci.accdb");

        private void kayit()
        {
            try
            {
                bag.Open();
                OleDbDataAdapter kayit = new OleDbDataAdapter("select * from ilac", bag);
                DataSet dt = new DataSet();
                kayit.Fill(dt);
                dataGridView1.DataSource = dt.Tables[0];
                bag.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
                bag.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 anasayfa = new Form1();
            anasayfa.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bag.Open();
            OleDbCommand guncelle = new OleDbCommand("update ilac set fiyat ='" + textBox2.Text + "' where ilacKodu='" + textBox1.Text + "'", bag);
            guncelle.ExecuteNonQuery();
            bag.Close();

            MessageBox.Show("güncellendi");
            kayit();
        }

        private void guncelle_Load(object sender, EventArgs e)
        {
            kayit();
        }
    }
}
