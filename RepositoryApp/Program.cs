// See https://aka.ms/new-console-template for more information

using RepositoryApp;
using RepositoryApp.Models;
using RepositoryApp.Strategy;

//UnitOfWorkFunction();
StrategyFunction();
Console.ReadLine();


static void NotUnit()
{
    // Al tener varios Objetos repos, hay que ejecutar un save o update por cada transacción de ese objeto.
    // Unit of Work nos permite alojar varios repos en una misma clase, la ejecución de varios update o insert se llevaría en una sola transacción.
    // Así la apicación tendría un mejor performance.
    // Esta es un ejemplo donde podría aplicarse el patrón de diseño Unit Of Work.
    using (DesignPatternsContext context = new())
    {
        IRepository<Beer> beerRepo = new Repository<Beer>(context);
        beerRepo.Delete(1);
        beerRepo.Save();

        foreach (var b in beerRepo.Get())
            Console.WriteLine(b.Name);


        Console.WriteLine("---");


        IRepository<Brand> brandRepo = new Repository<Brand>(context);
        var brand = new Brand
        {
            Name = "Fuller"
        };
        brandRepo.Add(brand);
        brandRepo.Save();

        foreach (var br in brandRepo.Get())
        {
            Console.WriteLine(br.Name);
        }
    }
}

static void UnitOfWorkFunction()
{
    // En base al método "NotUnit" así se emplearía Unit Of Work.
    using var context = new DesignPatternsContext();
    IUnitOfWork unitOfWork = new UnitOfWork(context);

    IRepository<Beer> beers = unitOfWork.Beers;
    beers.Delete(1);

    Brand brand = new()
    {
        Name = "Delirium"
    };

    IRepository<Brand> brands = unitOfWork.Brands;
    brands.Add(brand);

    unitOfWork.Save();
}

static void RepositoryFunction()
{
    IEnumerable<Beer> lstBeer;
    using (DesignPatternsContext context = new())
    {
        // Repository separa la tecnología de obtención de datos (SQL Server, API, archivos) de la aplicación, es como una capa intermedia.
        // Pueden realizarse modificaciones a las clases repository sin que le afecte a la aplicación.
        IRepository<Beer> beerRepository = new Repository<Beer>(context);
        Beer beer = new()
        {
            Name = "Pikantus",
            Style = "Bock"
        };
        beerRepository.Add(beer);
        beerRepository.Save();

        lstBeer = beerRepository.Get();
    }

    foreach (var b in lstBeer)
    {
        Console.WriteLine($"{b.Name} - {b.Style}");
    }
}

static void StrategyFunction()
{
    var car = new CarStrategy();
    var moto = new MotoStrategy();
    var bike = new BikeStrategy();
    var context = new ContextStrategy(car);

    context.Run();
    context.Strategy = moto;
    context.Run();
    context.Strategy = bike;
    context.Run();
}