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
using BancodeDados;

namespace View
{
    public partial class CadFuncionario : Form
    {
        Funcionario fc = new Funcionario();
        string Mensagem = "";
        public CadFuncionario()
        {
            InitializeComponent();
            txtIDFunc.ReadOnly = true;
        }
        public void bind_data()
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=LIFETIME;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Select IDFunc as ID,Nome,CPF,Endereco,CEP,Bairro,Celular,Email,Sexo, Senha from Funcionario", conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dt.Clear();
            da.Fill(dt);
            ViewTabFunc.DataSource = dt;
            ViewTabFunc.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            ViewTabFunc.DefaultCellStyle.Font = new Font("Arial", 10);


        }




        private void btnInserirFunc_Click(object sender, EventArgs e)
        {
            fc.insert(txtNomeFunc.Text, txtCPFFunc.Text, txtEnderecoFunc.Text, txtCEPFunc.Text, txtBairroFunc.Text, txtCelularFunc.Text, txtEmailFunc.Text, cbSexoFunc.Text, txtSenhaFunc.Text);

            if (fc.Validar)
            {
                MessageBox.Show("Cadastrado com sucesso!", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(fc.Mensagem);
            }
            bind_data();
        }

        private void btnLimparFunc_Click(object sender, EventArgs e)
        {
            txtIDFunc.Text = "";
            txtNomeFunc.Text = "";
            txtCPFFunc.Text = "";
            txtEnderecoFunc.Text = "";
            txtCEPFunc.Text = "";
            txtBairroFunc.Text = "";
            txtCelularFunc.Text = "";
            txtEmailFunc.Text = "";
            cbSexoFunc.Text = "";
            txtSenhaFunc.Text = "";
        }

        private void btnAlterarFunc_Click(object sender, EventArgs e)
        {
            fc.update(txtNomeFunc.Text, txtCPFFunc.Text, txtEnderecoFunc.Text, txtCEPFunc.Text, txtBairroFunc.Text, txtCelularFunc.Text, txtEmailFunc.Text, cbSexoFunc.Text, txtSenhaFunc.Text, txtIDFunc.Text);
            if (fc.Validar)
            {
                MessageBox.Show("Informações alteradas com sucesso!", "Alterar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(fc.Mensagem);
            }
        
            bind_data();
        }

        private void btnDeletarFunc_Click(object sender, EventArgs e)
        {
            fc.delete(txtIDFunc.Text);
            if (fc.Validar)
            {
                MessageBox.Show("Informações deletadas com sucesso!", "Deletar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(fc.Mensagem);
            }
            bind_data();
        }

        private void btnProcurarFunc_Click(object sender, EventArgs e)
        {
            fc.select(txtSearchNomeFunc.Text, txtSearchCpfFunc.Text);

            bind_data();
        }

        private void ViewTabFunc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index;
            index = e.RowIndex;
            DataGridViewRow selectedRow = ViewTabFunc.Rows[index];
            txtIDFunc.Text = selectedRow.Cells[0].Value.ToString();
            txtNomeFunc.Text = selectedRow.Cells[1].Value.ToString();
            txtCPFFunc.Text = selectedRow.Cells[2].Value.ToString();
            txtEnderecoFunc.Text = selectedRow.Cells[3].Value.ToString();
            txtCEPFunc.Text = selectedRow.Cells[4].Value.ToString();
            txtBairroFunc.Text = selectedRow.Cells[5].Value.ToString();
            txtCelularFunc.Text = selectedRow.Cells[6].Value.ToString();
            txtEmailFunc.Text = selectedRow.Cells[7].Value.ToString();
            cbSexoFunc.Text = selectedRow.Cells[8].Value.ToString();
            txtSenhaFunc.Text = selectedRow.Cells[9].Value.ToString();
        }

        private void CadFuncionario_Load(object sender, EventArgs e)
        {
            bind_data();
        }
    }

}