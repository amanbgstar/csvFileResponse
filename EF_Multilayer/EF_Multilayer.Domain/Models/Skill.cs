using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Multilayer.Domain.Models
{
    public class Skill
    {
        public int SkillId { get; set; }
        public string TechName { get; set; }
        public decimal? WorkExp { get; set; }
        public decimal? Rating { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
