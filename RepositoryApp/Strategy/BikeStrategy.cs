using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryApp.Strategy
{
    internal class BikeStrategy : IStrategy
    {
        public void Run()
        {
            Console.WriteLine("Soy una bici, a pedalear y hacer ejercicio!!! :D");
        }
    }
}
