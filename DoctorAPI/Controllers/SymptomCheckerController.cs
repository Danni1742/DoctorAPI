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
using Models.SymptomeAPI;
using AutoMapper;
using DoctorAPI.DTOs;

namespace DoctorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SymptomChecker : ControllerBase
    {
        private readonly SymptomCheckerApiRepository _symptomCheckerApiRepository;
        //private readonly IMapper _mapper;
        public SymptomChecker(ISymptomCheckerApiRepository symptomCheckerApiRepository)
        {
            _symptomCheckerApiRepository = (SymptomCheckerApiRepository)symptomCheckerApiRepository;
        }
        [HttpGet("Symptomes")]
        public async Task<IActionResult> GetAllSymptomes()
        {
            return Ok(await _symptomCheckerApiRepository.GetAllSymptoms());
        }
        //List<int> selectedSymptoms, Gender gender, int yearOfBirth
        [HttpGet("Specialisation")]
        public async Task<IActionResult> GetSpecialisation(List<int> selectedSymptoms, Gender gender, int yearOfBirth)
        {
            //List<int> selectedSymptoms = new List<int>();
            //selectedSymptoms.Add(104);
            //Gender gender = Gender.Male;
            return Ok(await _symptomCheckerApiRepository.GetSpecialisationBySymptoms(selectedSymptoms, gender, yearOfBirth));
        }
        //[HttpGet("Symptome/{id}")]
        //public IActionResult GetSymptomeById(int id)
        //{
        //    return Ok(_symptomCheckerApiRepository.());

        //}


    }
}
