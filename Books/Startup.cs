using Books.Interface;
using Books.Services;
using ClassLibrary.Interface;
using ClassLibrary.Mappers;
using ClassLibrary.Repositories;
using ClassLibrary.Services;
using ClassLibrary.Validators;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Books
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

            services.AddTransient<ISqlDb, DbContext>();

            services.AddScoped<IBookService, BookService>();
            services.AddTransient<IBooksService, BooksService>();

            services.AddTransient<IBooksMapper, BooksMapper>();

            services.AddTransient<IBooksRepository, BooksRepository>();
            services.AddTransient<ITransactionalAdapter, AbstractTransactionalAdapter>();

            services.AddTransient<IBooksValidationService, BooksValidator>();


            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Books",
                    Version = "v1"
                });
            });
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

            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
