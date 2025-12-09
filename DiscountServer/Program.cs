
using DiscountServer.Context;
using DiscountServer.Handler;
using DiscountServer.Repository;
using DiscountServer.Service;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DiscountServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();



            builder.Services.AddScoped<IDiscountRepo, DiscountRepo>();
            //adding GRPC service
            builder.Services.AddGrpc();
            //Adding DB context
            builder.Services.AddDbContext<AppDbContext>(options => {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            // Register MediatR
            var assemblies = new Assembly[]
            {
                Assembly.GetExecutingAssembly(),
                typeof(GetDiscountByIdHandler).Assembly
            };
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();



            //Mapping GRPC servicce
            app.MapGrpcService<DiscountService>();



            app.Run();
        }
    }
}
