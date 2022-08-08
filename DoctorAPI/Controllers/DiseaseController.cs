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
    public class DiseaseController : ControllerBase
    {
        private readonly IDiseaseService _diseaseService;
        private readonly IMapper _mapper;
        public DiseaseController(IDiseaseService diseaseService, IMapper mapper)
        {
            _diseaseService = diseaseService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDiseases()
        {
            return Ok(await _diseaseService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiseaseById(int id)
        {
            var disease = await _diseaseService.GetById(id);
            DiseaseDTO diseaseDTO = _mapper.Map<DiseaseDTO>(disease);
            return Ok(diseaseDTO);
        }
        [HttpPost]
        public async Task<IActionResult> AddDisease(DiseaseDTO diseaseDTO)
        {
            Disease disease = _mapper.Map<Disease>(diseaseDTO);
            await _diseaseService.Add(disease);
            return Ok("Added disease");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveDisease(int id)
        {
            await _diseaseService.RemoveById(id);
            return Ok("Disease removed");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDisease(DiseaseDTO diseaseDTO)
        {
            Disease disease = _mapper.Map<Disease>(diseaseDTO);
            await _diseaseService.Update(disease);
            return Ok("Disease updated");
        }


    }
}
