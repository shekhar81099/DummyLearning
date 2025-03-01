using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testapi.Services.PaymentGateways
{
    public class PaymentGatewayFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public PaymentGatewayFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IPaymentGateway GetPaymentGateway(string gatewayType)
        {
            return gatewayType switch
            {
                "Card" => _serviceProvider.GetRequiredService<CardPaymentService>(),
                "PayPal" => _serviceProvider.GetRequiredService<PayPalPaymentService>(),
                _ => throw new NotImplementedException("Payment Gateway not supported"),
            };
        }
    }

}