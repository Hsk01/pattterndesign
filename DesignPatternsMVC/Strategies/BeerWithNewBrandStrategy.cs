using DesignPatternsMVC.Models.ViewModels;
using RepositoryApp;
using RepositoryApp.Models;

namespace DesignPatternsMVC.Strategies
{
    public class BeerWithNewBrandStrategy : IBeerStrategy
    {
        public void Add(FormBeerViewModel beerVM, IUnitOfWork unitOfWork)
        {
            var beer = new Beer
            {
                Name = beerVM.Name,
                Style = beerVM.Style
            };

            var brand = new Brand
            {
                Name = beerVM.OtherBrand,
                BrandId = Guid.NewGuid()
            };

            beer.BrandId = brand.BrandId;

            unitOfWork.Brands.Add(brand);
            unitOfWork.Beers.Add(beer);
            unitOfWork.Save();
        }
    }
}
