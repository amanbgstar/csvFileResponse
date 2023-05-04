using EF_Multilayer.Domain.Context;
using EF_Multilayer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Multilayer.Repository.EmpRepo
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly EmployeeContext _context;
        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;
        }

        public List<Employee> GetEmployees()
        {
            return _context.Employees.ToList();
        }
        public Employee? GetEmployee(int empId)
        {
            return _context.Employees.FirstOrDefault(a => a.Id == empId);
        }
        public void AddEmloyee(Employee emp)
        {
            _context.Employees.Add(emp);
            _context.SaveChanges();
        }
        public void UpdateEmloyee(Employee oldEmp,Employee newEmp)
        {
            _context.Entry<Employee>(oldEmp).CurrentValues.SetValues(newEmp);
            _context.SaveChanges();
        }
        public void DeleteEmloyee(Employee newEmp)
        {
            _context.Employees.Remove(newEmp);
            _context.SaveChanges();
        }
    }
}
