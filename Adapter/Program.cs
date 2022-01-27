using System;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Log4NetAdapter());
            ProductManager productManager2 = new ProductManager(new OoLogger());
            productManager.Save();
            productManager2.Save();

            Console.ReadLine();
        }
    }

    public class ProductManager
    {
        private ILogger _logger;
        public ProductManager(ILogger logger)
        {
            _logger = logger;
        }

        public void Save()
        {
            _logger.Log("User Data");
            Console.WriteLine("Saved");
        }
    }

    public interface ILogger
    {
        void Log(string message);
    }

    public class OoLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Logged with OoLogger {0} ",message);
        }
    }


    //Nuget
    public class Log4Net
    {
        public void LogMessage(string message)
        {
            Console.WriteLine("Log4net log " + message);
        }
    }

    public class Log4NetAdapter : ILogger
    {
        public void Log(string message)
        {
            Log4Net log4Net = new Log4Net();
            log4Net.LogMessage(message);
        }
    }

}
