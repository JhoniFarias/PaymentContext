using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;
using System.Net;

namespace PaymentContext.Tests
{
    [TestClass]
    public class StudentTests
    {
        private readonly Name _name;
        private readonly Document _document;
        private readonly Address _address;
        private readonly Email _email;
        private readonly Student _student;
        private readonly Subscription _subscription;


        public StudentTests()
        {
            _name = new Name("Bruce", "Waine");
            _document = new Document("79446165067", Domain.Enums.EdocumentType.CPF);
            _email = new Email("jhonifarias.developer@gmail.com");
            _address = new Address("Rua 1", "205", "Bairro Legal", "guarulhos", "são paulo", "brazil", "07270410");

            _student = new Student(_name, _document, _email);


            _subscription = new Subscription(null);

        }


        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscription()
        {

            var payment = new PayPalPayment("123456789", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, _document, "Wayne corp", _address, _email);
            _subscription.AddPayment(payment);

            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
        {

            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);
        }


        [TestMethod]
        public void ShouldReturnSuccessWhenAddSubscription()
        {
            var payment = new PayPalPayment("123456789", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, _document, "Wayne corp", _address, _email);
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Valid);
        }


    }
}