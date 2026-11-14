using Payment.Application.Contracts;
using Payment.Application.Services;
using Payment.Infrastructure.Gateways;

namespace Payment.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // SWAGGER
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // APPLICATION
            builder.Services.AddScoped<ProcessPaymentService>();

            // INFRASTRUCTURE
            builder.Services.AddScoped<IPaymentGateway, FakePaymentGateway>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
