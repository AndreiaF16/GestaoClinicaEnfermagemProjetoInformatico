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
                 // btnDefinicoes.Visible = true;
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

          /*  Login login = new Login();
            login.Show();
            this.Close();*/

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
                 //  btnDefinicoes.Visible = true;
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
            dataGridViewConsultas.DataSource = new List<AgendamentoConsultaGridView>();
            consultaAgendada.Clear();
            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select agendamento.horaProximaConsulta, agendamento.dataProximaConsulta, p.Nome, p.Nif from AgendamentoConsulta agendamento INNER JOIN Paciente p ON agendamento.IdPaciente = p.IdPaciente WHERE agendamento.IdEnfermeiro =  " + enfermeiro.IdEnfermeiro + " AND agendamento.dataProximaConsulta = '" + DateTime.Now.ToString("MM/dd/yyyy") + "' ORDER BY agendamento.horaProximaConsulta", conn);
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
            dataGridViewConsultas.DataSource = consultaAgendada;
            dataGridViewConsultas.Columns[0].HeaderText = "Hora Consulta";
            dataGridViewConsultas.Columns[1].HeaderText = "Data Consulta";
            dataGridViewConsultas.Columns[2].HeaderText = "Nome Utente";
            dataGridViewConsultas.Columns[3].HeaderText = "Nif";
            conn.Close();
        }
    }
}
