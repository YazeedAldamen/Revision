using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pomelo.EntityFrameworkCore.MySql;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace DataLayer
{
    public class FactoryDbContext : IDbContextFactory<RevisionDbContext>
    {
        public RevisionDbContext CreateDbContext()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "../Revision");
            //string path = AppContext.BaseDirectory;

            IConfigurationBuilder builder =
                new ConfigurationBuilder()
                    .SetBasePath(path)
                    .AddJsonFile("appsettings.json");

            IConfigurationRoot config = builder.Build();

            string connectionString = config.GetConnectionString("DefaultConnection");
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 32));
            var optionsBuilder = new DbContextOptionsBuilder<RevisionDbContext>();
            optionsBuilder.UseMySql(connectionString, serverVersion);

            return new RevisionDbContext(optionsBuilder.Options);
        }
    }
}