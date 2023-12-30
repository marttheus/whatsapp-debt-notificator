namespace WhatsAppDebtNotificator
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly Job _job;

        private Timer _timer;

        public Worker(ILogger<Worker> logger, Job job)
        {
            _logger = logger;
            _job = job;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _timer = new Timer(_job.Execute, null, TimeSpan.Zero, TimeSpan.FromHours(1));

            return Task.CompletedTask;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Worker started at: {time}", DateTimeOffset.Now);

            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
            _timer.Dispose();

            _logger.LogInformation("Worker stopped at: {time}", DateTimeOffset.Now);

            return base.StopAsync(cancellationToken);
        }
    }
}
