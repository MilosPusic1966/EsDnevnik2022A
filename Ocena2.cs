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
        int broj_reda = 0;
        public Ocena2()
        {
            InitializeComponent();
        }

        private void Ocena2_Load(object sender, EventArgs e)
        {
            ucenik_populate();
            predmet_populate();
            ocena_populate();
            popuni_kontrole();
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
        public void popuni_kontrole()
        {
            /*
            comboBox1.SelectedValue = dataGridView1.Rows[broj_reda].Cells[0].Value.ToString();
            comboBox2.SelectedValue = dataGridView1.Rows[broj_reda].Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.Rows[broj_reda].Cells[2].Value.ToString();
            */
            comboBox1.SelectedValue = dt_ocena.Rows[broj_reda]["ucenik_id"].ToString();
            comboBox2.SelectedValue = dt_ocena.Rows[broj_reda]["predmet_id"].ToString();
            textBox1.Text = dt_ocena.Rows[broj_reda]["ocena"].ToString();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            string naredba = "INSERT INTO ocena2 (ucenik_id, predmet_id, ocena) VALUES(";
            naredba += comboBox1.SelectedValue.ToString()+", ";
            naredba += comboBox2.SelectedValue.ToString() + ", ";
            naredba += textBox1.Text+")";
            SqlConnection veza = konekcija.connect();
            SqlCommand komanda = new SqlCommand(naredba, veza);
            veza.Open();
            komanda.ExecuteNonQuery();
            veza.Close();
            ocena_populate();
            broj_reda = 0;
            popuni_kontrole();
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridView1.Focused && dataGridView1.CurrentRow != null)
            broj_reda = dataGridView1.CurrentRow.Index;
            popuni_kontrole();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string naredba = "UPDATE ocena2 SET ";
            naredba += "ucenik_id=" + comboBox1.SelectedValue.ToString();
            naredba += ", predmet_id=" + comboBox2.SelectedValue.ToString();
            naredba += ", ocena=" + textBox1.Text+" WHERE id="+dt_ocena.Rows[broj_reda]["id"].ToString();
            SqlConnection veza = konekcija.connect();
            SqlCommand komanda = new SqlCommand(naredba, veza);
            veza.Open();
            komanda.ExecuteNonQuery();
            veza.Close();
            ocena_populate();
            broj_reda = 0;
            popuni_kontrole();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string naredba = "DELETE FROM ocena2 WHERE id=" + dt_ocena.Rows[broj_reda]["id"].ToString();
            SqlConnection veza = konekcija.connect();
            SqlCommand komanda = new SqlCommand(naredba, veza);
            veza.Open();
            komanda.ExecuteNonQuery();
            veza.Close();
            ocena_populate();
            broj_reda = 0;
            popuni_kontrole();
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
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["predmet_id"].Visible = false;
            dataGridView1.AllowUserToDeleteRows = false;
        }
    }
}
