using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {

            var customerManager = CustomerManager.CreateInstance();
            customerManager.Save();

            Console.ReadLine();
        }
    }

    public class CustomerManager
    {
        private static CustomerManager _customerManager { get; set; }
        private static object _lockObject = new object();
        private CustomerManager()
        {

        }
        public static CustomerManager CreateInstance()
        {
            lock (_lockObject) // thread safe
            {
                if (_customerManager == null)
                    _customerManager = new CustomerManager();

                return _customerManager;
            }
        }

        public void Save()
        {
            Console.WriteLine("Saved");
        }
    }
}
