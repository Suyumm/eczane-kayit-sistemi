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
    public partial class sil : Form
    {
        public sil()
        {
            InitializeComponent();
        }
        OleDbConnection Fiydan = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=" + Application.StartupPath + "\\eczaci.accdb");


        private void kayit()
        {
            try
            {
                Fiydan.Open();
                OleDbDataAdapter kayit = new OleDbDataAdapter("select * from ilac", Fiydan);
                DataSet dt = new DataSet();
                kayit.Fill(dt);
                dataGridView1.DataSource = dt.Tables[0];
                Fiydan.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
                Fiydan.Close();
            }
        }

        private void sil_Load(object sender, EventArgs e)
        {
            kayit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 anasayfa = new Form1();
            anasayfa.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Fiydan.Open();
            OleDbCommand sil = new OleDbCommand("delete*from ilac where ilacKodu='" + textBox1.Text +"'", Fiydan);
            sil.ExecuteNonQuery();
            Fiydan.Close();

            MessageBox.Show("sil");
            kayit();

        }

        

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
