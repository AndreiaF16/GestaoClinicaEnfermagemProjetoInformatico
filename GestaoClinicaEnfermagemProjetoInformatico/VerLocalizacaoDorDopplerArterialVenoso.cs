using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GestaoClinicaEnfermagemProjetoInformatico
{
    public partial class VerLocalizacaoDorDopplerArterialVenoso : Form
    {
        private Paciente paciente = new Paciente();
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private List<LocalizazaoDorDopplerArterialVenoso> localizacaoDorPacientes = new List<LocalizazaoDorDopplerArterialVenoso>();
        public VerLocalizacaoDorDopplerArterialVenoso(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
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

        private void dataGridViewLocalizacaoDor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VerLocalizacaoDorDopplerArterialVenoso_Load(object sender, EventArgs e)
        {
            var bindingSource2 = new System.Windows.Forms.BindingSource { DataSource = localizacaoDorPacientes };
            dataGridViewLocalizacaoDor.DataSource = bindingSource2;
            UpdateDataGridView();       
        }
        
        private void UpdateDataGridView()
        {
            try
            {

                localizacaoDorPacientes.Clear();
                conn.Open();
                com.Connection = conn;

                SqlCommand cmd = new SqlCommand("select * from LocalizacaoDorDopplerArterialVenoso WHERE IdPaciente = @IdPaciente ORDER BY data", conn);
                cmd.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string dataR = ((reader["data"] == DBNull.Value) ? "" : DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy"));

                    LocalizazaoDorDopplerArterialVenoso localizacao = new LocalizazaoDorDopplerArterialVenoso
                    {

                        data = dataR,
                        localizacao = ((reader["localizacao"] == DBNull.Value) ? "" : (string)reader["localizacao"]),
                        observacoes = ((reader["observacoes"] == DBNull.Value) ? "" : (string)reader["observacoes"]),


                    };
                    localizacaoDorPacientes.Add(localizacao);

                }
                var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = localizacaoDorPacientes };
                dataGridViewLocalizacaoDor.DataSource = bindingSource1;

                dataGridViewLocalizacaoDor.Columns[0].HeaderText = "Data";
                dataGridViewLocalizacaoDor.Columns[1].HeaderText = "Localização Dor";
                dataGridViewLocalizacaoDor.Columns[2].HeaderText = "Observações";

                conn.Close();
                dataGridViewLocalizacaoDor.Update();
                dataGridViewLocalizacaoDor.Refresh();
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

        private void hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Hora " + DateTime.Now.ToLongTimeString();
            lblDia.Text = DateTime.Now.ToString("dddd, dd " + "'de '" + "MMMM" + "' de '" + "yyyy");
        }
    }


}
