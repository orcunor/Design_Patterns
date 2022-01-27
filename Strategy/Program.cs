using System;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.CreditCalculatorBase = new Before2010CreditCalculator();
            customerManager.SaveCredit();


            Console.ReadLine();
        }
    }

    public abstract class CreditCalculatorBase
    {
        public abstract void Calculate();

    }

    public class Before2010CreditCalculator : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Credit calculated Before 2010");
        }
    }

    public class After2010CreditCalculator : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Credit calculated After 2010");
        }
    }


    public class CustomerManager
    {
        public CreditCalculatorBase CreditCalculatorBase { get; set; }
        public void SaveCredit()
        {
            Console.WriteLine("Customer manager business");
            CreditCalculatorBase.Calculate();

        }
    }
}
