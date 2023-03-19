using DesignPatternsMVC.Models.ViewModels;
using RepositoryApp;

namespace DesignPatternsMVC.Strategies
{
    public interface IBeerStrategy
    {
        void Add(FormBeerViewModel beerVM, IUnitOfWork unitOfWork);
    }
}
