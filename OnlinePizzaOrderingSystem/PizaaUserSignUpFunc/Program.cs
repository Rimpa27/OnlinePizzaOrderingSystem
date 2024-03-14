using FoodApp.Data;
using FoodApp.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
       services.AddScoped<IAdminAccessServices, AdminAccessService>();
       services.AddScoped<ICustomerAccessService, CustomerAccessService>();

        // Add services to the container.
        services.AddDbContext<PizzaOrderingAppContext>
(Options => Options.UseSqlServer
("Server=tcp:online-pizza-ordering-system.database.windows.net,1433;Initial Catalog=OnlinePizzaOrderingSystem;Persist Security Info=False;User ID=Rimpa;Password=Priyanka@2799;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
    })
    .Build();

host.Run();
