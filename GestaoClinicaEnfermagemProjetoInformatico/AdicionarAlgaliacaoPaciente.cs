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
    public partial class AdicionarAlgaliacaoPaciente : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private ErrorProvider errorProvider = new ErrorProvider();
        private int id = -1;
        public AdicionarAlgaliacaoPaciente(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            dataRegistoMed.Value = DateTime.Today;
            dataProximaRealgaliacao.Value = DateTime.Today;
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;

        }

        private void AdicionarAlgariacaoPaciente_Load(object sender, EventArgs e)
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

                        string queryInsertData = "INSERT INTO Atitude(nomeAtitude) VALUES('Algaliação');";
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
                SqlCommand cmd = new SqlCommand("select * from Atitude WHERE nomeAtitude = 'Algaliação'", conn);
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
            DateTime dataRegisto = dataRegistoMed.Value;
            DateTime dataProx = dataProximaRealgaliacao.Value;
            string silastic = txtSilastic.Text;
            string folley = "";
            string tresVias = "";
            string obs = txtObservacoes.Text;

            //folley
            if (cbFolley.Checked == true)
            {
                folley = "Sim";
            }
            if (cbFolley.Checked == false)
            {
                folley = "";
            }

            //tresVias
            if (cbTresVias.Checked == true)
            {
                tresVias = "Sim";
            }
            if (cbTresVias.Checked == false)
            {
                tresVias = "";
            }

            if (VerificarDadosInseridos())
            {
                try
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    connection.Open();

                    string queryInsertData = "INSERT INTO Algaliacao(IdAtitude,IdPaciente,data,silastic,folley,tresVias,dataProximaRealgaliacao,observacoes) VALUES(@id,@IdPaciente,@dataR,@silastic,@folley,@tresVias,@dataP,@obs);";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                    sqlCommand.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
                    sqlCommand.Parameters.AddWithValue("@dataR", dataRegisto.ToString("MM/dd/yyyy"));

                    sqlCommand.Parameters.AddWithValue("@id", id);

                    if (cbDataProximaAlgariacao.Checked == true)
                    {
                        sqlCommand.Parameters.AddWithValue("@dataP", dataProx.ToString("MM/dd/yyyy"));
                    }
                    else 
                    {
                        sqlCommand.Parameters.AddWithValue("@dataP", DBNull.Value);
                    }

                    if (folley != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@folley", Convert.ToString(folley));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@folley", DBNull.Value);
                    }

                    if (tresVias != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@tresVias", Convert.ToString(tresVias));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@tresVias", DBNull.Value);
                    }

                    if (silastic != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@silastic", Convert.ToString(silastic));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@silastic", DBNull.Value);
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
                    MessageBox.Show("Algaliação registada com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    limparCampos();
                }
                catch (SqlException)
                {

                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    MessageBox.Show("Por erro interno é impossível registar a Algaliação!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            dataProximaRealgaliacao.Value = DateTime.Today;
            txtSilastic.Text = "";
            txtObservacoes.Text = "";
            cbFolley.Checked = false;
            cbTresVias.Checked = false;
            errorProvider.Clear();
        }

        private Boolean VerificarDadosInseridos()
        {
            DateTime data = dataRegistoMed.Value;
            DateTime dataP = dataProximaRealgaliacao.Value;

            int var = (int)((data - DateTime.Today).TotalDays);
            int var2 = (int)((dataP - DateTime.Today).TotalDays);

            if (var > 0)
            {
                MessageBox.Show("A data de registo tem de ser inferior à data de hoje! \n Selecione outra data!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(dataRegistoMed, "A data tem de ser inferior à data de hoje!");
                return false;
            }

            if (var2 < 0)
            {
                MessageBox.Show("A data da próxima reAlgaliação tem de ser superior à data de hoje! \n Selecione outra data!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(dataRegistoMed, "A data tem de ser superior à data de hoje!");
                return false;
            }


            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select * from Algaliacao WHERE IdPaciente = @IdPaciente AND IdAtitude = @id", conn);
            cmd.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DateTime dataRegisto = DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null);
                if (dataRegistoMed.Value.ToShortDateString().Equals(dataRegisto.ToShortDateString()) && paciente.IdPaciente == (int)reader["IdPaciente"] && id == (int)reader["IdAtitude"])
                {
                    MessageBox.Show("Não é possível registar a Algaliacao, porque já está um registo na data que selecionou! \n Selecione outra data!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    conn.Close();
                    return false;
                }
            }
            conn.Close();
            return true;
        }

        private void txtSilastic_KeyPress(object sender, KeyPressEventArgs e)
        {
            //garantir que são inseridos apenas numeros
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Hide();
            VerAlgaliacaoPaciente verAlgariacaoPaciente = new VerAlgaliacaoPaciente(paciente);
            verAlgariacaoPaciente.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(cbDataProximaAlgariacao.Checked == true)
            {
                dataProximaRealgaliacao.Enabled = true;
            }
            else
            {
                dataProximaRealgaliacao.Enabled = false;
            }
        }
    }
}
