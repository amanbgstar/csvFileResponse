using EF_Multilayer.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Multilayer.Repository.SystemDetailsRepo
{
    public interface ISystemDetailsRepo
    {
        List<SystemDetail> GetSysDetails();

        SystemDetail GetEmpSystemDetaills(int empId);

        SystemDetail GetSysDetailsById(int id);

        void AddSysInfo(SystemDetail detail);
       
    }
}
