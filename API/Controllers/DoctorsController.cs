

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorsController : ControllerBase
    {

        private readonly IGenericRepository<Doctor> _doctorRepo;
        private readonly IGenericRepository<TitleType> _titleRep;

        public DoctorsController(IGenericRepository<Doctor> doctorRepo, IGenericRepository<TitleType> titleRep)
        {
            _titleRep = titleRep;
            _doctorRepo = doctorRepo;

        }

        [HttpGet]
        public async Task<ActionResult<List<Doctor>>> GetDoctors()
        {
            var spec = new DoctorWithTitles();

            var doctors = await _doctorRepo.ListAsync(spec);
            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> GetDoctor(int id)
        {
            var spec = new DoctorWithTitles(id);

            return await _doctorRepo.GetEntityWithSpec(spec);
        }

        [HttpGet("titles")]
        public async Task<ActionResult<List<TitleType>>> GetTitles()
        {
            var titles = await _titleRep.ListAllAsync();
            return Ok(titles);
        }
    }
}