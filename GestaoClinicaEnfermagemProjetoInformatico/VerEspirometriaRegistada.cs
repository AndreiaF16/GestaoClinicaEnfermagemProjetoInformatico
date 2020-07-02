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
    public partial class VerEspirometriaRegistada : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private ErrorProvider errorProvider = new ErrorProvider();
        private List<Espirometria> espirometria = new List<Espirometria>();
        
        public VerEspirometriaRegistada(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        private void VerEspirometriaRegistada_Load(object sender, EventArgs e)
        {
            var bindingSource2 = new System.Windows.Forms.BindingSource { DataSource = espirometria };
            dataGridViewEspirometria.DataSource = bindingSource2;
            UpdateDataGridView();
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

        private void hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Hora " + DateTime.Now.ToLongTimeString();
            lblDia.Text = DateTime.Now.ToString("dddd, dd " + "'de '" + "MMMM" + "' de '" + "yyyy");
        }

        public void UpdateDataGridView()
        {
            try
            {
                espirometria.Clear();
                conn.Open();
                com.Connection = conn;

                SqlCommand cmd = new SqlCommand("select data, fev, fvc, fr, caracteristicaSuperficial, caracteristicaProfunda, caracteristicaAdbominal, caracteristicaToracica, caracteristicaMista, escalaDor, observacoes  from Espirometria ORDER BY data asc", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string data = DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy");

                    Espirometria esp = new Espirometria
                    {

                        dataEspirometria = data,
                        fev = ((reader["fev"] == DBNull.Value) ? "" : (string)reader["fev"]),
                        fvc = ((reader["fvc"] == DBNull.Value) ? "" : (string)reader["fvc"]),
                        numerofr = ((reader["fr"] == DBNull.Value) ? null : (int?)reader["fr"]),
                        superficial = ((reader["caracteristicaSuperficial"] == DBNull.Value) ? "" : (string)reader["caracteristicaSuperficial"]),
                        profunda = ((reader["caracteristicaProfunda"] == DBNull.Value) ? "" : (string)reader["caracteristicaProfunda"]),
                        abdominal = ((reader["caracteristicaAdbominal"] == DBNull.Value) ? "" : (string)reader["caracteristicaAdbominal"]),
                        toracica = ((reader["caracteristicaToracica"] == DBNull.Value) ? "" : (string)reader["caracteristicaToracica"]),
                        mista = ((reader["caracteristicaMista"] == DBNull.Value) ? "" : (string)reader["caracteristicaMista"]),
                        escalaDor = ((reader["escalaDor"] == DBNull.Value) ? "" : (string)reader["escalaDor"]),
                        observacoes = ((reader["observacoes"] == DBNull.Value) ? "" : (string)reader["observacoes"]),

                    };
                    espirometria.Add(esp);
                }
                var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = espirometria };
                dataGridViewEspirometria.DataSource = bindingSource1;
                dataGridViewEspirometria.Columns[0].HeaderText = "Data da Espirometria";
                dataGridViewEspirometria.Columns[1].HeaderText = "FEV";
                dataGridViewEspirometria.Columns[2].HeaderText = "FVC";
                dataGridViewEspirometria.Columns[3].HeaderText = "FR";
                dataGridViewEspirometria.Columns[4].HeaderText = "Característica Superficial";
                dataGridViewEspirometria.Columns[5].HeaderText = "Característica Profunda";
                dataGridViewEspirometria.Columns[6].HeaderText = "Característica Abdominal";
                dataGridViewEspirometria.Columns[7].HeaderText = "Característica Toracica";
                dataGridViewEspirometria.Columns[8].HeaderText = "Característica Mista";
                dataGridViewEspirometria.Columns[9].HeaderText = "Dor";
                dataGridViewEspirometria.Columns[10].HeaderText = "Observações";

                conn.Close();
                dataGridViewEspirometria.Update();
                dataGridViewEspirometria.Refresh();
            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível visualizar os dados!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
