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
    public class VisitController : ControllerBase
    {
        private readonly IVisitService _visitService;
        private readonly IMapper _mapper;
        public VisitController(IVisitService visitService, IMapper mapper)
        {
            _visitService = visitService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllVisits()
        {
            return Ok(await _visitService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVisitById(int id)
        {
            var visit = await _visitService.GetById(id);
            VisitDTO visitDTO = _mapper.Map<VisitDTO>(visit);
            return Ok(visitDTO);
        }
        [HttpPost]
        public async Task<IActionResult> AddVisit(VisitDTO visitDTO)
        {
            Visit visit = _mapper.Map<Visit>(visitDTO);
            await _visitService.Add(visit);
            return Ok("Added visit");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveVisit(int id)
        {
            await _visitService.RemoveById(id);
            return Ok("Visit removed");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateVisit(VisitDTO visitDTO)
        {
            Visit visit = _mapper.Map<Visit>(visitDTO);
            await _visitService.Update(visit);
            return Ok("Visit updated");
        }


    }
}
