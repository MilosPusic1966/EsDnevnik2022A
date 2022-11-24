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
    public partial class Osoba : Form
    {
        int broj_sloga = 0;
        DataTable tabela;
        public Osoba()
        {
            InitializeComponent();
        }
        private void TxtPopulate()
        {
            if (tabela.Rows.Count == 0)
            {
                tbId.Text = "";
                tbIme.Text = "";
                tbPrezime.Text = "";
                tbAdresa.Text = "";
            }
            else
            {
                tbId.Text = tabela.Rows[broj_sloga][0].ToString();
                tbIme.Text = tabela.Rows[broj_sloga][1].ToString();
                tbPrezime.Text = tabela.Rows[broj_sloga][2].ToString();
                tbAdresa.Text = tabela.Rows[broj_sloga][3].ToString();
                if (broj_sloga == tabela.Rows.Count - 1)
                {
                    btNext.Enabled = false;
                    btLast.Enabled = false;
                }
                else
                {
                    btNext.Enabled = true;
                    btLast.Enabled = true;
                }
                if (broj_sloga == 0)
                {
                    btPrev.Enabled = false;
                    btFirst.Enabled = false;
                }
                else
                {
                    btPrev.Enabled = true;
                    btFirst.Enabled = true;
                }

            }
        }
        private void Osoba_Load(object sender, EventArgs e)
        {
            tabela = new DataTable();
            // ovo izbacujemo uskoro...
            SqlConnection veza = new SqlConnection("Data Source=INF_4_PROFESOR\\SQLPBG;Initial Catalog=ednevnik2022;Integrated Security=true");
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM osoba", veza);
            da.Fill(tabela);
            TxtPopulate();
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            broj_sloga++;
            TxtPopulate();
        }

        private void btFirst_Click(object sender, EventArgs e)
        {
            broj_sloga = 0;
            TxtPopulate();
        }

        private void btPrev_Click(object sender, EventArgs e)
        {
            broj_sloga--;
            TxtPopulate();
        }

        private void btLast_Click(object sender, EventArgs e)
        {
            broj_sloga = tabela.Rows.Count - 1;
            TxtPopulate();
        }

        private void btUpd_Click(object sender, EventArgs e)
        {
            string naredba = "UPDATE osoba SET ";
            naredba = naredba + "ime = '" + tbIme.Text + "', ";
            naredba = naredba + "prezime='" + tbPrezime.Text + "', ";
            naredba = naredba + "adresa='" + tbAdresa.Text + "' ";
            naredba = naredba + "WHERE id=" + tbId.Text;
            // textBox1.Text = naredba;
            SqlConnection veza = new SqlConnection("Data Source=INF_4_PROFESOR\\SQLPBG;Initial Catalog=ednevnik2022;Integrated Security=true");
            SqlCommand komanda = new SqlCommand(naredba, veza);
            veza.Open();
            komanda.ExecuteNonQuery();
            veza.Close();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM osoba", veza);
            da.Fill(tabela);
        }
    }
}
