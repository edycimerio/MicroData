using Dapper;
using Micro.Data.Domain.Dtos;
using Micro.Data.Domain.Entities;
using Micro.Data.Domain.Interfaces.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro.Data.Dapper.Repository.Repositories
{
    public class ProdutoDapperRepository: RepositoryBase, IProdutoDapperRepository
    {
        private readonly string? _connstring;
        public ProdutoDapperRepository(IConfiguration configuration) : base(configuration)
        {
            _connstring = GetConnectionString();
        }
        public async Task<IEnumerable<Produto>> SelectProduto()
        {
            // Select
            await using (var db = new SqlConnection(_connstring))
            {
                var sql = @"SELECT * from Produto  ORDER BY id;";

                return await db.QueryAsync<Produto>(sql, commandType: CommandType.Text);
            }
        }

        public async Task<Produto> SelectProdutoById(int id)
        {
            await using (var db = new SqlConnection(_connstring))
            {
                var sql =
                    @"SELECT * from Produto  WHERE id = @id";

                return await db.QueryFirstOrDefaultAsync<Produto>(sql, new { id }, commandType: CommandType.Text);
            }
        }
    }
}
