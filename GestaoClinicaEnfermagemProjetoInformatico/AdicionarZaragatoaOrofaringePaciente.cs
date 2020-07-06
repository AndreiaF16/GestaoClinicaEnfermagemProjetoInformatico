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
    public partial class AdicionarZaragatoaOrofaringePaciente : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private ErrorProvider errorProvider = new ErrorProvider();
        private int id = -1;

        public AdicionarZaragatoaOrofaringePaciente(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            dataRegistoMed.Value = DateTime.Today;
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;

        }

        private void AdicionarZaragatoaOnofaringePaciente_Load(object sender, EventArgs e)
        {
            idAtitude();
            if (id == -1)
            {
                var resposta = MessageBox.Show("Atitude não encontrada! Deseja inserir a atitude na base de dados?", "Aviso!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resposta == DialogResult.Yes)
                {
                    try
                    {
                        SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                        connection.Open();

                        string queryInsertData = "INSERT INTO Atitude(nomeAtitude) VALUES('Zaragatoa Orofaringe');";
                        SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                        sqlCommand.ExecuteNonQuery();
                        MessageBox.Show("Atitude Terapêutica registada com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        connection.Close();
                    }
                    catch (SqlException)
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                        }
                        MessageBox.Show("Por erro interno é impossível registar a atitude terapêutica!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (resposta == DialogResult.No)
                {
                    this.Close();
                    MessageBox.Show("Você escolheu 'Não', por isso não é possível realizar tarefas com esta atitude!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
                }
            }
            idAtitude();

        }

        private void idAtitude()
        {
            try
            {
                conn.Open();
                com.Connection = conn;
                SqlCommand cmd = new SqlCommand("select * from Atitude WHERE nomeAtitude = 'Zaragatoa Orofaringe'", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    id = (int)reader["IdAtitude"];
                }

                conn.Close();
            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível selecionar a atitude terapêutica!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            string zaragatoaOrofaringe = txtZaragatoaOrofaringe.Text;
            string obs = txtObservacoes.Text;

            if (VerificarDadosInseridos())
            {
                try
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    connection.Open();

                    string queryInsertData = "INSERT INTO ZaragatoaOrofaringe(IdAtitude,IdPaciente,data,zaragatoaOrofaringe,observacoes) VALUES(@id,@IdPaciente,@dataR,@zaragatoaOrofaringe,@obs);";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                    sqlCommand.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
                    sqlCommand.Parameters.AddWithValue("@dataR", dataRegisto.ToString("MM/dd/yyyy"));

                    sqlCommand.Parameters.AddWithValue("@id", id);

                    //zaragatoa Onofaringe 
                    if (zaragatoaOrofaringe != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@zaragatoaOrofaringe", Convert.ToString(zaragatoaOrofaringe));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@zaragatoaOrofaringe", DBNull.Value);
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
                    MessageBox.Show("Zaragatoa Orofaringe registada com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    limparCampos();
                }
                catch (SqlException)
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    MessageBox.Show("Por erro interno é impossível registar a  Zaragatoa Orofaringe!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLimparCampos_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void limparCampos()
        {
            txtZaragatoaOrofaringe.Text = "";
            txtObservacoes.Text = "";
            dataRegistoMed.Value = DateTime.Today;
            errorProvider.Clear();
        }

        private Boolean VerificarDadosInseridos()
        {
            DateTime data = dataRegistoMed.Value;

            int var = (int)((data - DateTime.Today).TotalDays);

            if (var > 0)
            {
                MessageBox.Show("A data de registo tem de ser inferior ou igual à data de hoje! \n Selecione outra data!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(dataRegistoMed, "A data tem de ser inferior ou igual à data de hoje!");
                return false;
            }

            try
            {
                conn.Open();
                com.Connection = conn;

                SqlCommand cmd = new SqlCommand("select * from ZaragatoaOrofaringe WHERE IdPaciente = @IdPaciente AND IdAtitude = @id", conn);
                cmd.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DateTime dataRegisto = DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null);
                    if (dataRegistoMed.Value.ToShortDateString().Equals(dataRegisto.ToShortDateString()) && paciente.IdPaciente == (int)reader["IdPaciente"] && id == (int)reader["IdAtitude"])
                    {
                        MessageBox.Show("Não é possível registar a Zaragatoa, porque já está um registo na data que selecionou! \n Selecione outra data!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        conn.Close();
                        return false;
                    }

                }
                conn.Close();

            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível verificar os dados!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VerZaragatoaOrofaringe verZaragatoaOrofaringe = new VerZaragatoaOrofaringe(paciente);
            verZaragatoaOrofaringe.Show();
        }
    }
}
