
using FoodApp.Data;
using FoodApp.Services;
using Microsoft.EntityFrameworkCore;

namespace OnlinePizzaOrderingwebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IAdminAccessServices,AdminAccessService>();
            // Add services to the container.
            builder.Services.AddDbContext<PizzaOrderingAppContext>
    (Options => Options.UseSqlServer
    (builder.Configuration.GetConnectionString("Constr")));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
