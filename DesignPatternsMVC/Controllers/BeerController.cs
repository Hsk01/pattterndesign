using DesignPatternsMVC.Models.ViewModels;
using DesignPatternsMVC.Strategies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RepositoryApp;
using RepositoryApp.Models;

namespace DesignPatternsMVC.Controllers
{
    public class BeerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BeerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<BeerViewModel> beers = from d in _unitOfWork.Beers.Get()
                                               select new BeerViewModel
                                               {
                                                   Id = d.BeerId,
                                                   Name = d.Name,
                                                   Style = d.Style
                                               };

            return View("Index", beers);
        }

        public IActionResult Add()
        {
            GetBrandsData();
            return View();
        }

        [HttpPost]
        public IActionResult Add(FormBeerViewModel beerVM)
        {
            if (!ModelState.IsValid)
            {
                GetBrandsData();
                return View("Add", beerVM);
            }

            var beerContext = beerVM.BrandId == null ?
                                new BeerContext(new BeerWithNewBrandStrategy()) :
                                new BeerContext(new BeerStrategy());

            beerContext.Add(beerVM, _unitOfWork);

            return RedirectToAction("Index");
        }

        #region Helpers
        private void GetBrandsData()
        {
            IEnumerable<Brand> brands = _unitOfWork.Brands.Get();
            ViewBag.Brands = new SelectList(brands, "BrandId", "Name");
        }
        #endregion
    }
}
