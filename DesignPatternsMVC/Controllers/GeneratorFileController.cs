using Microsoft.AspNetCore.Mvc;
using RepositoryApp;
using Tools.Generator;

namespace DesignPatternsMVC.Controllers
{
    public class GeneratorFileController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly GeneratorConcreteBuilder _generatorConcreteBuilder;

        public IActionResult Index()
        {
            return View();
        }

        public GeneratorFileController(IUnitOfWork unitOfWork, GeneratorConcreteBuilder generatorConcreteBuilder)
        {
            _unitOfWork = unitOfWork;
            _generatorConcreteBuilder = generatorConcreteBuilder;
        }

        public IActionResult CreateFile(int optionFile)
        {
            try
            {
                var beers = _unitOfWork.Beers.Get();
                List<string> content = beers.Select(b => b.Name).ToList();
                string path = "file" + DateTime.Now.Ticks + new Random().Next(1000) + ".txt";
                var generatorDirector = new GeneratorDirector(_generatorConcreteBuilder);

                if (optionFile == 1)
                    generatorDirector.CreateSimpleJsonGenerator(content, path);
                else
                    generatorDirector.CreateSimplePipeGenerator(content, path);

                //Se obtiene el objeto final después de haber seteadp las variables y ejecutado ciertos métodos
                Generator generator = _generatorConcreteBuilder.GetGenerator();
                generator.Save();

                return Json("Archivo generado.");
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
