using DemoProject.Data.model;
using DemoProject.Data;
using DemoProject.ModelDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoProject.RepositoryBattern;
using Microsoft.AspNetCore.Http.HttpResults;


namespace DemoProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        
        public DoctorController(RepositoryInterface<Doctor> db)
        {
            _db = db;
        }
        private readonly RepositoryInterface<Doctor> _db;

        [HttpGet]
        public async Task<IActionResult> GetDoctor()
        {
            return Ok(await _db.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctorByID(int id)
        {
            var doctor = await _db.GetByIdAsync(id);
            if(doctor != null)
            {
                DoctorDTO dTO = new()
                {
                    ID = doctor.DocId,
                    Name = doctor.Name,
                    appoitment = doctor.Appointment
                };
                return Ok(dTO);
            }
            return NotFound();
        }

        [HttpPost]
        public virtual async Task<IActionResult> addDoctor(DoctorDTO DoDTO)
        {
            if(ModelState.IsValid) 
            {
                Doctor doctor = new()
                {
                    DocId = DoDTO.ID,
                    Name = DoDTO.Name,
                    Appointment = DoDTO.appoitment
                };
                await _db.InsertAsync(doctor);
                return Ok(doctor);
            }
            return NotFound();
        }
        
        [HttpPut]
        public async Task<IActionResult> updateDoctor(DoctorDTO DoDTO)
        {
            Doctor doctor = new()
            {
                DocId = DoDTO.ID,
                Name = DoDTO.Name,
                Appointment = DoDTO.appoitment
            };
            await _db.UpdateAsync(doctor);
            return Ok(doctor);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleDoctor(int id)
        {
           var doctor = await _db.GetByIdAsync(id);
            if(doctor == null)
            {
                return NotFound();
            }
           await _db.DeleteAsync(doctor);
            return Ok(doctor);
        }
    }
}
