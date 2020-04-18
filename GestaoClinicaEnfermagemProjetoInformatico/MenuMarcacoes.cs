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
        private AgendamentoConsultaGridView agenda = new AgendamentoConsultaGridView();
        private FormMenu formMenu = null;
        public MenuMarcacoes(Enfermeiro enf, FormMenu formM)
        {
            InitializeComponent();
            enfermeiro = enf;
            formMenu = formM;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
           
            UpdateGridViewConsultas();
           
            dataConsulta.MinDate = DateTime.Today;
            dataConsulta.Enabled = false;
            dataConsultaAdiar.MinDate = DateTime.Today;
            horaConsultaAdiar.Format = DateTimePickerFormat.Custom;
            horaConsultaAdiar.CustomFormat = "HH:mm";
            horaConsultaAdiar.ShowUpDown = true;
        }

        private void btnAlteraPassword_Click(object sender, EventArgs e)
        {
            if (dataGridViewMarcacoes.Rows.Count > 1)
            {
               
                int i = dataGridViewMarcacoes.CurrentCell.RowIndex;
                //dataGridViewMarcacoes.CurrentRow.
                if (i != auxiliar.Count + 1)
                {
                   // if (dataGridViewMarcacoes.Rows[i].Cells[1].Value != null)
               // {
                    agenda = new AgendamentoConsultaGridView
                    {
                        horaProximaConsulta = dataGridViewMarcacoes.Rows[i].Cells[0].Value.ToString(),
                        dataProximaConsulta = dataGridViewMarcacoes.Rows[i].Cells[1].Value.ToString(),
                        NomePaciente = dataGridViewMarcacoes.Rows[i].Cells[2].Value.ToString(),
                        NifPaciente = Convert.ToDouble(dataGridViewMarcacoes.Rows[i].Cells[3].Value.ToString())
                    };

                    if (agenda != null)
                    {
                        string data = DateTime.ParseExact(agenda.dataProximaConsulta, "dd/MM/yyyy", null).ToString("MM/dd/yyyy");
                        Paciente paciente1 = ClasseAuxiliarBD.getPacienteByNif(agenda.NifPaciente);

                        var resposta = MessageBox.Show("Tem a certeza que deseja eliminar esta consulta?", "Eliminar Consulta!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resposta == DialogResult.Yes)
                        {
                            conn.Open();
                            string queryInsertData = "DELETE from AgendamentoConsulta WHERE IdEnfermeiro =@IdEnfermeiro AND IdPaciente = @IdPaciente AND dataProximaConsulta = @dataProximaConsulta AND horaProximaConsulta = @horaProximaConsulta ";
                            SqlCommand sqlCommand = new SqlCommand(queryInsertData, conn);
                            sqlCommand.Parameters.AddWithValue("@IdEnfermeiro", enfermeiro.IdEnfermeiro);
                            sqlCommand.Parameters.AddWithValue("@IdPaciente", paciente1.IdPaciente);
                            sqlCommand.Parameters.AddWithValue("@dataProximaConsulta", data);
                            sqlCommand.Parameters.AddWithValue("@horaProximaConsulta", agenda.horaProximaConsulta);


                            sqlCommand.ExecuteNonQuery();
                            MessageBox.Show("Consulta desmarcada com Sucesso!", "Consulta Desmarcada Consulta!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            conn.Close();
                            UpdateGridViewConsultas();
                            formMenu.UpdateGridViewConsultas();
                        }
                    }
                }
                var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = filtrosDePesquisa() };
                dataGridViewMarcacoes.DataSource = bindingSource1;
                agenda = null;

            }
            agenda = null;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dtaConsulta = dataConsultaAdiar.Value;
            DateTime hrConsulta = horaConsultaAdiar.Value;

            if (!VerificarDadosInseridos() || agenda== null)
            {
                MessageBox.Show("Dados incorretos!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Paciente paciente = ClasseAuxiliarBD.getPacienteByNif(agenda.NifPaciente);
                try
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

                    connection.Open();
                    string queryUpdateData = "UPDATE AgendamentoConsulta SET horaProximaConsulta = '" + string.Format("{0:00}", hrConsulta.Hour) + ":" + string.Format("{0:00}", hrConsulta.Minute) + "', dataProximaConsulta = '" + dtaConsulta.ToString("MM/dd/yyyy") + "' WHERE IdPaciente = '" + paciente.IdPaciente + "' AND horaProximaConsulta = '" + agenda.horaProximaConsulta + "' AND dataProximaConsulta = '" + DateTime.ParseExact(agenda.dataProximaConsulta, "dd/MM/yyyy", null).ToString("MM/dd/yyyy") + "';";
                    SqlCommand sqlCommand = new SqlCommand(queryUpdateData, connection);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Marcação alterada com Sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    UpdateGridViewConsultas();

                    var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = filtrosDePesquisa() };
                    dataGridViewMarcacoes.DataSource = bindingSource1;
                    formMenu.UpdateGridViewConsultas();

                }
                catch (SqlException excep)
                {
                    MessageBox.Show("Não foi possível adiar a consulta devido a erro interno" , excep.Message);
                }
            }
        }

        private Boolean VerificarDadosInseridos()
        {

            DateTime data = dataConsultaAdiar.Value;
            DateTime thisDay = DateTime.Now;

            DateTime horaSup = horaConsultaAdiar.Value;
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

            if (agendamentos == null) {
                MessageBox.Show("Não pode alterar uma consulta porque não tem um dia e/ou consulta selecionado!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = filtrosDePesquisa() };
            dataGridViewMarcacoes.DataSource = bindingSource1;
        }

        public void UpdateGridViewConsultas()
        {
            agendamentos.Clear();
         
            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select agendamento.dataProximaConsulta,  agendamento.horaProximaConsulta, p.Nome, p.Nif from AgendamentoConsulta agendamento INNER JOIN Paciente p ON agendamento.IdPaciente = p.IdPaciente WHERE agendamento.IdEnfermeiro =  " + enfermeiro.IdEnfermeiro + " AND ConsultaRealizada= 0 ORDER BY agendamento.horaProximaConsulta", conn);
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
            
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = auxiliar };
            dataGridViewMarcacoes.DataSource = bindingSource1;

            dataGridViewMarcacoes.Columns[0].HeaderText = "Hora Consulta";
            dataGridViewMarcacoes.Columns[1].HeaderText = "Data Consulta";
            dataGridViewMarcacoes.Columns[2].HeaderText = "Nome Utente";
            dataGridViewMarcacoes.Columns[3].HeaderText = "Nif Paciente";
            conn.Close();
            CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dataGridViewMarcacoes.DataSource];

            currencyManager1.SuspendBinding();
            //   dataGridViewMarcacoes.CurrentCell = null;
            //   dataGridViewMarcacoes.Rows[dataGridViewMarcacoes.Rows.Count -1].Disable = false;
        }

        private List<AgendamentoConsultaGridView> filtrosDePesquisa()
        {
            auxiliar = new List<AgendamentoConsultaGridView>();
            if ( txtNIF.Text != "" && txtNome.Text == "" && checkBox1.Checked == false)
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
            if (txtNIF.Text == "" && txtNome.Text != "" && checkBox1.Checked == false)
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
            if (txtNIF.Text != "" && txtNome.Text != "" && checkBox1.Checked == false)
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
            if (txtNIF.Text != "" && txtNome.Text != "" && checkBox1.Checked == true)
            {
                foreach (AgendamentoConsultaGridView agendamentoConsulta in agendamentos)
                {
                    DateTime data = DateTime.ParseExact(agendamentoConsulta.dataProximaConsulta, "dd/MM/yyyy", null);
                    if (agendamentoConsulta.NomePaciente.ToLower().Contains(txtNome.Text.ToLower()) && agendamentoConsulta.NifPaciente == Convert.ToDouble(txtNIF.Text) && data.ToShortDateString().Equals(dataConsulta.Value.ToString("dd/MM/yyyy")))
                    {
                        auxiliar.Add(agendamentoConsulta);
                    }
                }
                return auxiliar;
            }

            if (txtNIF.Text != "" && txtNome.Text == "" && checkBox1.Checked == true)
            {
                foreach (AgendamentoConsultaGridView agendamentoConsulta in agendamentos)
                {
                    DateTime data = DateTime.ParseExact(agendamentoConsulta.dataProximaConsulta, "dd/MM/yyyy", null);
                    if (agendamentoConsulta.NifPaciente == Convert.ToDouble(txtNIF.Text) && data.ToShortDateString().Equals(dataConsulta.Value.ToString("dd/MM/yyyy")))
                    {
                        auxiliar.Add(agendamentoConsulta);
                    }
                }
                return auxiliar;
            }

            if (txtNIF.Text == "" && txtNome.Text != "" && checkBox1.Checked == true)
            {
                foreach (AgendamentoConsultaGridView agendamentoConsulta in agendamentos)
                {
                    DateTime data = DateTime.ParseExact(agendamentoConsulta.dataProximaConsulta, "dd/MM/yyyy", null);
                    if (agendamentoConsulta.NomePaciente.ToLower().Contains(txtNome.Text.ToLower()) && data.ToShortDateString().Equals(dataConsulta.Value.ToString("dd/MM/yyyy")))
                    {
                        auxiliar.Add(agendamentoConsulta);
                    }
                }
                return auxiliar;
            }

            if (txtNIF.Text == "" && txtNome.Text == "" && checkBox1.Checked == true)
            {
                foreach (AgendamentoConsultaGridView agendamentoConsulta in agendamentos)
                {
                    DateTime data = DateTime.ParseExact(agendamentoConsulta.dataProximaConsulta, "dd/MM/yyyy", null);
                    if (data.ToShortDateString().Equals(dataConsulta.Value.ToString("dd/MM/yyyy")))
                    {
                        auxiliar.Add(agendamentoConsulta);
                    }
                }
                return auxiliar;
            }

            auxiliar = agendamentos;
            return auxiliar;
        }

        private void txtNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = filtrosDePesquisa() };
                dataGridViewMarcacoes.DataSource = bindingSource1;
            }
        }

        private void txtNIF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = filtrosDePesquisa() };
                dataGridViewMarcacoes.DataSource = bindingSource1;
            }
        }

        private void hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Hora " + DateTime.Now.ToLongTimeString();
            lblDia.Text = DateTime.Now.ToString("dddd, dd " + "'de '" + "MMMM" + "' de '" + "yyyy");
        }

        private void dataGridViewMarcacoes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                dataConsulta.Enabled = true;
            }
            else
            {
                dataConsulta.Enabled = false;
            }

            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = filtrosDePesquisa() };
            dataGridViewMarcacoes.DataSource = bindingSource1;

        }

        private void dataGridViewMarcacoes_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridViewMarcacoes.Rows.Count > 0 )
            {
                int i = dataGridViewMarcacoes.CurrentCell.RowIndex;
                if (i != auxiliar.Count +1)
                {
                    foreach (var marcar in auxiliar)
                    {
                        if (marcar.NifPaciente == Double.Parse(dataGridViewMarcacoes.Rows[i].Cells[3].Value.ToString()))
                        {
                            if (dataGridViewMarcacoes.Rows[i].Cells[1].Value != null)
                            {
                                if (marcar.dataProximaConsulta.Equals(dataGridViewMarcacoes.Rows[i].Cells[1].Value.ToString()))
                                {
                                    if (marcar.horaProximaConsulta.Equals(dataGridViewMarcacoes.Rows[i].Cells[0].Value.ToString()))
                                    {
                                        agenda = marcar;
                                    }
                                }
                            }
                        }
                    }
                }
                if (agenda != null)
                {
                    dataConsultaAdiar.MinDate = DateTime.Today;
                    //  dataConsultaAdiar.MinDate = DateTime.ParseExact(agenda.dataProximaConsulta, "dd/MM/yyyy", null);
                    dataConsultaAdiar.Value = DateTime.ParseExact(agenda.dataProximaConsulta, "dd/MM/yyyy", null);

                    horaConsultaAdiar.Value = DateTime.ParseExact(agenda.horaProximaConsulta, "HH:mm", null);
                }
            }
        }

        private void dataConsultaAdiar_ValueChanged(object sender, EventArgs e)
        {

        }

        private void MenuMarcacoes_Load(object sender, EventArgs e)
        {

        }
    }
}
