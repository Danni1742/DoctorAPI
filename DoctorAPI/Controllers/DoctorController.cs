using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Services;
using DAL;
using Models;
using AutoMapper;
using DoctorAPI.DTOs;

namespace DoctorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        private readonly IMapper _mapper;
        public DoctorController(IDoctorService doctorService, IMapper mapper)
        {
            _doctorService = doctorService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
            var doctors = await _doctorService.GetAll();
            IEnumerable<DoctorDTO> doctorDTOs = _mapper.Map<IEnumerable<DoctorDTO>>(doctors);
            return Ok(doctorDTOs);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctorById(int id)
        {
            var doctor = await _doctorService.GetById(id);
            DoctorDTO doctorDTO = _mapper.Map<DoctorDTO>(doctor);
            return Ok(doctorDTO);
        }
        [HttpGet("Age/{id}")]
        public async Task<IActionResult> GetDoctorsAgeById(int id)
        {
            var doctor = await _doctorService.GetById(id);
            int age = doctor.Age();
            return Ok(age);
        }

        [HttpGet("Visits")]
        public IActionResult GetDoctorsWithVisits()
        {
            var doctors =  _doctorService.GetDoctorsWithVisits();
            return Ok(doctors);
        }

        [HttpPost]
        public async Task<IActionResult> AddDoctor(DoctorDTO doctorDTO)
        {
            Doctor doctor = _mapper.Map<Doctor>(doctorDTO);
            await _doctorService.Add(doctor);
            return Ok("Added doctor");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveDoctor(int id)
        {
            await _doctorService.RemoveById(id);
            return Ok("Doctor removed");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDoctor(DoctorDTO doctorDTO)
        {
            Doctor doctor = _mapper.Map<Doctor>(doctorDTO);
            await _doctorService.Update(doctor);
            return Ok("Doctor updated");
        }
        [HttpGet("Avt")]
        public async Task<IActionResult> AddAvaliableVisitTimeDoctor(int id)
        {
            var doctor = await _doctorService.GetByIdWithInclude(id);
            DoctorDTO doctorDTO = _mapper.Map<DoctorDTO>(doctor);
            IEnumerable<AvtDTO> avtDTOs = doctorDTO.AvaliableVisitTimes;
            return Ok(avtDTOs);
        }



    }
}
