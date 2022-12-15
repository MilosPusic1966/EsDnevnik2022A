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
    public partial class Odeljenje : Form
    {
        int broj_sloga = 0;
        DataTable odeljenje;
        public Odeljenje()
        {
            InitializeComponent();
        }

        private void Odeljenje_Load(object sender, EventArgs e)
        {
            SqlConnection veza = konekcija.connect();
            // ----------- popunjavam prvi combo box------------
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM smer", veza);
            DataTable smer = new DataTable();
            da.Fill(smer);
            comboBox1.DataSource = smer;
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "Naziv";

            // -------------- popunjavam baznu tabelu: odeljenje -------------
            da = new SqlDataAdapter("SELECT * FROM odeljenje", veza);
            odeljenje = new DataTable();
            da.Fill(odeljenje);

            // prikazujem odeljenje - popunjavam text boxove i combo boxove
            // ovo treba parametrizovati: odeljenje.Rows[broj_sloga]
            textBox1.Text = odeljenje.Rows[broj_sloga][0].ToString();
            textBox2.Text = odeljenje.Rows[broj_sloga][1].ToString();
            textBox3.Text = odeljenje.Rows[broj_sloga][2].ToString();
            comboBox1.SelectedValue = (int) odeljenje.Rows[broj_sloga][3];

            da = new SqlDataAdapter("SELECT id, ime+' '+prezime AS imeprez FROM osoba WHERE uloga=2", veza);
            DataTable osoba = new DataTable();
            da.Fill(osoba);
            comboBox2.DataSource = osoba;
            comboBox2.DisplayMember = "imeprez";
            comboBox2.ValueMember = "id";
            comboBox2.SelectedValue = (int)odeljenje.Rows[broj_sloga][4];

            da = new SqlDataAdapter("SELECT * FROM skolska_godina", veza);
            DataTable godina = new DataTable();
            da.Fill(godina);
            comboBox3.DataSource = godina;
            comboBox3.DisplayMember = "naziv";
            comboBox3.ValueMember = "id";
            comboBox3.SelectedValue = (int)odeljenje.Rows[broj_sloga][5];
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ovo je samo ilustracija - obrisati je, kasnije
            // textBox1.Text = comboBox1.SelectedValue.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // next
            broj_sloga++;
            prikazi(broj_sloga);
        }
        private void prikazi(int n)
        {
            textBox1.Text = odeljenje.Rows[n][0].ToString();
            textBox2.Text = odeljenje.Rows[n][1].ToString();
            textBox3.Text = odeljenje.Rows[n][2].ToString();
            comboBox1.SelectedValue = (int)odeljenje.Rows[n][3];
            comboBox2.SelectedValue = (int)odeljenje.Rows[n][4];
            comboBox3.SelectedValue = (int)odeljenje.Rows[n][5];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            broj_sloga--;
            prikazi(broj_sloga);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            broj_sloga = 0;
            prikazi(broj_sloga);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            broj_sloga = odeljenje.Rows.Count - 1;
            prikazi(broj_sloga);
        }
    }
}
