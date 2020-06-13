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
    public partial class VerDoplerRegistado : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private ErrorProvider errorProvider = new ErrorProvider();
        private List<DoplerFetal> doplerFetal = new List<DoplerFetal>();
        public VerDoplerRegistado(Paciente pac)
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
            doplerFetal.Clear();
            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select ig, dppData, dppcData, primeiraEcografia, escalaDor, observacoes from DopletFetal ORDER BY IdDoplerFetal asc", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string datadpp = ((reader["dppData"] == DBNull.Value) ? "" : DateTime.ParseExact(reader["dppData"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy"));
                string datadppc = ((reader["dppcData"] == DBNull.Value) ? "" : DateTime.ParseExact(reader["dppcData"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy"));
                string dataEcografia = ((reader["primeiraEcografia"] == DBNull.Value) ? "" : DateTime.ParseExact(reader["primeiraEcografia"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy"));

              //  string dataEcografia = DateTime.ParseExact(reader["primeiraEcografia"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy");

                DoplerFetal dp = new DoplerFetal
                {

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
            dataGridViewDopler.Columns[0].HeaderText = "IG";
            dataGridViewDopler.Columns[1].HeaderText = "Data DPP";
            dataGridViewDopler.Columns[2].HeaderText = "Data DPPC";
            dataGridViewDopler.Columns[3].HeaderText = "Data 1ª Ecografia";
            dataGridViewDopler.Columns[4].HeaderText = "Dor";
            dataGridViewDopler.Columns[5].HeaderText = "Observações";

            conn.Close();
            dataGridViewDopler.Update();
            dataGridViewDopler.Refresh();
        }
    }
}
