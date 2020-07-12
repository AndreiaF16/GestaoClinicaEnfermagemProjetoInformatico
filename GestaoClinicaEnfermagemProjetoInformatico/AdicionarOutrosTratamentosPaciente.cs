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
    public partial class AdicionarOutrosTratamentosPaciente : Form
    {
        private Paciente paciente = new Paciente();
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private int idTratamentos = -1;

        public AdicionarOutrosTratamentosPaciente(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AdicionarOutrosTratamentosPaciente_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var resposta = MessageBox.Show("Tem a certeza que deseja sair da aplicação?", "Fechar Aplicação!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resposta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Hora " + DateTime.Now.ToLongTimeString();
            lblDia.Text = DateTime.Now.ToString("dddd, dd " + "'de '" + "MMMM" + "' de '" + "yyyy");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AdicionarTratamentoVacinacao adicionarTratamentoVacinacao = new AdicionarTratamentoVacinacao(paciente);
            adicionarTratamentoVacinacao.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdicionarEpisiotomiaPaciente adicionarEpisiotomiaPaciente = new AdicionarEpisiotomiaPaciente(paciente);
            adicionarEpisiotomiaPaciente.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            AdicionarDopplerFetalPaciente adicionarDoplerFetalPaciente = new AdicionarDopplerFetalPaciente(paciente);
            adicionarDoplerFetalPaciente.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            FormLocalizacaoDorDopplerArterialVenoso formLocalizacaoDorDopplerArterialVenoso = new FormLocalizacaoDorDopplerArterialVenoso(paciente);
            formLocalizacaoDorDopplerArterialVenoso.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            idVarios();
            if (idTratamentos == -1)
            {
                var resposta = MessageBox.Show("Tipo de tratamentos não encontrados! Deseja inserir os tipos na base de dados?", "Aviso!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resposta == DialogResult.Yes)
                {
                    try
                    {
                        SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                        connection.Open();

                        string queryInsertData = "INSERT INTO TratamentoMaosPes(tratamento) VALUES('Ferida Cirúrgica');";
                        SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                        sqlCommand.ExecuteNonQuery();
                        MessageBox.Show("Tipo de Tratamento 'Onicocriptoses' registado com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        connection.Close();
                    }
                    catch (SqlException)
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                        }
                        MessageBox.Show("Por erro interno é impossível registar o tipo de tratamento 'Onicocriptoses'!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    try
                    {
                        SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                        connection.Open();

                        string queryInsertData = "INSERT INTO TratamentoMaosPes(tratamento) VALUES('Onicomicoses');";
                        SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                        sqlCommand.ExecuteNonQuery();
                        MessageBox.Show("Tipo de Tratamento 'Onicomicoses' registado com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        connection.Close();
                    }
                    catch (SqlException)
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                        }
                        MessageBox.Show("Por erro interno é impossível registar o tipo de tratamento 'Onicomicoses'!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    try
                    {
                        SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                        connection.Open();

                        string queryInsertData = "INSERT INTO TratamentoMaosPes(tratamento) VALUES('Pé Diabético');";
                        SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                        sqlCommand.ExecuteNonQuery();
                        MessageBox.Show("Tipo de Tratamento 'Pé Diabético' registado com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        connection.Close();
                    }
                    catch (SqlException)
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                        }
                        MessageBox.Show("Por erro interno é impossível registar o tipo de tratamento 'Pé Diabético'!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }                  
                }

                if (resposta == DialogResult.No)
                {
                    MessageBox.Show("Você escolheu 'Não', por isso não é possível realizar tarefas!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
                }
            }

            idVarios();
            if (idTratamentos != -1)
            {
                FormMaosEPes formMaosEPes = new FormMaosEPes(paciente);
                formMaosEPes.Show();
            }


        }

        private void idVarios()
        {
            try
            {
                conn.Open();
                com.Connection = conn;
                SqlCommand cmd = new SqlCommand("select * from TratamentoMaosPes", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    idTratamentos = (int)reader["IdTratamentoMaosPes"];
                }
                conn.Close();
            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível selecionar os tratamentos!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
