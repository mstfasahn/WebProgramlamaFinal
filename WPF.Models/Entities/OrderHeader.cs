using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models.Entities
{
    public class OrderHeader
    {
        public int Id { get; set; }
        public int UserId { get; set; }


        public DateTime OrderDate { get; set; }
        public double OrderTotal { get; set; }

        public string? OrderStatus { get; set; }
        public string? PaymentStatus { get; set; }
        public string? TrackingNumber { get; set; }
        public int? CarrierId { get; set; }

        public Carrier? Carrier { get; set; }
        public DateTime PaymentDate { get; set; }

        public string PhoneNumber { get; set; }
        public string StreetAddress { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public string Name { get; set; }


        public User? User { get; set; }
        public  City? City { get; set; }
        public State? State { get; set; }
        public  ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}
