using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models.Dtos.OrderDetail
{
    public class UpdateOrderDetailDto:CreateOrderDetailDto
    {
        public int Id { get; set; }
    }
}
