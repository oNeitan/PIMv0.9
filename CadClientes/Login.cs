using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BancodeDados;

namespace View
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnCloseLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Acessar lg = new Acessar();
            lg.verificarLogin(txtUserLogin.Text, txtPassLogin.Text);

            if (lg.mensagem.Equals(""))
            {

                if (lg.validacao)
                {
                    MessageBox.Show("Logado com sucesso!", "Entrando", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    FormMenu tmenu = new FormMenu();

                    tmenu.Show();
                }
                else
                {
                    MessageBox.Show("Falha ao logar", "E-mail ou senha incorretos", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show(lg.mensagem);
            }
            
        }

        private void txtUserLogin_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
