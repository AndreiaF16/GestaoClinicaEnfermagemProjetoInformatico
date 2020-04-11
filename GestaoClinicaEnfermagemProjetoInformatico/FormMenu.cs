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
    public partial class FormMenu : Form
    {
        private Enfermeiro enfermeiro = new Enfermeiro();
        UtenteGridView utente = new UtenteGridView();
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private List<AgendamentoConsultaGridView> consultaAgendada = new List<AgendamentoConsultaGridView>();
        private List<AgendamentoConsultaGridView> auxiliar = new List<AgendamentoConsultaGridView>();

        public FormMenu(Enfermeiro enf)
        {
           
            InitializeComponent();
            if (enf != null)
            {
                enfermeiro = enf;
                label1.Text = "Enfermeiro: " + enfermeiro.nome;
                
                if(enfermeiro.permissao == 1)
                {
                    btnAdmin.Visible = false;
                }
            }
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            FormAdmin form = new FormAdmin();
            form.Show();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void btnRegistarUtente_Click(object sender, EventArgs e)
        {
            FormRegistarUtente formRegistarUtente = new FormRegistarUtente(enfermeiro);
            formRegistarUtente.Show();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void buttonTerminarSessao_Click(object sender, EventArgs e)
        {
            var resposta = MessageBox.Show("Tem a certeza que deseja terminar sessão?", "Terminar Sessão!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resposta == DialogResult.Yes)
            {
                Login login = new Login();
                login.Show();
                this.Close();
            }
            
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            var resposta = MessageBox.Show("Tem a certeza que deseja sair da aplicação?", "Fechar Aplicação!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resposta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            FormAdmin formAdmin = new FormAdmin();
            formAdmin.Show();
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

        private void button1_Click(object sender, EventArgs e)
        {
            FormVerUtentesRegistados formVerUtentesRegistados = new FormVerUtentesRegistados(enfermeiro, this);
            formVerUtentesRegistados.Show();
        }

        private void panelFormulario_Paint(object sender, PaintEventArgs e)
        {

        }

        private void hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Hora " + DateTime.Now.ToLongTimeString();
            lblDia.Text = DateTime.Now.ToString("dddd, dd " + "'de '" + "MMMM" + "' de '" + "yyyy");
        }

        private void lblDia_Click(object sender, EventArgs e)
        {

        }

        private void lblHora_Click(object sender, EventArgs e)
        {

        }

        private void btnDefinicoes_Click(object sender, EventArgs e)
        {
            FormDefinicoesPessoais meuPerfil = new FormDefinicoesPessoais(enfermeiro, this);
            meuPerfil.Show();
        }

        public void updateLogedIn(Enfermeiro enf)
        {
            //prevensão se houver algum problema
            if (enf != null)
            {
                enfermeiro = enf;
                label1.Text = "Utilizador: " + enfermeiro.nome;

                if (enfermeiro.permissao == 1)
                {
                    btnAdmin.Visible = false;
                }
            }
            else 
            {
                MessageBox.Show("Houve um problema interno! \n Por favor volte a fazer login!");
                Login login = new Login();
                login.Show();
                this.Close();
            }
           
                
        }

        private void btnRegistarConsulta_Click(object sender, EventArgs e)
        {
           
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            UpdateGridViewConsultas();
        }

        public void UpdateGridViewConsultas() 
        {
           // dataGridViewConsultasHoje.DataSource = new List<AgendamentoConsultaGridView>();
            consultaAgendada.Clear();
            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select agendamento.horaProximaConsulta, agendamento.dataProximaConsulta, p.Nome, p.Nif from AgendamentoConsulta agendamento INNER JOIN Paciente p ON agendamento.IdPaciente = p.IdPaciente WHERE agendamento.IdEnfermeiro =  " + enfermeiro.IdEnfermeiro + " AND agendamento.dataProximaConsulta = '" + DateTime.Now.ToString("MM/dd/yyyy") + "' AND ConsultaRealizada= 0 ORDER BY agendamento.horaProximaConsulta", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string dataConsulta = DateTime.ParseExact(reader["dataProximaConsulta"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy");

                AgendamentoConsultaGridView agendamento = new AgendamentoConsultaGridView
                {
                    horaProximaConsulta = (string)reader["horaProximaConsulta"],
                    dataProximaConsulta = dataConsulta,
                    NomePaciente = (string)reader["Nome"],
                    NifPaciente = Convert.ToDouble(reader["Nif"]),
                };

                consultaAgendada.Add(agendamento);

            }
            auxiliar = consultaAgendada;
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = consultaAgendada };
            dataGridViewConsultasHoje.DataSource = bindingSource1;
           // dataGridViewConsultasHoje.DataSource = consultaAgendada;
            dataGridViewConsultasHoje.Columns[0].HeaderText = "Hora Consulta";
            dataGridViewConsultasHoje.Columns[1].HeaderText = "Data Consulta";
            dataGridViewConsultasHoje.Columns[2].HeaderText = "Nome Utente";
            dataGridViewConsultasHoje.Columns[3].HeaderText = "Nif";
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridViewConsultasHoje.Rows.Count > 0 )
            {
                int i = dataGridViewConsultasHoje.CurrentCell.RowIndex;
                AgendamentoConsultaGridView consultaAgendada = null; ;

                foreach (var ut in auxiliar)
                {
                    if (ut.NifPaciente == Double.Parse(dataGridViewConsultasHoje.Rows[i].Cells[3].Value.ToString()))
                    {
                        consultaAgendada = ut;
                    }

                }
                conn.Open();
                com.Connection = conn;

                SqlCommand cmd = new SqlCommand("select * from Paciente WHERE Nif =  " + consultaAgendada.NifPaciente, conn);

                SqlDataReader reader = cmd.ExecuteReader();
                Paciente paciente = null;

                if (reader.Read())
                {
                    paciente = new Paciente
                    {
                        IdPaciente = (int)reader["IdPaciente"],
                        Nome = (string)reader["nome"],
                        DataNascimento = Convert.ToDateTime(reader["dataNascimento"]),
                        Email = (string)reader["email"],
                        Contacto = Convert.ToDouble(reader["contacto"]),
                        Nif = Convert.ToDouble(reader["nif"]),
                        Profissao = (string)reader["Profissao"],
                        Rua = (string)reader["Rua"],
                        NumeroCasa = (int)reader["NumeroCasa"],
                        Andar = (string)reader["Andar"],
                        codPostalPrefixo = Convert.ToDouble(reader["codPostalPrefixo"]),
                        codPostalSufixo = Convert.ToDouble(reader["codPostalSufixo"]),
                        localidade = (string)reader["localidade"],
                        IdEnfermeiro = (int)reader["IdEnfermeiro"],
                    };
                }

                conn.Close();
                IniciarConsultaMarcada iniciarConsultaMarcada = new IniciarConsultaMarcada(enfermeiro, paciente, this, consultaAgendada);
                iniciarConsultaMarcada.Show();
            }
            else 
            {
                MessageBox.Show("Não é possivel iniciar uma consulta porque não tem consultas agendadas para hoje!!!");
            }
        }

        private List<AgendamentoConsultaGridView> filtrosDePesquisa()
        {
            auxiliar = new List<AgendamentoConsultaGridView>();
            if (txtNIF.Text != "" && txtNome.Text == "")
            {
                foreach (AgendamentoConsultaGridView consulta in consultaAgendada)
                {
                    if (consulta.NifPaciente == Convert.ToDouble(txtNIF.Text))
                    {
                        auxiliar.Add(consulta);
                    }
                }
                return auxiliar;
            }
            if (txtNIF.Text == "" && txtNome.Text != "")
            {
                foreach (AgendamentoConsultaGridView consulta in consultaAgendada)
                {
                    if (consulta.NomePaciente.ToLower().Contains(txtNome.Text.ToLower()))
                    {
                        auxiliar.Add(consulta);
                    }
                }
                return auxiliar;
            }
            if (txtNIF.Text != "" && txtNome.Text != "")
            {
                foreach (AgendamentoConsultaGridView consulta in consultaAgendada)
                {
                    if (consulta.NomePaciente.ToLower().Contains(txtNome.Text.ToLower()) && consulta.NifPaciente == Convert.ToDouble(txtNIF.Text))
                    {
                        auxiliar.Add(consulta);
                    }
                }
                return auxiliar;
            }
            auxiliar = consultaAgendada;
            return consultaAgendada;
        }

        private void txtNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridViewConsultasHoje.DataSource = filtrosDePesquisa();
            }
        }

        private void txtNIF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridViewConsultasHoje.DataSource = filtrosDePesquisa();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridViewConsultasHoje.Rows.Count > 0)
            {
                int i = dataGridViewConsultasHoje.CurrentCell.RowIndex;
                AgendamentoConsultaGridView consultaAgendada = null; ;

                foreach (var ut in auxiliar)
                {
                    if (ut.NifPaciente == Double.Parse(dataGridViewConsultasHoje.Rows[i].Cells[3].Value.ToString()))
                    {
                        consultaAgendada = ut;
                    }

                }
                conn.Open();
                com.Connection = conn;

                SqlCommand cmd = new SqlCommand("select * from Paciente WHERE Nif =  " + consultaAgendada.NifPaciente, conn);

                SqlDataReader reader = cmd.ExecuteReader();
                Paciente paciente = null;

                if (reader.Read())
                {
                    paciente = new Paciente
                    {
                        IdPaciente = (int)reader["IdPaciente"],
                        Nome = (string)reader["nome"],
                        DataNascimento = Convert.ToDateTime(reader["dataNascimento"]),
                        Email = (string)reader["email"],
                        Contacto = Convert.ToDouble(reader["contacto"]),
                        Nif = Convert.ToDouble(reader["nif"]),
                        Profissao = (string)reader["Profissao"],
                        Rua = (string)reader["Rua"],
                        NumeroCasa = (int)reader["NumeroCasa"],
                        Andar = (string)reader["Andar"],
                        codPostalPrefixo = Convert.ToDouble(reader["codPostalPrefixo"]),
                        codPostalSufixo = Convert.ToDouble(reader["codPostalSufixo"]),
                        localidade = (string)reader["localidade"],
                        IdEnfermeiro = (int)reader["IdEnfermeiro"],
                    };
                }

                conn.Close();

                MenuMarcacoes menu = new MenuMarcacoes(enfermeiro, this);
                menu.Show();
            }
            else
            {
                MenuMarcacoes menu = new MenuMarcacoes(enfermeiro, this);
                menu.Show();
            }
        }

        private void dataGridViewConsultas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnVerConcultasPorClientes_Click(object sender, EventArgs e)
        {      
            VerConsultasPorCliente verConsultasPorClientes = new VerConsultasPorCliente(enfermeiro);
            verConsultasPorClientes.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Doencas doencas = new Doencas(null);
            doencas.Show(); 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ainda não implementado, fazer!!!");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ainda não implementado, fazer!!!");
        }
    }
}
