using InsanKaynaklariAPI.Contexts;
using InsanKaynaklariAPI.Dtos;
using InsanKaynaklariAPI.Migrations;
using InsanKaynaklariAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsanKaynaklariAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase {
        private readonly OrnekVeriTabaniContext _context;
        public CompanyController(OrnekVeriTabaniContext context) {
            _context = context;

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllCompanies() {
            var companies = _context.Companies.ToList();
            return Ok(companies);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateCompany([FromBody] DtoCreateCompany request) {
            Company yeniFirmam = new()
            {
                Name = request.Name
            };
            _context.Companies.Add(yeniFirmam);
            _context.SaveChanges();

            return Ok();
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateCompany([FromBody] DtoUpdateCompany request) {

            Company? arananFirma = _context.Companies.Where(firma => firma.Id == Guid.Parse
            (request.Id)).FirstOrDefault();

            if (arananFirma == null)
                return NotFound();

            arananFirma.Name = request.Name;

            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> DeleteCompany([FromRoute] string Id) {

            Company? arananFirma = _context.Companies
                .Where(firma => firma.Id == Guid.Parse(Id))
                .FirstOrDefault();

            if (arananFirma == null)
                return NotFound();
            _context.Companies.Remove(arananFirma);
            _context.SaveChanges();
            return Ok();

        }

    }
}
