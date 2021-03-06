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
    public partial class VerEditarAleitamento : Form
    { 
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Aleitamento aleitamento = null;
        private List<Aleitamento> listaAleitamento = new List<Aleitamento>();
        private List<Aleitamento> auxiliar = new List<Aleitamento>();
        private ErrorProvider errorProvider = new ErrorProvider();

        public VerEditarAleitamento()
        {
            InitializeComponent();
            conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
        }

        private void VerEditarAleitamento_Load(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            var resposta = MessageBox.Show("Tem a certeza que deseja sair da aplicação?", "Fechar Aplicação!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resposta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (VerificarDadosInseridos())
                {
                    string tipo = txtTipo.Text;
                    string obs = txtObs.Text;


                    SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

                    connection.Open();

                    string queryUpdateData = "UPDATE Aleitamento SET tipoAleitamento = @tipoAleitamento, Observacoes = @Observacoes WHERE IdAleitamento = @IdAleitamento";
                    SqlCommand sqlCommand = new SqlCommand(queryUpdateData, connection);
                    sqlCommand.Parameters.AddWithValue("@tipoAleitamento", tipo);
                    sqlCommand.Parameters.AddWithValue("@Observacoes", obs);
                    sqlCommand.Parameters.AddWithValue("@IdAleitamento", aleitamento.IdAleitamento);
                    sqlCommand.ExecuteNonQuery();
                    foreach (var cirurgia in listaAleitamento)
                    {
                        aleitamento.tipoAleitamento = txtTipo.Text;
                        aleitamento.Observacoes = txtObs.Text;
                    }
                    MessageBox.Show("Tipo de aleitamento alterado com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    limparCampos();
                    UpdateDataGridView();

                }
                
            }
            catch (SqlException)
            {
                MessageBox.Show("Erro interno, não foi possível alterar o tipo de aleitamento!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = "Hora " + DateTime.Now.ToLongTimeString();
            lblDia.Text = DateTime.Now.ToString("dddd, dd " + "'de '" + "MMMM" + "' de '" + "yyyy");
        }

        private void UpdateDataGridView()
        {
            listaAleitamento.Clear();
            listaAleitamento = getTipoAleitamento();
            dataGridViewTipoAleitamento.DataSource = new List<Aleitamento>();
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaAleitamento };
            dataGridViewTipoAleitamento.DataSource = bindingSource1;
            dataGridViewTipoAleitamento.Columns[0].HeaderText = "Tipo de Aleitamento";
            dataGridViewTipoAleitamento.Columns[1].HeaderText = "Observações";
            dataGridViewTipoAleitamento.Columns[2].Visible = false;
            foreach (var item in listaAleitamento)
            {
                auxiliar.Add(item);
            }

            dataGridViewTipoAleitamento.Update();
            dataGridViewTipoAleitamento.Refresh();
        }

        private List<Aleitamento> getTipoAleitamento()
        {
            try
            {
                conn.Open();
                com.Connection = conn;

                SqlCommand cmd = new SqlCommand("select * from Aleitamento order by tipoAleitamento", conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    aleitamento = new Aleitamento
                    {
                        tipoAleitamento = ((reader["tipoAleitamento"] == DBNull.Value) ? "" : (string)reader["tipoAleitamento"]),
                        Observacoes = ((reader["Observacoes"] == DBNull.Value) ? "" : (string)reader["Observacoes"]),
                        IdAleitamento = (int)reader["IdAleitamento"],
                    };
                    listaAleitamento.Add(aleitamento);
                }
                conn.Close();
            }
            catch (Exception)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show("Por erro interno é impossível visualizar os dados!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return listaAleitamento;
        }

        private Boolean VerificarDadosInseridos()
        {
            string tipo = txtTipo.Text;

            if (tipo == string.Empty)
            {
                MessageBox.Show("Campo Obrigatório, por favor preencha o tipo de aleitamento!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (txtTipo.Text == string.Empty)
                {
                    errorProvider.SetError(txtTipo, "O tipo de aleitamento é obrigatório!");
                }
                else
                {
                    errorProvider.SetError(txtTipo, String.Empty);
                }

                return false;
            }
            return true;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = filtrosDePesquisa() };
                dataGridViewTipoAleitamento.DataSource = bindingSource1;
            }
        }

        private List<Aleitamento> filtrosDePesquisa()
        {

            auxiliar.Clear();
            if (textBox1.Text != "")
            {
                foreach (Aleitamento aleitamentooo in listaAleitamento)
                {
                    if (aleitamentooo.tipoAleitamento.ToLower().Contains(textBox1.Text.ToLower()))
                    {
                        auxiliar.Add(aleitamentooo);
                    }
                }
                return auxiliar;
            }

            foreach (var item in listaAleitamento)
            {
                auxiliar.Add(item);
            }
            return auxiliar;
        }

        private void dataGridViewTipoAleitamento_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            int i = dataGridViewTipoAleitamento.CurrentCell.RowIndex;
            aleitamento = null;
            foreach (var m in auxiliar)
            {
                if (m.tipoAleitamento == dataGridViewTipoAleitamento.Rows[i].Cells[0].Value.ToString())
                {
                    aleitamento = m;
                }

            }
            if (aleitamento != null)
            {
                txtTipo.Text = aleitamento.tipoAleitamento;
                txtObs.Text = aleitamento.Observacoes;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void limparCampos()
        {
            txtObs.Text = "";
            txtTipo.Text = "";
            errorProvider.Clear();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var resposta = MessageBox.Show("Tem a certeza que deseja sair da aplicação?", "Fechar Aplicação!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resposta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
