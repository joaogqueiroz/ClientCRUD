using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjetoAspNetMVC02.Interfaces;
using ProjetoAspNetMVC02.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAspNetMVC02
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            var connectionstring = Configuration.GetConnectionString("Connection");
            services.AddTransient<IClientRepository, ClientRepository>
                (map => new ClientRepository(connectionstring));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //Define frist page in web browser when application starts.
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name:"default", pattern: "{controller=Home}/{action=Index}");
            });
        }
    }
}
