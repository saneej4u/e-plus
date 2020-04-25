

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorRepository _repo;

        public DoctorsController(IDoctorRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Doctor>>> GetDoctors()
        {
            var doctors = await _repo.GetDoctorsAsync();
            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> GetDoctor(int id)
        {
            return await _repo.GetDoctorByIdAsync(id);
        }

        [HttpGet("titles")]
        public async Task<ActionResult<List<TitleType>>> GetTitles()
        {
            var titles = await _repo.GetTitleAsync();
            return Ok(titles);
        }
    }
}