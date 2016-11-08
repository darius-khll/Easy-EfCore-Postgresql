using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace PgCore
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var sqlConnectionString = "User ID=postgres;Password=123;Host=localhost;Port=5433;Database=Db1;Pooling=true;";

            services.AddDbContext<DomainModelPostgreSqlContext>(options =>
                options.UseNpgsql(
                    sqlConnectionString,
                    b => b.MigrationsAssembly("PgCore")
                )
            );

            services.AddScoped<IDataAccessProvider, PgCore.DataAccessPostgreSqlProvider>();

            services.AddMvc();

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvcWithDefaultRoute();

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
