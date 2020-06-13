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
    public partial class AdicionarCateterismoPaciente : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private ErrorProvider errorProvider = new ErrorProvider();
        private int id = -1;
        public AdicionarCateterismoPaciente(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            dataRegistoMed.Value = DateTime.Today;
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;

        }

        private void AdicionarCateterismoPaciente_Load(object sender, EventArgs e)
        {
            conn.Open();
            com.Connection = conn;
            SqlCommand cmd = new SqlCommand("select * from Atitude WHERE nomeAtitude = 'Cateterismo'", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                id = (int)reader["IdAtitude"];
            }

            conn.Close();
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DateTime dataRegisto = dataRegistoMed.Value;
            string cateterismo = txtCateterismo.Text;
            string obs = txtObservacoes.Text;

            if (VerificarDadosInseridos())
            {
                try
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    connection.Open();

                    string queryInsertData = "INSERT INTO Cateterismo(IdAtitude,IdPaciente,data,cateterismo,observacoes) VALUES(@id,@IdPaciente,@dataR,@cateterismo,@obs);";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                    sqlCommand.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
                    sqlCommand.Parameters.AddWithValue("@dataR", dataRegisto.ToString("MM/dd/yyyy"));
                    sqlCommand.Parameters.AddWithValue("@id", id);

                    if (cateterismo != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@cateterismo", Convert.ToString(cateterismo));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@cateterismo", DBNull.Value);
                    }

                    if (obs != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@obs", Convert.ToString(obs));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@obs", DBNull.Value);
                    }


                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Cataterismo registado com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    limparCampos();

                }
                catch (SqlException excep)
                {

                    MessageBox.Show("Por erro interno é impossível registar o cataterismo!", excep.Message);
                }

            }
        }

        private void btnLimparCampos_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void limparCampos() 
        {
            dataRegistoMed.Value = DateTime.Today;
            txtObservacoes.Text = "";
            txtCateterismo.Text = "";
            errorProvider.Clear();
        }


        private Boolean VerificarDadosInseridos()
        {
            DateTime data = dataRegistoMed.Value;

            int var = (int)((data - DateTime.Today).TotalDays);

            if (var > 0)
            {
                MessageBox.Show("A data tem de ser inferior a data de hoje!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(dataRegistoMed, "A data tem de ser inferior a data de hoje!");
                return false;
            }

            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select * from Cateterismo WHERE IdPaciente = @IdPaciente AND IdAtitude = @id", conn);
            cmd.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DateTime dataRegisto = DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null);
                if (dataRegistoMed.Value.ToShortDateString().Equals(dataRegisto.ToShortDateString()) && paciente.IdPaciente == (int)reader["IdPaciente"] && id == (int)reader["IdAtitude"])
                {
                    MessageBox.Show("Não é possível registar, porque já esta registado na data que selecionou!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    conn.Close();
                    return false;
                }

            }
            conn.Close();

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VerCateterismo verCateterismo = new VerCateterismo(paciente);
            verCateterismo.Show();
        }
    }
}
