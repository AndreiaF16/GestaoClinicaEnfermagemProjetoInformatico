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
    public partial class VerEditarMetodosContracetivos : Form
    {

        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private MetodoContracetivo metodo = null;
        private List<MetodoContracetivo> listaMetodosContracetivos = new List<MetodoContracetivo>();
        private List<MetodoContracetivo> auxiliar = new List<MetodoContracetivo>();


        public VerEditarMetodosContracetivos()
        {
            InitializeComponent();
            conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        private void VerEditarMetodosContracetivos_Load(object sender, EventArgs e)
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

        private void UpdateDataGridView()
        {/*
            listaMetodosContracetivos.Clear();
            listaMetodosContracetivos = getMetodosContracetivos();
            dataGridViewMetodosContracetivos.DataSource = new List<MetodoContracetivo>();
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaMetodosContracetivos };
            dataGridViewMetodosContracetivos.DataSource = bindingSource1;
            dataGridViewMetodosContracetivos.Columns[0].HeaderText = "Nome Método Contracetivo";
            dataGridViewMetodosContracetivos.Columns[1].HeaderText = "Observações";
            dataGridViewMetodosContracetivos.Columns[2].Visible = false;
            foreach (var item in listaMetodosContracetivos)
            {
                auxiliar.Add(item);
            }

            dataGridViewMetodosContracetivos.Update();
            dataGridViewMetodosContracetivos.Refresh();

            */

            listaMetodosContracetivos.Clear();
            listaMetodosContracetivos = getMetodosContracetivos();
            dataGridViewMetodos.DataSource = new List<Doencas>();
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaMetodosContracetivos };
            dataGridViewMetodos.DataSource = bindingSource1;
            dataGridViewMetodos.Columns[0].HeaderText = "Nome";
            dataGridViewMetodos.Columns[1].HeaderText = "Sintomas";
            dataGridViewMetodos.Columns[2].Visible = false;
            foreach (var item in listaMetodosContracetivos)
            {
                auxiliar.Add(item);
            }

            dataGridViewMetodos.Update();
            dataGridViewMetodos.Refresh();


        }

        private List<MetodoContracetivo> getMetodosContracetivos()
        {
            /*MetodoContracetivo met= new MetodoContracetivo();

            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select * from MetodoContracetivo order by nomeMetodoContracetivo", conn);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                metodo = new MetodoContracetivo
                {
                    nomeMetodoContracetivo = (string)reader["nomeMetodoContracetivo"],
                    observacao = (string)reader["observacoes"],
                    IdMetodoContracetivo = (int)reader["IdMetodoContracetivo"],

                };
                listaMetodosContracetivos.Add(metodo);
            }
            conn.Close();
            return listaMetodosContracetivos;*/

            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select * from MetodoContracetivo order by nomeMetodoContracetivo", conn);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                metodo = new MetodoContracetivo
                {
                    nomeMetodoContracetivo = (string)reader["nomeMetodoContracetivo"],
                    observacao = (string)reader["observacoes"],
                    IdMetodoContracetivo = (int)reader["IdMetodoContracetivo"],
                };
                listaMetodosContracetivos.Add(metodo);
            }
            conn.Close();

            return listaMetodosContracetivos;
        }

       

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(txtId.Text);
            string nome = txtNome.Text;
            string observacao = txtObs.Text;

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

                    string queryUpdateData = "UPDATE MetodoContracetivo SET nomeMetodoContracetivo = @nome, observacoes = @observacao WHERE IdMetodoContracetivo = @IdMetodoContracetivo";
                    SqlCommand sqlCommand = new SqlCommand(queryUpdateData, connection);
                    sqlCommand.Parameters.AddWithValue("@nome", nome);
                    sqlCommand.Parameters.AddWithValue("@observacao", observacao);
                    sqlCommand.Parameters.AddWithValue("@IdMetodoContracetivo", metodo.IdMetodoContracetivo);
                    sqlCommand.ExecuteNonQuery();
                    foreach (var cirurgia in listaMetodosContracetivos)
                    {
                        metodo.nomeMetodoContracetivo = txtNome.Text;
                        metodo.observacao = txtObs.Text;
                    }
                    MessageBox.Show("Método Contracetivo alterado com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    UpdateDataGridView();

                }
                catch (SqlException excep)
                {
                    MessageBox.Show("Erro interno, não foi possível alterar o método contracetivo!", excep.Message);
                }

            }

        }
        private Boolean VerificarDadosInseridos()
        {
            string nome = txtNome.Text;

            if (nome == string.Empty)
            {
                MessageBox.Show("Campo Obrigatório, por favor preencha o campo obrigatorio!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
            }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = filtrosDePesquisa() };
                dataGridViewMetodos.DataSource = bindingSource1;
            }
        }

        private List<MetodoContracetivo> filtrosDePesquisa()
        {

            auxiliar.Clear();
            if (textBox1.Text != "")
            {
                foreach (MetodoContracetivo metodoo in listaMetodosContracetivos)
                {
                    if (metodoo.nomeMetodoContracetivo.ToLower().Contains(textBox1.Text.ToLower()))
                    {
                        auxiliar.Add(metodoo);
                    }
                }
                return auxiliar;
            }

            foreach (var item in listaMetodosContracetivos)
            {
                auxiliar.Add(item);
            }
            return auxiliar;
        }

        private void dataGridViewMetodos_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}
