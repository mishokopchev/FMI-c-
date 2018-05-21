using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspdota.Adapter;
using aspdota.Data;
using aspdota.Repository;
using aspdota.Serializer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace asp_dota
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
            services.AddSingleton<IGameRepository, GameRepository>();
            services.AddSingleton<IDotaRepository, DotaRepository>();
            services.AddTransient<IReader<aspdota.XmlDto.Dota>, Reader<aspdota.XmlDto.Dota>>();
            services.AddSingleton<Adapter<aspdota.Models.DotaEntity,aspdota.XmlDto.Dota>,DotaDtoToDotaEntityAdapter> ();
            // mvc config
            services.AddDbContext<DotaContext>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
