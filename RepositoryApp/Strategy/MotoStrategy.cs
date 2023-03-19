using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryApp.Strategy
{
    public class MotoStrategy : IStrategy
    {
        public void Run()
        {
            Console.WriteLine("Soy una moto, tengo 2 llantas.");
            Console.WriteLine("Moto: Y tengo un motorcito.");
        }
    }
}
