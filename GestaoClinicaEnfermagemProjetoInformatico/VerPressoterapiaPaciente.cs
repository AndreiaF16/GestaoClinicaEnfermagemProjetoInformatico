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
    public partial class VerPressoterapiaPaciente : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private List<PressoterapiaPaciente> pressoterapiaPaciente = new List<PressoterapiaPaciente>();
        public VerPressoterapiaPaciente(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        }

        private void VerPressoterapiaPaciente_Load(object sender, EventArgs e)
        {
            var bindingSource2 = new System.Windows.Forms.BindingSource { DataSource = pressoterapiaPaciente };
            dataGridViewAlgPaciente.DataSource = bindingSource2;
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

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void UpdateDataGridView()
        {
            try
            {
                pressoterapiaPaciente.Clear();
                conn.Open();
                com.Connection = conn;

                SqlCommand cmd = new SqlCommand("select data, membrosInferiores, membrosSuperiores, observacoes from Pressoterapia ORDER BY data asc", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string data = ((reader["data"] == DBNull.Value) ? "" : DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy"));

                    PressoterapiaPaciente pressoterapia = new PressoterapiaPaciente
                    {
                        data = data,
                        membrosInferiores = ((reader["membrosInferiores"] == DBNull.Value) ? "" : (string)reader["membrosInferiores"]),
                        membrosSuperiores = ((reader["membrosSuperiores"] == DBNull.Value) ? "" : (string)reader["membrosSuperiores"]),
                        observacoes = ((reader["observacoes"] == DBNull.Value) ? "" : (string)reader["observacoes"]),
                    };
                    pressoterapiaPaciente.Add(pressoterapia);
                }
                var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = pressoterapiaPaciente };
                dataGridViewAlgPaciente.DataSource = bindingSource1;
                dataGridViewAlgPaciente.Columns[0].HeaderText = "Data de Registo";
                dataGridViewAlgPaciente.Columns[1].HeaderText = "Membros Inferiores";
                dataGridViewAlgPaciente.Columns[2].HeaderText = "Membros Superiores";
                dataGridViewAlgPaciente.Columns[3].HeaderText = "Observações";

                conn.Close();
                dataGridViewAlgPaciente.Update();
                dataGridViewAlgPaciente.Refresh();
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
