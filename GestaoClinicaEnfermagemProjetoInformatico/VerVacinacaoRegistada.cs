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
    public partial class VerVacinacaoRegistada : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private ErrorProvider errorProvider = new ErrorProvider();
        private List<Vacinacao> vacinacao = new List<Vacinacao>();
        public VerVacinacaoRegistada(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        }

        private void VerVacinacaoRegistada_Load(object sender, EventArgs e)
        {
            var bindingSource2 = new System.Windows.Forms.BindingSource { DataSource = vacinacao };
            dataGridViewVacinacao.DataSource = bindingSource2;
            UpdateDataGridView();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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

        public void UpdateDataGridView()
        {
            vacinacao.Clear();
            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select data, nomeVacina, marcaComercial, numeroInoculacao, lote, local, escalaDor, observacoes from Vacinacao ORDER BY data, nomeVacina asc", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string data = DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy");

                Vacinacao queima = new Vacinacao
                {

                    dataVacinacao = data,
                    nomeVacina = ((reader["nomeVacina"] == DBNull.Value) ? "" : (string)reader["nomeVacina"]),
                    marcaComercial = ((reader["marcaComercial"] == DBNull.Value) ? "" : (string)reader["marcaComercial"]),
                    numeroInoculacao = ((reader["numeroInoculacao"] == DBNull.Value) ? "" : (string)reader["numeroInoculacao"]),
                    lote = ((reader["lote"] == DBNull.Value) ? "" : (string)reader["lote"]),
                    local = ((reader["local"] == DBNull.Value) ? "" : (string)reader["local"]),
                    escalaDor = ((reader["escalaDor"] == DBNull.Value) ? "" : (string)reader["escalaDor"]),
                    observacoes = ((reader["observacoes"] == DBNull.Value) ? "" : (string)reader["observacoes"]),

                };
                vacinacao.Add(queima);
            }
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = vacinacao };
            dataGridViewVacinacao.DataSource = bindingSource1;
            dataGridViewVacinacao.Columns[0].HeaderText = "Data da Vacinação";
            dataGridViewVacinacao.Columns[1].HeaderText = "Nome da Vacina";
            dataGridViewVacinacao.Columns[2].HeaderText = "Marca Comercial";
            dataGridViewVacinacao.Columns[3].HeaderText = "Número da Inoculação";
            dataGridViewVacinacao.Columns[4].HeaderText = "Lote";
            dataGridViewVacinacao.Columns[5].HeaderText = "Local";
            dataGridViewVacinacao.Columns[6].HeaderText = "Dor";
            dataGridViewVacinacao.Columns[7].HeaderText = "Observações";

            conn.Close();
            dataGridViewVacinacao.Update();
            dataGridViewVacinacao.Refresh();
        }
    }
}
