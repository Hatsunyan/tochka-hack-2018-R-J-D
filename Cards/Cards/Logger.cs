using System.Reflection;
using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;

namespace Cards
{
    public static class Logger
    {
        public static void Setup()
        {
            var hierarchy = (Hierarchy)LogManager.GetRepository(Assembly.GetEntryAssembly());

            var patternLayout = new PatternLayout
            {
                ConversionPattern = "%date [%thread] %-5level %logger - %message%newline"
            };
            patternLayout.ActivateOptions();

            /*
            var roller = new RollingFileAppender
            {
                AppendToFile = false,
                File = @"Logs\log.txt",
                Layout = patternLayout,
                MaxSizeRollBackups = 5,
                MaximumFileSize = "1GB",
                RollingStyle = RollingFileAppender.RollingMode.Size,
                StaticLogFileName = true
            };
            roller.ActivateOptions();
            hierarchy.Root.AddAppender(roller);
            */

            var console = new ConsoleAppender
            {
                Layout = patternLayout
            };
            console.ActivateOptions();
            hierarchy.Root.AddAppender(console);

            hierarchy.Root.Level = Level.All;
            hierarchy.Configured = true;
        }
    }
}