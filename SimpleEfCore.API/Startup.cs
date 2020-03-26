using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleEfCore.API.DbContexts;
using SimpleEfCore.API.Services;

namespace SimpleEfCore.API
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
            services.AddControllers(options =>
            {
            })
            .AddNewtonsoftJson()
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddScoped<AuthorRepository>();

            services.AddDbContext<CourseContext>(options =>
            {
                //options.UseInMemoryDatabase("CourseManagerInMemoryDB");
                options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CourseManagerDB;Trusted_Connection=True;");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllers();
            });
        }
    }
}
