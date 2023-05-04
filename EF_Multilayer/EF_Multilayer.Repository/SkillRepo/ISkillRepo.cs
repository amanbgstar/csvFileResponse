using EF_Multilayer.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Multilayer.Repository.SkillRepo
{
    public interface ISkillRepo
    {
         List<Skill> GetSkills();
       
        List<Skill> GetSkillsByEmployee(int empId);
       
         Skill GetSkillById(int id);
        void AddSkills(Skill skill);
       
    }
}
