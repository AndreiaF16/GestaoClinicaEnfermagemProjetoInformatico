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
    public partial class VerVariasAtitudes : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private List<VariasAtitudes> variasAtitudes = new List<VariasAtitudes>();
        public VerVariasAtitudes(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        }

        private void VerVariasAtitudes_Load(object sender, EventArgs e)
        {
            var bindingSource2 = new System.Windows.Forms.BindingSource { DataSource = variasAtitudes };
            dataGridViewVariasAtitudes.DataSource = bindingSource2;
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
                variasAtitudes.Clear();
                conn.Open();
                com.Connection = conn;

                SqlCommand cmd = new SqlCommand("select atitude.nomeAtitude, variasAtitudes.data from VariasAtitudes variasAtitudes LEFT JOIN Atitude atitude ON variasAtitudes.IdAtitude = atitude.IdAtitude WHERE variasAtitudes.IdPaciente = @IdPaciente ORDER by variasAtitudes.data asc", conn);
                cmd.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string data = ((reader["data"] == DBNull.Value) ? "" : DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy"));
                    VariasAtitudes variasAt = new VariasAtitudes
                    {
                        atitude = ((reader["nomeAtitude"] == DBNull.Value) ? "" : (string)reader["nomeAtitude"]),
                        data = data,

                    };
                    variasAtitudes.Add(variasAt);
                }
                var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = variasAtitudes };
                dataGridViewVariasAtitudes.DataSource = bindingSource1;
                dataGridViewVariasAtitudes.Columns[0].HeaderText = "Atitude Realizada";
                dataGridViewVariasAtitudes.Columns[1].HeaderText = "Data de Registo";

                conn.Close();
                dataGridViewVariasAtitudes.Update();
                dataGridViewVariasAtitudes.Refresh();
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
