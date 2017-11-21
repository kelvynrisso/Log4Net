using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Log4Net;


namespace Log4Net.ConsoleApp {
   public class Program {
      public static void Main(string[] args) {
         var serviceProvider = new ServiceCollection()
            .AddLogging(builder => builder.AddLog4Net("log4net.config"))
            .BuildServiceProvider();

         using (var loggerFactory = serviceProvider.GetService<ILoggerFactory>()) {
            var logger = loggerFactory.CreateLogger<Program>();

            logger.LogTrace("This is a trace message");
            logger.LogDebug("This is a debug message");
            logger.LogInformation("This is an information message");
            logger.LogWarning("This is a warning message");
            logger.LogError("This is an warning error message");
            logger.LogCritical("This is a critical message");
         }

         Console.WriteLine("Press [ENTER] to Exit!");
         Console.ReadLine();
      }
   }
}
