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
    public partial class AdicionarCrioterapiaPaciente : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private ErrorProvider errorProvider = new ErrorProvider();
        private int id = -1;

        public AdicionarCrioterapiaPaciente(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            dataRegisto.Value = DateTime.Today;
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
        }

        private void AdicionarCrioterapiaPaciente_Load(object sender, EventArgs e)
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

                        string queryInsertData = "INSERT INTO Atitude(nomeAtitude) VALUES('Crioterapia');";
                        SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                        sqlCommand.ExecuteNonQuery();
                        MessageBox.Show("Atitude Terapêutica registada com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        connection.Close();
                    }
                    catch (SqlException excep)
                    {

                        MessageBox.Show("Por erro interno é impossível registar a atitude terapêutica!", excep.Message);
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
            conn.Open();
            com.Connection = conn;
            SqlCommand cmd = new SqlCommand("select * from Atitude WHERE nomeAtitude = 'Crioterapia'", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                id = (int)reader["IdAtitude"];
            }
            conn.Close();
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

            //  TextBox tb = new TextBox();
            textBox.KeyDown += new KeyEventHandler(tb_KeyDown);

            //textBox1.Text = tb;

            string dor = textBox.Text;
            for (int i = 0; i < this.pictureBoxCorpo.Controls.Count; i++)
            {
                if (this.pictureBoxCorpo.Controls[i] is TextBox)
                {
                    TextBox txtserial = (TextBox)this.pictureBoxCorpo.Controls[i];
                    string value = txtserial.Text;
                    if (value != string.Empty)
                    {
                        textBox1.Text += value.ToString();
                        textBox1.AppendText(", ");
                    }
                }
            }
        }

        private void tb_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                textBox1.Clear();

                //enter key is down
                for (int i = 0; i < pictureBoxCorpo.Controls.Count; i++)
                {

                    if (pictureBoxCorpo.Controls[i] is TextBox)
                    {
                        TextBox txtserial = (TextBox)pictureBoxCorpo.Controls[i];
                        string value = txtserial.Text;
                        if (value != string.Empty)
                        {
                            textBox1.Text += value.ToString();
                            textBox1.AppendText(", ");
                        }
                    }
                }
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
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
            txtObservacoes.Text = "";

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (VerificarDadosInseridos())
            {
                string localizacaoDor = textBox1.Text;
                //remove o ultimo caracter
                localizacaoDor = localizacaoDor.Remove(localizacaoDor.Length - 1);
                localizacaoDor = localizacaoDor.Remove(localizacaoDor.Length - 1);

                DateTime data = dataRegisto.Value;
                string obs = txtObservacoes.Text;


                try
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    connection.Open();

                    string queryInsertData = "INSERT INTO Crioterapia(IdAtitude,IdPaciente,data,localizacao,observacoes) VALUES(@id,@idPaciente,@dataR,@localizacao,@obs);";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);

                    sqlCommand.Parameters.AddWithValue("@idPaciente", paciente.IdPaciente);
                    sqlCommand.Parameters.AddWithValue("@localizacao", localizacaoDor);
                    sqlCommand.Parameters.AddWithValue("@dataR", data.ToString("MM/dd/yyyy"));
                    sqlCommand.Parameters.AddWithValue("@id", id);

                    if (obs != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@obs", Convert.ToString(obs));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@obs", DBNull.Value);
                    }

                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Crioterapia registada com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    limparCampos();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Por erro interno é impossível registar os dados da crioterapia", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private Boolean VerificarDadosInseridos()
        {
            DateTime data = dataRegisto.Value;

            int var = (int)((data - DateTime.Today).TotalDays);
            string local = textBox1.Text;

            if (local == string.Empty)
            {
                MessageBox.Show("Campo Obrigatório, por favor preencha a localização!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (textBox1.Text == string.Empty)
                {
                    MessageBox.Show("A localização é obrigatória. \n Se por ventura inseriu, selecione o texto das caixas (uma de cada vez), carregue ENTER e volte a tentar guardar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorProvider.SetError(textBox1, "A localização é obrigatória!");
                }
                return false;
            }

            if (var > 0)
            {
                MessageBox.Show("A data de registo tem de ser inferior ou igual à data de hoje! \n Selecione outra data!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(dataRegisto, "A data tem de ser inferior ou igual à data de hoje!");
                return false;
            }

            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select * from Crioterapia WHERE IdPaciente = @IdPaciente", conn);
            cmd.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DateTime dataR = DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null);
                if (dataRegisto.Value.ToShortDateString().Equals(dataR.ToShortDateString()) && paciente.IdPaciente == (int)reader["IdPaciente"])
                {
                    MessageBox.Show("Não é possível registar, porque já está registado na data que selecionou!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    conn.Close();
                    return false;
                }
            }
            conn.Close();

            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VerCrioterapia verCrioterapia = new VerCrioterapia(paciente);
            verCrioterapia.Show();
        }
    }
}
