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
    public partial class AdicionarInalacaoPaciente : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private ErrorProvider errorProvider = new ErrorProvider();
        private int id = -1;

        public AdicionarInalacaoPaciente(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            dataRegistoMed.Value = DateTime.Today;
        }

        private void AdicionarInalacaoPaciente_Load(object sender, EventArgs e)
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

                        string queryInsertData = "INSERT INTO Atitude(nomeAtitude) VALUES('Inalações');";
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
                SqlCommand cmd = new SqlCommand("select * from Atitude WHERE nomeAtitude = 'Inalações'", conn);
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

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
           

            if (VerificarDadosInseridos())
            {
                DateTime dataR = dataRegistoMed.Value;
                string obs = txtObservacoes.Text;
                string O2 = txtO2.Text;
                string inaladores = txtInaladores.Text;
                string aerossol = txtAerossol.Text;
                try
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    connection.Open();

                    string queryInsertData = "INSERT INTO Inalacoes(IdAtitude,IdPaciente,data,O2,aerossol,inaladores,observacoes) VALUES(@id,@IdPaciente,@dataR,@O2,@inaladores,@aerossol,@obs);";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                    sqlCommand.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
                    sqlCommand.Parameters.AddWithValue("@dataR", dataR.ToString("MM/dd/yyyy"));
                    sqlCommand.Parameters.AddWithValue("@id", id);

                    //O2
                    if (O2 != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@O2", Convert.ToString(O2));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@O2", DBNull.Value);
                    }

                    //inaladores
                    if (inaladores != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@inaladores", Convert.ToString(inaladores));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@inaladores", DBNull.Value);
                    }

                    //aerossol
                    if (obs != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@aerossol", Convert.ToString(aerossol));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@aerossol", DBNull.Value);
                    }

                    //observacoes
                    if (obs != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@obs", Convert.ToString(obs));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@obs", DBNull.Value);
                    }


                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Inalação registada com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    limparCampos();
                }
                catch (SqlException)
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    MessageBox.Show("Por erro interno é impossível registar as inalações!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLimparCampos_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void limparCampos()
        {
            txtAerossol.Text = "";
            txtInaladores.Text = "";
            txtO2.Text = "";
            txtObservacoes.Text = "";
        }

        private Boolean VerificarDadosInseridos()
        {

            DateTime dataR = dataRegistoMed.Value;

            int var = (int)((dataR - DateTime.Today).TotalDays);

            if (var > 0)
            {
                MessageBox.Show("A data de registo das inalações tem de ser inferior ou igual à data de hoje! \n Selecione outra data!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(dataRegistoMed, "A data tem de ser inferior ou igual à data de hoje!");
                return false;
            }

            try
            {

                conn.Open();
                com.Connection = conn;

                SqlCommand cmd = new SqlCommand("select * from Inalacoes WHERE IdPaciente = @IdPaciente AND IdAtitude = @id", conn);
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
            VerInalacoes verInalacoes = new VerInalacoes(paciente);
            verInalacoes.Show();
        }
    }
}
