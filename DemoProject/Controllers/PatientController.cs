using DemoProject.Data.model;
using DemoProject.Data;
using DemoProject.ModelDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoProject.RepositoryBattern;


namespace DemoProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        // Inject AppDbContext In CTOR
        public PatientController(RepositoryInterface<Patient> db)
        {
            _db = db;
        }
        private readonly RepositoryInterface<Patient> _db;

        [HttpGet]
        public async Task<IActionResult> Getpatient()
        {
            return Ok(await _db.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetpatientByID(int id)
        {
            var patient = await _db.GetByIdAsync(id);
            if (patient != null)
            {
                PatientDTO dTO = new()
                {
                   Id = patient.PatId,
                   Name = patient.Name,
                   Appointament = patient.Appointment
                };
                return Ok(dTO);
            }
            return NotFound();
        }

        [HttpPost]
        public virtual async Task<IActionResult> addpatient(PatientDTO PaDTO)
        {
            if (ModelState.IsValid)
            {
                Patient patient = new()
                {
                   PatId = PaDTO.Id,
                   Name = PaDTO.Name,
                   Appointment = PaDTO.Appointament
                };
                await _db.InsertAsync(patient);
                return Ok(patient);
            }
            return NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> updatepatient(PatientDTO PaDTO)
        {
            Patient patient = new()
            {
                PatId = PaDTO.Id,
                Name = PaDTO.Name,
                Appointment = PaDTO.Appointament
            };
            await _db.UpdateAsync(patient);
            return Ok(patient);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> delepatient(int id)
        {
            var patient = await _db.GetByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            await _db.DeleteAsync(patient);
            return Ok(patient);
        }
    }
}
