using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Handlers
{
    public class SubscriptionHandler : Notifiable, 
        IHandler<CreateBoletoSubscriptionCommand>,
        IHandler<CreatePayPalSubscriptionCommand>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IEmailService _emailService;

        public SubscriptionHandler(IStudentRepository studentRepository, IEmailService emailService)
        {
            _studentRepository = studentRepository;
            _emailService = emailService;
        }
        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            //Fail Fast Validations
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                    return new CommandResult(false, "assinatura invalida");
            }

            // validar se o documento já está cadastrado

            if (_studentRepository.DocumentExists(command.PayerDocument))
                AddNotification("PayerDocument", "Este cpf já está em uso");

            // verificar se o e-amil já está cadastrado

            if (_studentRepository.EmailExists(command.Email))
                AddNotification("Email", "Este Email já está em uso");

            //gerar VOs

            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.PayerDocument, command.PayerDocumentType);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.StreetNumber, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);



            // gerar entidades

            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));

            var payment = new BoletoPayment(command.BarCode,
                command.BoletoNumber, command.PaidDate, command.ExpireDate, 
                command.Total, command.TotalPaid, document, command.Payer, address, email);


            // Relacionamentos

            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            //Agrupar as validações

            AddNotifications(name, document, email, address, subscription, payment);

            if (Invalid)
            {
                return new CommandResult(false, "Não foi possivel realizar sua assinatura");
            }

            // salvar as informações
            _studentRepository.CreateSubscription(student);

            _emailService.SendEmail(student.Name.FirstName, student.Email.Address, "Bem vindo ao balta.io", "Seja bem vindo");

            return new CommandResult(true, "Assinatura realizada com sucesso");
        }

        public ICommandResult Handle(CreatePayPalSubscriptionCommand command)
        {
            //Fail Fast Validations
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(true, "Assinatura realizada com sucesso");
            }

            // validar se o documento já está cadastrado

            if (_studentRepository.DocumentExists(command.PayerDocument))
                AddNotification("PayerDocument", "Este cpf já está em uso");

            // verificar se o e-amil já está cadastrado

            if (_studentRepository.EmailExists(command.Email))
                AddNotification("Email", "Este Email já está em uso");

            //gerar VOs

            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.PayerDocument, command.PayerDocumentType);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.StreetNumber, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);



            // gerar entidades

            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));

            var payment = new PayPalPayment(command.TransactionCode, command.PaidDate, command.ExpireDate,
                command.Total, command.TotalPaid, document, command.Payer, address, email);


            // Relacionamentos

            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            //Agrupar as validações

            AddNotifications(name, document, email, address, subscription, payment);

            // salvar as informações
            _studentRepository.CreateSubscription(student);

            _emailService.SendEmail(student.Name.FirstName, student.Email.Address, "Bem vindo ao balta.io", "Seja bem vindo");

            return new CommandResult(true, "Assinatura realizada com sucesso");
        }
    }
}
