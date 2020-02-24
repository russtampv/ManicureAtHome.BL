using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ManicureAtHome.BL
{
   public class WorkLogger : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new LogWork();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }


        public class LogWork : ILogger
        {
            public IDisposable BeginScope<TState>(TState state)
            {
                return null;
            }

            public bool IsEnabled(LogLevel logLevel)
            {
                return true;
            }

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
                File.AppendAllText($"{DateTime.Now.ToString("yyyy-MM-dd")}log.txt", formatter(state, exception));
                Console.WriteLine(formatter(state, exception));
            }
        }
    }
}
