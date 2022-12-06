using System;
using MeuIngresso.Models;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuIngresso.Data
{
    public class ClienteData : Data
    {
        //CRUD da classe Cliente
        public void Create(Cliente cliente)
        {
            SqlCommand comandoSql = new SqlCommand();

            //Conexao com o Banco de Dados
            comandoSql.Connection = base.conexaoDB;
            comandoSql.CommandText = @"INSERT INTO Clientes (nome, email, senha) values(@nome, @email, @senha)";

            comandoSql.Parameters.AddWithValue(@"nome", cliente.Nome);
            comandoSql.Parameters.AddWithValue(@"email", cliente.Email);
            comandoSql.Parameters.AddWithValue(@"senha", cliente.Senha);

            comandoSql.ExecuteNonQuery();
        }

        public List<Cliente> Read()
        {
            List<Cliente> listaClientes = null;
            try
            {
                SqlCommand comandoSql = new SqlCommand();

                //Conexao com o Banco de Dados
                comandoSql.Connection = base.conexaoDB;
                comandoSql.CommandText = @"SELECT * from Clientes ORDER BY nome ASC";

                SqlDataReader dadosSQL = comandoSql.ExecuteReader();
                listaClientes = new List<Cliente>();

                while (dadosSQL.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.IdCliente = (int)dadosSQL["idCliente"];
                    cliente.Nome = dadosSQL["nome"].ToString();
                    cliente.Email = dadosSQL["email"].ToString();

                    listaClientes.Add(cliente);
                }
            }
            catch (SqlException erro)
            {
                Console.WriteLine("Erro: " + erro);
            }
            return listaClientes;
        }
        public Cliente Read(int idCli)
        {
            Cliente cliente01 = null;
            try
            {
                SqlCommand comandoSql = new SqlCommand();

                //Conectando com o banco de dados
                comandoSql.Connection = base.conexaoDB;

                comandoSql.CommandText = @"SELECT * from Clientes where idCliente = @id";
                comandoSql.Parameters.AddWithValue("@id", idCli);
                SqlDataReader dadosSQL = comandoSql.ExecuteReader();
                if (dadosSQL.Read())
                {
                    cliente01 = new Cliente();
                    cliente01.IdCliente = (int)dadosSQL["idCliente"];
                    cliente01.Nome = dadosSQL["nome"].ToString();
                    cliente01.Email = dadosSQL["email"].ToString();
                }
            }
            catch (SqlException erro)
            {
                Console.WriteLine("Erro" + erro);
            }
            return cliente01;
        }
        public Cliente Read(string email)
        {
            Cliente cliente02 = null;
            try
            {
                SqlCommand comandoSql = new SqlCommand();

                //Conectando com o banco de dados
                comandoSql.Connection = base.conexaoDB;

                comandoSql.CommandText = @"SELECT * from Clientes where email = @email";
                comandoSql.Parameters.AddWithValue("@email", email);
                SqlDataReader dadosSQL = comandoSql.ExecuteReader();

                if (dadosSQL.Read())
                {
                    cliente02 = new Cliente();
                    cliente02.IdCliente = (int)dadosSQL["idCliente"];
                    cliente02.Nome = dadosSQL["nome"].ToString();
                    cliente02.Email = dadosSQL["email"].ToString();
                    cliente02.Senha = dadosSQL["senha"].ToString();
                }

            }
            catch (SqlException erro)
            {
                Console.WriteLine("Erro" + erro);
            }

            return cliente02;
        }
        public void Update(Cliente cliente)
        {
            try
            {
                SqlCommand comandoSql = new SqlCommand();
                //Conectando com o banco de dados
                comandoSql.Connection = base.conexaoDB;

                comandoSql.CommandText = @"Update Clientes SET nome = @nome, email = @email, senha = @senha where IdCliente = @id";
                comandoSql.Parameters.AddWithValue("@id", cliente.IdCliente);
                comandoSql.Parameters.AddWithValue("@nome", cliente.Nome);
                comandoSql.Parameters.AddWithValue("@email", cliente.Email);
                comandoSql.Parameters.AddWithValue("@senha", cliente.Senha);
                comandoSql.ExecuteNonQuery();
            }
            catch (SqlException erro)
            {
                Console.WriteLine("Erro" + erro);
            }
        }

        public void Delete(int id)
        {
            try
            {
                SqlCommand comandoSql = new SqlCommand();
                //Conectando com o banco de dados
                comandoSql.Connection = base.conexaoDB;

                comandoSql.CommandText = @"DELETE FROM Clientes WHERE idCliente = @id";
                comandoSql.Parameters.AddWithValue("@id", id);


                comandoSql.ExecuteNonQuery();
            }
            catch (SqlException erro)
            {
                Console.WriteLine("Erro " + erro);
            }
        }

    }
}
