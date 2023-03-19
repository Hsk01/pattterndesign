using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BuilderPattern
{
    public class BarmanDirector
    {
        private IBuilder _builder;
        public BarmanDirector(IBuilder builder)
        {
            SetBuilder(builder);
        }

        public void SetBuilder(IBuilder builder)
        {
            _builder = builder;
        }

        public void PrepareRusa()
        {
            _builder.Reset();
            _builder.AddIngredients("50ml Tequila");
            _builder.AddIngredients("300ml Squirt");
            _builder.AddIngredients("Una pizca de sal");
            _builder.AddIngredients("Medio Limón");
            _builder.AddIngredients("3 Hielos");
            _builder.SetAlcohol(5);
            _builder.Mix();
        }

        public void PrepareMargarita()
        {
            _builder.Reset();
            _builder.SetAlcohol(10);
            _builder.SetWater(30);
            _builder.AddIngredients("2 Limones");
            _builder.AddIngredients("Pizca de sal");
            _builder.AddIngredients("1/2 taza de Tequila");
            _builder.AddIngredients("3/4 taza de licor de naranja");
            _builder.AddIngredients("4 cubos de hielo");
            _builder.Mix();
            _builder.Rest(1000);
        }
    }
}
