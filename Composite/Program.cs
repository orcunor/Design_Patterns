using System;
using System.Collections;
using System.Collections.Generic;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee orcun = new Employee { FirstName = "Orçun"};
            Employee deniz = new Employee { FirstName = "Deniz" };
            Employee ersen = new Employee { FirstName = "Ersen" };
            Employee mehmet = new Employee { FirstName = "Mehmet" };

            orcun.AddSubordinate(deniz);

            Employee gorkem = new Employee { FirstName = "Görkem" };
            orcun.AddSubordinate(gorkem);

            Employee ahmet = new Employee { FirstName = "Ahmet" };
            deniz.AddSubordinate(ahmet);
            orcun.AddSubordinate(ersen);
            ersen.AddSubordinate(mehmet);

            Console.WriteLine(orcun.FirstName);
            foreach (Employee manager in orcun)
            {
                Console.WriteLine(" -" + manager.FirstName);

                foreach (IPerson employee in manager)
                {
                    Console.WriteLine("    *" + employee.FirstName);
                }
            }

            Console.ReadLine();
        }
    }

    public interface IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Employee : IPerson, IEnumerable<IPerson>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

       private readonly List<IPerson> _subordinates = new List<IPerson>();

        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }
        public void RemoveSubordinate(IPerson person)
        {
            _subordinates.Remove(person);
        }

        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }

        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
