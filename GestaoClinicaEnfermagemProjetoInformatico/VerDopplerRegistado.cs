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
    public partial class VerDopplerRegistado : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private ErrorProvider errorProvider = new ErrorProvider();
        private List<DopplerFetal> doplerFetal = new List<DopplerFetal>();
        public VerDopplerRegistado(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        }

        private void VerDoplerRegistado_Load(object sender, EventArgs e)
        {
            var bindingSource2 = new System.Windows.Forms.BindingSource { DataSource = doplerFetal };
            dataGridViewDopler.DataSource = bindingSource2;
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
                doplerFetal.Clear();
                conn.Open();
                com.Connection = conn;

                SqlCommand cmd = new SqlCommand("select dataRegisto, ig, dppData, dppcData, primeiraEcografia, escalaDor, observacoes from DopplerFetal ORDER BY dataRegisto asc, ig asc, dppData asc, dppcData asc", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string dataR = ((reader["dataRegisto"] == DBNull.Value) ? "" : DateTime.ParseExact(reader["dataRegisto"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy"));
                    string datadpp = ((reader["dppData"] == DBNull.Value) ? "" : DateTime.ParseExact(reader["dppData"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy"));
                    string datadppc = ((reader["dppcData"] == DBNull.Value) ? "" : DateTime.ParseExact(reader["dppcData"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy"));
                    string dataEcografia = ((reader["primeiraEcografia"] == DBNull.Value) ? "" : DateTime.ParseExact(reader["primeiraEcografia"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy"));

                    DopplerFetal dp = new DopplerFetal
                    {
                        dataRegisto = dataR,
                        ig = ((reader["ig"] == DBNull.Value) ? null : (int?)reader["ig"]),
                        ddp = datadpp,
                        dppc = datadppc,
                        ecografia = dataEcografia,
                        escalaDor = ((reader["escalaDor"] == DBNull.Value) ? "" : (string)reader["escalaDor"]),
                        observacoes = ((reader["observacoes"] == DBNull.Value) ? "" : (string)reader["observacoes"]),

                    };
                    doplerFetal.Add(dp);
                }
                var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = doplerFetal };
                dataGridViewDopler.DataSource = bindingSource1;
                dataGridViewDopler.Columns[0].HeaderText = "Data de Registo";
                dataGridViewDopler.Columns[1].HeaderText = "IG";
                dataGridViewDopler.Columns[2].HeaderText = "Data DPP";
                dataGridViewDopler.Columns[3].HeaderText = "Data DPPC";
                dataGridViewDopler.Columns[4].HeaderText = "Data 1ª Ecografia";
                dataGridViewDopler.Columns[5].HeaderText = "Dor";
                dataGridViewDopler.Columns[6].HeaderText = "Observações";

                conn.Close();
                dataGridViewDopler.Update();
                dataGridViewDopler.Refresh();
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
