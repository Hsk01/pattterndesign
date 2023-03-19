using DesignPatterns.BuilderPattern;
using DesignPatterns.DependencyInjection;
using DesignPatterns.Models.FactoryMethod;
using System.Runtime.CompilerServices;
using System.Security.Principal;

//FactoryMethod();
//DependencyInjection();
Builder();

Console.ReadLine();


static void FactoryMethod()
{
    //Creator - ConcreteCreator
    //la responsabilidad recae en la fábrica, se introduce de una vez el extra para no tener que meter ese dato cada vez que se llame un método del ConcreteProduct.
    SaleFactory storeSaleFactory = new StoreSaleFactory(10);
    SaleFactory internetSaleFactory = new InternetSaleFactory(5);
    SaleFactory ambulanteSaleFactory = new AmbulanteSaleFactory();

    //ConcreteCreator creates ConcreteProduct
    ISale storeSale = storeSaleFactory.GetSale();
    ISale internetSale = internetSaleFactory.GetSale();
    ISale ambulanteSale = ambulanteSaleFactory.GetSale();

    //ConcreteProduct does what it has to do
    storeSale.Sell(100);
    internetSale.Sell(100);
    ambulanteSale.Sell(100);
}

static void DependencyInjection()
{
    /*
     * A la clase Drink se le debería pasar el objeto cerveza ya hecho, no es responsabilidad de Drink crear una cerveza para después poder crearse.
     * Si se llega a modificar Beer, también debería modificarse Drink, y demás clases donde creen dentro de si mismas un objeto Beer.
     */

    Beer myBeer = new("Victoria", "Modelo");
    DrinkWithBeer myDrink = new(200, 10, myBeer);
    myDrink.Build();
}

static void Builder()
{
    var builder = new PreparedAlcoholDrinkConcreteBuilder();
    var barman = new BarmanDirector(builder);

    barman.PrepareRusa();

    PreparedDrink myPreparedDrink = builder.GetPreparedDrink();
    Console.WriteLine(myPreparedDrink.Result);
}