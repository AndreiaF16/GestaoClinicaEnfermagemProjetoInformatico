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
    public partial class VerInalacoes : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private List<InalacoesPaciente> inalacoesPaciente = new List<InalacoesPaciente>();

        public VerInalacoes(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        private void VerInalacoes_Load(object sender, EventArgs e)
        {
            var bindingSource2 = new System.Windows.Forms.BindingSource { DataSource = inalacoesPaciente };
            dataGridViewInalacoes.DataSource = bindingSource2;
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
            inalacoesPaciente.Clear();
            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select data, O2, aerossol, inaladores, observacoes from Inalacoes ORDER BY data asc", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string data = ((reader["data"] == DBNull.Value) ? "" : DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy"));
                InalacoesPaciente inalacoes = new InalacoesPaciente
                {
                    data = data,
                    O2 = ((reader["O2"] == DBNull.Value) ? "" : (string)reader["O2"]),
                    aerossol = ((reader["aerossol"] == DBNull.Value) ? "" : (string)reader["aerossol"]),
                    inaladores = ((reader["inaladores"] == DBNull.Value) ? "" : (string)reader["inaladores"]),
                    observacoes = ((reader["observacoes"] == DBNull.Value) ? "" : (string)reader["observacoes"]),

                };
                inalacoesPaciente.Add(inalacoes);
            }
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = inalacoesPaciente };
            dataGridViewInalacoes.DataSource = bindingSource1;
            dataGridViewInalacoes.Columns[0].HeaderText = "Data de Registo";
            dataGridViewInalacoes.Columns[1].HeaderText = "Aerossol";
            dataGridViewInalacoes.Columns[2].HeaderText = "Inaladores";
            dataGridViewInalacoes.Columns[3].HeaderText = "Observações";

            conn.Close();
            dataGridViewInalacoes.Update();
            dataGridViewInalacoes.Refresh();
        }
    }
}
