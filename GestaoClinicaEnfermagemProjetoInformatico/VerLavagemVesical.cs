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
    public partial class VerLavagemVesical : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private List<LavagemVesicalPaciente> lavagemVesicalPaciente = new List<LavagemVesicalPaciente>();
        public VerLavagemVesical(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        }

        private void VerLavagemVesical_Load(object sender, EventArgs e)
        {
            var bindingSource2 = new System.Windows.Forms.BindingSource { DataSource = lavagemVesicalPaciente };
            dataGridViewLavagemVesical.DataSource = bindingSource2;
            UpdateDataGridView();
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

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void UpdateDataGridView()
        {
            lavagemVesicalPaciente.Clear();
            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select data, lavagemVesical, observacoes from LavagemVesical ORDER BY data asc", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string data = ((reader["data"] == DBNull.Value) ? "" : DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy"));

                LavagemVesicalPaciente lavagemVesical = new LavagemVesicalPaciente
                {
                    data = data,
                    lavagemVesical = ((reader["lavagemVesical"] == DBNull.Value) ? "" : (string)reader["lavagemVesical"]),
                    observacoes = ((reader["observacoes"] == DBNull.Value) ? "" : (string)reader["observacoes"]),
                };
                lavagemVesicalPaciente.Add(lavagemVesical);
            }
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = lavagemVesicalPaciente };
            dataGridViewLavagemVesical.DataSource = bindingSource1;
            dataGridViewLavagemVesical.Columns[0].HeaderText = "Data de Registo";
            dataGridViewLavagemVesical.Columns[1].HeaderText = "Lavagem Vesical";
            dataGridViewLavagemVesical.Columns[2].HeaderText = "Observações";

            conn.Close();
            dataGridViewLavagemVesical.Update();
            dataGridViewLavagemVesical.Refresh();
        }
    }
}
