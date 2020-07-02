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
    public partial class VerDesbridamento : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private List<DesbridamentoPaciente> desbridamentoPaciente = new List<DesbridamentoPaciente>();

        public VerDesbridamento(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            var resposta = MessageBox.Show("Tem a certeza que deseja sair da aplicação?", "Fechar Aplicação!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resposta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VerDesbridamento_Load(object sender, EventArgs e)
        {
            var bindingSource2 = new System.Windows.Forms.BindingSource { DataSource = desbridamentoPaciente };
            dataGridViewDesbridamento.DataSource = bindingSource2;
            UpdateDataGridView();
        }

        public void UpdateDataGridView()
        {
            try
            {
                desbridamentoPaciente.Clear();
                conn.Open();
                com.Connection = conn;

                SqlCommand cmd = new SqlCommand("select data, antolitico, enzimatico, cirurgico, observacoes from Desbridamento ORDER BY data asc", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string data = ((reader["data"] == DBNull.Value) ? "" : DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy"));
                    DesbridamentoPaciente md = new DesbridamentoPaciente
                    {
                        data = data,
                        antolitico = ((reader["antolitico"] == DBNull.Value) ? "" : (string)reader["antolitico"]),
                        enzimatico = ((reader["enzimatico"] == DBNull.Value) ? "" : (string)reader["enzimatico"]),
                        cirurgico = ((reader["cirurgico"] == DBNull.Value) ? "" : (string)reader["cirurgico"]),
                        observacoes = ((reader["observacoes"] == DBNull.Value) ? "" : (string)reader["observacoes"]),

                    };
                    desbridamentoPaciente.Add(md);
                }
                var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = desbridamentoPaciente };
                dataGridViewDesbridamento.DataSource = bindingSource1;
                dataGridViewDesbridamento.Columns[0].HeaderText = "Data de Registo";
                dataGridViewDesbridamento.Columns[1].HeaderText = "Antolitico";
                dataGridViewDesbridamento.Columns[2].HeaderText = "Enzimático";
                dataGridViewDesbridamento.Columns[3].HeaderText = "Cirúrgico";
                dataGridViewDesbridamento.Columns[4].HeaderText = "Observações";

                conn.Close();
                dataGridViewDesbridamento.Update();
                dataGridViewDesbridamento.Refresh();
            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível visualizar os dados!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
