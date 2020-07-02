using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestaoClinicaEnfermagemProjetoInformatico
{
    public partial class Fornecedor : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand com = new SqlCommand();
        private List<ClassFornecedor> fornecedor = new List<ClassFornecedor>();
        private ErrorProvider errorProvider = new ErrorProvider();

        public Fornecedor()
        {
            InitializeComponent();
            conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SiltesSaude;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string observacoes = txtObservacoes.Text;
            string email = txtEmail.Text;
            string telemovel = txtContacto.Text;
            string nif = txtNif.Text;
            string rua = txtRua.Text;
            string nrMorada = txtNumeroCasa.Text;
            string andarPiso = txtAndarPiso.Text;
            string localidade = txtLocalidade.Text;
            string bairroLocal = txtBairroLocal.Text;
            string codPrefixo = txtCodPostalPre.Text;
            string codSufixo = txtCodPostalSuf.Text;
            string designacao = txtDesignacao.Text;


            if (VerificarDadosInseridos())
            {
                
                try
                {
                    conn.Open();

                    string queryInsertData = "INSERT INTO Fornecedor(nif,nome,contacto,email,observacoes,rua,numeroMorada,andarPiso,localidade,bairroLocal,codPostalPrefixo,codPostalSufixo,designacao) VALUES(@Nif,@Nome,@Contacto,@email,@Observacoes,@rua,@numeroMorada,@andarPiso,@localidade,@bairroLocal,@codPrefixo,@codSufixo,@designacao)";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, conn);
                    sqlCommand.Parameters.AddWithValue("@Nome", nome);
                    sqlCommand.Parameters.AddWithValue("@Nif", nif);
                    sqlCommand.Parameters.AddWithValue("@Contacto", telemovel);
                    sqlCommand.Parameters.AddWithValue("@rua", rua);
                    sqlCommand.Parameters.AddWithValue("@localidade", localidade);
                    sqlCommand.Parameters.AddWithValue("@codPrefixo", codPrefixo);
                    sqlCommand.Parameters.AddWithValue("@codSufixo", codSufixo);
          
                    if (nrMorada != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@numeroMorada", Convert.ToInt32(nrMorada));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@numeroMorada", DBNull.Value);
                    }

                    if (andarPiso != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@andarPiso", Convert.ToString(andarPiso));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@andarPiso", DBNull.Value);
                    }                

                    if (bairroLocal != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@bairroLocal", Convert.ToString(bairroLocal));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@bairroLocal", DBNull.Value);
                    }


                    if (email != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@email", Convert.ToString(email));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@email", DBNull.Value);
                    }

                    if (designacao != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@designacao", Convert.ToString(designacao.ToUpper()));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@designacao", DBNull.Value);
                    }

                    if (observacoes != string.Empty)
                    {
                        sqlCommand.Parameters.AddWithValue("@Observacoes", Convert.ToString(observacoes));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Observacoes", DBNull.Value);
                    }

                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Fornecedor registado com Sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    limparCampos();
                    UpdateDataGridView();
                }
                catch (SqlException)
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    MessageBox.Show("Por erro interno é impossível registar o fornecedor!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtContacto_KeyPress(object sender, KeyPressEventArgs e)
        {
            //garantir que são inseridos apenas numeros
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNif_KeyPress(object sender, KeyPressEventArgs e)
        {
            //garantir que são inseridos apenas numeros
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
                MessageBox.Show("Este Campo aceita apenas Letras!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private Boolean VerificarDadosInseridos()
        {
            string nome = txtNome.Text;  
            string telemovel = txtContacto.Text;
            string nif = txtNif.Text;


            string observacoes = txtObservacoes.Text;
            string email = txtEmail.Text;
            string rua = txtRua.Text;
            string nrMorada = txtNumeroCasa.Text;
            string andarPiso = txtAndarPiso.Text;
            string localidade = txtLocalidade.Text;
            string bairroLocal = txtBairroLocal.Text;
            string codPrefixo = txtCodPostalPre.Text;
            string codSufixo = txtCodPostalSuf.Text;
            string designacao = txtDesignacao.Text;


            if (nome == string.Empty || telemovel == string.Empty || nif == string.Empty || rua == string.Empty || localidade == string.Empty 
                || codPrefixo == string.Empty || codSufixo == string.Empty)
            {
                MessageBox.Show("Campos Obrigatórios, por favor preencha os campos vazios!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (txtNome.Text == string.Empty)
                {
                    errorProvider.SetError(txtNome, "O nome é obrigatório!");
                }
                else
                {
                    errorProvider.SetError(txtNome, String.Empty);
                }

                if (nif == string.Empty)
                {
                    errorProvider.SetError(txtNif, "O nif é obrigatório!");
                }
                else
                {
                    errorProvider.SetError(txtNif, String.Empty);
                }

                
                if (telemovel == string.Empty)
                {
                    errorProvider.SetError(txtContacto, "O telemóvel é obrigatório!");
                }
                else
                {
                    errorProvider.SetError(txtContacto, String.Empty);
                }

                if (txtRua.Text == string.Empty)
                {
                    errorProvider.SetError(txtRua, "A Avenida, Beco, Rua ou Praça é obrigatório!");
                }
                else
                {
                    errorProvider.SetError(txtRua, String.Empty);
                }

                if (localidade == string.Empty)
                {
                    errorProvider.SetError(txtLocalidade, "A localidade é obrigatória!");
                }
                else
                {
                    errorProvider.SetError(txtLocalidade, String.Empty);
                }

                if (codPrefixo == string.Empty)
                {
                    errorProvider.SetError(txtCodPostalPre, "O prefixo do código portal é é obrigatório!");
                }
                else
                {
                    errorProvider.SetError(txtCodPostalPre, String.Empty);
                }

                if (codSufixo == string.Empty)
                {
                    errorProvider.SetError(txtCodPostalSuf, "O sufixo do código postal é obrigatório!");
                }
                else
                {
                    errorProvider.SetError(txtCodPostalSuf, String.Empty);
                }
                return false;
            }
            try
            {
                conn.Open();
                com.Connection = conn;

                SqlCommand cmd = new SqlCommand("select * from Fornecedor", conn);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (!(reader["email"] == DBNull.Value))
                    {
                        if (txtEmail.Text.Equals((string)reader["email"]))
                        {
                            MessageBox.Show("O Email que colocou já se encontra registado, coloque outro.");
                            conn.Close();
                            return false;
                        }

                    }

                    if (Convert.ToInt32(txtNif.Text) == Convert.ToInt32(reader["nif"]))
                    {
                        MessageBox.Show("O NIF que colocou já se encontra registado, coloque outro.");
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
                MessageBox.Show("Por erro interno é impossível verificar se o email e o NIF já se encontram registados!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Regex regexEmail = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (!regexEmail.IsMatch(txtEmail.Text))
            {
                MessageBox.Show("Por favor, introduza um email válido!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(txtEmail, "Por favor, introduza um email válido!");
                return false;
            }
            else
            {
                errorProvider.SetError(txtEmail, String.Empty);
            }

            if (!nrMorada.Equals("") && nrMorada.Length != 9 && Convert.ToInt32(nrMorada) < 0)
            {
                MessageBox.Show("O Número da Casa não pode ser um valor negativo!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(txtNumeroCasa, "O Número da Casa não pode ser um valor negativo!");
                return false;
            }
            else
            {
                errorProvider.SetError(txtNumeroCasa, String.Empty);
            }

            if (codPrefixo.Length != 4)
            {
                MessageBox.Show("O prefixo do código postal tem de ter exatamente 4 algarismos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(txtCodPostalPre, "O prefixo do código postal tem de ter exatamente 4 algarismos!");

                return false;
            }
            else
            {
                errorProvider.SetError(txtCodPostalPre, String.Empty);
            }

            if (codSufixo.Length != 3)
            {
                MessageBox.Show("O sufixo do código postal tem de ter exatamente 3 algarismos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(txtCodPostalSuf, "O sufixo do código postal tem de ter exatamente 3 algarismos!");

                return false;
            }
            else
            {
                errorProvider.SetError(txtCodPostalSuf, String.Empty);
            }

            if (telemovel.Length != 9)
            {
                MessageBox.Show("O telemóvel tem de ter exatamente 9 algarismos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(txtContacto, "O telemóvel tem de ter exatamente 9 algarismos!");
                return false;
            }
            else
            {
                errorProvider.SetError(txtContacto, String.Empty);
            }

            if (nif.Length != 9)
            {
                MessageBox.Show("O nif tem de ter exatamente 9 algarismos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider.SetError(txtNif, "O nif tem de ter exatamente 9 algarismos!");
                return false;
            }
            else
            {
                errorProvider.SetError(txtNif, String.Empty);
            }

            return true;
        }

        private void Fornecedor_Load(object sender, EventArgs e)
        {
            UpdateDataGridView();
            dataGridViewFornecedores.Columns[0].Width = dataGridViewFornecedores.Columns[0].Width + 100;
            dataGridViewFornecedores.Columns[1].Width = dataGridViewFornecedores.Columns[1].Width + 30;
            dataGridViewFornecedores.Columns[2].Width = dataGridViewFornecedores.Columns[2].Width + 30;
            dataGridViewFornecedores.Columns[3].Width = dataGridViewFornecedores.Columns[3].Width + 80;
            dataGridViewFornecedores.Columns[4].Width = dataGridViewFornecedores.Columns[4].Width + 150;
            dataGridViewFornecedores.Columns[6].Width = dataGridViewFornecedores.Columns[4].Width + 30; 
            dataGridViewFornecedores.Columns[7].Width = dataGridViewFornecedores.Columns[4].Width + 20;
            dataGridViewFornecedores.Columns[8].Width = dataGridViewFornecedores.Columns[4].Width + 50;
            dataGridViewFornecedores.Columns[10].Width = dataGridViewFornecedores.Columns[4].Width + 150;
            dataGridViewFornecedores.Columns[11].Width = dataGridViewFornecedores.Columns[4].Width + 150;

        }

        private void UpdateDataGridView()
        {
            try
            {
                fornecedor.Clear();
                conn.Open();
                com.Connection = conn;
                SqlCommand cmd = new SqlCommand("select * from Fornecedor ORDER BY nome", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    ClassFornecedor forn = new ClassFornecedor
                    {
                        nome = (string)reader["nome"],
                        nif = ((reader["nif"] == DBNull.Value) ? null : (int?)reader["nif"]),
                        contacto = ((reader["contacto"] == DBNull.Value) ? null : (int?)reader["contacto"]),

                        email = ((reader["email"] == DBNull.Value) ? "" : (string)reader["email"]),
                        rua = (string)reader["rua"],
                        numeroMorada = ((reader["numeroMorada"] == DBNull.Value) ? null : (int?)reader["numeroMorada"]),
                        andarPiso = ((reader["andarPiso"] == DBNull.Value) ? "" : (string)reader["andarPiso"]),
                        localidade = (string)reader["localidade"],
                        bairroLocal = ((reader["bairroLocal"] == DBNull.Value) ? "" : (string)reader["bairroLocal"]),
                        codigoPostal = (reader["codPostalPrefixo"]) + "-" + (reader["codPostalSufixo"]),
                        designacao = ((reader["designacao"] == DBNull.Value) ? "" : (string)reader["designacao"]),
                        observacoes = ((reader["observacoes"] == DBNull.Value) ? "" : (string)reader["observacoes"]),
                    };

                    fornecedor.Add(forn);
                }
                var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = fornecedor };
                dataGridViewFornecedores.DataSource = bindingSource1;
                dataGridViewFornecedores.Columns[0].HeaderText = "Nome Fornecedor";
                dataGridViewFornecedores.Columns[1].HeaderText = "Nif";
                dataGridViewFornecedores.Columns[2].HeaderText = "Contacto";
                dataGridViewFornecedores.Columns[3].HeaderText = "Email";
                dataGridViewFornecedores.Columns[4].HeaderText = "Morada";
                dataGridViewFornecedores.Columns[5].HeaderText = "Número";
                dataGridViewFornecedores.Columns[6].HeaderText = "Andar/Piso";
                dataGridViewFornecedores.Columns[7].HeaderText = "Localidade";
                dataGridViewFornecedores.Columns[8].HeaderText = "Bairro/Local";
                dataGridViewFornecedores.Columns[9].HeaderText = "Codigo Postal";
                dataGridViewFornecedores.Columns[10].HeaderText = "Designação";
                dataGridViewFornecedores.Columns[11].HeaderText = "Observações";
                dataGridViewFornecedores.Columns[12].Visible = false;
                conn.Close();
                dataGridViewFornecedores.Update();
                dataGridViewFornecedores.Refresh();
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

        private void txtNumeroCasa_KeyPress(object sender, KeyPressEventArgs e)
        {
            //garantir que são inseridos apenas numeros
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCodPostalPre_KeyPress(object sender, KeyPressEventArgs e)
        {
            //garantir que são inseridos apenas numeros
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCodPostalSuf_KeyPress(object sender, KeyPressEventArgs e)
        {
            //garantir que são inseridos apenas numeros
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void limparCampos()
        {
            txtNome.Text = "";
            txtNif.Text = "";
            txtContacto.Text = "";
            txtEmail.Text = "";
            txtRua.Text = "";
            txtNumeroCasa.Text = "";
            txtAndarPiso.Text = "";
            txtLocalidade.Text = "";
            txtBairroLocal.Text = "";
            txtCodPostalPre.Text = "";
            txtCodPostalSuf.Text = "";
            txtDesignacao.Text = "";
            txtObservacoes.Text = "";
            errorProvider.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limparCampos();
        }
    }
}
