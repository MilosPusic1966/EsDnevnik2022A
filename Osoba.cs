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

        private void Osoba_Load(object sender, EventArgs e)
        {
            tabela = new DataTable();
            // ovo izbacujemo uskoro...
            SqlConnection veza = new SqlConnection("Data Source=INF_4_PROFESOR\\SQLPBG;Initial Catalog=ednevnik2022;Integrated Security=true");
        }
    }
}
