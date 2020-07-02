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
    public partial class FormLocalizacaoDorDopplerFetal : Form
    {
        Paciente paciente = null;
        private ErrorProvider errorProvider = new ErrorProvider();
        Point point;
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        public FormLocalizacaoDorDopplerFetal(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            dataRegisto.Value = DateTime.Today;
        }

        private void FormLocalizacaoDorDopplerFetal_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (VerificarDadosInseridos())
            {
                string localizacaoDor = textBox1.Text;

                //remove o ultimo caracter
                localizacaoDor = localizacaoDor.Remove(localizacaoDor.Length - 1);
                localizacaoDor = localizacaoDor.Remove(localizacaoDor.Length - 1);
                DateTime dataReg = dataRegisto.Value;
                string obs = txtObservacoes.Text;

                try
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    connection.Open();

                    string queryInsertData = "INSERT INTO LocalizacaoDorDopplerFetal(idPaciente,data,localizacao,observacoes) VALUES(@idPaciente,@dataR,@localizacao,@obs);";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);

                    sqlCommand.Parameters.AddWithValue("@idPaciente", paciente.IdPaciente);
                    sqlCommand.Parameters.AddWithValue("@dataR", dataReg.ToString("MM/dd/yyyy"));
                    sqlCommand.Parameters.AddWithValue("@localizacao", localizacaoDor);

                    if (obs != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@obs", Convert.ToString(obs));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@obs", DBNull.Value);
                    }

                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Dados Localização da dor registados com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    limparCampos();
                }
                catch (SqlException)
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    MessageBox.Show("Por erro interno é impossível registar os dados da localizacao da dor", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private Boolean VerificarDadosInseridos()
        {
            DateTime data = dataRegisto.Value;
            string local = textBox1.Text;

            int var = (int)((data - DateTime.Today).TotalDays);

            if (local == string.Empty)
            {
                MessageBox.Show("Campos Obrigatórios, por favor preencha-os!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (textBox1.Text == string.Empty)
                {
                    MessageBox.Show("Localização é obrigatória. \n Se por ventura inseriu, selecione o texto das caixas (uma de cada vez), carregue ENTER e volte a tentar guardar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorProvider.SetError(textBox1, "A localização é obrigatória!");
                }
                return false;
            }

            if (var > 0)
            {
                MessageBox.Show("A data de registo tem de ser inferior ou igual à data de hoje!\n Selecione outra data!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(dataRegisto, "A data tem de ser inferior ou igual à data de hoje!");
                return false;
            }

            return true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void limparCampos()
        {
            errorProvider.Clear();
            dataRegisto.Value = DateTime.Today;
            txtObservacoes.Text = "";
            errorProvider.Clear();
            var bmp = new Bitmap(GestaoClinicaEnfermagemProjetoInformatico.Properties.Resources.identificacaoAnatomica1_jpg);
            pictureBoxCorpo.Image = bmp;
            pictureBoxCorpo.Controls.Clear();
            textBox1.Clear();
            pictureBoxCorpo.Refresh();
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

        private void button2_Click(object sender, EventArgs e)
        {
            VerLocalizacaoDorDopplerFetal verLocalizacaoDorDopplerFetal = new VerLocalizacaoDorDopplerFetal(paciente);
            verLocalizacaoDorDopplerFetal.Show();
        }
    }
}
