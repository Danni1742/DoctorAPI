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
    public class AnalysisController : ControllerBase
    {
        private readonly IAnalysisService _analysisService;
        private readonly IMapper _mapper;
        public AnalysisController(IAnalysisService analysisService, IMapper mapper)
        {
            _analysisService = analysisService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAnalyses()
        {
            return Ok(await _analysisService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnalysisById(int id)
        {
            var analysis = await _analysisService.GetById(id);
            AnalysisDTO analysisDTO = _mapper.Map<AnalysisDTO>(analysis);
            return Ok(analysisDTO);
        }
        [HttpPost]
        public async Task<IActionResult> AddAnalysis(AnalysisDTO analysisDTO)
        {
            Analysis analysis = _mapper.Map<Analysis>(analysisDTO);
            await _analysisService.Add(analysis);
            return Ok("Aanalysis added ");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveAnalysis(int id)
        {
            await _analysisService.RemoveById(id);
            return Ok("Analysis removed");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAnalysis(AnalysisDTO analysisDTO)
        {
            Analysis analysis = _mapper.Map<Analysis>(analysisDTO);
            await _analysisService.Update(analysis);
            return Ok("Analysis updated");
        }


    }
}
