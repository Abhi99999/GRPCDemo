
using DiscountClient.Service;
using DiscountServer.Protos;
using System.Reflection;

namespace DiscountClient
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



            //Adding Swagger services
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // Registering GRPC services
            builder.Services.AddScoped<DiscountGrpcService>();
            builder.Services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>(
                cfg => cfg.Address = new Uri(builder.Configuration["GrpcSettings:DiscountUrl"])
            );



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();



            //Enable Swagger
            app.UseSwagger();
            app.UseSwaggerUI();




            app.Run();
        }
    }
}
