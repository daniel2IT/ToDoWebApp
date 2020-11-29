using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ToDoWebApp.Data.Intefaces;
using ToDoWebApp.DataProviders;
using ToDoWebApp.Repository;

namespace ToDoWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration
        {
            get;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /* AddTransient/AddSingleton leidzia susieti tam tikra interfeisa ir klase kuri realizuoja ji */
            services.AddSingleton<ITodoItemRepository,
            TodoItemProvider>();
            /*AddTransient*/
            services.AddSingleton<ICategoryRepository,
            CategoryProvider>();
            // Add our repository type
            services.AddSingleton<ITodoItemAPIRepository,
            TodoAPIRepository>();
            /* Transient services: The object of these services are created newly every time a controller or service class is called or executed. ...
                  Singleton service: The object of this service are created once initially and does not change for any no of requests, regardless of 
                  whether an instance is provided in ConfigureServices. */

            services.AddScoped<TodoAPIRepository>();

            services.AddControllersWithViews();

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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}