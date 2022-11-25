using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancodeDados
{
    public class Acessar
    {
        public bool validacao = false;
        public string mensagem = "";

        SqlCommand cmd = new SqlCommand();
        Conexao cnx = new Conexao();
        SqlDataReader dataR;


        string comandoLogin = "select email, senha from Funcionario where Email = @email and Senha = @senha";

        public bool verificarLogin(string email, string senha)
        {
            cmd.CommandText = comandoLogin;

            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@senha", senha);

            try
            {
                cmd.Connection = cnx.conectar();

                dataR = cmd.ExecuteReader();

                if (dataR.HasRows)
                {
                    validacao = true;
                }

                cnx.desconectar();

                dataR.Close();
            }
            catch (SqlException e)
            {
                this.mensagem = "Erro ao se conectar com o banco\n" + e;
            }


            return validacao;
        }
    }
}
