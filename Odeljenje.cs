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
            DataTable odeljenje = new DataTable();
            da.Fill(odeljenje);

            // prikazujem odeljenje - popunjavam text boxove i combo boxove
            // ovo treba parametrizovati: odeljenje.Rows[broj_sloga]
            textBox1.Text = odeljenje.Rows[0][0].ToString();
            textBox2.Text = odeljenje.Rows[0][1].ToString();
            comboBox1.SelectedValue = (int) odeljenje.Rows[0][3];
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ovo je samo ilustracija - obrisati je, kasnije
            textBox1.Text = comboBox1.SelectedValue.ToString();
        }
    }
}
