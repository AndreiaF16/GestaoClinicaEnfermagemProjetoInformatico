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
        Paciente paciente = null;
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


        private void button1_Click(object sender, EventArgs e)
        {
            if (VerificarDadosInseridos())
            {

                string localizacaoDor = textBox1.Text;
                DateTime dataReg = dataRegisto.Value;
                int tratamento = (comboBoxTratamento.SelectedItem as ComboBoxItem).Value;


                try
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    connection.Open();

                    string queryInsertData = "INSERT INTO LocalizacaoDor(IdTratamentoMaosPes, IdPaciente,data,localizacao) VALUES(@idTratamento,@idPaciente,@dataR,@localizacao);";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);

                    sqlCommand.Parameters.AddWithValue("@idPaciente", paciente.IdPaciente);
                    sqlCommand.Parameters.AddWithValue("@dataR", dataReg.ToString("MM/dd/yyyy"));
                    sqlCommand.Parameters.AddWithValue("@localizacao", localizacaoDor);
                    sqlCommand.Parameters.AddWithValue("@idTratamento", Convert.ToInt32(tratamento));

                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Dados Localizacao dor registados com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
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
                MessageBox.Show("A data de registo tem de ser inferior a data de hoje!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(dataRegisto, "A data tem de ser inferior a data de hoje!");
                return false;
            }

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
            VerLocalizacaoDorConsulta verLocalizacaoDor = new VerLocalizacaoDorConsulta(paciente);
            verLocalizacaoDor.Show();
        }
    }
}
