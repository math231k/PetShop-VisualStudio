using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PetShop.Core.ApplicationServices;
using PetShop.Core.ApplicationServices.Implementation;
using PetShop.Core.DomainServices;
using PetShop.Infrastructure.Data;
using PetShop.Infrastructure.MSSQL.Data;
using PetShop.Infrastructure.MSSQL.Data.repositories;
using OwnerRepository = PetShop.Infrastructure.MSSQL.Data.repositories.OwnerRepository;
using PetTypeRepository = PetShop.Infrastructure.MSSQL.Data.repositories.PetTypeRepository;

namespace PetShot.RestAPI
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
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });

            services.AddDbContext<PetShopAppContext>(opt => opt.UseSqlite("Data Source=petshop.db").
            UseLoggerFactory(loggerFactory).
            AddInterceptors(new DBInterceptor()),
            ServiceLifetime.Transient
            );
            

            services.AddScoped<IPetRepository, PetSQLRepository>();
            services.AddScoped<IPetService, PetService>();

            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IOwnerService, OwnerService>();

            services.AddScoped<IPetTypeRepository, PetTypeRepository>();
            services.AddScoped<IPetTypeService, PetTypeService>();

            

            

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo 
                    { 
                        Title = "Swagger Demo api",
                        Description = "Demo",
                        Version = "v1"
                    });
                var fileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var filePath = Path.Combine(AppContext.BaseDirectory, fileName);
            });

            services.AddControllers().AddNewtonsoftJson(o =>
            {
                o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                o.SerializerSettings.MaxDepth = 5;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
                //Hvis det k�res lokalt ryk using ud af In Development
            }

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var ctx = scope.ServiceProvider.GetService<PetShopAppContext>();
                var petRepository = scope.ServiceProvider.GetService<IPetRepository>();
                var ownerRepository = scope.ServiceProvider.GetService<IOwnerRepository>();
                var petTypeRepository = scope.ServiceProvider.GetService<IPetTypeRepository>();
                ctx.initData();

                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Demo API");
                options.RoutePrefix = "";
            });
        }
    }
}
