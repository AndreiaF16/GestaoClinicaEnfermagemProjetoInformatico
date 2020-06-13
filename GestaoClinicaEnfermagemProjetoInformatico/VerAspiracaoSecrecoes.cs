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
    public partial class VerAspiracaoSecrecoes : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private List<AspiracaoSecrecoes> aspiracaoSecrecoes = new List<AspiracaoSecrecoes>();

        public VerAspiracaoSecrecoes(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        }

        private void VerAspiracaoSecrecoes_Load(object sender, EventArgs e)
        {
            var bindingSource2 = new System.Windows.Forms.BindingSource { DataSource = aspiracaoSecrecoes };
            dataGridViewSecrecoes.DataSource = bindingSource2;
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
            aspiracaoSecrecoes.Clear();
            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select data, aspiracao, observacoes from AspiracaoSecrecao ORDER BY data asc", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string data = ((reader["data"] == DBNull.Value) ? "" : DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy"));
                AspiracaoSecrecoes aspiracaoSec = new AspiracaoSecrecoes
                {
                    data = data,
                    aspiracao = ((reader["aspiracao"] == DBNull.Value) ? "" : (string)reader["aspiracao"]),
                    observacoes = ((reader["observacoes"] == DBNull.Value) ? "" : (string)reader["observacoes"]),

                };
                aspiracaoSecrecoes.Add(aspiracaoSec);
            }
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = aspiracaoSecrecoes };
            dataGridViewSecrecoes.DataSource = bindingSource1;
            dataGridViewSecrecoes.Columns[0].HeaderText = "Data de Registo";
            dataGridViewSecrecoes.Columns[1].HeaderText = "Aspiração Secreções";
            dataGridViewSecrecoes.Columns[2].HeaderText = "Observações";

            conn.Close();
            dataGridViewSecrecoes.Update();
            dataGridViewSecrecoes.Refresh();
        }
    }
}
