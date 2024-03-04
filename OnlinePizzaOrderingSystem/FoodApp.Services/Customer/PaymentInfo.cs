﻿using FoodApp.Entities.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.Services.Customer
{
    public class PaymentInfo
    {
        public PaymentStatus Status { get; set; }
        public string TransactionId { get; set; }

        public PaymentType PaymentType { get; set; }

    }
}
