using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using StatlerWaldorfCorp.Grabbymon.DAL;

namespace StatlerWaldorfCorp.Grabbymon {
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IMonstersRepository, MemoryMonstersRepository>();
	        services.AddMvc();
        }        
    }
}
