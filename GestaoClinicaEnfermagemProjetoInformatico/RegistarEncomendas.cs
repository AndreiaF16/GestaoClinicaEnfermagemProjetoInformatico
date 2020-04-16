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
    public partial class RegistarEncomendas : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private DateTime inicio;
        private DateTime real;
        private ClassFornecedor fornecedor = new ClassFornecedor();
        private List<ComboBoxItem> encomendas = new List<ComboBoxItem>();
        private List<ComboBoxItem> auxiliar = new List<ComboBoxItem>();
        private List<Encomendas> listaEncomendas = new List<Encomendas>();
        public RegistarEncomendas()
        {
            InitializeComponent();
            inicio = DateTime.Now;
            labelData.Text = inicio.ToString("dd/MM/yyyy");

            real = DateTime.Now;
            labelData.ForeColor = Color.Black;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            dataEntregaPrevista.MinDate = DateTime.Now;

        }

        private void RegistarEncomendas_Load(object sender, EventArgs e)
        {
            UpdateDataGridView();
            reiniciar();
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!VerificarDadosInseridos())
            {
                MessageBox.Show("Dados incorretos!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int fornecedor = (comboBoxFornecedor.SelectedItem as ComboBoxItem).Value;
                DateTime data = dataEntregaPrevista.Value;
                // string observacoes = txtObservacoes.Text;
                string encomenda = txtNumeroEncomenda.Text;

                try
                {
                    conn.Open();

                    string queryInsertData = "INSERT INTO Encomenda(IdEncomenda,idFornecedor,dataRegistoEncomenda,dataEntregaPrevista,dataEntregaReal) VALUES(@IdEncomenda,@IdFornecedor,@DataRegistoEncomenda,@DataEntregaPrevista,@DataEntregaReal);";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, conn);
                    sqlCommand.Parameters.AddWithValue("@DataEntregaPrevista", data.ToString("MM/dd/yyyy"));
                    sqlCommand.Parameters.AddWithValue("@DataRegistoEncomenda", inicio.ToString("MM/dd/yyyy"));
                    sqlCommand.Parameters.AddWithValue("@DataEntregaReal", real.ToString("MM/dd/yyyy"));
                    sqlCommand.Parameters.AddWithValue("@IdFornecedor", fornecedor);
                    sqlCommand.Parameters.AddWithValue("@IdEncomenda", encomenda);

                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Encomenda registada com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    UpdateDataGridView();

                }
                catch (SqlException excep)
                {
                    MessageBox.Show("Por erro interno é impossível registar a encomenda", excep.Message);

                }
            }
        }

        private void UpdateDataGridView()
        {
            listaEncomendas.Clear();
            conn.Open();
            com.Connection = conn;
    
             SqlCommand cmd = new SqlCommand("select enc.IdEncomenda, fornecedor.nome, enc.dataRegistoEncomenda, enc.dataEntregaPrevista from Fornecedor fornecedor JOIN Encomenda enc ON fornecedor.IdFornecedor = enc.idFornecedor ORDER BY dataRegistoEncomenda", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string dataRegistoEnc = DateTime.ParseExact(reader["dataRegistoEncomenda"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy");
                string dataEntregaPrev = DateTime.ParseExact(reader["dataEntregaPrevista"].ToString(), "dd/MM/yyyy HH:mm:ss", null).ToString("dd/MM/yyyy");

                Encomendas encomendas = new Encomendas
                {
                    IdEncomenda = (int)reader["IdEncomenda"],
                    nome = (string)reader["nome"],
                    dataRegisto = dataRegistoEnc,
                    dataEntregaPrevista = dataEntregaPrev,
                };
                listaEncomendas.Add(encomendas);
            }
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaEncomendas };
            dataGridViewEncomendas.DataSource = bindingSource1;
            dataGridViewEncomendas.Columns[0].HeaderText = "Número da Encomenda";
            dataGridViewEncomendas.Columns[1].HeaderText = "Nome Fornecedor";
            dataGridViewEncomendas.Columns[2].HeaderText = "Data de Registo da Encomanda";
            dataGridViewEncomendas.Columns[3].HeaderText = "Data de Entrega Prevista";
            dataGridViewEncomendas.Columns[4].Visible = false;
            conn.Close();
            dataGridViewEncomendas.Update();
            dataGridViewEncomendas.Refresh();
        }

        private void txtProcurar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                comboBoxFornecedor.Items.Clear();
                foreach (var pesquisa in filtrosDePesquisa())
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.Text = pesquisa.Text;
                    item.Value = pesquisa.Value;
                    comboBoxFornecedor.Items.Add(item);
                }

            }
        }

        private List<ComboBoxItem> filtrosDePesquisa()
        {
            auxiliar = new List<ComboBoxItem>();
            if (txtProcurar.Text != "")
            {
                foreach (ComboBoxItem encomenda in encomendas)
                {
                    if (encomenda.Text.ToLower().Contains(txtProcurar.Text.ToLower()))
                    {
                        auxiliar.Add(encomenda);
                    }
                }
                return auxiliar;
            }
            auxiliar = encomendas;
            return auxiliar;
        }

        private Boolean VerificarDadosInseridos()
        {
            string nome = comboBoxFornecedor.Text;


            if (nome == string.Empty)
            {
                MessageBox.Show("Campos Obrigatório, por favor preencha o campo!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }          
            return true;
        }

        public void reiniciar()
        {
            encomendas.Clear();
            comboBoxFornecedor.Items.Clear();
            auxiliar.Clear();
            conn.Open();
            com.Connection = conn;
            SqlCommand cmd = new SqlCommand("select * from Fornecedor ", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Text = (string)reader["nome"];
                item.Value = (int)reader["IdFornecedor"];
                comboBoxFornecedor.Items.Add(item);
                encomendas.Add(item);
            }

            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EditarEncomenda editarEncomenda = new EditarEncomenda();
            editarEncomenda.Show();
        }

        private void txtNumeroEncomenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            //garantir que são inseridos apenas numeros
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
