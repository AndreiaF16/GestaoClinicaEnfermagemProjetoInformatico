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
    public partial class VerColocacaoDIU : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private List<ColocacaoDIUPaciente> colocacaoDIUPaciente = new List<ColocacaoDIUPaciente>();
        public VerColocacaoDIU(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        }

        private void VerColocacaoDIU_Load(object sender, EventArgs e)
        {
            var bindingSource2 = new System.Windows.Forms.BindingSource { DataSource = colocacaoDIUPaciente };
            dataGridViewColocacaoDIU.DataSource = bindingSource2;
            UpdateDataGridView();
        }

        private void btnFechar_Click(object sender, EventArgs e)
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

        public void UpdateDataGridView()
        {
            try
            {
                colocacaoDIUPaciente.Clear();
                conn.Open();
                com.Connection = conn;

                SqlCommand cmd = new SqlCommand("select data, dataColocacaoDIU, observacoes from ColocacaoDIU ORDER BY data asc", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string data = ((reader["data"] == DBNull.Value) ? "" : DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy"));
                    string dataColocacao = ((reader["dataColocacaoDIU"] == DBNull.Value) ? "" : DateTime.ParseExact(reader["dataColocacaoDIU"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy"));

                    ColocacaoDIUPaciente colocacaoDIU = new ColocacaoDIUPaciente
                    {
                        data = data,
                        dataColocacaoDIU = dataColocacao,
                        observacoes = ((reader["observacoes"] == DBNull.Value) ? "" : (string)reader["observacoes"]),
                    };
                    colocacaoDIUPaciente.Add(colocacaoDIU);
                }
                var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = colocacaoDIUPaciente };
                dataGridViewColocacaoDIU.DataSource = bindingSource1;
                dataGridViewColocacaoDIU.Columns[0].HeaderText = "Data de Registo";
                dataGridViewColocacaoDIU.Columns[1].HeaderText = "Data de Colocação DIU";
                dataGridViewColocacaoDIU.Columns[2].HeaderText = "Observações";

                conn.Close();
                dataGridViewColocacaoDIU.Update();
                dataGridViewColocacaoDIU.Refresh();
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
