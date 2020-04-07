using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestaoClinicaEnfermagemProjetoInformatico
{
    public partial class RegistarConsulta : Form
    {

        private Enfermeiro enfermeiro = null;
        private Paciente paciente = null;
        public RegistarConsulta(Enfermeiro enf, Paciente pac)
        {
            InitializeComponent();
            enfermeiro = enf;
            paciente = pac;
            
            label1.Text = "Nome do Paciente: " + paciente.Nome;


        }

        private void hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Hora " + DateTime.Now.ToLongTimeString();
            lblDia.Text = DateTime.Now.ToString("dddd, dd " + "'de '" + "MMMM" + "' de '" + "yyyy");
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

        private void RegistarConsulta_Load(object sender, EventArgs e)
        {
            dataConsulta.Format = DateTimePickerFormat.Short;
            // horaConsulta.Format = DateTimePickerFormat.Time;

            horaConsulta.Format = DateTimePickerFormat.Custom;
            horaConsulta.CustomFormat = "HH:mm";
            horaConsulta.ShowUpDown = true;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.LimpaCampos(this.panelFormulario.Controls);

        }

        public void LimpaCampos(Control.ControlCollection textBoxs)
        {
            foreach (Control txt in textBoxs)
            {
                if (txt.GetType() == typeof(TextBox))
                {
                    txt.Text = string.Empty;
                    this.Close();
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
           
            var dtaConsulta = dataConsulta.Value;
            var hrConsulta = horaConsulta.Value;
            //label5.Text = dataConsulta.ToString();
            //var data = dataConsulta2.
           // var horaConsulta = dataConsulta.Value;


            if (!VerificarDadosInseridos())
            {
                MessageBox.Show("Dados incorretos!");
            }
            else
            {
                try
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    connection.Open();
                   // MessageBox.Show(paciente.IdPaciente.ToString());
                    string queryInsertData = "INSERT INTO AgendamentoConsulta(horaProximaConsulta,dataProximaConsulta,idPaciente,idEnfermeiro)VALUES('" + string.Format("{0:00}", hrConsulta.Hour) + ":" + string.Format("{0:00}", hrConsulta.Minute) + "','" + dtaConsulta.Date + "','" + paciente.IdPaciente + "','" + enfermeiro.IdEnfermeiro + "');";


                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Consulta registada com Sucesso!");
                    this.Close();
                    connection.Close();
                }
                catch (SqlException excep)
                {

                    MessageBox.Show(excep.Message);
                }

            }
        }

        private Boolean VerificarDadosInseridos()
        {
            //  DateTime data = dataConsulta.Value.Date;
            //  string estaData = data.ToString();
            // var datadaConsulta =dataConsulta.Value;
            // string data = Convert.ToString(datadaConsulta);
            // DateTime data = dataConsulta.Value;
            // DateTime data = dataConsulta.Text;
           // MessageBox.Show(dataConsulta2.Text);

            //DateTime data = DateTime.ParseExact(dataConsulta.Text, "dd/MM/yyyy",null);
            //DateTime thisDay = DateTime.Today;


           /* System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-PT");
            DateTime dt = DateTime.Parse(dataConsulta.Text);*/
            /*if ((data - thisDay).TotalDays < 0)
            {
                MessageBox.Show("A data de marcacao da consulta não pode ser inferior a data de hoje!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            */
            /*  if (Convert.ToString(dataConsulta.Value)== string.Empty)
              {
                  MessageBox.Show("Campos Obrigatórios, por favor preencha os campos obrigatorios!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  return false;
              }*/


            return true;
        }
    }
}
