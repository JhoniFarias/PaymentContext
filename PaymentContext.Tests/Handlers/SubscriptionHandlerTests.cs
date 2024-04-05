using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Tests.Handlers
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());

            var command = new CreateBoletoSubscriptionCommand();

            command.FirstName = "Jhoni";
            command.LastName = "faria";
            command.Email = "jhonifarias.developer@gmail.com";
            command.BarCode = "123456";
            command.BoletoNumber = "123";
            command.PaymentNumber = "123456";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 1000;
            command.TotalPaid = 1000;
            command.Payer = "Jhoni Faria";
            command.PayerDocument = "99999999999";
            command.PayerDocumentType = EdocumentType.CPF;
            command.PayerEmail = "jhonifarias.developer@gmail.com";
            command.Street = "Rua 10";
            command.StreetNumber = "205";
            command.Neighborhood = "wow";
            command.City = "Guarulhos";
            command.State = "São paulo";
            command.Country = "Brasil";
            command.ZipCode = "07270410";
            command.CreateDate = DateTime.Now;
            command.LasUpdateDate = DateTime.Now;
            command.Active = true;

            handler.Handle(command);

            Assert.AreEqual(false,  handler.Valid);
        }
    }
}
