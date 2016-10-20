using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using StatlerWaldorfCorp.Grabbymon.DAL;
using Steeltoe.Extensions.Configuration;
using StatlerWaldorfCorp.Grabbymon.Models;
using Microsoft.EntityFrameworkCore;
using Steeltoe.Discovery.Client;
using StatlerWaldorfCorp.Grabbymon.Grab;

namespace StatlerWaldorfCorp.Grabbymon {
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .AddConfigServer(env);

            Configuration = builder.Build();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDiscoveryClient();
            app.UseMvc();            
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddConfigServer(Configuration);
            services.AddDiscoveryClient(Configuration);
            services.AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));            
            services.AddScoped<IMonstersRepository, SqlServerMonsterRepository>();
            services.AddScoped<IClient, StatlerWaldorfCorp.Grabbymon.Grab.Client>();            
            services.AddMvc();            
        }        
    }
}
