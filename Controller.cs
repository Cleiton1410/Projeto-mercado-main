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

        public async Task<List<Dictionary<string, object>>> getQuery(string command)
        {
            // Chama o método getQuery do Db e retorna os dados prontos para serialização
            return await _db.getQuery(command);
        }
    }
}
