using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EsDnevnik2022A
{
    public partial class sifarnik : Form
    {
        DataTable dtPodaci;
        SqlDataAdapter adapter;
        string odakle;
        
        public sifarnik(string naziv_tabele)
        {
            odakle = naziv_tabele;
            InitializeComponent();
        }
        private void sifarnik_Load(object sender, EventArgs e)
        {
            adapter = new SqlDataAdapter("SELECT * FROM "+odakle, konekcija.connect());
            dtPodaci = new DataTable();
            adapter.Fill(dtPodaci);
            dataGridView1.DataSource = dtPodaci;
            dataGridView1.Columns["Id"].ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable nova = new DataTable();
            nova = dtPodaci.GetChanges();
            dataGridView2.DataSource = nova;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable menjano = dtPodaci.GetChanges();
            adapter.UpdateCommand = new SqlCommandBuilder(adapter).GetUpdateCommand();
            if (menjano != null)
            {
                 
        }
    }
}
