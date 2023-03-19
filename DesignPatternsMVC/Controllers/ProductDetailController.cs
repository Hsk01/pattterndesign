using Microsoft.AspNetCore.Mvc;
using System.Xml.Schema;
using Tools.Earn;

namespace DesignPatternsMVC.Controllers
{
    public class ProductDetailController : Controller
    {
        private EarnFactory _localEarnFactory;
        private EarnFactory _foreignFactory;

        //Aquí la dependency injection ya crea el objeto cuando se realiza una solicitud 
        public ProductDetailController(LocalEarnFactory localEarnFactory, ForeignEarnFactory foreignFactory)
        {
            _localEarnFactory = localEarnFactory;
            _foreignFactory = foreignFactory;
        }

        //la variable decimal total es el precio del producto.
        public IActionResult Index(decimal total)
        {
            // Factories

            // Esta declaración no es necesaria dentro de la clase ProductDetailController por que ahora se crea desde antes y ProductDetailController la recibe.
            //LocalEarnFactory localEarnFactory = new(0.20m);
            //ForeignEarnFactory frEarnFactoy = new(0.20m, 1.25m);

            // Products (objeto(s) que crea la fábrica)
            var localEarn = _localEarnFactory.GetEarn();
            var frEarn = _foreignFactory.GetEarn();

            //total
            ViewBag.totalLocal = total + localEarn.Earn(total);
            ViewBag.totalForeign = total + frEarn.Earn(total);

            return View();
        }
    }
}
