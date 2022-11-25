using BancodeDados;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.ConstrainedExecution;
using System.Windows.Forms;

namespace CadClientes
{
    public partial class CadCliente : Form
    {
        Cliente cl = new Cliente();
        SqlDataReader DataR;
        string Mensagem = "";
        public CadCliente()
        {
            InitializeComponent();
            txtID.ReadOnly = true;
        }


        public void bind_data()
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=LIFETIME;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Select IDCliente as ID,Nome,CPF,Endereco,CEP,Bairro,Celular,Email,Sexo, Plano from Cliente", conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dt.Clear();
            da.Fill(dt);
            ViewTab.DataSource = dt;
            ViewTab.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            ViewTab.DefaultCellStyle.Font = new Font("Arial", 10);

           
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
            bind_data();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {

            cl.insert(txtNome.Text, txtCPF.Text, txtEndereco.Text, txtCEP.Text, txtBairro.Text, txtCelular.Text, txtEmail.Text, cbSexo.Text, cbPlanos.Text);
            
            if (cl.Validar)
            {
                MessageBox.Show("Cliente cadastrado com sucesso", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(cl.Mensagem);
            }
            bind_data();

        }

        private void ViewTab_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index;
            index = e.RowIndex;
            DataGridViewRow selectedRow = ViewTab.Rows[index];
            txtID.Text = selectedRow.Cells[0].Value.ToString();
            txtNome.Text = selectedRow.Cells[1].Value.ToString();
            txtCPF.Text = selectedRow.Cells[2].Value.ToString();
            txtEndereco.Text = selectedRow.Cells[3].Value.ToString();
            txtCEP.Text = selectedRow.Cells[4].Value.ToString();
            txtBairro.Text = selectedRow.Cells[5].Value.ToString();
            txtCelular.Text = selectedRow.Cells[6].Value.ToString();
            txtEmail.Text = selectedRow.Cells[7].Value.ToString();
            cbSexo.Text = selectedRow.Cells[8].Value.ToString();
            cbPlanos.Text = selectedRow.Cells[9].Value.ToString();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtNome.Text = "";
            txtCPF.Text = "";
            txtEndereco.Text = "";
            txtCEP.Text = "";
            txtBairro.Text = "";
            txtCelular.Text = "";
            txtEmail.Text = "";
            cbSexo.Text = "";
            cbPlanos.Text = "";
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
           
            cl.update(txtNome.Text, txtCPF.Text, txtEndereco.Text, txtCEP.Text, txtBairro.Text, txtCelular.Text, txtEmail.Text, cbSexo.Text, cbPlanos.Text, txtID.Text);
            if (cl.Validar)
            {
                MessageBox.Show("Informações alteradas com sucesso!", "Alterar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(cl.Mensagem);
            }
            bind_data();


        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            cl.delete(txtID.Text);
            if (cl.Validar)
            {
                MessageBox.Show("Informações deletadas com sucesso!", "Deletar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(cl.Mensagem);
            }
        
            bind_data();
        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            cl.select(txtSearchNome.Text, txtSearchCpf.Text);
            bind_data();
        }

            
    }
    }
