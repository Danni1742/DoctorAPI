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
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;
        public PatientController(IPatientService patientService, IMapper mapper)
        {
            _patientService = patientService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            return Ok(await _patientService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            var patient = await _patientService.GetById(id);
            PatientDTO patientDTO = _mapper.Map<PatientDTO>(patient);
            return Ok(patientDTO);
        }

        [HttpGet("Age/{id}")]
        public async Task<IActionResult> GetPatientsAgeById(int id)
        {
            var patient = await _patientService.GetById(id);
            int age = patient.Age();
            return Ok(age);
        }
        [HttpPost]
        public async Task<IActionResult> AddPatient(PatientDTO patientDTO)
        {
            Patient patient = _mapper.Map<Patient>(patientDTO);
            await _patientService.Add(patient);
            return Ok("Added patient");
        }
        [HttpDelete]
        public async Task<IActionResult> RemovePatient(int id)
        {
            await _patientService.RemoveById(id);
            return Ok("Patient removed");
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePatient(PatientDTO patientDTO)
        {
            Patient patient = _mapper.Map<Patient>(patientDTO);
            await _patientService.Update(patient);
            return Ok("Patient updated");
        }


    }
}
