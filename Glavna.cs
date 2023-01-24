using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EsDnevnik2022A
{
    public partial class Glavna : Form
    {
        public Glavna()
        {
            InitializeComponent();
            // ovde ide dodatak

        }

        private void osobaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Osoba nova = new Osoba();
            nova.Show();
        }

        private void odeljenjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Odeljenje nova = new Odeljenje();
            nova.Show();
        }

        private void probaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aaaaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sifarnik nova = new sifarnik("smer");
            nova.Show();
        }

        private void skolskaGodinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sifarnik nova = new sifarnik("skolska_godina");
            nova.Show();
        }

        private void Glavna_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void oceneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ocena2 nova = new Ocena2();
            nova.Show();
        }
    }
}
