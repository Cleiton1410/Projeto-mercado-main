using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace PrimeiroProjeto
{
    public class BancoDados
    {
       string connectionString = "Server=mysql;Database=mercado;Uid=meu_usuario;Pwd=minha_senha;";

        
        private readonly MySqlConnection conn;

        private static BancoDados? instancia = null;
        
        private BancoDados()
        {
            if (connectionString == null) throw new Exception("Erro ao configurar a string de conexão.");
            
            conn = new MySqlConnection(connectionString);
            conn.Open();
        }

        public static BancoDados banco
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new BancoDados();
                }
                return instancia;
            }
        }

        public MySqlConnection conexao
        {
            get
            {
                return conn;
            }
        }
    }
}
