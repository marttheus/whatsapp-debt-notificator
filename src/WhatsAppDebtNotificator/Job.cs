namespace WhatsAppDebtNotificator;

public class Job
{
    private readonly ILogger<Job> _logger;

    public Job(ILogger<Job> logger)
    {
        _logger = logger;
    }

    public void Execute(object state) => _logger.LogInformation("Job started at: {time}", DateTimeOffset.Now);
}
