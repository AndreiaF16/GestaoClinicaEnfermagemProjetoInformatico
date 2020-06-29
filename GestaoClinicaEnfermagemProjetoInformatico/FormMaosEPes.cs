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
    public partial class FormMaosEPes : Form
    {
        private Paciente paciente = null;
        Point point;
        private ErrorProvider errorProvider = new ErrorProvider();
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private List<ComboBoxItem> tratamentos = new List<ComboBoxItem>();
        private List<ComboBoxItem> auxiliar = new List<ComboBoxItem>();

        public FormMaosEPes(Paciente ut)
        {
            InitializeComponent();
            paciente = ut;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            dataRegisto.Value = DateTime.Today;

        }

        private void panelFormulario_Paint(object sender, PaintEventArgs e)
        {

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

        private void FormMaosEPes_Load(object sender, EventArgs e)
        {
            reiniciar();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var resposta = MessageBox.Show("Tem a certeza que deseja sair da aplicação?", "Fechar Aplicação!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resposta == DialogResult.Yes)
            {
                Application.Exit();
            }

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (VerificarDadosInseridos())
            {


                string localizacaoDor = textBox1.Text;

                //remove o ultimo caracter
                localizacaoDor = localizacaoDor.Remove(localizacaoDor.Length -1);
                localizacaoDor = localizacaoDor.Remove(localizacaoDor.Length - 1);

                DateTime dataReg = dataRegisto.Value;
                int tratamento = (comboBoxTratamento.SelectedItem as ComboBoxItem).Value;
                string obs = txtObservacoes.Text;


                try
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    connection.Open();

                    string queryInsertData = "INSERT INTO LocalizacaoDor(IdTratamentoMaosPes, IdPaciente,data,localizacao, observacoes) VALUES(@idTratamento,@idPaciente,@dataR,@localizacao,@obs);";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);

                    sqlCommand.Parameters.AddWithValue("@idPaciente", paciente.IdPaciente);
                    sqlCommand.Parameters.AddWithValue("@dataR", dataReg.ToString("MM/dd/yyyy"));
                    sqlCommand.Parameters.AddWithValue("@localizacao", localizacaoDor);
                    sqlCommand.Parameters.AddWithValue("@idTratamento", Convert.ToInt32(tratamento));

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
                catch (SqlException excep)
                {
                    MessageBox.Show("Por erro interno é impossível registar os dados da localizacao da dor", excep.Message);
                }
            }
        }

        private Boolean VerificarDadosInseridos()
        {
            DateTime data = dataRegisto.Value;
            string tratamento = comboBoxTratamento.Text;
            string local = textBox1.Text;

            int var = (int)((data - DateTime.Today).TotalDays);

            if (tratamento == string.Empty || local == string.Empty)
            {
                MessageBox.Show("Campos Obrigatórios, por favor preencha-os!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (comboBoxTratamento.Text == string.Empty)
                {
                    errorProvider.SetError(comboBoxTratamento, "O tratamento é obrigatório!");
                }

                if (textBox1.Text == string.Empty)
                {
                    MessageBox.Show("Localização é obrigatória. \n Se por ventura inseriu, selecione o texto das caixas (uma de cada vez), carregue ENTER e volte a tentar guardar!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorProvider.SetError(textBox1, "A localização é obrigatória!");
                }
                return false;
            }

                if (var > 0)
            {
                MessageBox.Show("A data de registo tem de ser inferior a data de hoje!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(dataRegisto, "A data tem de ser inferior a data de hoje!");
                return false;
            }

            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select * from LocalizacaoDor WHERE IdPaciente = @IdPaciente", conn);
            cmd.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
            int localizacao = (comboBoxTratamento.SelectedItem as ComboBoxItem).Value;

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DateTime dataR = DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null);
                if (dataRegisto.Value.ToShortDateString().Equals(dataR.ToShortDateString()) && paciente.IdPaciente == (int)reader["IdPaciente"] && localizacao == (int)reader["IdTratamentoMaosPes"])
                {
                    MessageBox.Show("Não é possível registar, porque já esta registado na data que selecionou!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    conn.Close();
                    return false;
                }

            }
            conn.Close();

            return true;
        }

        public void reiniciar()
        {
            tratamentos.Clear();
            comboBoxTratamento.Items.Clear();

            auxiliar.Clear();
            conn.Open();
            com.Connection = conn;
            SqlCommand cmd = new SqlCommand("select * from TratamentoMaosPes order by tratamento asc", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Text = (string)reader["tratamento"];
                item.Value = (int)reader["IdTratamentoMaosPes"];
                comboBoxTratamento.Items.Add(item);
                tratamentos.Add(item);
            }
            conn.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            VerLocalizacaoDorMaosPes verLocalizacaoDor = new VerLocalizacaoDorMaosPes(paciente);
            verLocalizacaoDor.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void limparCampos()
        {
            dataRegisto.Value = DateTime.Today;
            txtObservacoes.Text = "";
            reiniciar();
            errorProvider.Clear();
            var bmp = new Bitmap(GestaoClinicaEnfermagemProjetoInformatico.Properties.Resources.identificacaoAnatomica1_jpg);
            pictureBoxCorpo.Image = bmp;
            pictureBoxCorpo.Controls.Clear();
            textBox1.Clear();
            pictureBoxCorpo.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdicionarTratamentoMaosPes adicionarTratamentoMaosPes = new AdicionarTratamentoMaosPes(this);
            adicionarTratamentoMaosPes.Show();
        }
    }
}
