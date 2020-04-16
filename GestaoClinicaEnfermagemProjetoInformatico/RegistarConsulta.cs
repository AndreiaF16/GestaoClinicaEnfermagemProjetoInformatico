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
            dataConsulta.MinDate = DateTime.Today;


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

            UpdateGridViewConsultas();
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
             DateTime dtaConsulta = dataConsulta.Value;
             DateTime hrConsulta = horaConsulta.Value;

            if (!VerificarDadosInseridos())
            {
                MessageBox.Show("Dados incorretos!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    connection.Open();
                    string queryInsertData = "INSERT INTO AgendamentoConsulta(horaProximaConsulta,dataProximaConsulta,idPaciente,idEnfermeiro)VALUES(@horaProximaConsulta,@dataProximaConsulta,@idPaciente,@idEnfermeiro)";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                    sqlCommand.Parameters.AddWithValue("@horaProximaConsulta",string.Format("{0:00}", hrConsulta.Hour) + ":" + string.Format("{0:00}", hrConsulta.Minute));
                    sqlCommand.Parameters.AddWithValue("@dataProximaConsulta", dtaConsulta.ToString("MM/dd/yyyy"));
                    sqlCommand.Parameters.AddWithValue("@idPaciente",paciente.IdPaciente.ToString());
                    sqlCommand.Parameters.AddWithValue("@idEnfermeiro", enfermeiro.IdEnfermeiro.ToString());
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Consulta registada com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // this.Close();
                    connection.Close();
                    UpdateGridViewConsultas();

                    formVerUtentesRegistados.formMenu.UpdateGridViewConsultas();
                }
                catch (SqlException excep)
                {
                    // MessageBox.Show(excep.Message);

                      MessageBox.Show("Por erro interno é impossível registar a consulta", excep.Message);
                }

            }
        }

        private Boolean VerificarDadosInseridos()
        {

             DateTime data = dataConsulta.Value;
             DateTime thisDay = DateTime.Now;

            DateTime horaSup = horaConsulta.Value;
            int var = (int)((data - DateTime.Today).TotalDays);
           
            if (var < 0)
             {
                MessageBox.Show("A data de marcação da consulta não pode ser inferior a data de hoje!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return false;
             }
            
            else if ((var == 0) && horaSup.Hour < thisDay.Hour)
            {

                MessageBox.Show("A hora de marcação da consulta não pode ser inferior a hora atual!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if ((var == 0) && horaSup.Hour == thisDay.Hour && horaSup.Minute <= thisDay.Minute)
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

        public void UpdateGridViewConsultas()
        {
           List<AgendamentoConsultaGridView> consultasAgendadas = new List<AgendamentoConsultaGridView>();
            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select agendamento.dataProximaConsulta,  agendamento.horaProximaConsulta, p.Nome, p.Nif from AgendamentoConsulta agendamento INNER JOIN Paciente p ON agendamento.IdPaciente = p.IdPaciente WHERE agendamento.IdEnfermeiro =  " + enfermeiro.IdEnfermeiro + " AND agendamento.dataProximaConsulta = '" + dataConsulta.Value.ToString("MM/dd/yyyy") + "' AND ConsultaRealizada= 0 ORDER BY agendamento.horaProximaConsulta", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string dataConsulta = DateTime.ParseExact(reader["dataProximaConsulta"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy");

                AgendamentoConsultaGridView agendamento = new AgendamentoConsultaGridView
                {
                    dataProximaConsulta = dataConsulta,
                    horaProximaConsulta =(string)reader["horaProximaConsulta"],
                    NomePaciente = (string)reader["Nome"],
                    NifPaciente = Convert.ToDouble(reader["Nif"]),
                };
                consultasAgendadas.Add(agendamento); 
            }
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = consultasAgendadas };
            dataGridViewConsultas.DataSource = bindingSource1;
            dataGridViewConsultas.Columns[0].HeaderText = "Hora Consulta";
            dataGridViewConsultas.Columns[1].HeaderText = "Data Consulta";
            dataGridViewConsultas.Columns[2].HeaderText = "Nome Utente";
            dataGridViewConsultas.Columns[3].HeaderText = "Nif Paciente";
            dataGridViewConsultas.Columns[0].Width = dataGridViewConsultas.Columns[0].Width - 100;
            dataGridViewConsultas.Columns[1].Width = dataGridViewConsultas.Columns[1].Width - 100;
            dataGridViewConsultas.Columns[2].Width = dataGridViewConsultas.Columns[2].Width + 150;

            conn.Close();
        }

        private void dataConsulta_ValueChanged(object sender, EventArgs e)
        {
            UpdateGridViewConsultas();
        }
    }
}
