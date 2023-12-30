namespace WhatsAppDebtNotificator;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);
        builder.Services.AddHostedService<Worker>();

        builder.Services.AddSingleton<Job>();

        var host = builder.Build();
        host.Run();
    }
}