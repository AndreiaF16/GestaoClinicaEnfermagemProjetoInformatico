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
    public partial class AdicionarVisualizarCirurgiaPaciente : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private List<ComboBoxItem> cirurgias = new List<ComboBoxItem>();
        private List<ComboBoxItem> auxiliar = new List<ComboBoxItem>();
        private List<DoencaPaciente> cirurgiaPacientes = new List<DoencaPaciente>();
        private ErrorProvider errorProvider = new ErrorProvider();


        public AdicionarVisualizarCirurgiaPaciente(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            dataDiagnostico.MaxDate = DateTime.Today;
            dataDiagnostico.Value = DateTime.Today;
        }

        private void AdicionarVisualizarCirurgiaPaciente_Load(object sender, EventArgs e)
        {
            UpdateDataGridView();
            reiniciar();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Hora " + DateTime.Now.ToLongTimeString();
            lblDia.Text = DateTime.Now.ToString("dddd, dd " + "'de '" + "MMMM" + "' de '" + "yyyy");

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (VerificarDadosInseridos())
                {
                    int alergia = (comboBoxDoenca.SelectedItem as ComboBoxItem).Value;
                    DateTime data = dataDiagnostico.Value;
                    string observacoes = txtObservacoes.Text;

                    conn.Open();

                    string queryInsertData = "INSERT INTO CirurgiaPaciente(IdCirurgia,IdPaciente,data,observacoes) VALUES(@IdAlergia, @IdPaciente, @data, @observacoes);";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, conn);
                    sqlCommand.Parameters.AddWithValue("@IdAlergia", alergia);
                    sqlCommand.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
                    sqlCommand.Parameters.AddWithValue("@data", data.ToString("MM/dd/yyyy"));
                    sqlCommand.Parameters.AddWithValue("@observacoes", observacoes);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Cirurgia registada com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    limparCampos();
                    UpdateDataGridView();

                }
            }
            catch (SqlException)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível registar a cirurgia", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateDataGridView()
        {
            try
            {
                cirurgiaPacientes.Clear();
                conn.Open();
                com.Connection = conn;
                SqlCommand cmd = new SqlCommand("select cirurgia.Nome, cirurgiaP.data, cirurgiaP.observacoes from CirurgiaPaciente cirurgiaP JOIN Cirurgia cirurgia ON cirurgia.IdCirurgia = cirurgiaP.IdCirurgia WHERE IdPaciente = @IdPaciente ORDER BY cirurgiaP.data, cirurgia.Nome", conn);
                cmd.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string data = DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy");

                    DoencaPaciente doencaPaciente = new DoencaPaciente
                    {
                        nome = (string)reader["Nome"],
                        data = data,
                        observacoes = (string)reader["observacoes"],
                    };
                    cirurgiaPacientes.Add(doencaPaciente);
                }
                var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = cirurgiaPacientes };
                dataGridViewCirurgias.DataSource = bindingSource1;
                dataGridViewCirurgias.Columns[0].HeaderText = "Cirurgia";
                dataGridViewCirurgias.Columns[1].HeaderText = "Data de Diagnóstico";
                dataGridViewCirurgias.Columns[2].HeaderText = "Observações";

                conn.Close();
                dataGridViewCirurgias.Update();
                dataGridViewCirurgias.Refresh();
            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível selecionar as cirurgias da paciente!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            limparCampos();
            Cirurgias cirurgias = new Cirurgias(this);
            cirurgias.Show();
        }

        public void reiniciar()
        {
            try
            {
                cirurgias.Clear();
                comboBoxDoenca.Items.Clear();
                auxiliar.Clear();
                conn.Open();
                com.Connection = conn;
                SqlCommand cmd = new SqlCommand("select * from Cirurgia order by nome asc", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.Text = (string)reader["Nome"];
                    item.Value = (int)reader["IdCirurgia"];
                    comboBoxDoenca.Items.Add(item);
                    cirurgias.Add(item);
                }

                conn.Close();
            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível selecionar as cirurgias!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtProcurar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                comboBoxDoenca.Items.Clear();
                foreach (var pesquisa in filtrosDePesquisa())
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.Text = pesquisa.Text;
                    item.Value = pesquisa.Value;
                    comboBoxDoenca.Items.Add(item);
                }

            }
        }

        private List<ComboBoxItem> filtrosDePesquisa()
        {
            auxiliar = new List<ComboBoxItem>();
            if (txtProcurar.Text != "")
            {
                foreach (ComboBoxItem doenca in cirurgias)
                {
                    if (doenca.Text.ToLower().Contains(txtProcurar.Text.ToLower()))
                    {
                        auxiliar.Add(doenca);
                    }
                }
                return auxiliar;
            }
            auxiliar = cirurgias;
            return auxiliar;
        }

        private Boolean VerificarDadosInseridos()
        {
            string nome = comboBoxDoenca.Text;
            DateTime data = dataDiagnostico.Value;


            if (nome == string.Empty)
            {
                MessageBox.Show("Campo Obrigatório, por favor selecione a cirurgia!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (comboBoxDoenca.Text == string.Empty)
                {
                    errorProvider.SetError(this.comboBoxDoenca, "A cirurgia é obrigatório!");
                }
                else
                {
                    errorProvider.SetError(comboBoxDoenca, String.Empty);
                }
                return false;
            }

            if ((data - DateTime.Today).TotalDays > 0)
            {
                MessageBox.Show("A data da cirurgia tem de ser inferior ou igual à data de hoje!  \n Selecione outra data!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                conn.Open();
                com.Connection = conn;

                SqlCommand cmd = new SqlCommand("select * from CirurgiaPaciente WHERE IdPaciente = @IdPaciente order by data", conn);
                cmd.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DateTime dataRegisto = DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null);
                    int cirurgia = (comboBoxDoenca.SelectedItem as ComboBoxItem).Value;
                    if (dataDiagnostico.Value.ToShortDateString().Equals(dataRegisto.ToShortDateString()) && paciente.IdPaciente == (int)reader["IdPaciente"] && cirurgia == (int)reader["IdCirurgia"])
                    {
                        MessageBox.Show("Não é possível registar a cirurgia, porque já está um registo na data que selecionou.\nEscolha outra data ou outra cirurgia!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        conn.Close();
                        return false;
                    }

                }
                conn.Close();
            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível selecionar as cirurgias do paciente!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void limparCampos() 
        {
            errorProvider.Clear();
            txtProcurar.Text = "";
            txtObservacoes.Text = "";
            dataDiagnostico.Value = DateTime.Today;
            comboBoxDoenca.SelectedItem = null;
            comboBoxDoenca.Items.Clear();
            foreach (var pesquisa in filtrosDePesquisa())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Text = pesquisa.Text;
                item.Value = pesquisa.Value;
                comboBoxDoenca.Items.Add(item);
            }
        }
    }
  }
