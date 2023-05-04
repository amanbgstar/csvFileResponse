using CsvHelper;
using EF_Multilayer.Domain.Models;
using EF_Multilayer.Repository.EmpRepo;
using EF_Multilayer.Repository.SkillRepo;
using EF_Multilayer.Repository.SystemDetailsRepo;
using EF_Multilayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;
using System.Globalization;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EF_Multilayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _empRepo;
        private readonly ISkillRepo _skillRepo;
        private readonly ISystemDetailsRepo _detailsRepo;
        public EmployeeController(IEmployeeRepository empRepo, 
            ISkillRepo skillRepo,
            ISystemDetailsRepo detailsRepo)
        {
            _empRepo=empRepo;
            _skillRepo=skillRepo;
            _detailsRepo=detailsRepo;
        }
        
        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
           var op=_empRepo.GetEmployee(id);
            return Ok(op);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public IActionResult Post([FromBody] EmployeeVM employee)
        {
            if (employee.FirstName == null || employee.LastName == null)
                return BadRequest("Emplyee name is required.");

            var emp = new Employee
            {
                Name=employee.FirstName+" "+employee.LastName,
                Age=DateTime.Now.Year - employee.DateOfBirth.Year
            };
            _empRepo.AddEmloyee(emp);

            return Ok(emp.Id);
        }
        // POST api/<EmployeeController>
        [HttpPost("SystemDetails")]
        public IActionResult AddSystemDetails([FromBody] DetailsVM details)
        {
            var detail = new SystemDetail
            {
               SeatCode=details.SeatCode,
               EmployeeId=details.EmployeeId,
               IpAddress=details.IpAddress,
               SystemName=details.SystemName
            };
            _detailsRepo.AddSysInfo(detail);

            return Ok(detail.DetailId);
        }

        // POST api/<EmployeeController>
        [HttpPost("Skills")]
        public IActionResult AddSkills([FromBody] SkillsVM skill)
        {
            var skillObj= new Skill
            {
            Rating=skill.Rating,
            TechName=skill.TechName,
            WorkExp=skill.WorkExp,
            EmployeeId=skill.EmployeeId
            };
            _skillRepo.AddSkills(skillObj);

            return Ok(skillObj.SkillId);

        }

        [HttpGet]
        [Produces("text/csv")]
        public IActionResult GetEmployeesCsv()
        {
            var Employees = _empRepo.GetEmployees();

            using var stream = new MemoryStream();
            using var writer = new StreamWriter(stream, Encoding.UTF8);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(Employees);
            writer.Flush();

            var csvBytes = stream.ToArray();
            return File(csvBytes, "text/csv", "Employess.csv");
        }
    }
}
