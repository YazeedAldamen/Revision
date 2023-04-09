using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<RevisionDbContext>
    {
        public RevisionDbContext CreateDbContext(string[] args)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "../Revision");
            //string path = AppContext.BaseDirectory;

            IConfigurationBuilder builder =
                new ConfigurationBuilder()
                    .SetBasePath(path)
                    .AddJsonFile("appsettings.json");

            IConfigurationRoot config = builder.Build();

            string connectionString = config.GetConnectionString("DefaultConnection");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Could not find connection string named 'DefaultConnection'");
            }


            //  DbContextOptionsBuilder allow you to configure the database connection (and other options) to be used for a context.
            DbContextOptionsBuilder<RevisionDbContext> dbContextOptionsBuilder =
                new DbContextOptionsBuilder<RevisionDbContext>();


            //  it sets the database provider and connection string for the context options,
            RevisionDbContext.AddBaseOptions(dbContextOptionsBuilder, connectionString);
            // .Options is what holds the configurations of that instance 
            return new RevisionDbContext(dbContextOptionsBuilder.Options);
        }
    }
}
