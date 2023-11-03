using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro.Data.Dapper.Repository.Repositories
{
    [ExcludeFromCodeCoverage]
    public class RepositoryBase
    {
        private readonly IConfiguration _configuration;

        public RepositoryBase(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected string GetConnectionString()
        {
            var strConnection = _configuration.GetSection("ConnectionStrings").GetSection("ConnMicroData").Value;
            return strConnection ?? "";
        }

        


    }
}
