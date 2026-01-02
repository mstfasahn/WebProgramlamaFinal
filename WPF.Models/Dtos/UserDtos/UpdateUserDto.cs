using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models.Dtos.User
{
    public class UpdateUserDto:CreateUserDto
    {
        public int Id { get; set; }
    }
}
