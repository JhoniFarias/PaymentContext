﻿using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Commands
{
    public class CreateBoletoSubscriptionCommand : Notifiable, ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }

        public string BarCode { get; set; } 
        public string BoletoNumber { get; set; }

        public string PaymentNumber { get;  set; }



        public DateTime PaidDate { get;  set; }

        public DateTime ExpireDate { get;  set; }

        public decimal Total { get;  set; }

        public decimal TotalPaid { get;  set; }

        public string Payer { get; set; }
        public string PayerDocument { get;  set; }
        public EdocumentType PayerDocumentType { get;  set; }

        public string PayerEmail { get; set; }

        public string Street { get;  set; }
        public string StreetNumber { get;  set; }

        public string Neighborhood { get;  set; }

        public string City { get;  set; }

        public string State { get;  set; }
        public string Country { get;  set; }

        public string ZipCode { get;  set; }

        public DateTime CreateDate { get;  set; }

        public DateTime LasUpdateDate { get;  set; }

        public bool Active { get;  set; }

        public void Validate()
        {
            AddNotifications(new Contract()
              .Requires()
              .HasMinLen(FirstName, 3, "Name.FirstName", "Nome deve conter pelo menos 3 caracteres")
              .HasMinLen(LastName, 3, "Name.LastName", "Sobrenome deve conter pelo menos 3 caracteres")
              );
        }
    }
}
