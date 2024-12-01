using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PrimeiroProjeto
{
    public class Db
    {
        private readonly MySqlConnection _connection;

        public Db()
        {
            // Certifique-se de que o banco de dados está configurado corretamente
            _connection = BancoDados.banco.conexao;
        }

        public async Task<List<Dictionary<string, object>>> GetQueryAsync(string command)
        {
            var result = new List<Dictionary<string, object>>();

            try
            {
                // Verifica se a conexão está aberta
                if (_connection.State != System.Data.ConnectionState.Open)
                {
                    await _connection.OpenAsync(); // Abre a conexão de forma assíncrona
                }

                // Cria o comando a ser executado
                MySqlCommand cmd = new MySqlCommand(command, _connection);

                // Executa o comando assíncrono e obtém o leitor de dados
                MySqlDataReader reader = (MySqlDataReader)await cmd.ExecuteReaderAsync();

                // Processa os resultados retornados
                while (await reader.ReadAsync())
                {
                    var row = new Dictionary<string, object>();

                    // Adiciona os dados das colunas ao dicionário
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        row.Add(reader.GetName(i), reader.GetValue(i));
                    }

                    // Adiciona a linha ao resultado
                    result.Add(row);
                }

                // Fecha o reader após o uso
                await reader.CloseAsync();
            }
            catch (Exception ex)
            {
                // Trate os erros caso algo aconteça durante a execução da consulta
                Console.WriteLine("Erro ao executar a consulta: " + ex.Message);
            }
            
            // Retorna os resultados da consulta
            return result;
        }
    }
}
