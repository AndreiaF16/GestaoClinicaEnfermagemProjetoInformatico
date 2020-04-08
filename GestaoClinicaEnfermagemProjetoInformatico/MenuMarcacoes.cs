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
    public partial class MenuMarcacoes : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Enfermeiro enfermeiro = null;
        private List<AgendamentoConsultaGridView> auxiliar = new List<AgendamentoConsultaGridView>();
        private List<AgendamentoConsultaGridView> agendamentos = new List<AgendamentoConsultaGridView>();
        private Paciente paciente = null;
        private FormMenu formMenu = null;
        public MenuMarcacoes(Enfermeiro enf, Paciente pac, FormMenu formM)
        {
            InitializeComponent();
            enfermeiro = enf;
            paciente = pac;
            formMenu = formM;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            UpdateGridViewConsultas();
            dataConsulta.MinDate = DateTime.Today;

        }

        private void btnAlteraPassword_Click(object sender, EventArgs e)
        {
            int i = dataGridViewConsultas.CurrentCell.RowIndex;
            AgendamentoConsultaGridView agendamento = null;

            agendamento = new AgendamentoConsultaGridView
            {
                horaProximaConsulta = dataGridViewConsultas.Rows[i].Cells[0].Value.ToString(),
                dataProximaConsulta = dataGridViewConsultas.Rows[i].Cells[1].Value.ToString(),
                NomePaciente = dataGridViewConsultas.Rows[i].Cells[2].Value.ToString(),
                NifPaciente = Convert.ToDouble(dataGridViewConsultas.Rows[i].Cells[3].Value.ToString())


            };

            if (agendamento != null)
            {
                Paciente paciente1 = ClasseAuxiliarBD.getPacienteByNif(agendamento.NifPaciente);

                var resposta = MessageBox.Show("Tem a certeza que deseja eliminar esta consulta?", "Eliminar Consulta!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resposta == DialogResult.Yes)
                {                   
                    conn.Open();
                    string queryInsertData = "DELETE from AgendamentoConsulta WHERE IdEnfermeiro = " + enfermeiro.IdEnfermeiro + " AND IdPaciente = " + paciente1.IdPaciente + " AND dataProximaConsulta = '" + DateTime.ParseExact(agendamento.dataProximaConsulta, "dd/MM/yyyy", null).ToString("MM/dd/yyyy") + "' AND horaProximaConsulta = '" + agendamento.horaProximaConsulta + "';";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, conn);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Agendamento de consulta eliminado com Sucesso!");
                    conn.Close();
                    UpdateGridViewConsultas();
                }
                formMenu.UpdateGridViewConsultas();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EditarMarcacoes editarMarcacoes = new EditarMarcacoes();
            editarMarcacoes.Show();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Minimized;

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var resposta = MessageBox.Show("Tem a certeza que deseja sair da aplicação?", "Fechar Aplicação!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resposta == DialogResult.Yes)
            {
                Application.Exit();
            }


        }

        private void dataConsulta_ValueChanged(object sender, EventArgs e)
        {
            UpdateGridViewConsultas();

        }

        public void UpdateGridViewConsultas()
        {
            agendamentos.Clear();
            dataGridViewConsultas.DataSource = new List<AgendamentoConsultaGridView>();

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
                    horaProximaConsulta = (string)reader["horaProximaConsulta"],
                    NomePaciente = (string)reader["Nome"],
                    NifPaciente = Convert.ToDouble(reader["Nif"]),
                };
                agendamentos.Add(agendamento);
            }
            auxiliar = agendamentos;

            dataGridViewConsultas.DataSource = filtrosDePesquisa();
            dataGridViewConsultas.Columns[0].HeaderText = "Hora Consulta";
            dataGridViewConsultas.Columns[1].HeaderText = "Data Consulta";
            dataGridViewConsultas.Columns[2].HeaderText = "Nome Utente";
            dataGridViewConsultas.Columns[3].HeaderText = "Nif Paciente";
          //  auxiliar = agendamentos;
            conn.Close();
            filtrosDePesquisa();
        }

        private List<AgendamentoConsultaGridView> filtrosDePesquisa()
        {
            auxiliar = new List<AgendamentoConsultaGridView>();
            if ( txtNIF.Text != "" && txtNome.Text == "")
            {
                foreach (AgendamentoConsultaGridView agendamentoConsulta in agendamentos)
                {
                    if (agendamentoConsulta.NifPaciente == Convert.ToDouble(txtNIF.Text))
                    {
                        auxiliar.Add(agendamentoConsulta);
                    }
                }
                return auxiliar;
            }
            if (txtNIF.Text == "" && txtNome.Text != "")
            {
                foreach (AgendamentoConsultaGridView agendamentoConsulta in agendamentos)
                {
                    if (agendamentoConsulta.NomePaciente.ToLower().Contains(txtNome.Text.ToLower()))
                    {
                        auxiliar.Add(agendamentoConsulta);
                    }
                }
                return auxiliar;
            }
            if (txtNIF.Text != "" && txtNome.Text != "")
            {
                foreach (AgendamentoConsultaGridView agendamentoConsulta in agendamentos)
                {
                    if (agendamentoConsulta.NomePaciente.ToLower().Contains(txtNome.Text.ToLower()) && agendamentoConsulta.NifPaciente == Convert.ToDouble(txtNIF.Text))
                    {
                        auxiliar.Add(agendamentoConsulta);
                    }
                }
                return auxiliar;
            }
            auxiliar = agendamentos;
            return agendamentos;
        }

        private void txtNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridViewConsultas.DataSource = filtrosDePesquisa();
            }
        }

        private void txtNIF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridViewConsultas.DataSource = filtrosDePesquisa();
            }
        }

        private void hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Hora " + DateTime.Now.ToLongTimeString();
            lblDia.Text = DateTime.Now.ToString("dddd, dd " + "'de '" + "MMMM" + "' de '" + "yyyy");
        }

        private void dataGridViewConsultas_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            
        }
    }
}
