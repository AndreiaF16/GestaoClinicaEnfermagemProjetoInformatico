using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;

namespace GestaoClinicaEnfermagemProjetoInformatico
{
    public partial class FormRegistarEnfermeiro : Form
    {

        public FormRegistarEnfermeiro()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            FormInicial form = new FormInicial();
            form.Show();       }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panelFormulario_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtContacto_KeyPress(object sender, KeyPressEventArgs e)
        {
            //garantir que são inseridos apenas numeros
            if(!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar)){
                e.Handled = true;
            }
        }

        private void txtContacto_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNome_Validating(object sender, CancelEventArgs e)
        {
            if(!Regex.IsMatch(txtNome.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Apenas são permitidas letras neste campo!");
            }
        }

        private void FormRegistarEnfermeiro_Load(object sender, EventArgs e)
        {
            this.txtNome.Focus();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            Regex regexEmail = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (!regexEmail.IsMatch(txtEmail.Text))
            {
                MessageBox.Show("Por favor, introduza um email válido!","Atenção",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Sq
        }
    }
}
