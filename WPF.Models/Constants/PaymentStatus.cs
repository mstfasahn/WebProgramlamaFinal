using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models.Constants
{
    public class PaymentStatus
    {
        public const string PaymentWaiting = "Payment is waiting";
        public const string Paid = "Payment Completed";
        public const string PaymentProblem = "There's a problem during payment proccess";
    }
}
