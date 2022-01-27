using System;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            var personalCar = new PersonalCar { Make = "BMW", Model = "3.20", HirePrice = 2000 };
            SpecialOffer specialOffer = new SpecialOffer(personalCar, 10);

            Console.WriteLine("Concrete : {0} ", personalCar.HirePrice);
            Console.WriteLine("Special Offer : {0} ", specialOffer.HirePrice);
            


            Console.ReadLine();
        }
    }

    public abstract class CarBase
    {
        public abstract string Model { get; set; }
        public abstract string Make { get; set; }
        public abstract decimal HirePrice { get; set; }
        
    }

    public class PersonalCar : CarBase
    {
        public override string Model { get; set; }
        public override string Make { get; set; }
        public override decimal HirePrice { get; set; }
    }

    public class CommercialCar : CarBase
    {
        public override string Model { get; set; }
        public override string Make { get; set; }
        public override decimal HirePrice { get; set; }
    }

    public abstract class CarDecoratorBase : CarBase
    {
        private CarBase _carBase;
        public CarDecoratorBase(CarBase carBase)
        {
            _carBase = carBase;
        }
    }

    public class SpecialOffer : CarDecoratorBase
    {
        private decimal _discountPercentage { get; set; }
        private readonly CarBase _carBase;

        public SpecialOffer(CarBase carBase , decimal discountPercentage) : base (carBase)
        {
            _carBase = carBase;
            _discountPercentage = discountPercentage;
        }
        public override string Model { get; set; }
        public override string Make { get; set; }
        public override decimal HirePrice
        { 
            get
            {
                return _carBase.HirePrice - (_carBase.HirePrice * _discountPercentage / 100); // %10 luk indirim
            }
            set 
            {

            }
        }
    }
}
