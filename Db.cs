using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PrimeiroProjeto
{
    public class Db
    {
        public async Task<List<Dictionary<string, object>>> getQuery(string command)
        {
            MySqlConnection conexao = BancoDados.banco.conexao;

            if (conexao.State == ConnectionState.Closed)
            {
                await conexao.OpenAsync();
            }

            MySqlCommand selectCommand = new MySqlCommand(command, conexao);
            var resultado = new List<Dictionary<string, object>>();

            using (var reader = await selectCommand.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    var row = new Dictionary<string, object>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        row.Add(reader.GetName(i), reader.GetValue(i));
                    }
                    resultado.Add(row);
                }
            }

            return resultado;
        }
    }
}
