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
    public partial class VerEditarPartosRegistados : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private Parto parto = null;
        private List<Parto> listaPartos = new List<Parto>();
        private List<Parto> auxiliar = new List<Parto>();
        public VerEditarPartosRegistados()
        {
            InitializeComponent();
            conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        private void VerEditarPartosRegistados_Load(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }

        private void dataGridViewPartos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int i = dataGridViewPartos.CurrentCell.RowIndex;
            parto = null;
            foreach (var p in auxiliar)
            {
                if (p.nomeParto == dataGridViewPartos.Rows[i].Cells[0].Value.ToString())
                {
                    parto = p;
                }

            }
            if (parto != null)
            {
                txtNome.Text = parto.nomeParto;
                txtObservacoes.Text = parto.observacao;
            }
        }

        private void txtNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = filtrosDePesquisa() };
                dataGridViewPartos.DataSource = bindingSource1;
            }
        }

        private void UpdateDataGridView()
        {
            listaPartos.Clear();
            listaPartos = getParto();
            dataGridViewPartos.DataSource = new List<Parto>();
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaPartos };
            dataGridViewPartos.DataSource = bindingSource1;
            dataGridViewPartos.Columns[0].HeaderText = "Nome do Tipo de Parto";
            dataGridViewPartos.Columns[1].HeaderText = "Observações";
            dataGridViewPartos.Columns[2].HeaderText = "ID";

            //dataGridViewPartos.Columns[2].Visible = false;
            foreach (var item in listaPartos)
            {
                auxiliar.Add(item);
            }

            dataGridViewPartos.Update();
            dataGridViewPartos.Refresh();

        }
        private List<Parto> getParto()
        {
            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select * from Parto order by tipoParto", conn);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                parto = new Parto
                {
                    nomeParto = (string)reader["tipoParto"],
                    observacao = (string)reader["Observacoes"],
                    IdTipoParto = (int)reader["IdParto"],
                };
                listaPartos.Add(parto);
            }
            conn.Close();

            return listaPartos;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

           // int id = Convert.ToInt32(txtId.Text);
            string nomeParto = txtNome.Text;
            string observacao = txtObservacoes.Text;

            if (!VerificarDadosInseridos())
            {
                MessageBox.Show("Dados incorretos!");
            }
            else
            {
                try
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

                    connection.Open();

                    string queryUpdateData = "UPDATE Parto SET tipoParto = @nome, Observacoes = @obs WHERE IdParto = @IdParto";
                    SqlCommand sqlCommand = new SqlCommand(queryUpdateData, connection);
                    sqlCommand.Parameters.AddWithValue("@nome", nomeParto);
                    sqlCommand.Parameters.AddWithValue("@obs", observacao);
                    sqlCommand.Parameters.AddWithValue("@IdParto", parto.IdTipoParto);
                    sqlCommand.ExecuteNonQuery();
                    foreach (var part in listaPartos)
                    {
                        part.nomeParto = txtNome.Text;
                        part.observacao = txtObservacoes.Text;
                    }
                    MessageBox.Show("Tipo de parto alterado com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    UpdateDataGridView();

                }
                catch (SqlException excep)
                {
                    MessageBox.Show("Erro interno, não foi possível alterar o tipo de parto!", excep.Message);
                }

            }
        }

        private Boolean VerificarDadosInseridos()
        {
            string nome = txtNome.Text;


            if (nome == string.Empty)
            {
                MessageBox.Show("Campo Obrigatório, por favor preencha o nome do tipo de parto!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private List<Parto> filtrosDePesquisa()
        {

            auxiliar.Clear();
            if (txt1.Text != "")
            {
                foreach (Parto partooo in listaPartos)
                {
                    if (partooo.nomeParto.ToLower().Contains(txt1.Text.ToLower()))
                    {
                        auxiliar.Add(partooo);
                    }
                }
                return auxiliar;
            }

            foreach (var item in listaPartos)
            {
                auxiliar.Add(item);
            }
            return auxiliar;
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
    }
}