using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testapi.Services.PaymentGateways
{
    public class CardPaymentService : IPaymentGateway
    {
        public async Task<bool> ProcessPayment(decimal amount, string currency, string customerId)
        {
            Console.WriteLine($"Processing {amount} {currency} via Card for {customerId}");
            return await Task.FromResult(true);  // Simulating success response
        }
    }

}