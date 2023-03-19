using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DependencyInjection
{
    public class DrinkWithBeer
    {
        //Este objeto no debe crearse dentro de la clase, mejor lo recibe (se le "inyecta").
        //private Beer _beer = new Beer("Pikantus", "Erdinger");

        private Beer _beer;
        private decimal _water;
        private decimal _sugar;

        public DrinkWithBeer(decimal water, decimal sugar, Beer beer)
        {
            _water = water;
            _sugar = sugar;
            _beer = beer;
        }

        public void Build()
        {
            Console.WriteLine($"Preparamos la bebida con {_water} de agua, {_sugar} de azúcar con la cerveza {_beer.Name}!");
        }
    }
}
