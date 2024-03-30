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
    public partial class ara : Form
    {
        public ara()
        {
            InitializeComponent();
        }

        OleDbConnection Fiydan = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0; Data Source=" + Application.StartupPath + "\\eczaci.accdb");

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

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 anasayfa = new Form1();
            anasayfa.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Fiydan.Open();
                OleDbDataAdapter ara = new OleDbDataAdapter("select * from ilac where siraNo='" + textBox1.Text + "'", Fiydan);
                DataSet ds = new DataSet();
                ara.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                Fiydan.Close();
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
                Fiydan.Close();
            }
        }

        private void ara_Load(object sender, EventArgs e)
        {
            kayitlistele();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
