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
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private FormVerUtentesRegistados formVerUtentesRegistados = null;
        public RegistarConsulta(Enfermeiro enf, Paciente pac, FormVerUtentesRegistados formVerUtentes)
        {
            InitializeComponent();
            enfermeiro = enf;
            paciente = pac;
            formVerUtentesRegistados = formVerUtentes;


            label1.Text = "Nome do Paciente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


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
            // DateTime dtaConsulta = DateTime.ParseExact(dataConsulta.Text, "dd/MM/yyyy", null);
            // DateTime hrConsulta = DateTime.ParseExact(horaConsulta.Text, "HH:mm", null);

             DateTime dtaConsulta = dataConsulta.Value;
             DateTime hrConsulta = horaConsulta.Value;

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
                    string queryInsertData = "INSERT INTO AgendamentoConsulta(horaProximaConsulta,dataProximaConsulta,idPaciente,idEnfermeiro)VALUES('" + string.Format("{0:00}", hrConsulta.Hour) + ":" + string.Format("{0:00}", hrConsulta.Minute) + "','" + dtaConsulta.ToString("MM/dd/yyyy") + "','" + paciente.IdPaciente + "','" + enfermeiro.IdEnfermeiro + "');";


                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Consulta registada com Sucesso!");
                    this.Close();
                    connection.Close();
                    formVerUtentesRegistados.formMenu.UpdateGridViewConsultas();
                }
                catch (SqlException excep)
                {

                    MessageBox.Show(excep.Message);
                }

            }
        }

        private Boolean VerificarDadosInseridos()
        {

             DateTime data = dataConsulta.Value;
             DateTime thisDay = DateTime.Now;

            DateTime horaSup = horaConsulta.Value;
           // DateTime thisDay = DateTime.Today;

            if ((data - DateTime.Today).TotalDays < 0)
             {
                MessageBox.Show("A data de marcação da consulta não pode ser inferior a data de hoje!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return false;
             }

            else if (horaSup.Hour < thisDay.Hour)
            {

                MessageBox.Show("A hora de marcação da consulta não pode ser inferior a hora atual!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (horaSup.Hour == thisDay.Hour && horaSup.Minute <= thisDay.Minute)
                {
                MessageBox.Show("A hora de marcação da consulta não pode ser inferior a hora atual!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select * from AgendamentoConsulta WHERE IdEnfermeiro =  " + enfermeiro.IdEnfermeiro, conn);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string hora = (string)reader["horaProximaConsulta"];
                DateTime dataConsulta = DateTime.ParseExact(reader["dataProximaConsulta"].ToString(), "dd/MM/yyyy HH:mm:ss", null);

               // DateTime hrConsulta = DateTime.ParseExact(reader["horaProximaConsulta"].ToString(), "HH:mm", null);

                if (data.ToShortDateString().Equals(dataConsulta.ToShortDateString()) && hora.Equals(string.Format("{0:00}", horaSup.Hour) + ":" + string.Format("{0:00}", horaSup.Minute)))
                {
                    MessageBox.Show("O horário que pretende marcar a consulta está indisponível, já existe consulta nesse momento. Tende outra data e/ou outra hora.");
                    conn.Close();
                    return false;
                }
               
            }
            conn.Close();
            return true;
        }
    }
}
