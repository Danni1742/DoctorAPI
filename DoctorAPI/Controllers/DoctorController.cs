using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL;

namespace DoctorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        private readonly DoctorsContext _context;

        public DoctorController(IDoctorService doctorService, DoctorsContext context)
        {
            _doctorService = doctorService;
            _context = context;
        }
        [HttpGet]
        public IActionResult 
        
    }
}
