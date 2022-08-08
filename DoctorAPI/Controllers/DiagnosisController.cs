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
    public class DiagnosisController : ControllerBase
    {
        private readonly IGenericService<Diagnosis> _diagnosisService;
        private readonly IMapper _mapper;
        public DiagnosisController(IGenericService<Diagnosis> diagnosisService, IMapper mapper)
        {
            _diagnosisService = diagnosisService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDiagnoses()
        {
            return Ok(await _diagnosisService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiagnosisById(int id)
        {
            var diagnosis = await _diagnosisService.GetById(id);
            DiagnosisDTO diagnosisDTO = _mapper.Map<DiagnosisDTO>(diagnosis);
            return Ok(diagnosisDTO);
        }
        [HttpPost]
        public async Task<IActionResult> AddDiagnosis(DiagnosisDTO diagnosisDTO)
        {
            Diagnosis diagnosis = _mapper.Map<Diagnosis>(diagnosisDTO);
            await _diagnosisService.Add(diagnosis);
            return Ok("Diagnosis added ");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveDiagnosis(int id)
        {
            await _diagnosisService.RemoveById(id);
            return Ok("Diagnosis removed");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDiagnosis(DiagnosisDTO diagnosisDTO)
        {
            Diagnosis diagnosis = _mapper.Map<Diagnosis>(diagnosisDTO);
            await _diagnosisService.Update(diagnosis);
            return Ok("Diagnosis updated");
        }


    }
}
