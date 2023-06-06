using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorSys.MVVM.Model
{
    internal class AllOrderReceipt
    {
        public int Id { get; set; }

        public decimal TotalPrice { get; set; }

        public string? CustomerName { get; set; }

        public string? CashierName { get; set; }

        public DateTime Date { get; set; }
        
        public AllOrderReceipt(int id,decimal totalPrice,string customerName,string cashierName, DateTime date) 
        {
            Id = id;
            TotalPrice = totalPrice;
            CustomerName = customerName;
            CashierName = cashierName;
            Date = date;
        }
    }
}
