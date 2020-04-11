using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestaoClinicaEnfermagemProjetoInformatico
{
    public partial class VerDoencasRegistadas : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        List<Doenca> listaDoencas= new List<Doenca>();

        public VerDoencasRegistadas()
        {
            InitializeComponent();
            conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            var resposta = MessageBox.Show("Tem a certeza que deseja sair da aplicação?", "Fechar Aplicação!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resposta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }

        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Hora " + DateTime.Now.ToLongTimeString();
            lblDia.Text = DateTime.Now.ToString("dddd, dd " + "'de '" + "MMMM" + "' de '" + "yyyy");
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VerDoencasRegistadas_Load(object sender, EventArgs e)
        {
            Doenca doenca = new Doenca();

            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select * from Doenca ", conn);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                doenca = new Doenca
                {
                    nome = (string)reader["nome"],
                    sintomas = (string)reader["sintomas"],
                };
                listaDoencas.Add(doenca);
            }
            conn.Close();
            //dataGridViewHistoricoClinico.DataSource = listaHistorico;

            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaDoencas };
            dataGridViewDoencas.DataSource = bindingSource1;
       
    }
    }
}
