using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MeuIngresso.Data
{
    public abstract class Data : IDisposable
    {
        protected SqlConnection conexaoDB;

        public Data() //Conexao com o Banco de Dados
        {
            try
            {
                string stringConexao = @"Data source =DESKTOP-6VETETO;
                                     Initial Catalog =BD_MeuIngresso;
                                     Integrated Security = true";
                                     //User Id =aluno; password =aa11++--";

                conexaoDB = new SqlConnection(stringConexao);
                conexaoDB.Open();
            }
            catch(SqlException er)
            {
                Console.WriteLine("\n Erro ao conectar no banco" + er);
            }
        }

        public void Dispose() //Fechar a conexao com o Banco de Dados
        {
            conexaoDB.Close();
        }
    }
}
