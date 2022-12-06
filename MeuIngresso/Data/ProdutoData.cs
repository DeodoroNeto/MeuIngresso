using System;
using MeuIngresso.Models;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuIngresso.Data
{
    public class ProdutoData : Data
    {
        public void Create(Produto produto)
        {

            SqlCommand comandoSql = new SqlCommand();

            comandoSql.Connection = base.conexaoDB;
            comandoSql.CommandText = @"INSERT INTO Produto (nome, descricao, valor, tipo_De_Show) values(@nome, @descricao, @valor, @tipo_De_Show)";

            comandoSql.Parameters.AddWithValue(@"nome", produto.Nome);
            comandoSql.Parameters.AddWithValue(@"descricao", produto.Descricao);
            comandoSql.Parameters.AddWithValue(@"valor", produto.Valor);
            comandoSql.Parameters.AddWithValue(@"tipo_De_Show", produto.TipoDeShow);

            comandoSql.ExecuteNonQuery();
        }
        
        public List<Produto> Read()
        {
            List<Produto> listaProdutos = null;
            try
            {
                SqlCommand comandoSql = new SqlCommand();

                comandoSql.Connection = base.conexaoDB;
                comandoSql.CommandText = @"SELECT * FROM Produto ORDER BY nome ASC";

                SqlDataReader dadosSql = comandoSql.ExecuteReader();
                listaProdutos = new List<Produto>();

                while (dadosSql.Read())
                {
                    Produto produto = new Produto();
                    produto.IdProduto = (int)dadosSql["idProduto"];
                    produto.Nome = dadosSql["nome"].ToString();
                    produto.Descricao = dadosSql["descricao"].ToString();
                    produto.Valor = dadosSql["valor"].ToString();
                    produto.TipoDeShow = dadosSql["tipo_De_Show"].ToString();

                    listaProdutos.Add(produto);
                }
            }
            catch (SqlException erro)
            {
                Console.WriteLine("Erro: " + erro);
            }
            return listaProdutos;
        }
        public Produto Read(int idProduto)
        {

            Produto produto = null;
            try
            {
                SqlCommand comandoSql = new SqlCommand();

                comandoSql.Connection = base.conexaoDB;
                comandoSql.CommandText = @"SELECET * FROM Produtos WHERE idProduto = @id";
                comandoSql.Parameters.AddWithValue("@id", idProduto);

                SqlDataReader dadosSql = comandoSql.ExecuteReader();
                if (dadosSql.Read())
                {
                    produto = new Produto();
                    produto.IdProduto = (int)dadosSql["idProduto"];
                    produto.Nome = dadosSql["nome"].ToString();
                    produto.Descricao = dadosSql["descricao"].ToString();
                    produto.Valor = dadosSql["valor"].ToString();
                    produto.TipoDeShow = dadosSql["tipo_De_Show"].ToString();
                }
            }
            catch (SqlException erro)
            {
                Console.WriteLine("Erro: " + erro);
            }
            return produto;
        }
        public void Update(Produto produto)
        {
            try
            {
                SqlCommand comandoSql = new SqlCommand();
                comandoSql.Connection = base.conexaoDB;

                comandoSql.CommandText = @"UPDATE Produto SET nome = @nome, descicao = @descricao, valor = @valor, tipo_De_Show = @tipo_De_Show WHERE idProduto = @idProduto";

                comandoSql.Parameters.AddWithValue("@idProduto", produto.IdProduto);
                comandoSql.Parameters.AddWithValue("@nome", produto.Nome);
                comandoSql.Parameters.AddWithValue("@descricao", produto.Descricao);
                comandoSql.Parameters.AddWithValue("@valor", produto.Valor);
                comandoSql.Parameters.AddWithValue("@tipo_De_Show", produto.TipoDeShow);
                comandoSql.ExecuteNonQuery();
            }
            catch(SqlException erro)
            {
                Console.WriteLine("Erro: " + erro);
            }
        }
        public void Delete(int id)
        {
            try
            {
                SqlCommand comandoSql = new SqlCommand();
                comandoSql.Connection = base.conexaoDB;
                comandoSql.CommandText = @"DELETE FROM Produtos WHERE idProduto = @idProduto";
                comandoSql.Parameters.AddWithValue("@idProduto", id);
                comandoSql.ExecuteNonQuery();
            }
            catch (SqlException erro)
            {
                Console.WriteLine("Erro: " + erro);
            }
        }
    }
}
