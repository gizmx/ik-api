using InsanKaynaklariAPI.Contexts;
using InsanKaynaklariAPI.Dtos;
using InsanKaynaklariAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace InsanKaynaklariAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase {

        private readonly OrnekVeriTabaniContext _context;
        public EmployeeController(OrnekVeriTabaniContext context) {
            _context = context;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllEmployees()  {
            var employees = _context.Employees.ToList();
            return Ok(employees);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateEmployee([FromBody] DtoCreateEmployee request) {
            Employee personelim = new()
            {
                Age = request.Age,
                Name = request.Name,
                Surname = request.Surname,
                BirthDate = request.BirthDate,
                FirstStartDate = request.FirstStartDate,
                CompanyID = Guid.Parse(request.CompanyID)
            };

            _context.Employees.Add(personelim);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateEmployee([FromBody] DtoUpdateEmployee request)
        {
        
            Employee? personel = _context.Employees.Where(personel => personel.Id == Guid.Parse
             (request.Id)).FirstOrDefault();

            if (personel == null) return NotFound();

            if (!string.IsNullOrEmpty(request.Name))
                personel.Name = request.Name;

            if (!string.IsNullOrEmpty(request.Surname))
                personel.Surname = request.Surname;

            if (request.FirstStartDate != null)
                personel.FirstStartDate = request.FirstStartDate ?? DateTime.UtcNow;

            if (request.Age != null)
                personel.Age = request.Age ?? 0; 

            if (request.CompanyID != null)
                personel.CompanyID = Guid.Parse(request.CompanyID);

            _context.SaveChanges();
            return Ok();
         }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> DeleteEmployees([FromRoute] string Id)
        {
            Employee? personel = _context.Employees
            .Where(personel => personel.Id == Guid.Parse(Id)).FirstOrDefault();

            if (personel == null)
                return NotFound();

            _context.Employees.Remove(personel);
            _context.SaveChanges();
            return Ok();
        }
    }
}
