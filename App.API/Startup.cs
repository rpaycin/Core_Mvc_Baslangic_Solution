using App.Core.Service;
using App.Repository;
using App.Service.Mapping;
using App.Service.Service;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace App.API
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

            // ben ekledim altakileri
            services.AddDbContext<AksaContext>(
                x => x.UseSqlServer(Configuration["ConnectionStrings:AksaConnectionString"],
                options => options.MigrationsAssembly(Assembly.GetAssembly(typeof(AksaContext)).GetName().Name))
            );

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IParamGenService, ParamGenService>();

            services.AddAutoMapper(typeof(MapperProfile));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
