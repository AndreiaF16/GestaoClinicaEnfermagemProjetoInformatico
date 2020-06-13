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
    public partial class VerAlgariacaoPaciente : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private List<AlgariacaoPaciente> algariacaoPaciente = new List<AlgariacaoPaciente>();

        public VerAlgariacaoPaciente(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        }

        private void VerAlgariacaoPaciente_Load(object sender, EventArgs e)
        {
            var bindingSource2 = new System.Windows.Forms.BindingSource { DataSource = algariacaoPaciente };
            dataGridViewAlgPaciente.DataSource = bindingSource2;
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
            algariacaoPaciente.Clear();
            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select data, silastic, folley, tresVias, dataProximaRealgariacao, observacoes from Algariacao ORDER BY data asc", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string data = ((reader["data"] == DBNull.Value) ? "" : DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy"));
                string dataPAlgariacao = ((reader["dataProximaRealgariacao"] == DBNull.Value) ? "" : DateTime.ParseExact(reader["dataProximaRealgariacao"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy"));

                AlgariacaoPaciente aP = new AlgariacaoPaciente
                {
                    data = data,
                    silastic = ((reader["silastic"] == DBNull.Value) ? null : (int?)reader["silastic"]),
                    folley = ((reader["folley"] == DBNull.Value) ? "" : (string)reader["folley"]),
                    tresVias = ((reader["tresVias"] == DBNull.Value) ? "" : (string)reader["tresVias"]),
                    dataProximaRealgariacao = dataPAlgariacao,
                    observacoes = ((reader["observacoes"] == DBNull.Value) ? "" : (string)reader["observacoes"]),
                };
                algariacaoPaciente.Add(aP);
            }
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = algariacaoPaciente };
            dataGridViewAlgPaciente.DataSource = bindingSource1;
            dataGridViewAlgPaciente.Columns[0].HeaderText = "Data de Registo";
            dataGridViewAlgPaciente.Columns[1].HeaderText = "Silastic";
            dataGridViewAlgPaciente.Columns[2].HeaderText = "Folley";
            dataGridViewAlgPaciente.Columns[3].HeaderText = "Três Vias";
            dataGridViewAlgPaciente.Columns[4].HeaderText = "Data da Próxima Realgariação";
            dataGridViewAlgPaciente.Columns[5].HeaderText = "Observações";

            conn.Close();
            dataGridViewAlgPaciente.Update();
            dataGridViewAlgPaciente.Refresh();
        }
    }
}
