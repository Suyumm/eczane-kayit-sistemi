using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eczane
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kayit kayit = new kayit();
            kayit.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sil sil = new sil();
            sil.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            guncelle guncelle = new guncelle();
            guncelle.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ara ara = new ara();
            ara.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
