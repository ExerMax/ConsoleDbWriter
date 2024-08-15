using DbWriter.DbAccess;
using DbWriter.src.Interfaces;
using DbWriter.src.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

internal class Program
{
    private static void Main(string[] args)
    {
        RunApplication(args);
    }

    private static void RunApplication(string[] args)
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

        string connection = "Server=localhost;Database=DbWriter;Trusted_Connection=True;TrustServerCertificate=True";

        builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));
        builder.Services.AddSingleton<Application>();
        builder.Services.AddTransient<InteractionContext>();
        builder.Services.AddTransient<IXmlParser, XmlParser>();
        builder.Services.AddTransient<IDbWriter, Writer>();
        builder.Services.AddTransient<IInteractHandler, Interactor>();

        IHost host = builder.Build();

        var app = host.Services.GetRequiredService<Application>();

        app.Run();
    }
}