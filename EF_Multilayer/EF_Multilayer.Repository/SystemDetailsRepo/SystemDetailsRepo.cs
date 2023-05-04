using EF_Multilayer.Domain.Context;
using EF_Multilayer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Multilayer.Repository.SystemDetailsRepo
{
    public class SystemDetailsRepo: ISystemDetailsRepo
    {
        private readonly EmployeeContext _context;
        public SystemDetailsRepo(EmployeeContext context)
        {
            _context = context;
        }

        public List<SystemDetail> GetSysDetails()
        {
            return _context.SystemDetails.ToList();
        }
        public SystemDetail GetEmpSystemDetaills(int empId)
        {
            return _context.SystemDetails.Where(a => a.EmployeeId == empId).FirstOrDefault(); ;
        }
        public SystemDetail GetSysDetailsById(int id)
        {
            return _context.SystemDetails.FirstOrDefault(a => a.DetailId == id);
        }
        public void AddSysInfo(SystemDetail detail)
        {
            _context.SystemDetails.Add(detail);
            _context.SaveChanges();
        }
    }
}
