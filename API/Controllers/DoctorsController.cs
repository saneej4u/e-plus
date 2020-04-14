

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Infastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorsController : ControllerBase
    {
        private readonly ClinicContext _context;
        public DoctorsController(ClinicContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Doctor>>> GetDoctors()
        {
            var doctors = await _context.Doctors.ToListAsync();
            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> GetDoctor(int id)
        {
            return await _context.Doctors.FindAsync(id);
        }

    }
}