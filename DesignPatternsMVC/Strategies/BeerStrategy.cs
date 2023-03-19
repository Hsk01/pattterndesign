using DesignPatternsMVC.Models.ViewModels;
using RepositoryApp;
using RepositoryApp.Models;

namespace DesignPatternsMVC.Strategies
{
    public class BeerStrategy : IBeerStrategy
    {
        // The brands already exists
        public void Add(FormBeerViewModel beerVM, IUnitOfWork unitOfWork)
        {
            var beer = new Beer
            {
                Name = beerVM.Name,
                Style = beerVM.Style,
                BrandId = (Guid)beerVM.BrandId
            };

            unitOfWork.Beers.Add(beer);
            unitOfWork.Save();
        }
    }
}
