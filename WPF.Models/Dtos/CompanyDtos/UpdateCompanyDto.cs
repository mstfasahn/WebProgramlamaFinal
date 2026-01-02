using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models.Dtos.Company
{
    public class UpdateCompanyDto: CreateCompanyDto
    {
        public int Id { get; set; }
    }
}
