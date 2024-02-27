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
    public class SMISController : ControllerBase
    {
        [Authorize]
        [HttpGet("getListFlight")]
        public IActionResult getListFlight(string flightdate, int nature)
        {
            DateTime date;
            try
            {
                date = DateTime.ParseExact(flightdate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            catch
            {
                date = DateTime.ParseExact(flightdate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            }
            flightdate = date.ToString("dd/MM/yyyy");
            IActionResult response = Unauthorized();
            using (var db = new HMIS_BKKContext())
            {
                List<SMIS1> Result1 = db.SMIS.FromSqlRaw($"EXEC getFlightDataToNIA '{flightdate}',{nature.ToString()}").ToList();
                response = Ok(new { data = Result1 });
            }
            return response;
        }
        [Authorize]
        [HttpGet("getListFlightInf")]
        public IActionResult getListFlightInf(string flightdate, string flightNo)
        {
            DateTime date;
            try
            {
                date = DateTime.ParseExact(flightdate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            catch
            {
                date = DateTime.ParseExact(flightdate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            }
            flightdate = date.ToString("dd/MM/yyyy");
            IActionResult response = Unauthorized();
            using (var db = new HMIS_BKKContext())
            {
                List<SMIS2> Result1 = db.SMIS2.FromSqlRaw($"EXEC getFlightInforToNIA '{flightdate}','{flightNo}'").ToList();
                response = Ok(new { data = Result1 });
            }
            return response;
        }

        [Authorize]
        [HttpPost("SaveDataFromSMIS")]
        public IActionResult SaveDataFromSMIS(FlightModel model)
        {
            IActionResult response = Unauthorized();
            Flight myFlight;
            Tobt myTOBT;
            string flightNo, flightDate, route;
            string _time = "";
            int flightId = 0;

            flightNo = model == null ? "" : model.FlightNo.Trim();
            route = model == null ? "" : model.Route.Trim();
            flightDate = model == null ? "" : model.FlightDate.ToString("dd/MM/yyyy");

            using (var db = new HMIS_BKKContext())
            {
                //lay thong tin chuyen bay
                myFlight = db.Flights.Where(f => f.FlightNo.Trim().Equals(flightNo) && f.FlightDate.Equals(flightDate) && f.RouteFlight.Trim().Equals(route)).FirstOrDefault();
                if (myFlight == null)
                    return response;

                flightId = myFlight.FlightId.Value;

                foreach (FlightItemModel item in model.FlightData)
                {
                    if (item.FieldName.Trim() == "ALDT")
                    {
                        Aldt myAldt = new Aldt();
                        myAldt.FlightId = flightId;
                        myAldt.Time = item.FieldValue.Trim();
                        myAldt.TimeReceive = DateTime.Now;
                        db.Aldts.Add(myAldt);
                        db.SaveChanges();
                    }
                    else if (item.FieldName.Trim() == "ELDT")
                    {
                        Eldt myEldt = new Eldt();
                        myEldt.FlightId = flightId;
                        myEldt.Time = item.FieldValue.Trim();
                        myEldt.TimeReceive = DateTime.Now;
                        db.Eldts.Add(myEldt);
                        db.SaveChanges();
                    }
                    else if (item.FieldName.Trim() == "TOBT")
                    {
                        //lay gia tri TOBT hien tai
                        _time = item.FieldValue.Trim();
                        myTOBT = db.Tobts.Where(t => t.FlightId.Equals(flightId) && t.Time.Trim().Equals(_time)).FirstOrDefault();
                        if (myTOBT != null)
                        {
                            myTOBT = new Tobt();
                            myTOBT.FlightId = flightId;
                            myTOBT.Time = item.FieldValue.Trim();
                            myTOBT.Mgha = "ACV";
                            myTOBT.DateModified = DateTime.Now;
                            myTOBT.Acvtime = DateTime.Now;
                            myTOBT.Acvstatus = true;
                            db.Tobts.Add(myTOBT);
                            db.SaveChanges();
                        }
                        // 
                    }
                    else if (item.FieldName.Trim() == "TSAT")
                    {
                        Tsat myTsat = new Tsat();
                        myTsat.FlightId = flightId;
                        myTsat.Time = item.FieldValue.Trim();
                        myTsat.TimeReceive = DateTime.Now;
                        db.Tsats.Add(myTsat);
                        db.SaveChanges();
                    }
                    else if (item.FieldName.Trim() == "TTOT")
                    {
                        Ttot myTtot = new Ttot();
                        myTtot.FlightId = flightId;
                        myTtot.Time = item.FieldValue.Trim();
                        myTtot.TimeReceive = DateTime.Now;
                        db.Ttots.Add(myTtot);
                        db.SaveChanges();
                    }
                    else if (item.FieldName.Trim() == "BELT")
                    {
                        Ttot myTtot = new Ttot();
                        myTtot.FlightId = flightId;
                        myTtot.Time = item.FieldValue.Trim();
                        myTtot.TimeReceive = DateTime.Now;
                        db.Ttots.Add(myTtot);
                        db.SaveChanges();
                    }
                    else if (item.FieldName.Trim() == "DPRK")
                    {
                        Gate myGate = new Gate();
                        myGate.FlightId = flightId;
                        myGate.Dpark = item.FieldValue.Trim();
                        myGate.TimeReceive = DateTime.Now;
                        db.Gates.Add(myGate);
                        db.SaveChanges();
                    }
                    else if (item.FieldName.Trim() == "APRK")
                    {
                        Position myPosition = new Position();
                        myPosition.FlightId = flightId;
                        myPosition.Apark = item.FieldValue.Trim();
                        myPosition.TimeReceive = DateTime.Now;
                        db.Positions.Add(myPosition);
                        db.SaveChanges();
                    }
                    else if (item.FieldName.Trim() == "EOBT")
                    {
                        Eobt myEobt = new Eobt();
                        myEobt.FlightId = flightId;
                        myEobt.Time = item.FieldValue.Trim();
                        myEobt.DateModified = DateTime.Now;
                        myEobt.UserName = "ACV";
                        db.Eobts.Add(myEobt);
                        db.SaveChanges();
                    }
                }
                response = Ok(new { message = "Save successful" });
                return response;
            }
        }
    }
}
