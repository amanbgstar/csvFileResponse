using EF_Multilayer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Multilayer.Repository.EmpRepo
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployees();
        Employee GetEmployee(int employeeId);
        void AddEmloyee(Employee emp);
        void UpdateEmloyee(Employee oldEmp, Employee newEmp);
        void DeleteEmloyee(Employee newEmp);
    }
}
