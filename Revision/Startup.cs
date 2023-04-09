using DataLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace Revision
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public void Configure(IApplicationBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddDbContext<RevisionDbContext>(options=>options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
