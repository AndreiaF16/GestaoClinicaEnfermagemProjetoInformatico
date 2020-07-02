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
    public partial class VerImplanteContracetivoPaciente : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private List<ImplanteContracetivoPaciente> implanteContracetivoPaciente = new List<ImplanteContracetivoPaciente>();
        public VerImplanteContracetivoPaciente(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        private void VerImplanteContracetivoPaciente_Load(object sender, EventArgs e)
        {
            var bindingSource2 = new System.Windows.Forms.BindingSource { DataSource = implanteContracetivoPaciente };
            dataGridViewImplanteContracetivoDermico.DataSource = bindingSource2;
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
            implanteContracetivoPaciente.Clear();
            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select data, dataColocacao, dataRetirada, observacoes from ImplanteContracetivo WHERE IdPaciente = @IdPaciente ORDER BY data asc, dataColocacao asc,dataRetirada asc ", conn);
            cmd.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string data = ((reader["data"] == DBNull.Value) ? "" : DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy"));
                string dataColocacao = ((reader["dataColocacao"] == DBNull.Value) ? "" : DateTime.ParseExact(reader["dataColocacao"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy"));
                string dataRetirada = ((reader["dataRetirada"] == DBNull.Value) ? "" : DateTime.ParseExact(reader["dataRetirada"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy"));

                ImplanteContracetivoPaciente implanteContracetivo = new ImplanteContracetivoPaciente
                {
                    data = data,
                    dataColocacao = dataColocacao,
                    dataRetirada = dataRetirada,
                    observacoes = ((reader["observacoes"] == DBNull.Value) ? "" : (string)reader["observacoes"]),
                };
                implanteContracetivoPaciente.Add(implanteContracetivo);
            }
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = implanteContracetivoPaciente };
            dataGridViewImplanteContracetivoDermico.DataSource = bindingSource1;
            dataGridViewImplanteContracetivoDermico.Columns[0].HeaderText = "Data de Registo";
            dataGridViewImplanteContracetivoDermico.Columns[1].HeaderText = "Data de Colocação";
            dataGridViewImplanteContracetivoDermico.Columns[2].HeaderText = "Data de Remoção";
            dataGridViewImplanteContracetivoDermico.Columns[3].HeaderText = "Observações";

            conn.Close();
            dataGridViewImplanteContracetivoDermico.Update();
            dataGridViewImplanteContracetivoDermico.Refresh();
        }
    }
}
