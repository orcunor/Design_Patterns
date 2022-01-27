using System;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new LoggerFactory());

            customerManager.Save();

            Console.ReadLine();
        }
    }

    public class LoggerFactory : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            // duruma göre logger ver burda iş geliştir.
            return new DatabaseLogger();
        }
    }

    public interface ILogger
    {
        void Log();
    }

    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }

    public class FileLogger : ILogger
    {
        public void Log()
        {
            // business
            Console.WriteLine("File logger!!!.");
        }
    }

    public class DatabaseLogger : ILogger
    {
        public void Log()
        {
            // business
            Console.WriteLine("Database logger!!!.");
        }
    }


    public class CustomerManager
    {
        private readonly ILoggerFactory _loggerFactory;
        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }
        public void Save()
        {
            Console.WriteLine("Saved");
            var logger = _loggerFactory.CreateLogger();
            logger.Log();
        }
    }
}
