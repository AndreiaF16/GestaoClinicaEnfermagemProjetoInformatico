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
    public partial class AdicionarVisualizarProdutosStockConsulta : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private List<ListarProdutos> listaProdutos = new List<ListarProdutos>();
        private List<ListarProdutos> listaProdutosConsulta = new List<ListarProdutos>();
        private ErrorProvider errorProvider = new ErrorProvider();
        private Paciente paciente = new Paciente();
        private Consulta consulta = new Consulta();
        public AdicionarVisualizarProdutosStockConsulta(Paciente pac, Consulta produtosConsulta)
        {
            InitializeComponent();
            paciente = pac;
            consulta = produtosConsulta;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            label7.Text = "Id: " + consulta.IdConsulta;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
        }

        private void AdicionarVOsualizarProdutosStockConsulta_Load(object sender, EventArgs e)
        {

            UpdateListBox();
            dataGridViewListaProdutos.Columns[1].Visible = false;
            dataGridViewListaProdutos.Columns[2].Visible = false;
            dataGridViewListaProdutos.Columns[4].Visible = false;
            
            dataGridViewProdutosConsulta.Columns[0].ReadOnly = true;
            dataGridViewProdutosConsulta.Columns[1].Visible = false;
            dataGridViewProdutosConsulta.Columns[2].Visible = false;
            dataGridViewProdutosConsulta.Columns[4].Visible = false;

            dataGridViewListaProdutos.Columns[0].HeaderText = "Produto";
            dataGridViewListaProdutos.Columns[3].HeaderText = "Quantidade Em Stock";

            dataGridViewProdutosConsulta.Columns[0].HeaderText = "Produto";
            dataGridViewProdutosConsulta.Columns[3].HeaderText = "Quantidade Usada na Consulta";

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

        public void UpdateListBox()
        {
            listaProdutos.Clear();
            conn.Open();
            com.Connection = conn;

            SqlCommand cmd = new SqlCommand("select IdProdutoStock, NomeProduto, quantidadeArmazenada from ProdutoStock ORDER BY NomeProduto ", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ListarProdutos produto = new ListarProdutos
                {
                    id = (int)reader["IdProdutoStock"],
                    nome = (string)reader["NomeProduto"],           
                    quant = (int)reader["quantidadeArmazenada"]
                };
                // produto.quant = 0;
                listaProdutos.Add(produto);

            }
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaProdutos };
            dataGridViewListaProdutos.DataSource = bindingSource1;

            conn.Close();
            var bindingSource2 = new System.Windows.Forms.BindingSource { DataSource = listaProdutosConsulta };
            dataGridViewProdutosConsulta.DataSource = bindingSource2;
        }

        private void btnAdicionarProdutoLista_Click(object sender, EventArgs e)
        {
            int i = dataGridViewListaProdutos.CurrentCell.RowIndex;
            foreach (var produto in listaProdutos)
            {
                if (produto.id == Convert.ToInt32(dataGridViewListaProdutos.Rows[i].Cells[4].Value.ToString()))
                {
                    ListarProdutos listar = produto;
                    listar.quant = 0;
                    //listaEncomenda.Add(listar);
                    int existe = 0;
                    foreach (var item in listaProdutosConsulta)
                    {
                        if (listar.id == item.id)
                        {
                            existe = 1;
                        }
                    }
                    if (existe == 0)
                    {
                        listaProdutosConsulta.Add(listar);
                    }
                }
            }
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = dataGridViewProdutosConsulta };
            dataGridViewProdutosConsulta.DataSource = bindingSource1;
        }

        private void btnRetirarProdutoLista_Click(object sender, EventArgs e)
        {
            
                int i = dataGridViewProdutosConsulta.CurrentCell.RowIndex;
                ListarProdutos listar = null;
                foreach (var produto in listaProdutos)
                {
                    // var sad = dataGridViewEncomenda.Rows[i].Cells[4];
                    if (produto.id == Convert.ToInt32(dataGridViewProdutosConsulta.Rows[i].Cells[4].Value.ToString()))
                    {
                        listar = produto;
                    }
                }
                foreach (var item in listaProdutosConsulta)
                {
                    if (listar != null && listar.id == item.id)
                    {
                        listar = item;
                    }
                }
                listaProdutosConsulta.Remove(listar);

                var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = dataGridViewProdutosConsulta };
                dataGridViewProdutosConsulta.DataSource = bindingSource1;
            
        }

        private Boolean VerificarDadosInseridos()
        {

            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (VerificarDadosInseridos())
            {
                if (listaProdutosConsulta.Count > 0)
                {
                    string observacoes = txtObservacoes.Text;

                    try
                    {
                        conn.Open();
                        foreach (var item in listaProdutosConsulta)
                        {
                            string queryInsertData = "INSERT INTO ConsultaProdutoStock(IdProdutoStock,IdConsulta,quantidadeUsada,observacoes) VALUES(@IdProdutoStock,@IdConsulta,@Quantidade,@obs);";
                            SqlCommand sqlCommand = new SqlCommand(queryInsertData, conn);
                            sqlCommand.Parameters.AddWithValue("@IdProdutoStock", item.id);
                            sqlCommand.Parameters.AddWithValue("@Quantidade", item.quant);
                            sqlCommand.Parameters.AddWithValue("@IdConsulta", consulta.IdConsulta);

                            if (observacoes != String.Empty)
                            {
                                sqlCommand.Parameters.AddWithValue("@obs", Convert.ToString(observacoes));
                            }
                            else
                            {
                                sqlCommand.Parameters.AddWithValue("@obs", DBNull.Value);
                            }
                            // sqlCommand.Parameters.AddWithValue("@IdEncomenda", encomendas.IdEncomenda);
                            sqlCommand.ExecuteNonQuery();
                        }

                        MessageBox.Show("Registado com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        conn.Close();
                        this.Close();
                    }
                    catch (SqlException excep)
                    {
                        MessageBox.Show("Por erro interno é impossível registar", excep.Message);
                    }
                }
                else
                {
                    MessageBox.Show("A lista de produtos usados na consulta não contem items. Para poder registar, tem de ter pelo menos um item", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
