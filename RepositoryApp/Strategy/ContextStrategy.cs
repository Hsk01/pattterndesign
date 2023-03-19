using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryApp.Strategy
{
    public class ContextStrategy
    {
        private IStrategy _strategy;

        public IStrategy Strategy
        {
            set
            {
                _strategy = value;
            }
        }

        public ContextStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public void Run()
        {
            _strategy.Run();
        }
    }
}
