using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using StatlerWaldorfCorp.Grabbymon.DAL;
using SteelToe.Extensions.Configuration;
using StatlerWaldorfCorp.Grabbymon.Models;
using Microsoft.EntityFrameworkCore;

namespace StatlerWaldorfCorp.Grabbymon {
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .AddConfigServer(env);

            Configuration = builder.Build();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddConfigServer(Configuration);
            services.AddMvc();
            services.AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));            
            services.AddScoped<IMonstersRepository, SqlServerMonsterRepository>();
        }        
    }
}
