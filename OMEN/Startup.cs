using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OMEN.Core.Common;
using OMEN.Core.Model;
using OMEN.Core.Repository;
using OMEN.Core.IRepository.Menu;
using OMEN.Core.IRepository.Role;
using OMEN.Core.IRepository.UserMenu;
using OMEN.Core.IRepository.Users;
using OMEN.Core.Repository.Menu;
using OMEN.Core.Repository.Role;
using OMEN.Core.Repository.Users;
using OMEN.Core.IRepository;

namespace OMEN
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OMEN", Version = "v1" });
            });
            services.AddScoped<IBaseRepository<OMEN.Core.Model.Users>, UserRepository>();
            services.AddScoped<IUsersRepository, UserRepository>();

            services.AddSingleton<IBaseRepository<OMEN.Core.Model.Menu>, MenuRepository>();
            services.AddSingleton<IRoleRepository, RoleRepository>();

            // 配置跨域处理，允许所有来源
            services.AddCors(options =>
            options.AddPolicy("cors",
            p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

          
    // Add the whole configuration object here.
    services.AddSingleton<IConfiguration>(Configuration);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OMEN v1"));
            }
            app.UseCors("cors");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
