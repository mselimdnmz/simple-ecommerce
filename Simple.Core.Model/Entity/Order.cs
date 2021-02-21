using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Core.Model.Entity
{
   public class Order
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int UserAddressId { get; set; }
        public UserAddress UserAddress { get; set; }
        public int StatusId { get; set; }
        public decimal TotalProductPrice { get; set; }
        public decimal TotalTaxPrice { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalPrice { get; set; }
        public virtual List<OrderPayment> OrderPayments { get; set; }
        public virtual List<OrderProduct> OrderProducts { get; set; }
    }
}
