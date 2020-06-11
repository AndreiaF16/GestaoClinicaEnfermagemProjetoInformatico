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
    public partial class AdicionarColheitaUrinaPaciente : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private ErrorProvider errorProvider = new ErrorProvider();
        private int id = -1;
        public AdicionarColheitaUrinaPaciente(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            dataRegistoMed.Value = DateTime.Today;
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;

        }

        private void AdicionarColheitaUrinaPaciente_Load(object sender, EventArgs e)
        {
            conn.Open();
            com.Connection = conn;
            SqlCommand cmd = new SqlCommand("select * from Atitude WHERE nomeAtitude = 'Colheita urina'", conn);
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
            string exameSumario = "";
            string urocultura = "";
            string vinteQuatroHoras = "";
            string obs = txtObservacoes.Text;

            //exameSumario
            if (cbExameSumario.Checked == true)
            {
                exameSumario = "Sim";
            }
            if (cbExameSumario.Checked == false)
            {
                exameSumario = "Não";
            }

            //urocultura
            if (cbUrocultura.Checked == true)
            {
                urocultura = "Sim";
            }
            if (cbUrocultura.Checked == false)
            {
                urocultura = "Não";
            }

            //vinteQuatroHoras
            if (cbVintaQuatroHoras.Checked == true)
            {
                vinteQuatroHoras = "Sim";
            }
            if (cbVintaQuatroHoras.Checked == false)
            {
                vinteQuatroHoras = "Não";
            }

            if (VerificarDadosInseridos())
            {
                try
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    connection.Open();

                    string queryInsertData = "INSERT INTO ColheitaUrina(IdAtitude,IdPaciente,data,exameSumario,urocultura,vinteQuantroHoras,observacoes) VALUES(@id,@IdPaciente,@dataR,@exameSumario,@urocultura,@vinteQuatroHoras,@obs);";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                    sqlCommand.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
                    sqlCommand.Parameters.AddWithValue("@dataR", dataRegisto.ToString("MM/dd/yyyy"));
                    sqlCommand.Parameters.AddWithValue("@id", id);

                    if (exameSumario != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@exameSumario", Convert.ToString(exameSumario));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@exameSumario", DBNull.Value);
                    }

                    if (urocultura != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@urocultura", Convert.ToString(urocultura));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@urocultura", DBNull.Value);
                    }

                    if (vinteQuatroHoras != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@vinteQuatroHoras", Convert.ToString(vinteQuatroHoras));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@vinteQuatroHoras", DBNull.Value);
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
                    MessageBox.Show("A colheita de urina foi registada com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    connection.Close();
                    //limparCampos();

                }
                catch (SqlException excep)
                {

                    MessageBox.Show("Por erro interno é impossível registar a colheita de urina!", excep.Message);
                }

            }
        }

        private void btnLimparCampos_Click(object sender, EventArgs e)
        {
            dataRegistoMed.Value = DateTime.Today;
            cbExameSumario.Checked = false;
            cbUrocultura.Checked = false;
            cbVintaQuatroHoras.Checked = false;
            txtObservacoes.Text = "";
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

            SqlCommand cmd = new SqlCommand("select * from ColheitaUrina WHERE IdPaciente = @IdPaciente AND IdAtitude = @id", conn);
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
    }
}
