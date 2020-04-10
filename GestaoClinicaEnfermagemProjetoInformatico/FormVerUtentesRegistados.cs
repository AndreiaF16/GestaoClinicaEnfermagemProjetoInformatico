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

            SqlCommand cmd = new SqlCommand("select * from Paciente WHERE IdEnfermeiro =  " +enfermeiro.IdEnfermeiro , conn);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                UtenteGridView utente = new UtenteGridView
                {
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

                };
                utentes.Add(utente);
                

            }
            string nome = txtNome.Text;
            UpdateDataGridView();
            auxiliar = utentes;

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
                    if (utente.Nif == Convert.ToDouble(txtNIF.Text))
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
                    if (utente.Nome.ToLower().Contains(txtNome.Text.ToLower()) && utente.Nif == Convert.ToDouble(txtNIF.Text))
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
            dataGridViewUtentes.Columns[9].HeaderText = "Código";
            dataGridViewUtentes.Columns[10].HeaderText = "Postal";
            dataGridViewUtentes.Columns[11].HeaderText = "Localidade";
              dataGridViewUtentes.Columns[0].Width = dataGridViewUtentes.Columns[0].Width + 200;
            dataGridViewUtentes.Columns[2].Width = dataGridViewUtentes.Columns[2].Width + 80;
            dataGridViewUtentes.Columns[6].Width = dataGridViewUtentes.Columns[6].Width + 150;

      
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
            if (dataGridViewUtentes.SelectedRows.Count > 0 && dataGridViewUtentes.Rows[dataGridViewUtentes.CurrentCell.RowIndex].Cells[0].Value.ToString() == "")
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

                SqlCommand cmd = new SqlCommand("select * from Paciente WHERE Nif =  " + utente.Nif, conn);

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
                IniciarConsultaSemMarcacao iniciarConsulta = new IniciarConsultaSemMarcacao(enfermeiro, paciente);
                iniciarConsulta.Show();

            }
            else
            {
                MessageBox.Show("Não é possivel iniciar uma consulta porque não tem utentes associados!!!");
            }
        }

            private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridViewUtentes.Rows.Count > 0 && dataGridViewUtentes.Rows[dataGridViewUtentes.CurrentCell.RowIndex].Cells[0].Value.ToString() == "")
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

                SqlCommand cmd = new SqlCommand("select * from Paciente WHERE Nif =  " + utente.Nif, conn);

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

                RegistarConsulta registarConsulta = new RegistarConsulta(enfermeiro, paciente, this);
                registarConsulta.Show();
            }
            {
                MessageBox.Show("Não é possivel registar uma consulta porque não tem utentes associados!!!");
            }
        }

        private void dataGridViewUtentes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            EditUtente editar = new EditUtente(enfermeiro, this);
            editar.Show();
        }

        public void UpdateUtentes() 
        {
            conn.Open();
            com.Connection = conn;
            utentes = new List<UtenteGridView>();
            SqlCommand cmd = new SqlCommand("select * from Paciente WHERE IdEnfermeiro =  " + enfermeiro.IdEnfermeiro, conn);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                UtenteGridView utente = new UtenteGridView
                {
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
            if (dataGridViewUtentes.SelectedRows.Count > 0 && dataGridViewUtentes.Rows[dataGridViewUtentes.CurrentCell.RowIndex].Cells[0].Value.ToString() == "")
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

                VisualizarHistoricoPaciente verHistoricoPaciente = new VisualizarHistoricoPaciente(paciente);
                verHistoricoPaciente.Show();
            }
            else
            {
                MessageBox.Show("Não tem utentes associados para poder selecionar o historico do mesmo");
            }
        }
    }
}
