using System;
using System.Collections.Generic;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager orcun = new Manager { Name = "Orçun" , Salary = 1000};
            Manager salih = new Manager { Name = "Salih", Salary = 1100 };
           
            Worker engin = new Worker { Name = "Engin" , Salary = 800};
            Worker ali = new Worker { Name = "Ali", Salary = 800 };

            orcun.Subordinates.Add(salih);
            salih.Subordinates.Add(engin);
            salih.Subordinates.Add(ali);

            OrganizationalStructure organizationalStructure = new OrganizationalStructure(orcun);

            PayrollVisitor payrollVisitor = new PayrollVisitor();
            PayriseVisitor payriseVisitor = new PayriseVisitor();

            organizationalStructure.Accept(payrollVisitor);
            organizationalStructure.Accept(payriseVisitor);


            Console.ReadLine();
        }
    }

    class OrganizationalStructure
    {
        public EmployeeBase Employee;
        
        public OrganizationalStructure(EmployeeBase firstEmployee)
        {
            Employee = firstEmployee; 
        }

        public void Accept(VisitorBase visitor)
        {
            Employee.Accept(visitor);
        }
    }
    abstract class EmployeeBase
    {
        public abstract void Accept(VisitorBase visitor);
        public string Name { get; set; }
        public decimal Salary { get; set; }
    }
    class Manager : EmployeeBase
    {
        public List<EmployeeBase> Subordinates { get; set; }
        public Manager()
        {
            if (Subordinates == null)
            {
                Subordinates = new List<EmployeeBase>();
            }
        }
        
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);

            foreach (var employee in Subordinates)
            {
                employee.Accept(visitor);
            }
        }
    }

    class Worker : EmployeeBase
    {
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
        }
    }
    abstract class VisitorBase
    {
        public abstract void Visit(Worker worker);
        public abstract void Visit(Manager manager);
    }

    class PayrollVisitor : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} paid {1}", worker.Name , worker.Salary);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} paid {1}", manager.Name, manager.Salary);
        }

    }

    class PayriseVisitor : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} salary increased to {1}", worker.Name, worker.Salary * (decimal) 1.1);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} salary increased to {1}", manager.Name, manager.Salary * (decimal)1.5);
        }
    }
}
