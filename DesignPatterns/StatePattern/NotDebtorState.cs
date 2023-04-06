using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StatePattern
{
    public class NotDebtorState : IState
    {
        public void Action(CustomerContext customerContext, decimal amount)
        {
            if (amount <= customerContext.Residue)
            {
                customerContext.Discount(amount);
                Console.WriteLine($"Gastó {amount} y le queda de saldo: {customerContext.Residue}");

                if(customerContext.Residue <= 0)
                    customerContext.SetState(new DebtorState());
            }
            else
            {
                Console.WriteLine($"No te alcanza. Saldo en cuenta: {customerContext.Residue} | Monto solicitado: {amount}");
            }
        }
    }
}
