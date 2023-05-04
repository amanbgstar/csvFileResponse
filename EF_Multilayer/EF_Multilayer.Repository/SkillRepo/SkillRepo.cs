using EF_Multilayer.Domain.Context;
using EF_Multilayer.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Multilayer.Repository.SkillRepo
{
    public class SkillRepo:ISkillRepo
    {
        private readonly EmployeeContext _context;
        public SkillRepo(EmployeeContext context)
        {
            _context = context;
        }

        public List<Skill> GetSkills()
        {
            return _context.Skills.ToList();
        }
        public List<Skill> GetSkillsByEmployee(int empId)
        {
            return _context.Skills.Where(a=>a.EmployeeId== empId).ToList();
        }
        public Skill GetSkillById(int id)
        {
            return _context.Skills.FirstOrDefault(a => a.SkillId == id);
        }
        public void AddSkills(Skill skill)
        {
            _context.Skills.Add(skill);
            _context.SaveChanges();
        }
    }
}
