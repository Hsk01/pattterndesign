using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DependencyInjection
{
    public class Beer
    {
        private readonly string _name;
        private readonly string _brand;

        public Beer(string name, string brand)
        {
            _name = name;
            _brand = brand;
        }

        public string Name
        {
            get 
            { 
                return _name;
            }
        }
    }
}
