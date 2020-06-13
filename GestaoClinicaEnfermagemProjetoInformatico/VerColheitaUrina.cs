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
    public partial class VerColheitaUrina : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private List<ColheitaUrina> colheitaUrina = new List<ColheitaUrina>();

        public VerColheitaUrina(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        }

        private void VerColheitaSangue_Load(object sender, EventArgs e)
        {
            var bindingSource2 = new System.Windows.Forms.BindingSource { DataSource = colheitaUrina };
            dataGridViewColheitaUrina.DataSource = bindingSource2;
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
            colheitaUrina.Clear();
            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select data, exameSumario, urocultura, vinteQuantroHoras, observacoes from ColheitaUrina ORDER BY data asc", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string data = ((reader["data"] == DBNull.Value) ? "" : DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy"));
                ColheitaUrina colherUrina = new ColheitaUrina
                {
                    data = data,
                    exameSumario = ((reader["exameSumario"] == DBNull.Value) ? "" : (string)reader["exameSumario"]),
                    urocultura = ((reader["urocultura"] == DBNull.Value) ? "" : (string)reader["urocultura"]),
                    vinteQuantroHoras = ((reader["vinteQuantroHoras"] == DBNull.Value) ? "" : (string)reader["vinteQuantroHoras"]),
                    observacoes = ((reader["observacoes"] == DBNull.Value) ? "" : (string)reader["observacoes"]),

                };
                colheitaUrina.Add(colherUrina);
            }
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = colheitaUrina };
            dataGridViewColheitaUrina.DataSource = bindingSource1;
            dataGridViewColheitaUrina.Columns[0].HeaderText = "Data de Registo";
            dataGridViewColheitaUrina.Columns[1].HeaderText = "Exame Sumário";
            dataGridViewColheitaUrina.Columns[2].HeaderText = "Urocultura";
            dataGridViewColheitaUrina.Columns[3].HeaderText = "24 Horas";
            dataGridViewColheitaUrina.Columns[4].HeaderText = "Observações";

            conn.Close();
            dataGridViewColheitaUrina.Update();
            dataGridViewColheitaUrina.Refresh();
        }
    }
}
