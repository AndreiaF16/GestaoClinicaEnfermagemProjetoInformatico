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
    public partial class VerLocalizacaoDorMaosPes : Form
    {
        private Paciente paciente = new Paciente();
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private List<LocalizacaoDorMaosPes> localizacaoDorMaosPes = new List<LocalizacaoDorMaosPes>();


        public VerLocalizacaoDorMaosPes(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            var resposta = MessageBox.Show("Tem a certeza que deseja sair da aplicação?", "Fechar Aplicação!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resposta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
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

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Hora " + DateTime.Now.ToLongTimeString();
            lblDia.Text = DateTime.Now.ToString("dddd, dd " + "'de '" + "MMMM" + "' de '" + "yyyy");
        }

        private void VerLocalizacaoDorMaosPes_Load(object sender, EventArgs e)
        {

            loadGridView();
        }

        private void loadGridView() {
            LocalizacaoDorMaosPes localizacao = new LocalizacaoDorMaosPes();

            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select tratamentoMaosPes.tratamento, localizacao.data, localizacao.localizacao from TratamentoMaosPes tratamentoMaosPes LEFT JOIN LocalizacaoDor localizacao ON tratamentoMaosPes.IdTratamentoMaosPes = localizacao.IdTratamentoMaosPes WHERE IdPaciente = @IdPaciente ORDER BY localizacao.data asc, tratamentoMaosPes.tratamento asc", conn);
            cmd.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                localizacao = new LocalizacaoDorMaosPes
                {
                    data = Convert.ToDateTime(reader["data"]),
                    tratamento = ((reader["tratamento"] == DBNull.Value) ? "" : (string)reader["tratamento"]),
                    localizacao = ((reader["localizacao"] == DBNull.Value) ? "" : (string)reader["localizacao"]),
                };
                localizacaoDorMaosPes.Add(localizacao);

            }
            conn.Close();
            UpdateDataGridView();
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = localizacaoDorMaosPes };
            dataGridViewLocalizacaoDor.DataSource = bindingSource1;
        }

        private void UpdateDataGridView()
        {

            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = localizacaoDorMaosPes };
            dataGridViewLocalizacaoDor.DataSource = bindingSource1;

            dataGridViewLocalizacaoDor.Columns[0].Visible = false;
            dataGridViewLocalizacaoDor.Columns[1].HeaderText = "Data de Registo";
            dataGridViewLocalizacaoDor.Columns[2].HeaderText = "Tratamento";
            dataGridViewLocalizacaoDor.Columns[3].HeaderText = "Localização Dor";
    }
    }
}
