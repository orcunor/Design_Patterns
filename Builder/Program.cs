using System;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductDirector productDirector = new ProductDirector();
            var newCustomerProductBuilderbuilder = new NewCustomerProductBuilder();
            var oldCustomerProductBuilder = new OldCustomerProductBuilder();
            productDirector.GenerateProduct(newCustomerProductBuilderbuilder);
            productDirector.GenerateProduct(oldCustomerProductBuilder);
            var newCustomermodel = newCustomerProductBuilderbuilder.GetModel();
            var oldCustomerModel = oldCustomerProductBuilder.GetModel();

            Console.WriteLine(newCustomermodel.ProductName);

            Console.WriteLine(oldCustomerModel.ProductName);


            Console.ReadLine();

        }
    }

    public class ProductModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public bool IsDiscountApplied { get; set; }
    }

    public abstract class ProductBuilder
    {
        public abstract void GetAllProducts();
        public abstract bool ApplyDisconut(bool _isDiscountApplied);
        public abstract ProductModel GetModel();
    }

    public class NewCustomerProductBuilder : ProductBuilder
    {
        ProductModel productModel = new ProductModel();

        public override bool ApplyDisconut(bool _DiscountApplied)
        {
            if (_DiscountApplied)
            {
                productModel.DiscountedPrice = productModel.UnitPrice *(decimal)0.90;
                productModel.IsDiscountApplied = true;
                return _DiscountApplied;
            }
            return _DiscountApplied;
        }

        public override void GetAllProducts()
        {
            productModel.Id = 1;
            productModel.CategoryName = "Beverages";
            productModel.ProductName = "Chai";
            productModel.UnitPrice = 20;
        }

        public override ProductModel GetModel()
        {
            return productModel;
        }
    }

    public class OldCustomerProductBuilder : ProductBuilder
    {
        ProductModel productModel = new ProductModel();
        public override bool ApplyDisconut(bool _DiscountApplied)
        {
            if (_DiscountApplied)
            {
                productModel.DiscountedPrice = productModel.UnitPrice * (decimal)0.90;
                productModel.IsDiscountApplied = true;
                return _DiscountApplied;
            }
            return _DiscountApplied;
        }

        public override void GetAllProducts()
        {
            productModel.Id = 2;
            productModel.CategoryName = "Beverages2";
            productModel.ProductName = "Chai2";
            productModel.UnitPrice = 30;
        }

        public override ProductModel GetModel()
        {
            return productModel;
        }
    }


    public class ProductDirector
    {
        public void GenerateProduct(ProductBuilder productBuilder)
        {
            productBuilder.GetAllProducts();
            productBuilder.ApplyDisconut(false);
        }
    }
}
