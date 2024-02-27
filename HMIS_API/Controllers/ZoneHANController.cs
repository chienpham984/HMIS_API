using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HMIS_API.Repository;
using Microsoft.AspNetCore.Authorization;
using HMIS_API.Repository.ModelView;
using HMIS_API.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace HMIS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZoneHANController : ControllerBase
    {
        [Authorize]
        [HttpGet("GetFlightInforBaseHAN")]
        public IActionResult GetFlightInforBaseHAN(string flightDate)
        {
            flightDate = flightDate.Trim();
            IActionResult response = Unauthorized();
            using (var db = new HMIS_BKKContext())
            {
                var Result1 = db.ApiFlights.FromSqlRaw($"EXEC SPgetDataToAPI_HAN '{flightDate}'").ToList();
                response = Ok(new { data = Result1 });
            }
            return response;
        }
    }
}
