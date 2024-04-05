﻿using Flunt.Notifications;
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
    public class CreatePayPalSubscriptionCommand : Notifiable, ICommand
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public string Email { get; set; }

        public string TransactionCode { get; set; }

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
            throw new NotImplementedException();
        }
    }
}
