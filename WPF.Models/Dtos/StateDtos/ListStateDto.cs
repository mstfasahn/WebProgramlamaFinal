using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Models.Dtos.State;

namespace WPF.Models.Dtos.StateDtos
{
    public class ListStateDto:GetStateDto
    {
        public string CityName { get; set; }
    }
}
