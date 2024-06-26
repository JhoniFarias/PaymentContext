﻿using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Tests.Mocks
{
    public class FakeEmailService : IEmailService
    {
        public Task SendEmail(string to, string email, string subject, string body)
        {
           return Task.CompletedTask;
        }
    }
}
