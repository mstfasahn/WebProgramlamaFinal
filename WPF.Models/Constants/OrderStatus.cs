using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models.Constants
{
    public class OrderStatus
    {
        public const string NewOrder = "New Order";
        public const string InProccess = "Proccessing";
        public const string Completed = "Completed";
        public const string WillBeRefunded = "Will be Refunded";
        public const string RefundingProccess = "In Refunding Proccess";
        public const string Refunded = "Refunded";
    }
}
