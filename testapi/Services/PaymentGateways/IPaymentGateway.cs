using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testapi.Services.PaymentGateways
{
    public interface IPaymentGateway
    {
        Task<bool> ProcessPayment(decimal amount, string currency, string customerId);
    }
}