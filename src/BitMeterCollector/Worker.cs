using System;
using System.Threading;
using System.Threading.Tasks;
using CodeBasement.NetCore.Common;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CodeBasement.BitMeterCollector
{
  public class Worker : BackgroundService
  {
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
      _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
      // Testing submodules
      Hello.Speak();

      while (!stoppingToken.IsCancellationRequested)
      {
        _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
        await Task.Delay(1000, stoppingToken);
      }
    }
  }
}
