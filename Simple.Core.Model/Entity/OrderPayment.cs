﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Core.Model.Entity
{
   public class OrderPayment:EntityBase
    {
        public int OrderId { get; set; }
        public _OrderType OrderType { get; set; }
        public decimal Price { get; set; }
        public string Bank { get; set; }
    }

    public enum _OrderType
    {
        Havale = 0,
        KrediKarti = 1
    }
}
