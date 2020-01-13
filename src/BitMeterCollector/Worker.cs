using System;
using System.Threading;
using System.Threading.Tasks;
using CodeBasement.NetCore.Common.Logging;
using Microsoft.Extensions.Hosting;

namespace CodeBasement.BitMeterCollector
{
  public class Worker : BackgroundService
  {
    private readonly ILoggerAdapter<Worker> _logger;

    public Worker(ILoggerAdapter<Worker> logger)
    {
      _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
      while (!stoppingToken.IsCancellationRequested)
      {
        _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
        await Task.Delay(1000, stoppingToken);
      }
    }
  }
}
