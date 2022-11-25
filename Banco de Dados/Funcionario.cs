using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace BancodeDados
{
    public class Funcionario
    {
        public bool Validar;
        public string Mensagem = "";

        SqlCommand cmd = new SqlCommand();
        Conexao cnx = new Conexao();
        SqlDataReader dataR;


        public string insert(string nome, string CPF, string Endereco, string CEP, string bairro, string celular, string email, string sexo, string senha)
        {
            cmd.CommandText = "insert into Funcionario(Nome,CPF,Endereco,CEP,Bairro,Celular,Email,Sexo,Senha) values(@nome,@CPF,@endereco,@CEP,@bairro,@celular,@email,@sexo,@senha)";
            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@CPF", CPF);
            cmd.Parameters.AddWithValue("@endereco", Endereco);
            cmd.Parameters.AddWithValue("@CEP", CEP);
            cmd.Parameters.AddWithValue("@bairro", bairro);
            cmd.Parameters.AddWithValue("@celular", celular);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@sexo", sexo);
            cmd.Parameters.AddWithValue("@senha", senha);

            try
            {
                cmd.Connection = cnx.conectar();

                cmd.ExecuteNonQuery();

                cnx.desconectar();

                this.Mensagem = "Funcionário cadastrado!";

                Validar = true;


            }
            catch (SqlException e)
            {
                this.Mensagem = "Erro ao se conectar com o servidor" + e;
            }

            return Mensagem;
        }


        public string update(string nome, string CPF, string Endereco, string CEP, string bairro, string celular, string email, string sexo, string senha, string id)
        {
            cmd.CommandText = "update Funcionario Set Nome=@nome,CPF=@CPF,Endereco=@endereco,CEP=@CEP,Bairro=@bairro,Celular=@celular,Email=@email,Sexo=@sexo, Senha=@senha where IDFunc=@id";
            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@CPF", CPF);
            cmd.Parameters.AddWithValue("@endereco", Endereco);
            cmd.Parameters.AddWithValue("@CEP", CEP);
            cmd.Parameters.AddWithValue("@bairro", bairro);
            cmd.Parameters.AddWithValue("@celular", celular);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@sexo", sexo);
            cmd.Parameters.AddWithValue("@senha", senha);
            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                cmd.Connection = cnx.conectar();

                cmd.ExecuteNonQuery();

                cnx.desconectar();

                this.Mensagem = "Informações alteradas com sucesso!";

                Validar = true;


            }
            catch (SqlException)
            {
                this.Mensagem = "Erro ao se conectar com o servidor";
            }


            return Mensagem;
        }

        public string delete(string id)
        {
            cmd.CommandText = "delete from Funcionario where IDFunc=@id";
            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                cmd.Connection = cnx.conectar();

                cmd.ExecuteNonQuery();

                cnx.desconectar();

                this.Mensagem = "Funcionário deletado!";

                Validar = true;


            }
            catch (SqlException)
            {
                this.Mensagem = "Erro ao se conectar com o servidor";
            }

            return Mensagem;
        }

        public string select(string nome, string CPF)
        {
            cmd.CommandText = "Select Nome,CPF,Endereco,CEP,Bairro,Celular,Email,Sexo,Senha from Funcionario where Nome Like @nome+'%'";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dt.Clear();
            da.Fill(dt);

            try
            {
                cmd.Connection = cnx.conectar();

                dataR = cmd.ExecuteReader();

                cnx.desconectar();

                dataR.Close();

            }
            catch (SqlException e)
            {
                this.Mensagem = "Erro ao se conectar com o banco\n" + e;
            }

            return Mensagem;
        }
    }
}
