using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Multilayer.Domain.Models
{
    public class SystemDetail
    {
        public int DetailId { get; set; }
        public string SystemName { get; set; }
        public string SeatCode { get; set; }
        public string IpAddress { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
