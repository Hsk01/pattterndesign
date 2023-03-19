using System;

namespace DesignPatterns.Models.FactoryMethod
{
    // Creator
    public abstract class SaleFactory
    {
        public abstract ISale GetSale();
    }

    // Concrete Creator
    public class StoreSaleFactory : SaleFactory
    {
        public decimal _extra;

        public StoreSaleFactory(decimal extra)
        {
            _extra = extra;
        }

        public override ISale GetSale()
        {
            return new StoreSale(_extra);
        }
    }

    // Concrete Creator
    public class InternetSaleFactory : SaleFactory
    {
        private decimal _discount;

        public InternetSaleFactory(decimal discount)
        {
            _discount = discount;
        }

        public override ISale GetSale()
        {
            return new InternetSale(_discount);
        }
    }

    // Concrete Creator
    public class AmbulanteSaleFactory : SaleFactory
    {
        public override ISale GetSale()
        {
            return new AmbulanteSale();
        }
    }


    // ConcreteProduct
    public class InternetSale : ISale
    {
        private decimal _discount;

        public InternetSale(decimal discount)
        {
            _discount = discount;
        }

        public void Sell(decimal total)
        {
            Console.WriteLine($"La venta en INTERNET tiene un total de {total - _discount}");
        }
    }

    // ConcreteProduct
    public class StoreSale : ISale
    {
        private decimal _extra;

        public StoreSale(decimal extra)
        {
            _extra = extra;
        }

        public void Sell(decimal total)
        {
            Console.WriteLine($"La venta en TIENDA tiene un total de {total + _extra}");
        }
    }

    // ConcreteProduct
    public class AmbulanteSale : ISale
    {
        public void Sell(decimal total)
        {
            Console.WriteLine($"La venta AMBULANTE tiene un total de {total} -Sin descuentos ni extras-");
        }
    }

    // Product
    public interface ISale
    {
        void Sell(decimal total);
    }
}
