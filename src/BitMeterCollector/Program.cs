using CodeBasement.NetCore.Common.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CodeBasement.BitMeterCollector
{
  public class Program
  {
    public static void Main(string[] args)
    {
      CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
      return Host
        .CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
          services
            .AddHostedService<Worker>()
            .AddSingleton(typeof(ILoggerAdapter<>), typeof(LoggerAdapter<>));
        });
    }
  }
}
