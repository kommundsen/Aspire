
using Microsoft.EntityFrameworkCore;
using Sample.Api;

public class MigrationJob(IServiceProvider serviceProvider) : BackgroundService
{
    private readonly IServiceProvider serviceProvider = serviceProvider;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<SampleDbContext>();
        await dbContext.Database.MigrateAsync(stoppingToken);
    }
}