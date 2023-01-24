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
    public partial class Ocena2 : Form
    {
        DataTable dt_ucenik, dt_predmet, dt_ocena;
        public Ocena2()
        {
            InitializeComponent();
        }

        private void Ocena2_Load(object sender, EventArgs e)
        {
            ucenik_populate();
            predmet_populate();
            ocena_populate();
        }
        private void ucenik_populate()
        {
            SqlConnection veza = konekcija.connect();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT id, ime+' '+prezime as naziv FROM osoba WHERE uloga=1", veza);
            dt_ucenik = new DataTable();
            adapter.Fill(dt_ucenik);
            comboBox1.DataSource = dt_ucenik;
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "naziv";

        }
        private void predmet_populate()
        {
            SqlConnection veza = konekcija.connect();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM predmet", veza);
            dt_predmet = new DataTable();
            adapter.Fill(dt_predmet);
            comboBox2.DataSource = dt_predmet;
            comboBox2.ValueMember = "id";
            comboBox2.DisplayMember = "naziv";
        }
        private void ocena_populate()
        {
            SqlConnection veza = konekcija.connect();
            string naredba = "select ocena2.id, ucenik_id, predmet_id, ime + ' ' + prezime as ucenik, naziv, ocena from ocena2 join osoba on Osoba.id = ucenik_id join Predmet on Predmet.id = predmet_id";
            SqlDataAdapter adapter = new SqlDataAdapter(naredba, veza);
            dt_ocena = new DataTable();
            adapter.Fill(dt_ocena);
            dataGridView1.DataSource = dt_ocena;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Columns["ucenik_id"].Visible = false;
            dataGridView1.AllowUserToDeleteRows = false;
        }
    }
}
