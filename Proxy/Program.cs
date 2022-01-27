using System;
using System.Threading;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            CreditBase creditManager = new CreditManagerProxy();
            Console.WriteLine(creditManager.Calculate());
            Console.WriteLine(creditManager.Calculate());

            Console.ReadLine();
        }
    }

    public abstract class CreditBase
    {
        public abstract decimal Calculate();
    }

    class CreditManager : CreditBase
    {
        public override decimal Calculate()
        {
            int result = 1;
            for (int i = 1; i < 5; i++)
            {
                result *= i;
                Thread.Sleep(1000);
            }
            return result;
        }
    }

    public class CreditManagerProxy : CreditBase // bi nevi cache mantığı
    {
        private CreditManager _creditManager;
        private decimal _cachedValue;
        public override decimal Calculate()
        {
            if (_creditManager == null) // daha önce çağırıldı mı çağırılmadı mı bak çağırılmadıysa işlemi yap cachevalue at, bir sonraki çağırıldığında direkt olarak cachedvalue yi returnla tekrar uğraşma calculate ile.
            {
                _creditManager = new CreditManager();
                _cachedValue = _creditManager.Calculate();
            }
            return _cachedValue;
        }
    }
}
