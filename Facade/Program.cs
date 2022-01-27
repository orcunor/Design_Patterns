using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();


            Console.ReadLine();
        }
    }
    public interface ILogging
    {
        void Log();
    }
    public interface ICaching
    {
        void Cache();
    }
    public interface IAuthorize
    {
        void CheckUser();
    }

    public class Logging : ILogging
    {
        public void Log()
        {
            Console.WriteLine("Loglandı.");
        }
    }

    public class Caching : ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Cachelendi.");
        }
    }

    public class Authorize : IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("User check.");
        }
    }

    public class CustomerManager
    {
        private readonly CrossCuttingConcernsFacade _concerns;
        public CustomerManager()
        {
            _concerns = new CrossCuttingConcernsFacade();
        }
        public void Save()
        {
            _concerns.Caching.Cache();
            _concerns.Logging.Log();
            _concerns.Authorize.CheckUser();
            Console.WriteLine("Saved");
        }
    }

    public class CrossCuttingConcernsFacade
    {
        public ILogging Logging;
        public ICaching Caching;
        public IAuthorize Authorize;

        public CrossCuttingConcernsFacade()
        {
            Logging = new Logging();
            Caching = new Caching();
            Authorize = new Authorize();
        }
    }
}
