﻿using System;
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
    public partial class VerLocalizacaoDorTratamentos : Form
    {
        private Paciente paciente = new Paciente();
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private List<LocalizacaoDorPaciente> localizacaoDorPacientes = new List<LocalizacaoDorPaciente>();

        public VerLocalizacaoDorTratamentos(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VerLocalizacaoDorTratamentos_Load(object sender, EventArgs e)
        {
            try
            {
                LocalizacaoDorPaciente localizacaoDorPaciente = new LocalizacaoDorPaciente();

                conn.Open();
                com.Connection = conn;

                SqlCommand cmd = new SqlCommand("select * from LocalizacaoDorTratamento WHERE IdPaciente = @IdPaciente", conn);
                cmd.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    localizacaoDorPaciente = new LocalizacaoDorPaciente
                    {
                        data = Convert.ToDateTime(reader["data"]),
                        localizacao = ((reader["localizacao"] == DBNull.Value) ? "" : (string)reader["localizacao"]),
                        observacoes = ((reader["observacoes"] == DBNull.Value) ? "" : (string)reader["observacoes"]),

                    };
                    localizacaoDorPacientes.Add(localizacaoDorPaciente);

                }
                conn.Close();
                UpdateDataGridView();
                var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = localizacaoDorPacientes };
                dataGridViewLocalizacaoDor.DataSource = bindingSource1;
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

        private void UpdateDataGridView()
        {

            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = localizacaoDorPacientes };
            dataGridViewLocalizacaoDor.DataSource = bindingSource1;


            dataGridViewLocalizacaoDor.Columns[0].HeaderText = "Data de Registo";
            dataGridViewLocalizacaoDor.Columns[1].HeaderText = "Localização Dor";
            dataGridViewLocalizacaoDor.Columns[2].HeaderText = "Observações";

        }



        private void pictureBox4_Click(object sender, EventArgs e)
        {
            var resposta = MessageBox.Show("Tem a certeza que deseja sair da aplicação?", "Fechar Aplicação!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resposta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Hora " + DateTime.Now.ToLongTimeString();
            lblDia.Text = DateTime.Now.ToString("dddd, dd " + "'de '" + "MMMM" + "' de '" + "yyyy");
        }
    }
}
