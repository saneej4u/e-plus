

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class DoctorsController : BaseApiController
    {

        private readonly IGenericRepository<Doctor> _doctorRepo;
        private readonly IGenericRepository<TitleType> _titleRep;
        private readonly IMapper _mapper;

        public DoctorsController(IGenericRepository<Doctor> doctorRepo, IGenericRepository<TitleType> titleRep, IMapper mapper)
        {
            _mapper = mapper;
            _titleRep = titleRep;
            _doctorRepo = doctorRepo;

        }

        [HttpGet]
        public async Task<ActionResult<List<Doctor>>> GetDoctors()
        {
            var spec = new DoctorWithTitles();

            var doctors = await _doctorRepo.ListAsync(spec);
            return Ok(_mapper.Map<IReadOnlyList<Doctor>, IReadOnlyList<DoctorToReturnDto>>(doctors));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DoctorToReturnDto>> GetDoctor(int id)
        {
            var spec = new DoctorWithTitles(id);
            var doctor = await _doctorRepo.GetEntityWithSpec(spec);

            if(doctor == null)
            {
                return NotFound(new ApiResponse(404));
            }

            return _mapper.Map<Doctor, DoctorToReturnDto>(doctor);
        }

        [HttpGet("titles")]
        public async Task<ActionResult<List<TitleType>>> GetTitles()
        {
            var titles = await _titleRep.ListAllAsync();
            return Ok(titles);
        }
    }
}