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
    public partial class FormLocalizacaoDorCorpoConsulta : Form
    {
        Point point;
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private ErrorProvider errorProvider = new ErrorProvider();

        public FormLocalizacaoDorCorpoConsulta(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            dataRegisto.Value = DateTime.Today;
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;

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

        private void pictureBoxCorpo_MouseClick(object sender, MouseEventArgs e)
        {
            TextBox textBox = new TextBox();


            textBox.Location = PointToScreen(e.Location);

            pictureBoxCorpo.Controls.Add(textBox);
            textBox1.Clear();

            // string dor = textBox.Text;
            for (int i = 0; i < this.pictureBoxCorpo.Controls.Count; i++)
            {

                if (this.pictureBoxCorpo.Controls[i] is TextBox)
                {
                    TextBox txtserial = (TextBox)this.pictureBoxCorpo.Controls[i];
                    string value = txtserial.Text;
                    textBox1.Text += value.ToString();
                    textBox1.AppendText("\r\n\t");

                }
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VerLocalizacaoDorConsulta verLocalizacaoDorConsulta = new VerLocalizacaoDorConsulta(paciente);
            verLocalizacaoDorConsulta.Show();
        }

        private void hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Hora " + DateTime.Now.ToLongTimeString();
            lblDia.Text = DateTime.Now.ToString("dddd, dd " + "'de '" + "MMMM" + "' de '" + "yyyy");
        }

        private void btnLimparCampos_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void limparCampos()
        {
            dataRegisto.Value = DateTime.Today;
            var bmp = new Bitmap(GestaoClinicaEnfermagemProjetoInformatico.Properties.Resources.identificacaoAnatomica1_jpg);
            pictureBoxCorpo.Image = bmp;
            pictureBoxCorpo.Controls.Clear();
            textBox1.Clear();
            pictureBoxCorpo.Refresh();
           // txtObservacoes.Text = "";

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {       
            if (VerificarDadosInseridos())
            {
                string localizacaoDor = textBox1.Text;
                DateTime data = dataRegisto.Value;

                try
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    connection.Open();

                    string queryInsertData = "INSERT INTO LocalizacaoDorConsulta(IdPaciente,data,localizacao) VALUES(@idPaciente,@dataR,@localizacao);";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);

                    sqlCommand.Parameters.AddWithValue("@idPaciente", paciente.IdPaciente);
                    sqlCommand.Parameters.AddWithValue("@localizacao", localizacaoDor);
                    sqlCommand.Parameters.AddWithValue("@dataR", data.ToString("MM/dd/yyyy"));

                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Dados Localizacao dor na consulta registados com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    limparCampos();
                }
                catch (SqlException excep)
                {
                    MessageBox.Show("Por erro interno é impossível registar os dados da localizacao da dor", excep.Message);
                }
            }
        }

        private Boolean VerificarDadosInseridos()
        {
            DateTime data = dataRegisto.Value;

            int var = (int)((data - DateTime.Today).TotalDays);

            if (var > 0)
            {
                MessageBox.Show("A data tem de ser inferior a data de hoje!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(dataRegisto, "A data tem de ser inferior a data de hoje!");
                return false;
            }

            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select * from LocalizacaoDorConsulta WHERE IdPaciente = @IdPaciente", conn);
            cmd.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DateTime dataR = DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null);
                if (dataRegisto.Value.ToShortDateString().Equals(dataR.ToShortDateString()) && paciente.IdPaciente == (int)reader["IdPaciente"])
                {
                    MessageBox.Show("Não é possível registar, porque já esta registado na data que selecionou!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    conn.Close();
                    return false;
                }
            }
            conn.Close();

            return true;
        }
    }

}

