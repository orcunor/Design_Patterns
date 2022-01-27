
using Ninject;

IKernel kernel = new StandardKernel();
kernel.Bind<IProductDal>().To<NHProductDal>().InSingletonScope(); // ninject IOC Container

ProductManager productManager = new ProductManager(kernel.Get<IProductDal>());
productManager.Save();


Console.ReadLine();



interface IProductDal
{
    void Save();
}

class EFProductDal : IProductDal
{
    public void Save()
    {
        Console.WriteLine("Saved with EF");
    }
}

class NHProductDal : IProductDal
{
    public void Save()
    {
        Console.WriteLine("Saved with NH");
    }
}

class ProductManager
{
    private IProductDal _productDal;
    public void Save()
    {
        // business code's

        _productDal.Save();
    }

    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }
}