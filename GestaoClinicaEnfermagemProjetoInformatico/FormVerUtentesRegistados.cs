using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestaoClinicaEnfermagemProjetoInformatico
{
    public partial class FormVerUtentesRegistados : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private List<UtenteGridView> utentes = new List<UtenteGridView>();
        private List<UtenteGridView> auxiliar = new List<UtenteGridView>();

        public FormMenu formMenu = null;
        private Enfermeiro enfermeiro = null;
        private Paciente paciente = new Paciente();
        public FormVerUtentesRegistados(Enfermeiro enf, FormMenu formM)
        {
            InitializeComponent();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            enfermeiro = enf;
            formMenu = formM;
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


        private void panelFormulario_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void panelTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        DataTable dataTable = new DataTable("Paciente");
        private void FormVerUtentesRegistados_Load_1(object sender, EventArgs e)
        {
            
            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select * from Paciente p LEFT JOIN Profissao prof ON p.IdProfissao = prof.IdProfissao WHERE IdEnfermeiro =  @IdEnfermeiro", conn);
            cmd.Parameters.AddWithValue("@IdEnfermeiro", enfermeiro.IdEnfermeiro);
            SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {

                UtenteGridView utente = new UtenteGridView
                {
                    Nome = (string)reader["nome"],
                    DataNascimento = Convert.ToDateTime(reader["dataNascimento"]),
                   // Email = (string)reader["email"],
                    Email = ((reader["email"] == DBNull.Value) ? "" : (string)reader["email"]),

                    Contacto = Convert.ToDouble(reader["contacto"]),
                    Nif = Convert.ToInt32(reader["nif"]),
                    Profissao = ((reader["nomeProfissao"] == DBNull.Value) ? "" : (string)reader["nomeProfissao"]),

                    // Profissao = (string)reader["Profissao"],
                    Rua = (string)reader["Rua"],
                    NumeroCasa = ((reader["NumeroCasa"] == DBNull.Value) ? null : (int?)reader["NumeroCasa"]),
                    Andar = ((reader["Andar"] == DBNull.Value) ? "" : (string)reader["Andar"]),

                    codigoPostal = (reader["codPostalPrefixo"]) + "-" + (reader["codPostalSufixo"]),
                    bairroLocal = ((reader["bairroLocal"] == DBNull.Value) ? "" : (string)reader["bairroLocal"]),
                    designacao = ((reader["designacao"] == DBNull.Value) ? "" : (string)reader["designacao"]),
                    localidade = (string)reader["localidade"],
                    Acordo = (string)reader["Acordo"],

                    NomeSeguradora = ((reader["NomeSeguradora"] == DBNull.Value) ? "" : (string)reader["NomeSeguradora"]),
                    //NomeSeguradora = (string)reader["NomeSeguradora"] |,

                    NumeroApoliceSeguradora = ((reader["NumeroApoliceSeguradora"] == DBNull.Value) ? null : (int?)reader["NumeroApoliceSeguradora"]),
                    // NumeroApoliceSeguradora = (int)reader["NumeroApoliceSeguradora"],

                    NomeSubsistema = ((reader["NomeSubsistema"] == DBNull.Value) ? "" : (string)reader["NomeSubsistema"]),
                    // NomeSubsistema = (string)reader["NomeSubsistema"],

                    NumeroSubsistema = ((reader["NumeroSubsistema"] == DBNull.Value) ? null : (int?)reader["NumeroSubsistema"]),
                   // NumeroSubsistema = (int)reader["NumeroSubsistema"],

                    NumeroSNS = ((reader["NumeroSNS"] == DBNull.Value) ? null : (int?)reader["NumeroSNS"]),
                    //NumeroSNS = (int)reader["NumeroSNS"],

                    Sexo = (string)reader["Sexo"],
                    PlanoVacinacao = (string)reader["PlanoVacinacao"],
                };
                utentes.Add(utente);
            }
            string nome = txtNome.Text;
            UpdateDataGridView();
            auxiliar = utentes;
            dataGridViewUtentes.Columns[0].Width = dataGridViewUtentes.Columns[0].Width + 200;
            dataGridViewUtentes.Columns[2].Width = dataGridViewUtentes.Columns[2].Width + 80;
            dataGridViewUtentes.Columns[6].Width = dataGridViewUtentes.Columns[6].Width + 150;
            conn.Close();
        }

        private void hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Hora " + DateTime.Now.ToLongTimeString();
            lblDia.Text = DateTime.Now.ToString("dddd, dd " + "'de '" + "MMMM" + "' de '" + "yyyy");

        }

        private void txtNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridViewUtentes.DataSource = filtrosDePesquisa();
            }
        }

        private void txtNIF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridViewUtentes.DataSource = filtrosDePesquisa();
            }
        }

        
        private List<UtenteGridView> filtrosDePesquisa()
        {
            auxiliar = new List<UtenteGridView>();
            if (txtNIF.Text != "" && txtNome.Text == "")
            {
                foreach (UtenteGridView utente in utentes)
                {
                    if (utente.Nif == Convert.ToInt32(txtNIF.Text))
                    {
                        auxiliar.Add(utente);
                    }
                }
                return auxiliar;
            }
           if (txtNIF.Text == "" && txtNome.Text != "")
            {
                foreach (UtenteGridView utente in utentes)
                {
                    if (utente.Nome.ToLower().Contains(txtNome.Text.ToLower()))
                    {
                        auxiliar.Add(utente);
                    }
                }
                return auxiliar;
            }
           if (txtNIF.Text != "" && txtNome.Text != "")
            {
                foreach (UtenteGridView utente in utentes)
                {
                    if (utente.Nome.ToLower().Contains(txtNome.Text.ToLower()) && utente.Nif == Convert.ToInt32(txtNIF.Text))
                    {
                        auxiliar.Add(utente);
                    }
                }
               return auxiliar;
            }
            auxiliar = utentes;
            return utentes;
        }

        private void UpdateDataGridView()
        {
           // dataGridViewUtentes.DataSource = new List<UtenteGridView>();
            // dataGridViewUtentes.DataSource = utentes;
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = utentes };
            dataGridViewUtentes.DataSource = bindingSource1;
            dataGridViewUtentes.Columns[0].HeaderText = "Nome";
            dataGridViewUtentes.Columns[1].HeaderText = "Data de Nascimento";
            dataGridViewUtentes.Columns[2].HeaderText = "Email";
            dataGridViewUtentes.Columns[3].HeaderText = "Contacto";
            dataGridViewUtentes.Columns[4].HeaderText = "NIF";
            dataGridViewUtentes.Columns[5].HeaderText = "Profissão";
            dataGridViewUtentes.Columns[6].HeaderText = "Morada";
            dataGridViewUtentes.Columns[7].HeaderText = "Nr";
            dataGridViewUtentes.Columns[8].HeaderText = "Andar";
            dataGridViewUtentes.Columns[9].HeaderText = "Localidade";
            dataGridViewUtentes.Columns[10].HeaderText = "Bairro/Local";
            dataGridViewUtentes.Columns[11].HeaderText = "Código Postal";

            dataGridViewUtentes.Columns[12].HeaderText = "Designação";

            dataGridViewUtentes.Columns[13].HeaderText = "Acordo"; 
            dataGridViewUtentes.Columns[14].HeaderText = "Nome da Seguradora"; 
            dataGridViewUtentes.Columns[15].HeaderText = "Numero da Apolice da Seguradora";
            dataGridViewUtentes.Columns[16].HeaderText = "Nome do Subsistema";
            dataGridViewUtentes.Columns[17].HeaderText = "Número do Subsistema";
            dataGridViewUtentes.Columns[18].HeaderText = "Número do SNS";
            dataGridViewUtentes.Columns[19].HeaderText = "Sexo";
            dataGridViewUtentes.Columns[20].HeaderText = "Plano de Vacinacao";


            auxiliar = utentes;

            dataGridViewUtentes.Update();
            dataGridViewUtentes.Refresh();

        }

        public void LimpaCampos(Control.ControlCollection textBoxs)
        {
            foreach (Control txt in textBoxs)
            {
                if (txt.GetType() == typeof(TextBox))
                {
                    txt.Text = string.Empty;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridViewUtentes.Rows.Count > 1)
            {
                int i = dataGridViewUtentes.CurrentCell.RowIndex;
                UtenteGridView utente = null; ;


                //    int id = int.Parse(dataGridViewUtentes.Rows[i].Cells[4].Value.ToString());
                foreach (var ut in auxiliar)
                {
                    if (ut.Nif == Double.Parse(dataGridViewUtentes.Rows[i].Cells[4].Value.ToString()))
                    {
                        utente = ut;
                    }

                }
                conn.Open();
                com.Connection = conn;

                SqlCommand cmd = new SqlCommand("select * from Paciente p LEFT JOIN Profissao prof ON p.IdProfissao = prof.IdProfissao WHERE Nif = @NifPaciente", conn);
                cmd.Parameters.AddWithValue("@NifPaciente", utente.Nif);
                SqlDataReader reader = cmd.ExecuteReader();
                Paciente paciente = null;

                if (reader.Read())
                {
                    paciente = new Paciente
                    {
                        IdPaciente = (int)reader["IdPaciente"],
                        Nome = (string)reader["nome"],
                        DataNascimento = Convert.ToDateTime(reader["dataNascimento"]),
                        Email = ((reader["email"] == DBNull.Value) ? "" : (string)reader["email"]),
                        Contacto = Convert.ToDouble(reader["contacto"]),
                        Nif = Convert.ToInt32(reader["nif"]),
                        Profissao = ((reader["nomeProfissao"] == DBNull.Value) ? "" : (string)reader["nomeProfissao"]),
                        Rua = (string)reader["Rua"],
                        NumeroCasa = ((reader["NumeroCasa"] == DBNull.Value) ? null : (int?)reader["NumeroCasa"]),
                        Andar = ((reader["Andar"] == DBNull.Value) ? "" : (string)reader["Andar"]),
                        codigoPostal = (reader["codPostalPrefixo"]) + "-" + (reader["codPostalSufixo"]),
                        bairroLocal = ((reader["bairroLocal"] == DBNull.Value) ? "" : (string)reader["bairroLocal"]),
                        designacao = ((reader["designacao"] == DBNull.Value) ? "" : (string)reader["designacao"]),
                        localidade = (string)reader["localidade"],
                        IdEnfermeiro = (int)reader["IdEnfermeiro"],
                        Acordo = (string)reader["Acordo"],

                        NomeSeguradora = ((reader["NomeSeguradora"] == DBNull.Value) ? "" : (string)reader["NomeSeguradora"]),
                        //NomeSeguradora = (string)reader["NomeSeguradora"] |,

                        NumeroApoliceSeguradora = ((reader["NumeroApoliceSeguradora"] == DBNull.Value) ? null : (int?)reader["NumeroApoliceSeguradora"]),
                        // NumeroApoliceSeguradora = (int)reader["NumeroApoliceSeguradora"],

                        NomeSubsistema = ((reader["NomeSubsistema"] == DBNull.Value) ? "" : (string)reader["NomeSubsistema"]),
                        // NomeSubsistema = (string)reader["NomeSubsistema"],

                        NumeroSubsistema = ((reader["NumeroSubsistema"] == DBNull.Value) ? null : (int?)reader["NumeroSubsistema"]),
                        // NumeroSubsistema = (int)reader["NumeroSubsistema"],

                        NumeroSNS = ((reader["NumeroSNS"] == DBNull.Value) ? null : (int?)reader["NumeroSNS"]),
                        //NumeroSNS = (int)reader["NumeroSNS"],

                        Sexo = (string)reader["Sexo"],
                        PlanoVacinacao = (string)reader["PlanoVacinacao"]

                    };
                }

                conn.Close();
                IniciarConsultaSemMarcacao iniciarConsulta = new IniciarConsultaSemMarcacao(enfermeiro, paciente);
                iniciarConsulta.Show();

            }
            else
            {
                MessageBox.Show("Não é possivel iniciar uma consulta, pois não tem utentes associados!!!", "Informação!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

            private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridViewUtentes.Rows.Count > 1 )
            {
                int i = dataGridViewUtentes.CurrentCell.RowIndex;
                UtenteGridView utente = null; ;


                //    int id = int.Parse(dataGridViewUtentes.Rows[i].Cells[4].Value.ToString());
                foreach (var ut in auxiliar)
                {
                    if (ut.Nif == Double.Parse(dataGridViewUtentes.Rows[i].Cells[4].Value.ToString()))
                    {
                        utente = ut;
                    }
                }
                conn.Open();
                com.Connection = conn;

                SqlCommand cmd = new SqlCommand("select * from Paciente p LEFT JOIN Profissao prof ON p.IdProfissao = prof.IdProfissao WHERE Nif =  @NifPaciente", conn);
                cmd.Parameters.AddWithValue("@NifPaciente", utente.Nif);
                SqlDataReader reader = cmd.ExecuteReader();
                Paciente paciente = null;

                if (reader.Read())
                {
                    paciente = new Paciente
                    {
                        IdPaciente = (int)reader["IdPaciente"],
                        Nome = (string)reader["nome"],
                        DataNascimento = Convert.ToDateTime(reader["dataNascimento"]),
                        Email = ((reader["email"] == DBNull.Value) ? "" : (string)reader["email"]),
                        Contacto = Convert.ToDouble(reader["contacto"]),
                        Nif = Convert.ToInt32(reader["nif"]),
                        Profissao = ((reader["nomeProfissao"] == DBNull.Value) ? "" : (string)reader["nomeProfissao"]),
                        Rua = (string)reader["Rua"],
                        NumeroCasa = ((reader["NumeroCasa"] == DBNull.Value) ? null : (int?)reader["NumeroCasa"]),
                        Andar = ((reader["Andar"] == DBNull.Value) ? "" : (string)reader["Andar"]),
                        codigoPostal = (reader["codPostalPrefixo"]) + "-" + (reader["codPostalSufixo"]),
                        bairroLocal = ((reader["bairroLocal"] == DBNull.Value) ? "" : (string)reader["bairroLocal"]),
                        designacao = ((reader["designacao"] == DBNull.Value) ? "" : (string)reader["designacao"]),
                        localidade = (string)reader["localidade"],
                        IdEnfermeiro = (int)reader["IdEnfermeiro"],
                        Acordo = (string)reader["Acordo"],

                        NomeSeguradora = ((reader["NomeSeguradora"] == DBNull.Value) ? "" : (string)reader["NomeSeguradora"]),
                        //NomeSeguradora = (string)reader["NomeSeguradora"] |,

                        NumeroApoliceSeguradora = ((reader["NumeroApoliceSeguradora"] == DBNull.Value) ? null : (int?)reader["NumeroApoliceSeguradora"]),
                        // NumeroApoliceSeguradora = (int)reader["NumeroApoliceSeguradora"],

                        NomeSubsistema = ((reader["NomeSubsistema"] == DBNull.Value) ? "" : (string)reader["NomeSubsistema"]),
                        // NomeSubsistema = (string)reader["NomeSubsistema"],

                        NumeroSubsistema = ((reader["NumeroSubsistema"] == DBNull.Value) ? null : (int?)reader["NumeroSubsistema"]),
                        // NumeroSubsistema = (int)reader["NumeroSubsistema"],

                        NumeroSNS = ((reader["NumeroSNS"] == DBNull.Value) ? null : (int?)reader["NumeroSNS"]),
                        //NumeroSNS = (int)reader["NumeroSNS"],

                        Sexo = (string)reader["Sexo"],
                        PlanoVacinacao = (string)reader["PlanoVacinacao"]
                    };
                }

                conn.Close();

                RegistarConsulta registarConsulta = new RegistarConsulta(enfermeiro, paciente, this);
                registarConsulta.Show();
            }
            else
            {
                MessageBox.Show("Não é possivel registar uma consulta, pois não tem utentes associados!!!", "Informação!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridViewUtentes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridViewUtentes.Rows.Count > 1)
            {
                int i = dataGridViewUtentes.CurrentCell.RowIndex;
                UtenteGridView utente = null; ;


                //    int id = int.Parse(dataGridViewUtentes.Rows[i].Cells[4].Value.ToString());
                foreach (var ut in auxiliar)
                {
                    if (ut.Nif == Double.Parse(dataGridViewUtentes.Rows[i].Cells[4].Value.ToString()))
                    {
                        utente = ut;
                    }
                }
                conn.Open();
                com.Connection = conn;

                SqlCommand cmd = new SqlCommand("select * from Paciente p LEFT JOIN Profissao prof ON p.IdProfissao = prof.IdProfissao WHERE Nif =  @NifPaciente", conn);
                cmd.Parameters.AddWithValue("@NifPaciente", utente.Nif);
                SqlDataReader reader = cmd.ExecuteReader();
                Paciente paciente = null;

                if (reader.Read())
                {
                    paciente = new Paciente
                    {
                        IdPaciente = (int)reader["IdPaciente"],
                        Nome = (string)reader["nome"],
                        DataNascimento = Convert.ToDateTime(reader["dataNascimento"]),
                        Email = ((reader["email"] == DBNull.Value) ? "" : (string)reader["email"]),
                        Contacto = Convert.ToDouble(reader["contacto"]),
                        Nif = Convert.ToInt32(reader["nif"]),
                        Profissao = ((reader["nomeProfissao"] == DBNull.Value) ? "" : (string)reader["nomeProfissao"]),
                        Rua = (string)reader["Rua"],
                        NumeroCasa = ((reader["NumeroCasa"] == DBNull.Value) ? null : (int?)reader["NumeroCasa"]),
                        Andar = ((reader["Andar"] == DBNull.Value) ? "" : (string)reader["Andar"]),

                        codigoPostal = (reader["codPostalPrefixo"]) + "-" + (reader["codPostalSufixo"]),
                        bairroLocal = ((reader["bairroLocal"] == DBNull.Value) ? "" : (string)reader["bairroLocal"]),
                        designacao = ((reader["designacao"] == DBNull.Value) ? "" : (string)reader["designacao"]),
                        localidade = (string)reader["localidade"],
                        IdEnfermeiro = (int)reader["IdEnfermeiro"],
                        Acordo = (string)reader["Acordo"],

                        NomeSeguradora = ((reader["NomeSeguradora"] == DBNull.Value) ? "" : (string)reader["NomeSeguradora"]),
                        //NomeSeguradora = (string)reader["NomeSeguradora"] |,

                        NumeroApoliceSeguradora = ((reader["NumeroApoliceSeguradora"] == DBNull.Value) ? null : (int?)reader["NumeroApoliceSeguradora"]),
                        // NumeroApoliceSeguradora = (int)reader["NumeroApoliceSeguradora"],

                        NomeSubsistema = ((reader["NomeSubsistema"] == DBNull.Value) ? "" : (string)reader["NomeSubsistema"]),
                        // NomeSubsistema = (string)reader["NomeSubsistema"],

                        NumeroSubsistema = ((reader["NumeroSubsistema"] == DBNull.Value) ? null : (int?)reader["NumeroSubsistema"]),
                        // NumeroSubsistema = (int)reader["NumeroSubsistema"],

                        NumeroSNS = ((reader["NumeroSNS"] == DBNull.Value) ? null : (int?)reader["NumeroSNS"]),
                        //NumeroSNS = (int)reader["NumeroSNS"],

                        Sexo = (string)reader["Sexo"],
                        PlanoVacinacao = (string)reader["PlanoVacinacao"]
                    };
                }

                conn.Close();

                EditUtente editar = new EditUtente(enfermeiro, paciente, this);
                editar.Show();
            }
            else 
            {
                MessageBox.Show("Não é possível editar um utente, pois não tem utentes associados!!!", "Informação!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void UpdateUtentes() 
        {
            conn.Open();
            com.Connection = conn;
            utentes = new List<UtenteGridView>();
            SqlCommand cmd = new SqlCommand("select * from Paciente p LEFT JOIN Profissao prof ON p.IdProfissao = prof.IdProfissao WHERE IdEnfermeiro =  @IdEnfermeiro", conn);
            cmd.Parameters.AddWithValue("@IdEnfermeiro", enfermeiro.IdEnfermeiro);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                UtenteGridView utente = new UtenteGridView
                {
                    Nome = (string)reader["nome"],
                    DataNascimento = Convert.ToDateTime(reader["dataNascimento"]),
                   // Email = (string)reader["email"],
                    Email = ((reader["email"] == DBNull.Value) ? "" : (string)reader["email"]),
                    Contacto = Convert.ToDouble(reader["contacto"]),
                    Nif = Convert.ToInt32(reader["nif"]),
                    Profissao = ((reader["nomeProfissao"] == DBNull.Value) ? "" : (string)reader["nomeProfissao"]),
                    Rua = (string)reader["Rua"],
                    NumeroCasa = ((reader["NumeroCasa"] == DBNull.Value) ? null : (int?)reader["NumeroCasa"]),
                    Andar = ((reader["Andar"] == DBNull.Value) ? "" : (string)reader["Andar"]),

                    codigoPostal = (reader["codPostalPrefixo"]) + "-" + (reader["codPostalSufixo"]),
                    bairroLocal = ((reader["bairroLocal"] == DBNull.Value) ? "" : (string)reader["bairroLocal"]),
                    designacao = ((reader["designacao"] == DBNull.Value) ? "" : (string)reader["designacao"]),
                    localidade = (string)reader["localidade"],
                    Acordo = (string)reader["Acordo"],

                    NomeSeguradora = ((reader["NomeSeguradora"] == DBNull.Value) ? "" : (string)reader["NomeSeguradora"]),
                    //NomeSeguradora = (string)reader["NomeSeguradora"] |,

                    NumeroApoliceSeguradora = ((reader["NumeroApoliceSeguradora"] == DBNull.Value) ? null : (int?)reader["NumeroApoliceSeguradora"]),
                    // NumeroApoliceSeguradora = (int)reader["NumeroApoliceSeguradora"],

                    NomeSubsistema = ((reader["NomeSubsistema"] == DBNull.Value) ? "" : (string)reader["NomeSubsistema"]),
                    // NomeSubsistema = (string)reader["NomeSubsistema"],

                    NumeroSubsistema = ((reader["NumeroSubsistema"] == DBNull.Value) ? null : (int?)reader["NumeroSubsistema"]),
                    // NumeroSubsistema = (int)reader["NumeroSubsistema"],

                    NumeroSNS = ((reader["NumeroSNS"] == DBNull.Value) ? null : (int?)reader["NumeroSNS"]),
                    //NumeroSNS = (int)reader["NumeroSNS"],

                    Sexo = (string)reader["Sexo"],
                    PlanoVacinacao = (string)reader["PlanoVacinacao"]

                };
                utentes.Add(utente);


            }
            string nome = txtNome.Text;
            UpdateDataGridView();
            auxiliar = utentes;

            conn.Close();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridViewUtentes.Rows.Count > 1)
            {
               // HistoricoPaciente historicoPaciente = new HistoricoPaciente();

                int i = dataGridViewUtentes.CurrentCell.RowIndex;
                UtenteGridView utente = null; ;

                foreach (var ut in auxiliar)
                {
                    if (ut.Nif == Double.Parse(dataGridViewUtentes.Rows[i].Cells[4].Value.ToString()))
                    {
                        utente = ut;
                    }
                }

                paciente = ClasseAuxiliarBD.getPacienteByNif(utente.Nif);

                AdicionarVisualizarDoencaPaciente adicionarVisualizarDoencaPaciente = new AdicionarVisualizarDoencaPaciente(paciente);
                adicionarVisualizarDoencaPaciente.Show();
            }
            else
            {
                MessageBox.Show("Não tem utentes associados para poder selecionar o histórico do mesmo", "Informação!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (dataGridViewUtentes.Rows.Count > 1)
            {
                // HistoricoPaciente historicoPaciente = new HistoricoPaciente();

                int i = dataGridViewUtentes.CurrentCell.RowIndex;
                UtenteGridView utente = null; ;

                foreach (var ut in auxiliar)
                {
                    if (ut.Nif == Double.Parse(dataGridViewUtentes.Rows[i].Cells[4].Value.ToString()))
                    {
                        utente = ut;
                    }
                }

                paciente = ClasseAuxiliarBD.getPacienteByNif(utente.Nif);

                VerDetalhesPaciente verConsultasPaciente = new VerDetalhesPaciente(paciente);
                verConsultasPaciente.Show();
            }
            else
            {
                MessageBox.Show("Não é possível ver os detalhes do utente, pois não tem utentes associados!!!", "Informação!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
