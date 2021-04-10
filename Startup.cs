using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using GiphyApp.Models;
using GiphyWebApi.Models;
using GiphyWebApi.Interfaces;
using GiphyWebApi.Tools;

namespace GiphyApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFrameworkInMemoryDatabase().
                AddDbContext<GiphyContext>(opt =>
                opt.UseInMemoryDatabase("GiphyList"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            GiphyConfig giphyConfig = new GiphyConfig();
            Configuration.GetSection("Giphy").Bind(giphyConfig);

            //Create singleton from instance
            services.AddSingleton<IGiphyTools, GiphyTools>();
            services.AddSingleton(giphyConfig);

            // Register custom application dependencies.
            //services.AddScoped<IMyCustomRepository, MyCustomSQLRepository>();
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
                app.UseHsts();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
