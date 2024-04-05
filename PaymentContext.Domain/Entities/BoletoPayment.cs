
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class BoletoPayment : Payment
    {
        public BoletoPayment(
                            string bardCode,
                            string boletoNumber,
                            DateTime paidDate, 
                            DateTime expireDate, 
                            decimal total, 
                            decimal totalPaid, 
                            Document document, 
                            string payer, 
                            Address address, 
                            Email email) : base(boletoNumber, paidDate, expireDate, total, totalPaid, document, payer, address, email)
        {
            BarCod = bardCode;
            BoletoNumber = boletoNumber;
        }

        public string BarCod { get; private set; }

        public string BoletoNumber { get; private set; }
    }
}