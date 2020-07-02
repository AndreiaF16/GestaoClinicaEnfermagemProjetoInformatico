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
        private AtualizarQuantidade produtos = new AtualizarQuantidade();
        private ErrorProvider errorProvider = new ErrorProvider();
        private Paciente paciente = new Paciente();
        private Consulta consulta = new Consulta();
        private List<ComboBoxItem> auxiliar = new List<ComboBoxItem>();
        private List<ComboBoxItem> fornecedores = new List<ComboBoxItem>();
        private ClassFornecedor fornecedor = new ClassFornecedor();
        private VerProdutosConsulta prods = new VerProdutosConsulta();
        private List<VerProdutosConsulta> listaProdutos = new List<VerProdutosConsulta>();
        private List<VerProdutosConsulta> listaProdutosConsulta = new List<VerProdutosConsulta>();
        private List<AtualizarQuantidade> listaAtualizarQuantidades = new List<AtualizarQuantidade>();
        private Encomendas encomendas = null;

          private List<ListarProdutos> listarQuantidades = new List<ListarProdutos>();

        // private List<ListarProdutos> listaProdutosConsulta = new List<ListarProdutos>();

        public AdicionarVisualizarProdutosStockConsulta(Paciente pac, Consulta produtosConsulta)
        {
            InitializeComponent();
            paciente = pac;
            consulta = produtosConsulta;
            label1.Text = "Nome do Utente: " + paciente.Nome;
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
        }

        private void AdicionarVOsualizarProdutosStockConsulta_Load(object sender, EventArgs e)
        {
            UpdateGridViewConsultas();
            selectProdutos();
            dataGridViewListaProdutos.Columns[2].Visible = false;
            
            dataGridViewListaProdutos.Columns[0].HeaderText = "Produto";
            dataGridViewListaProdutos.Columns[1].HeaderText = "Quantidade Em Stock";

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

        private void btnAdicionarProdutoLista_Click(object sender, EventArgs e)
        {
            if (listaProdutos.Count > 0)
            {

                int i = dataGridViewListaProdutos.CurrentCell.RowIndex;

                foreach (var produto in listaProdutos)
                {
                    if (produto.id == Convert.ToInt32(dataGridViewListaProdutos.Rows[i].Cells[2].Value.ToString()))
                    {
                        VerProdutosConsulta listar = produto;
                        //listar.quantidade = 0;
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
                            VerProdutosConsulta adicionar = new VerProdutosConsulta 
                            { 
                                nomeProduto = listar.nomeProduto,
                                quantidade = 0, 
                                id = listar.id
                            };
                            listaProdutosConsulta.Add(adicionar);
                        }
                    }
                }
                var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaProdutosConsulta };
                dataGridViewProdutosConsulta.DataSource = bindingSource1;

                dataGridViewProdutosConsulta.Columns[0].ReadOnly = true;
                dataGridViewProdutosConsulta.Columns[2].Visible = false;
                dataGridViewProdutosConsulta.Columns[0].HeaderText = "Produto";
                dataGridViewProdutosConsulta.Columns[1].HeaderText = "Quantidade Usada na Consulta";
            }
        }

        private void btnRetirarProdutoLista_Click(object sender, EventArgs e)
        {
            if (listaProdutosConsulta.Count > 0)
            {

                int i = dataGridViewProdutosConsulta.CurrentCell.RowIndex;
                VerProdutosConsulta listar = null;
                foreach (var produto in listaProdutos)
                {
                    // var sad = dataGridViewEncomenda.Rows[i].Cells[4];
                    if (produto.id == Convert.ToInt32(dataGridViewProdutosConsulta.Rows[i].Cells[2].Value.ToString()))
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

                var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaProdutosConsulta };
                dataGridViewProdutosConsulta.DataSource = bindingSource1;
            }
        }

        private Boolean VerificarDadosInseridos()
        {
            foreach (var item in listaProdutosConsulta)
            {
                if (item.quantidade <=0)
                {
                    MessageBox.Show("A quantidade não pode ser igual ou inferior a 0!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    if (item.quantidade <= 0)
                    {
                        errorProvider.SetError(dataGridViewProdutosConsulta, "A quantidade não pode ser igual ou inferior a 0!");
                    }
                    else
                    {
                        errorProvider.SetError(dataGridViewProdutosConsulta, String.Empty);
                    }
                    return false;
                }

                //quantidade da consulta sup à quantidade armazenada
                
                foreach (var produtoQuant in listarQuantidades)
                {
                    if (item.id == produtoQuant.id )
                    {
                        if (produtoQuant.quant < item.quantidade)
                        {
                            MessageBox.Show("A quantidade usada em consulta não pode ser superior à quantidade armazenada!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            errorProvider.SetError(dataGridViewProdutosConsulta, "A quantidade não pode ser superior à quantidade armazenada!");

                        }
                    }
                }
            }


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
                            string queryInsertData = "INSERT INTO ConsultaProdutoStock(IdProdutoStock,quantidadeUsada,observacoes) VALUES(@IdProdutoStock,@Quantidade,@obs);";
                            SqlCommand sqlCommand = new SqlCommand(queryInsertData, conn);
                            sqlCommand.Parameters.AddWithValue("@IdProdutoStock", item.id);
                            sqlCommand.Parameters.AddWithValue("@Quantidade", item.quantidade);

                            if (observacoes != String.Empty)
                            {
                                sqlCommand.Parameters.AddWithValue("@obs", Convert.ToString(observacoes));
                            }
                            else
                            {
                                sqlCommand.Parameters.AddWithValue("@obs", DBNull.Value);
                            }
                            sqlCommand.ExecuteNonQuery();
                        }

                        MessageBox.Show("Registado com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        conn.Close();
                        /*
                        listarQuantidades.Clear();
                        conn.Open();
                        //select produtoStock.IdProdutoStock, produtoStock.NomeProduto, produtoStock.quantidadeArmazenada, linha.quantidade from ProdutoStock produtoStock JOIN LinhaEncomenda linha ON produtoStock.IdProdutoStock = linha.idProdutoStock WHERE linha.idEncomenda = 3009;
                        string CMDselect = "select produtoStock.NomeProduto, produtoStock.quantidadeArmazenada, produtoStock.IdProdutoStock from Fornecedor fornecedor JOIN ProdutoStock produtoStock ON fornecedor.IdFornecedor = produtoStock.IdFornecedor Order by fornecedor.nome, produtoStock.NomeProduto;";

                      
                        SqlCommand cmd = new SqlCommand(CMDselect, conn);

                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            ListarProdutos quantidade = new ListarProdutos
                            {
                                id = (int)reader["IdProdutoStock"],
                                quant = (int)reader["quantidadeArmazenada"],

                            };
                            listarQuantidades.Add(quantidade);
                        }
                        conn.Close();*/

                        conn.Open();
                        foreach (var item in listarQuantidades)
                        {
                            foreach (var prods in listaProdutosConsulta)
                            {
                                if (item.id == prods.id)
                                {
                                    string queryUpdateData2 = "UPDATE ProdutoStock SET quantidadeArmazenada = @quantidadeArmazenada WHERE IdProdutoStock = " + item.id;
                                    SqlCommand sqlCommand2 = new SqlCommand(queryUpdateData2, conn);
                                    sqlCommand2.Parameters.AddWithValue("@quantidadeArmazenada", item.quant - prods.quantidade);
                                    sqlCommand2.ExecuteNonQuery();
                                }
                            }
                            
                        }
                        conn.Close();
                        UpdateGridViewConsultas();
                        selectProdutos();
                        /* if (registarEncomendas != null)
                         {
                             registarEncomendas.UpdateDataGridView();
                         } */
                    }
                    catch (SqlException excep)
                    {
                        MessageBox.Show("Por erro interno é impossível registar", excep.Message);
                    }
                }
                else
                {
                    MessageBox.Show("A lista de produtos usados na consulta não contem produtos. Para poder registar, tem de ter pelo menos um!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }


        }

        public void reiniciar()
        {
            fornecedores.Clear();
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
                fornecedores.Add(item);
            }

            conn.Close();
        }

        private void comboBoxFornecedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            int var = (comboBoxFornecedor.SelectedItem as ComboBoxItem).Value;
            foreach (var item in fornecedores)
            {
                if (item.Value == var )
                {
                    fornecedor = new ClassFornecedor {
                        nome = item.Text,
                        IdFornecedor = item.Value,
                        };
                }
            }
            UpdateGridViewConsultas();
        }
    
        public void UpdateGridViewConsultas()
        {

            listaProdutos.Clear();
            conn.Open();
            com.Connection = conn;

            SqlCommand cmd1 = new SqlCommand("select produtoStock.NomeProduto, produtoStock.quantidadeArmazenada, produtoStock.IdProdutoStock from Fornecedor fornecedor JOIN ProdutoStock produtoStock ON fornecedor.IdFornecedor = produtoStock.IdFornecedor WHERE fornecedor.IdFornecedor = @IdFornecedor Order by fornecedor.nome, produtoStock.NomeProduto", conn);
            cmd1.Parameters.AddWithValue("@IdFornecedor", fornecedor.IdFornecedor);
            SqlDataReader reader1 = cmd1.ExecuteReader();

            while (reader1.Read())
            {
                VerProdutosConsulta prods = new VerProdutosConsulta
                {
                    nomeProduto = (string)reader1["NomeProduto"], 
                    quantidade = (int)reader1["quantidadeArmazenada"],
                    id = (int)reader1["IdProdutoStock"]
                };
                listaProdutos.Add(prods);
            }
            var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = listaProdutos };
            dataGridViewListaProdutos.DataSource = bindingSource1;
            
            conn.Close();
        }

        private void selectProdutos() 
        {
          //  listarQuantidades.Clear();

            conn.Open();
            //select produtoStock.IdProdutoStock, produtoStock.NomeProduto, produtoStock.quantidadeArmazenada, linha.quantidade from ProdutoStock produtoStock JOIN LinhaEncomenda linha ON produtoStock.IdProdutoStock = linha.idProdutoStock WHERE linha.idEncomenda = 3009;
            string CMDselect = "select produtoStock.NomeProduto, produtoStock.quantidadeArmazenada, produtoStock.IdProdutoStock from Fornecedor fornecedor JOIN ProdutoStock produtoStock ON fornecedor.IdFornecedor = produtoStock.IdFornecedor Order by fornecedor.nome, produtoStock.NomeProduto;";


            SqlCommand cmd = new SqlCommand(CMDselect, conn);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ListarProdutos quantidade = new ListarProdutos
                {
                    id = (int)reader["IdProdutoStock"],
                    quant = (int)reader["quantidadeArmazenada"],

                };
                listarQuantidades.Add(quantidade);
            }
            conn.Close();
        }
    }
}
