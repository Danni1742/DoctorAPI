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
    public class AvalibleVisitTimeController : ControllerBase
    {
        private readonly IAvaliableVisitTimeService _avaliableVisitTimeService;
        private readonly IMapper _mapper;
        public AvalibleVisitTimeController(IAvaliableVisitTimeService avaliableVisitTimeService, IMapper mapper)
        {
            _avaliableVisitTimeService = avaliableVisitTimeService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAvts()
        {
            return Ok(await _avaliableVisitTimeService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAvtById(int id)
        {
            var avt = await _avaliableVisitTimeService.GetById(id);
            AvtDTO avtDTO = _mapper.Map<AvtDTO>(avt);
            return Ok(avtDTO);
        }
        [HttpPost]
        public async Task<IActionResult> AddAvt(AvtDTO avtDTO)
        {
            AvaliableVisitTime avaliableVisitTime = _mapper.Map<AvaliableVisitTime>(avtDTO);
            await _avaliableVisitTimeService.Add(avaliableVisitTime);
            return Ok("AvaliableVisitTime added ");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveAvt(int id)
        {
            await _avaliableVisitTimeService.RemoveById(id);
            return Ok("AvaliableVisitTime removed");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAvt(AvtDTO avtDTO)
        {
            AvaliableVisitTime avaliableVisitTime = _mapper.Map<AvaliableVisitTime>(avtDTO);
            await _avaliableVisitTimeService.Update(avaliableVisitTime);
            return Ok("AvaliableVisitTime updated");
        }
        [HttpPost("Avt/{doctorId}")]
        public async Task<IActionResult> AddDoctorAvt(AvtDTO avtDTO)
        {
            AvaliableVisitTime avaliableVisitTime = _mapper.Map<AvaliableVisitTime>(avtDTO);
            //avaliableVisitTime.DoctorId = 
            await _avaliableVisitTimeService.Add(avaliableVisitTime);
            return Ok("AvaliableVisitTime added ");
        }



    }
}
