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
    public partial class AdicionarVisualizarDoencaPaciente : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Paciente paciente = new Paciente();
        private List<ComboBoxItem> doencas = new List<ComboBoxItem>();
        private List<ComboBoxItem> auxiliar = new List<ComboBoxItem>();
        private List<DoencaPaciente> doencaPacientes = new List<DoencaPaciente>();
        private ErrorProvider errorProvider = new ErrorProvider();

        public AdicionarVisualizarDoencaPaciente(Paciente pac)
        {
            InitializeComponent();
            paciente = pac;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            dataDiagnostico.MaxDate = DateTime.Today;
            dataDiagnostico.Value = DateTime.Today;
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AdicionarVisualizarDoencaPaciente_Load(object sender, EventArgs e)
        {
           UpdateDataGridView();
            reiniciar();
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

                    int doenca = (comboBoxDoenca.SelectedItem as ComboBoxItem).Value;
                    DateTime data = dataDiagnostico.Value;
                    string observacoes = txtObservacoes.Text;


                    conn.Open();

                    string queryInsertData = "INSERT INTO DoencaPaciente(IdDoenca,IdPaciente,data,observacoes) VALUES(@IdDoenca, @IdPaciente, @data, @observacoes);";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, conn);
                    sqlCommand.Parameters.AddWithValue("@IdDoenca", doenca);
                    sqlCommand.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
                    sqlCommand.Parameters.AddWithValue("@data", data.ToString("MM/dd/yyyy"));
                    sqlCommand.Parameters.AddWithValue("@observacoes", observacoes);

                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Doença registada com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Por erro interno é impossível registar a doença", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      private void UpdateDataGridView()
        {
            try
            {
                doencaPacientes.Clear();
                conn.Open();
                com.Connection = conn;
                SqlCommand cmd = new SqlCommand("select doenca.Nome, doencaP.data, doencaP.observacoes from DoencaPaciente doencaP JOIN Doenca doenca ON doencaP.IdDoenca = doenca.IdDoenca WHERE IdPaciente = @IdPaciente ORDER BY doencaP.data, doenca.Nome", conn);
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
                    doencaPacientes.Add(doencaPaciente);
                }
                var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = doencaPacientes };
                dataGridViewDoencas.DataSource = bindingSource1;
                dataGridViewDoencas.Columns[0].HeaderText = "Doença";
                dataGridViewDoencas.Columns[1].HeaderText = "Data de Diagnóstico";
                dataGridViewDoencas.Columns[2].HeaderText = "Observações";

                conn.Close();
                dataGridViewDoencas.Update();
                dataGridViewDoencas.Refresh();
            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível selecionar as doenças do paciente!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void enfermeiroBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            limparCampos();
            Doencas doencas = new Doencas(this);
            doencas.Show();
        }
        public void reiniciar()
        {
            try
            {
                doencas.Clear();
                comboBoxDoenca.Items.Clear();
                auxiliar.Clear();
                conn.Open();
                com.Connection = conn;
                SqlCommand cmd = new SqlCommand("select * from Doenca ", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.Text = (string)reader["Nome"];
                    item.Value = (int)reader["IdDoenca"];
                    comboBoxDoenca.Items.Add(item);
                    doencas.Add(item);
                }

                conn.Close();

            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível selecionar o tipo de doença!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (txtProcurar.Text != "" )
            {
                foreach (ComboBoxItem doenca in doencas)
                {
                    if (doenca.Text.ToLower().Contains(txtProcurar.Text.ToLower()))
                    {
                        auxiliar.Add(doenca);
                    }
                }
                return auxiliar;
            }
            auxiliar = doencas;
            return auxiliar;
        }


        private Boolean VerificarDadosInseridos()
        {
            string nome = comboBoxDoenca.Text;
            DateTime data = dataDiagnostico.Value;

            if ((data - DateTime.Today).TotalDays > 0)
            {
                MessageBox.Show("A data de diagnóstico da doença tem de ser inferior ou igual à data de hoje! \n Selecione outra data!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (nome == string.Empty)
            {
                MessageBox.Show("Campos Obrigatórios, por favor preencha a doença!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (comboBoxDoenca.Text == string.Empty)
                {
                    errorProvider.SetError(comboBoxDoenca, "A doença é obrigatória!");
                }
                else
                {
                    errorProvider.SetError(comboBoxDoenca, String.Empty);
                }
                return false;
            }

            try
            {
                conn.Open();
                com.Connection = conn;

                SqlCommand cmd = new SqlCommand("select * from DoencaPaciente WHERE IdPaciente = @IdPaciente", conn);
                cmd.Parameters.AddWithValue("@IdPaciente", paciente.IdPaciente);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DateTime dataRegisto = DateTime.ParseExact(reader["data"].ToString(), "dd/MM/yyyy HH:mm:ss", null);
                    int doenca = (comboBoxDoenca.SelectedItem as ComboBoxItem).Value;
                    if (dataDiagnostico.Value.ToShortDateString().Equals(dataRegisto.ToShortDateString()) && paciente.IdPaciente == (int)reader["IdPaciente"] && doenca == (int)reader["IdDoenca"])
                    {
                        MessageBox.Show("Não é possível registar essa doença, porque já esta registada na data que selecionou.\n Escolha outra doenca ou outra cirurgia!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Por erro interno é impossível selecionar as doenças do paciente!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }

        private void txtProcurar_TextChanged(object sender, EventArgs e)
        {

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
            // filtrosDePesquisa();
        }
    }
}
