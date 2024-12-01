using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimeiroProjeto
{
    public class Controller
    {
        private readonly Db _db;

        public Controller(Db db)
        {
            _db = db;
        }

        public async Task<List<Dictionary<string, object>>> GetQueryAsync(string command)
        {
            // Chama o método GetQueryAsync da classe Db e retorna os dados
            return await _db.GetQueryAsync(command);
        }
    }
}
