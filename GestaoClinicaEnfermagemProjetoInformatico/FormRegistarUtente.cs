﻿using System;
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
    public partial class FormRegistarUtente : Form
    {
        public FormRegistarUtente()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private Boolean VerificarDadosInseridos()
        {
            string nome = txtNome.Text;
            var dtNascimento = dataNascimento.Value;
            string rua = txtMorada.Text;
            string numeroCasa = txtNumeroCasa.Text;
            string andarCasa = txtAndar.Text;
            string codPostalPrefixo = txtCodPostalPre.Text;
            string codPostalSufixo = txtCodPostalSuf.Text;
            string localidade = txtLocalidade.Text;
            string email = txtEmail.Text;
            string telemovel = txtContacto.Text;
            string nif = txtNif.Text;
            string profissao =(String) cbProfissoes.SelectedItem;

            if (nome == string.Empty || rua == string.Empty || numeroCasa == string.Empty || andarCasa == string.Empty || codPostalPrefixo == string.Empty || codPostalSufixo == string.Empty
                || localidade == string.Empty || email == string.Empty || telemovel == string.Empty || nif == string.Empty || profissao == string.Empty)
            {
                MessageBox.Show("Campos Obrigatórios, por favor preencha todos os campos!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            /*if (!Regex.IsMatch(txtNome.Text, @"^[A - Za - záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ] +$") )
            {
                MessageBox.Show("Apenas são permitidas letras no campo Nome!");
                return false;
            }
            if (!Regex.IsMatch(txtMorada.Text, @"^[A - Za - záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ] +$") )
            {
                MessageBox.Show("Apenas são permitidas letras no campo Morada!");
                return false;
            }
            if (!Regex.IsMatch(txtLocalidade.Text, @"^[A - Za - záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ] +$") )
            {
                MessageBox.Show("Apenas são permitidas letras no campo Localidade!");
                return false;
            }*/
            Regex regexEmail = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (!regexEmail.IsMatch(txtEmail.Text))
            {
                MessageBox.Show("Por favor, introduza um email válido!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            return true;
        }

            private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            var dtNascimento = dataNascimento.Value;
            string rua = txtMorada.Text;
            string numeroCasa = txtNumeroCasa.Text;
            string andarCasa = txtAndar.Text;
            string codPostalPrefixo = txtCodPostalPre.Text;
            string codPostalSufixo = txtCodPostalSuf.Text;
            string localidade = txtLocalidade.Text;
            string email = txtEmail.Text;
            string telemovel = txtContacto.Text;
            string nif = txtNif.Text;
            string profissao = (String)cbProfissoes.SelectedItem;

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

                    string queryInsertData = "INSERT INTO Paciente(nome,dataNascimento,morada,email,contacto,nif,profissao,rua,numeroCasa,andar,codPostalPrefixo,codPostalSufixo,localidade)VALUES('" + nome.ToString() + "','" + dtNascimento + "','" + rua.ToString() + "','"
                        + email.ToString() + "','" + telemovel.ToString() + "','" + nif.ToString() + "','" + profissao.ToString() + "','" + rua.ToString() + "','" + numeroCasa.ToString() + "','" + andarCasa.ToString() + "','" + codPostalPrefixo.ToString() + "','" + codPostalSufixo.ToString() + "','" + localidade.ToString() + "');";
                    SqlCommand sqlCommand = new SqlCommand(queryInsertData, connection);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Paciente registado com Sucesso!");
                    this.Close();
                    connection.Close();
                }
                catch (SqlException excep)
                {

                    MessageBox.Show(excep.Message);

                }

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

        private void txtCodPostalSuf_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCodPostalSuf_KeyPress(object sender, KeyPressEventArgs e)
        {
            //garantir que são inseridos apenas numeros
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
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

        private void btnFechar_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {

        }

        private void FormRegistarUtente_Load(object sender, EventArgs e)
        {
            this.txtNome.Focus();
        }
        public void LimpaCampos(Control.ControlCollection textBoxs)
        {
            foreach (Control txt in textBoxs)
            {
                if (txt.GetType() == typeof(TextBox))
                {
                    txt.Text = string.Empty;
                    this.Close();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.LimpaCampos(this.panelFormulario.Controls);
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            FormMenu formMenu = new FormMenu();
            formMenu.Show();
            this.Close();
        }
    }
}
