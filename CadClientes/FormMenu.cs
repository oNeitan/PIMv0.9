using CadClientes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

       

        private void AbrirFormNoPanel<Forms>() where Forms : Form, new()
        {
            Form formulario;
            formulario = pnlConteudo.Controls.OfType<Forms>().FirstOrDefault();

            if (formulario == null)
            {
                formulario = new Forms();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                pnlConteudo.Controls.Add(formulario);
                pnlConteudo.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
            }
            else 
            {
                if(formulario.WindowState== FormWindowState.Minimized) 
                {
                    formulario.WindowState = FormWindowState.Normal;
                }
                formulario.BringToFront();
            }

        }

        private void btnMenuFuncionario_Click(object sender, EventArgs e)
        {
            //Função para trazer o conteudo até o Panel
            AbrirFormNoPanel<CadFuncionario>();

            //Panel com o Cadastro e consulta
            pnlConteudo.Visible = true;

            //botão de voltar ao Menu
            btnbackMenu.Visible = true;
            btnMenuFuncionario.BackColor = Color.DarkGreen;
            btnMenuFuncionario.ForeColor = Color.LightSeaGreen;
            btnMenuCliente.BackColor = Color.LightSeaGreen;
            btnMenuCliente.ForeColor = Color.DarkGreen;

            //imagens
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = true;

            //labels
            lblMenu.Visible = false;
            lblCadFunc.Visible = true;
            lblCadCliente.Visible = false;
        }

        private void btnMenuCliente_Click(object sender, EventArgs e)
        {
            //Função para trazer o conteudo até o Panel
            AbrirFormNoPanel<CadCliente>();

            //Panel com o Cadastro e consulta
            pnlConteudo.Visible = true;

            //botão de voltar ao Menu
            btnbackMenu.Visible = true;
            btnMenuFuncionario.BackColor = Color.LightSeaGreen;
            btnMenuFuncionario.ForeColor = Color.DarkGreen;
            btnMenuCliente.BackColor = Color.DarkGreen;
            btnMenuCliente.ForeColor = Color.LightSeaGreen;

            //imagens
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = true;

            //labels
            lblMenu.Visible = false;
            lblCadFunc.Visible = false;
            lblCadCliente.Visible = true;
        }

        private void btnMenuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnbackMenu_Click(object sender, EventArgs e)
        {
            //Panel com o Cadastro e consulta
            pnlConteudo.Visible= false;

            //botão de voltar ao Menu
            btnMenuFuncionario.BackColor = Color.LightSeaGreen;
            btnMenuFuncionario.ForeColor = Color.DarkGreen;
            btnMenuCliente.BackColor = Color.LightSeaGreen;
            btnMenuCliente.ForeColor = Color.DarkGreen;
            btnbackMenu.Visible= false;

            //imagens
            pictureBox3.Visible= true;
            pictureBox4.Visible= true;
            pictureBox5.Visible= false;

            //labels
            lblMenu.Visible= true;
            lblCadFunc.Visible= false;
            lblCadCliente.Visible= false;
        }

        private void lblCadCliente_Click(object sender, EventArgs e)
        {

        }
    }
}
