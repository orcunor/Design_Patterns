using System;
using System.Collections.Generic;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            StockManager stockManager = new StockManager();
            Stock stock = new Stock { Name = "Alfasilin", Quantity = 5 };
            TakeStock takeStock = new TakeStock(stockManager);
            ReturnStock returnStock = new ReturnStock(stockManager);

            StockController stockController = new StockController();

            stockController.TakeOrder(takeStock);
            stockController.TakeOrder(takeStock);
            stockController.TakeOrder(returnStock);
            stockController.TakeOrder(takeStock);

            stockController.PlaceOrders(stock);


            Console.ReadLine();
        }
    }

    class StockManager
    {
      
        public void Take(Stock stock)
        {
            Console.WriteLine("Stock : {0} , {1} taked." , stock.Name, stock.Quantity);
        }

        public void Return(Stock stock)
        {
            Console.WriteLine("Stock : {0} , {1 }. Returned.", stock.Name, stock.Quantity);
        }
    }

    class Stock
    {
        public string Name { get; set; }
        public int Quantity { get; set; }

    }

    interface IOrder
    {
        void Execute(Stock stock);

    }
    class TakeStock : IOrder
    {
        private StockManager _stockManager;

        public TakeStock(StockManager stockManager)
        {
            _stockManager = stockManager;
        }
        public void Execute(Stock stock)
        {
            _stockManager.Take(stock);
        }
    }
    class ReturnStock : IOrder
    {
        private StockManager _stockManager;

        public ReturnStock(StockManager stockManager)
        {
            _stockManager = stockManager;
        }
        public void Execute(Stock stock)
        {
            _stockManager.Return(stock);
        }
    }


    class StockController
    {
        List<IOrder> _orders = new List<IOrder>();

        public void TakeOrder(IOrder order)
        {
            _orders.Add(order);
        }

        public void PlaceOrders(Stock stock)
        {
            foreach (var order in _orders)
            {
                order.Execute(stock);
            }

            _orders.Clear();
        }

    }
}
