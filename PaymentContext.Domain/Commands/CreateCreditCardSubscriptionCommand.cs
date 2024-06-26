﻿using PaymentContext.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Commands
{
    public class CreateCreditCardSubscriptionCommand
    {


        public string FirstName { get;  set; }
        public string LastName { get;  set; }

        public string Email { get; set; }

        public string CardHolderName { get;  set; }

        public string CardNumber { get; private set; }

        public string LastTransactionNumber { get;  set; }

        public DateTime PaidDate { get; set; }

        public DateTime ExpireDate { get; set; }

        public decimal Total { get; set; }

        public decimal TotalPaid { get; set; }

        public string Payer { get; set; }

        public string PayerDocument { get; set; }

        public EdocumentType PayerDocumentType { get; set; }

        public string PayerEmail { get; set; }

        public string Street { get; set; }

        public string Neighborhood { get; set; }

        public string City { get; set; }

        public string State { get; set; }
        public string Country { get; set; }

        public string ZipCode { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime LasUpdateDate { get; set; }

        public bool Active { get; set; }

    }
}

