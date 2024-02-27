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
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Microsoft.IdentityModel.Protocols;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace HMIS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZoneNIAController : ControllerBase
    {
        [Authorize]
        [HttpGet("GetFlightInforBaseNIA")]
        public IActionResult GetFlightInforBaseNIA(string flightDate)
        {
            flightDate = flightDate.Trim();
            IActionResult response = Unauthorized();
            using (var db = new HMIS_BKKContext())
            {
                var Result1 = db.ApiFlights.FromSqlRaw($"EXEC SPgetDataToAPI_NIA '{flightDate}'").ToList();
                response = Ok(new { data = Result1 });
            }
            return response;
        }

        [Authorize]
        [HttpPost("SaveAIBT")]
        public IActionResult SaveAIBT(string flightNo, string flightDate, string route, string aibt, string mgha, bool isSent, DateTime? timeSent)
        {
            IActionResult response = Unauthorized();
            Flight myFlight;
            int gioaibt = 0;
            string _aibt = "";
            using (var db = new HMIS_BKKContext())
            {
                myFlight = db.Flights.Where(f => f.FlightNo.Trim().Equals(flightNo) && f.FlightDate.Equals(flightDate) && f.RouteFlight.Trim().Equals(route)).FirstOrDefault();
                if (myFlight != null)
                {
                    _aibt = aibt;
                    _aibt.Replace("-", "");
                    _aibt.Replace("+", "");
                    try
                    {
                        gioaibt = Int32.Parse(_aibt);
                        if (gioaibt > 2400)
                            return response;

                        // luu aibt
                        Aibt myaibt = new Aibt();
                        myaibt.FlightId = myFlight.FlightId;
                        myaibt.Time = aibt.Trim();
                        myaibt.UserName = mgha.Trim();
                        myaibt.Acvstatus = true;
                        myaibt.Acvtime = timeSent;
                        myaibt.DateModified = DateTime.Now;
                        db.Aibts.Add(myaibt);
                        db.SaveChanges();
                        response = Ok(new { message = "Save successful" });
                        return response;
                    }
                    catch
                    {
                        return response;
                    }

                }
            }
            //kiem tra ton tai cbay khong
            //luu


            return response;
        }
        [Authorize]
        [HttpPost("SaveACGT")]
        public IActionResult SaveACGT(string flightNo, string flightDate, string route, string acgt, string mgha, bool isSent, DateTime? timeSent)
        {
            IActionResult response = Unauthorized();
            Flight myFlight;
            int gioacgt = 0;
            string _acgt = "";
            using (var db = new HMIS_BKKContext())
            {
                myFlight = db.Flights.Where(f => f.FlightNo.Trim().Equals(flightNo) && f.FlightDate.Equals(flightDate) && f.RouteFlight.Trim().Equals(route)).FirstOrDefault();
                if (myFlight != null)
                {
                    _acgt = acgt;
                    _acgt.Replace("-", "");
                    _acgt.Replace("+", "");
                    try
                    {
                        gioacgt = Int32.Parse(_acgt);
                        if (gioacgt > 2400)
                            return response;

                        // luu aibt
                        Acgt myacgt = new Acgt();
                        myacgt.FlightId = myFlight.FlightId;
                        myacgt.Time = acgt.Trim();
                        myacgt.UserName = mgha.Trim();
                        myacgt.Acvstatus = true;
                        myacgt.Acvtime = timeSent;
                        myacgt.DateModified = DateTime.Now;
                        db.Acgts.Add(myacgt);
                        db.SaveChanges();
                        response = Ok(new { message = "Save successful" });
                        return response;
                    }
                    catch
                    {
                        return response;
                    }

                }
            }
            //kiem tra ton tai cbay khong
            //luu


            return response;
        }

        [Authorize]
        [HttpPost("SaveASBT")]
        public IActionResult SaveASBT(string flightNo, string flightDate, string route, string asbt, string mgha, bool isSent, DateTime? timeSent)
        {
            IActionResult response = Unauthorized();
            Flight myFlight;
            int gioasbt = 0;
            string _asbt = "";
            using (var db = new HMIS_BKKContext())
            {
                myFlight = db.Flights.Where(f => f.FlightNo.Trim().Equals(flightNo) && f.FlightDate.Equals(flightDate) && f.RouteFlight.Trim().Equals(route)).FirstOrDefault();
                if (myFlight != null)
                {
                    _asbt = asbt;
                    _asbt.Replace("-", "");
                    _asbt.Replace("+", "");
                    try
                    {
                        gioasbt = Int32.Parse(_asbt);
                        if (gioasbt > 2400)
                            return response;

                        // luu aibt
                        Asbt myasbt = new Asbt();
                        myasbt.FlightId = myFlight.FlightId;
                        myasbt.Time = asbt.Trim();
                        myasbt.UserName = mgha.Trim();
                        myasbt.Acvstatus = true;
                        myasbt.Acvtime = timeSent;
                        myasbt.DateModified = DateTime.Now;
                        db.Asbts.Add(myasbt);
                        db.SaveChanges();
                        response = Ok(new { message = "Save successful" });
                        return response;
                    }
                    catch
                    {
                        return response;
                    }

                }
            }
            //kiem tra ton tai cbay khong
            //luu


            return response;
        }

        [Authorize]
        [HttpPost("SaveARDT")]
        public IActionResult SaveARDT(string flightNo, string flightDate, string route, string ardt, string mgha, bool isSent, DateTime? timeSent)
        {
            IActionResult response = Unauthorized();
            Flight myFlight;
            int gioardt = 0;
            string _ardt = "";
            using (var db = new HMIS_BKKContext())
            {
                myFlight = db.Flights.Where(f => f.FlightNo.Trim().Equals(flightNo) && f.FlightDate.Equals(flightDate) && f.RouteFlight.Trim().Equals(route)).FirstOrDefault();
                if (myFlight != null)
                {
                    _ardt = ardt;
                    _ardt.Replace("-", "");
                    _ardt.Replace("+", "");
                    try
                    {
                        gioardt = Int32.Parse(_ardt);
                        if (gioardt > 2400)
                            return response;

                        // luu aibt
                        Ardt myardt = new Ardt();
                        myardt.FlightId = myFlight.FlightId;
                        myardt.Time = ardt.Trim();
                        myardt.UserName = mgha.Trim();
                        myardt.Acvstatus = true;
                        myardt.Acvtime = timeSent;
                        myardt.DateModified = DateTime.Now;
                        db.Ardts.Add(myardt);
                        db.SaveChanges();
                        response = Ok(new { message = "Save successful" });
                        return response;
                    }
                    catch
                    {
                        return response;
                    }

                }
            }
            //kiem tra ton tai cbay khong
            //luu


            return response;
        }

        [Authorize]
        [HttpPost("SaveAEGT")]
        public IActionResult SaveAEGT(string flightNo, string flightDate, string route, string aegt, string mgha, bool isSent, DateTime? timeSent)
        {
            IActionResult response = Unauthorized();
            Flight myFlight;
            int gioaegt = 0;
            string _aegt = "";
            using (var db = new HMIS_BKKContext())
            {
                myFlight = db.Flights.Where(f => f.FlightNo.Trim().Equals(flightNo) && f.FlightDate.Equals(flightDate) && f.RouteFlight.Trim().Equals(route)).FirstOrDefault();
                if (myFlight != null)
                {
                    _aegt = aegt;
                    _aegt.Replace("-", "");
                    _aegt.Replace("+", "");
                    try
                    {
                        gioaegt = Int32.Parse(_aegt);
                        if (gioaegt > 2400)
                            return response;

                        // luu aibt
                        Aegt myaegt = new Aegt();
                        myaegt.FlightId = myFlight.FlightId;
                        myaegt.Time = aegt.Trim();
                        myaegt.UserName = mgha.Trim();
                        myaegt.Acvstatus = true;
                        myaegt.Acvtime = timeSent;
                        myaegt.DateModified = DateTime.Now;
                        db.Aegts.Add(myaegt);
                        db.SaveChanges();
                        response = Ok(new { message = "Save successful" });
                        return response;
                    }
                    catch
                    {
                        return response;
                    }

                }
            }
            //kiem tra ton tai cbay khong
            //luu


            return response;
        }

        [Authorize]
        [HttpPost("SaveTOBT")]
        public IActionResult SaveTOBT(string flightNo, string flightDate, string route, string tobt, string mgha, bool isSent, DateTime? timeSent)
        {
            IActionResult response = Unauthorized();
            Flight myFlight;
            int giotobt = 0;
            string _tobt = "";
            using (var db = new HMIS_BKKContext())
            {
                myFlight = db.Flights.Where(f => f.FlightNo.Trim().Equals(flightNo) && f.FlightDate.Equals(flightDate) && f.RouteFlight.Trim().Equals(route)).FirstOrDefault();
                if (myFlight != null)
                {
                    _tobt = tobt;
                    _tobt.Replace("-", "");
                    _tobt.Replace("+", "");
                    try
                    {
                        giotobt = Int32.Parse(_tobt);
                        if (giotobt > 2400)
                            return response;

                        // luu aibt
                        Tobt myTobt = new Tobt();
                        myTobt.FlightId = myFlight.FlightId;
                        myTobt.Time = tobt.Trim();
                        myTobt.UserName = mgha.Trim();
                        myTobt.Acvstatus = true;
                        myTobt.Acvtime = timeSent;
                        myTobt.DateModified = DateTime.Now;
                        db.Tobts.Add(myTobt);
                        db.SaveChanges();
                        response = Ok(new { message = "Save successful" });
                        return response;
                    }
                    catch
                    {
                        return response;
                    }

                }
            }
            //kiem tra ton tai cbay khong
            //luu


            return response;
        }

        [Authorize]
        [HttpPost("SaveAOBT")]
        public async Task<IActionResult> SaveAOBT(string flightNo, string flightDate, string route, string aobt, string mgha, bool isSent, DateTime? timeSent)
        {
            IActionResult response = Unauthorized();
            Flight myFlight;
            int gioaobt = 0;
            string _aobt = "";
            using (var db = new HMIS_BKKContext())
            {
                myFlight = db.Flights.Where(f => f.FlightNo.Trim().Equals(flightNo) && f.FlightDate.Equals(flightDate) && f.RouteFlight.Trim().Equals(route)).FirstOrDefault();
                if (myFlight != null)
                {
                    _aobt = aobt;
                    _aobt.Replace("-", "");
                    _aobt.Replace("+", "");
                    try
                    {
                        gioaobt = Int32.Parse(_aobt);
                        if (gioaobt > 2400)
                            return response;

                        // luu aibt
                        Aobt myaobt = new Aobt();
                        myaobt.FlightId = myFlight.FlightId;
                        myaobt.Time = aobt.Trim();
                        myaobt.UserName = mgha.Trim();
                        myaobt.Acvstatus = true;
                        myaobt.Acvtime = timeSent;
                        myaobt.DateModified = DateTime.Now;
                        db.Aobts.Add(myaobt);
                        await db.SaveChangesAsync();
                        response = Ok(new { message = "Save successful" });
                        return response;
                    }
                    catch
                    {
                        return response;
                    }

                }
            }
            //kiem tra ton tai cbay khong
            //luu


            return response;
        }
        [Authorize]
        [HttpPost("SaveDataFromRabitMQ")]
        public async Task<IActionResult> SaveDataFromRabitMQ(FlightUpdateModel model)
        {
            IActionResult response = Unauthorized();
            Flight myFlight = new Flight();
            string flightNo, flightDate, route, strPriDate, strNexDate;
            flightNo = model == null ? "" : model.FlightNo.Trim();
            route = model == null ? "" : model.Route.Trim();
            flightDate = model == null ? "" : model.FlightDate.ToString("dd/MM/yyyy");
            DateTime priDay, nexDay;
            priDay = model.FlightDate.AddDays(-1);
            strPriDate = priDay.ToString("dd/MM/yyyy");
            nexDay = model.FlightDate.AddDays(1);
            strNexDate = nexDay.ToString("dd/MM/yyyy");
            Boolean kq = false;
            using (var db = new HMIS_BKKContext())
            {
                myFlight = db.Flights.Where(f => f.FlightNo.Substring(0, 2) == flightNo.Substring(0, 2) && (f.FlightDate == flightDate || f.FlightDate == strPriDate || f.FlightDate == strNexDate)).FirstOrDefault();
            }
            if (myFlight == null)
                return response;

            List<FlightDataUpdateModel> listDataModel = new List<FlightDataUpdateModel>();

            List<FlightUpdateModel> ListData = new List<FlightUpdateModel>();
            FlightUpdateModel curModel = null;
            ListData = GetItemsAsync(model.FlightDate.ToString("yyyy-MM-dd")).Result;

            foreach (FlightUpdateModel item in ListData)
            {
                if (item.FlightNo.Trim() == model.FlightNo.Trim() && item.FlightDate.ToString("dd/MM/yyyy") == model.FlightDate.ToString("dd/MM/yyyy") && item.Route.Trim() == model.Route.Trim())
                {
                    curModel = item;
                    break;
                }
            }
            if (curModel == null)
                return response;

            listDataModel = curModel.FlightData;
            string time = "";
            List<Flight> myListFlight = new List<Flight>();
            Flight flightFound;
            int myFlightId = 0;
            foreach (FlightDataUpdateModel item in listDataModel)
            {
                if (item.FieldName.Trim() == "EOBT")
                {
                    time = item.FieldValue.Trim();
                    break;
                }
                if (item.FieldName.Trim() == "EIBT")
                {
                    time = item.FieldValue.Trim();
                    break;
                }
            }
            if (time != "")
            {
                using (var db = new HMIS_BKKContext())
                {
                    myListFlight = db.Flights.FromSqlRaw($"EXEC SPFindFlightByShortTime '{flightNo}','{flightDate}','{route}','{time}'").ToList();
                }
                if (myListFlight.Count > 0)
                {
                    flightFound = myListFlight[0];
                    myFlightId = flightFound.FlightId.Value;
                    kq = await saveToDatabaseFromRabitMQ(myFlightId, curModel);
                }
                else
                {
                    int hour = DateTime.Now.Hour;
                    if (hour >= 8 && hour <= 17)
                    {
                        return response;
                    }
                    using (var db = new HMIS_BKKContext())
                    {
                        myListFlight = db.Flights.FromSqlRaw($"EXEC SPFindFlightByLongTime '{flightNo}','{flightDate}','{route}','{time}'").ToList();
                    }
                    if (myListFlight.Count > 0)
                    {
                        flightFound = myListFlight[0];
                        myFlightId = flightFound.FlightId.Value;
                        kq = await saveToDatabaseFromRabitMQ(myFlightId, curModel);
                    }
                }
            }
            if (kq == false)
                return response;

            response = Ok(new { message = "Save successful" });
            return response;
        }
        #region
        //[Authorize]
        //[HttpPost("SaveDataFromTwoWay")]
        //public async Task<IActionResult> SaveDataFromTwoWay(FlightUpdateModel model)
        //{

        //    IActionResult response = Unauthorized();
        //    Flight myFlight;

        //    string flightNo, flightDate, route;
        //    int flightId = 0;
        //    string _FieldValue;
        //    int id = 0;
        //    string newflightNo = "";
        //    flightNo = model == null ? "" : model.FlightNo.Trim();
        //    route = model == null ? "" : model.Route.Trim();
        //    flightDate = model == null ? "" : model.FlightDate.ToString("dd/MM/yyyy");

        //    using (var db = new HMIS_BKKContext())
        //    {
        //        //lay thong tin chuyen bay
        //        myFlight = db.Flights.Where(f => f.FlightNo.Trim().Equals(flightNo.Trim()) && f.FlightDate.Equals(flightDate) && f.RouteFlight.Trim().Equals(route.Trim())).FirstOrDefault();
        //        if (myFlight == null)
        //        {
        //            if (flightNo.Contains("."))
        //            {
        //                newflightNo = flightNo.Replace(".", "");
        //                DateTime dt = model == null ? DateTime.Now : model.FlightDate;
        //                flightDate = dt.AddDays(-1).ToString("dd/MM/yyyy");
        //                //tim xem co ton tai chuyen bay khong. neu co thi chuyen ngay
        //                myFlight = db.Flights.Where(f => f.FlightNo.Trim().Equals(newflightNo.Trim()) && f.FlightDate.Equals(flightDate) && f.RouteFlight.Trim().Equals(route.Trim())).FirstOrDefault();
        //                if (myFlight != null)
        //                {
        //                    //goi api lay thong tin chuyen bay tu acdm
        //                    //cap nhat bang flightdate
        //                    //cap nhat bang hmis_bkk
        //                }
        //            }
        //            else
        //                return response;
        //        }
        //        flightId = myFlight.FlightId.Value;
        //        try
        //        {
        //            foreach (FlightDataUpdateModel item in model.FlightData)
        //            {
        //                _FieldValue = item.FieldValue == null ? "" : item.FieldValue.Trim();
        //                if (item.FieldName.Trim() == "ALDT")
        //                {
        //                    Aldt myAldt;
        //                    myAldt = db.Aldts.Where(a => a.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
        //                    id = myAldt == null ? 0 : myAldt.Id;
        //                    if (id != 0)
        //                        myAldt = db.Aldts.Where(a => a.Id.Equals(id) && a.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
        //                    if (myAldt == null || id == 0)
        //                    {
        //                        myAldt = new Aldt();
        //                        myAldt.FlightId = flightId;
        //                        myAldt.Time = item.FieldValue.Trim();
        //                        myAldt.TimeReceive = DateTime.Now;
        //                        myAldt.Mgha = "ACV";
        //                        db.Aldts.Add(myAldt);
        //                        await db.SaveChangesAsync();
        //                    }
        //                }
        //                else if (item.FieldName.Trim() == "ELDT")
        //                {
        //                    Eldt myEldt;
        //                    myEldt = db.Eldts.Where(a => a.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
        //                    id = myEldt == null ? 0 : myEldt.Id;
        //                    if (id != 0)
        //                        myEldt = db.Eldts.Where(a => a.Id.Equals(id) && a.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
        //                    if (myEldt == null || id == 0)
        //                    {
        //                        myEldt = new Eldt();
        //                        myEldt.FlightId = flightId;
        //                        myEldt.Time = item.FieldValue.Trim();
        //                        myEldt.TimeReceive = DateTime.Now;
        //                        myEldt.Mgha = "ACV";
        //                        db.Eldts.Add(myEldt);
        //                        await db.SaveChangesAsync();
        //                    }
        //                }
        //                else if (item.FieldName.Trim() == "EIBT")
        //                {
        //                    Eibt myEibt;
        //                    myEibt = db.Eibts.Where(a => a.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
        //                    id = myEibt == null ? 0 : myEibt.Id;
        //                    if (id != 0)
        //                        myEibt = db.Eibts.Where(a => a.Id.Equals(id) && a.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
        //                    if (myEibt == null || id == 0)
        //                    {
        //                        myEibt = new Eibt();
        //                        myEibt.FlightId = flightId;
        //                        myEibt.Time = item.FieldValue.Trim();
        //                        myEibt.TimeReceive = DateTime.Now;
        //                        myEibt.Mgha = "ACV";
        //                        db.Eibts.Add(myEibt);
        //                        await db.SaveChangesAsync();
        //                    }
        //                }
        //                else if (item.FieldName.Trim() == "TOBT")
        //                {
        //                    Tobt myTOBT;
        //                    myTOBT = db.Tobts.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
        //                    id = myTOBT == null ? 0 : myTOBT.Id;
        //                    if (id != 0)
        //                        myTOBT = db.Tobts.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
        //                    if (myTOBT == null || id == 0)
        //                    {
        //                        myTOBT = new Tobt();
        //                        myTOBT.FlightId = flightId;
        //                        myTOBT.Time = item.FieldValue.Trim();
        //                        myTOBT.Mgha = "ACV";
        //                        myTOBT.DateModified = DateTime.Now;
        //                        db.Tobts.Add(myTOBT);
        //                        await db.SaveChangesAsync();
        //                    }
        //                }
        //                else if (item.FieldName.Trim() == "TSAT")
        //                {
        //                    Tsat myTsat;
        //                    myTsat = db.Tsats.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
        //                    id = myTsat == null ? 0 : myTsat.Id;

        //                    if (id != 0)
        //                        myTsat = db.Tsats.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
        //                    if (myTsat == null || id == 0)
        //                    {
        //                        myTsat = new Tsat();
        //                        myTsat.FlightId = flightId;
        //                        myTsat.Time = item.FieldValue.Trim();
        //                        myTsat.TimeReceive = DateTime.Now;
        //                        myTsat.Mgha = "ACV";
        //                        db.Tsats.Add(myTsat);
        //                        await db.SaveChangesAsync();
        //                    }
        //                }
        //                else if (item.FieldName.Trim() == "ATOT")
        //                {
        //                    ATOT myAtot;
        //                    myAtot = db.ATOTs.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
        //                    id = myAtot == null ? 0 : myAtot.Id;

        //                    if (id != 0)
        //                        myAtot = db.ATOTs.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
        //                    if (myAtot == null || id == 0)
        //                    {
        //                        myAtot = new ATOT();
        //                        myAtot.FlightId = flightId;
        //                        myAtot.Time = item.FieldValue.Trim();
        //                        myAtot.TimeReceive = DateTime.Now;
        //                        myAtot.Mgha = "ACV";
        //                        db.ATOTs.Add(myAtot);
        //                        await db.SaveChangesAsync();
        //                    }
        //                }
        //                else if (item.FieldName.Trim() == "TTOT")
        //                {
        //                    Ttot myTtot;
        //                    myTtot = db.Ttots.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
        //                    id = myTtot == null ? 0 : myTtot.Id;
        //                    if (id != 0)
        //                        myTtot = db.Ttots.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
        //                    if (myTtot == null || id == 0)
        //                    {
        //                        myTtot = new Ttot();
        //                        myTtot.FlightId = flightId;
        //                        myTtot.Time = item.FieldValue.Trim();
        //                        myTtot.TimeReceive = DateTime.Now;
        //                        myTtot.Mgha = "ACV";
        //                        db.Ttots.Add(myTtot);
        //                        await db.SaveChangesAsync();
        //                    }
        //                }
        //                else if (item.FieldName.Trim().ToUpper() == "BELT")
        //                {
        //                    Belt mybel;
        //                    mybel = db.Belts.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
        //                    id = mybel == null ? 0 : mybel.Id;
        //                    if (id != 0)
        //                        mybel = db.Belts.Where(t => t.Id.Equals(id) && t.BeltNo.Trim().Equals(_FieldValue)).FirstOrDefault();
        //                    if (mybel == null || id == 0)
        //                    {
        //                        mybel = new Belt();
        //                        mybel.FlightId = flightId;
        //                        mybel.BeltNo = item.FieldValue.Trim();
        //                        mybel.TimeReceive = DateTime.Now;
        //                        mybel.Mgha = "ACV";
        //                        db.Belts.Add(mybel);
        //                        await db.SaveChangesAsync();
        //                    }
        //                }
        //                else if (item.FieldName.Trim() == "DGATE")
        //                {
        //                    Gate myGate;
        //                    myGate = db.Gates.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
        //                    id = myGate == null ? 0 : myGate.Id;
        //                    if (id != 0)
        //                        myGate = db.Gates.Where(t => t.Id.Equals(id) && t.Dpark.Trim().Equals(_FieldValue)).FirstOrDefault();
        //                    if (myGate == null || id == 0)
        //                    {
        //                        myGate = new Gate();
        //                        myGate.FlightId = flightId;
        //                        myGate.Dpark = item.FieldValue.Trim();
        //                        myGate.TimeReceive = DateTime.Now;
        //                        myGate.Mgha = "ACV";
        //                        db.Gates.Add(myGate);
        //                        await db.SaveChangesAsync();
        //                    }
        //                }
        //                else if (item.FieldName.Trim() == "DPRK")
        //                {
        //                    DPOS myDpost;
        //                    myDpost = db.DPOSs.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
        //                    id = myDpost == null ? 0 : myDpost.Id;
        //                    if (id != 0)
        //                        myDpost = db.DPOSs.Where(t => t.Id.Equals(id) && t.Dposition.Trim().Equals(_FieldValue)).FirstOrDefault();
        //                    if (myDpost == null || id == 0)
        //                    {
        //                        myDpost = new DPOS();
        //                        myDpost.FlightId = flightId;
        //                        myDpost.Dposition = item.FieldValue.Trim();
        //                        myDpost.TimeReceive = DateTime.Now;
        //                        myDpost.Mgha = "ACV";
        //                        db.DPOSs.Add(myDpost);
        //                        await db.SaveChangesAsync();
        //                    }
        //                }
        //                else if (item.FieldName.Trim() == "APRK")
        //                {
        //                    Position myPosition;
        //                    myPosition = db.Positions.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
        //                    id = myPosition == null ? 0 : myPosition.Id;
        //                    if (id != 0)
        //                        myPosition = db.Positions.Where(t => t.Id.Equals(id) && t.Apark.Trim().Equals(_FieldValue)).FirstOrDefault();
        //                    if (myPosition == null || id == 0)
        //                    {
        //                        myPosition = new Position();
        //                        myPosition.FlightId = flightId;
        //                        myPosition.Apark = item.FieldValue.Trim();
        //                        myPosition.TimeReceive = DateTime.Now;
        //                        myPosition.Mgha = "ACV";
        //                        db.Positions.Add(myPosition);
        //                        await db.SaveChangesAsync();
        //                    }
        //                }
        //                else if (item.FieldName.Trim().ToUpper() == "STATUS")
        //                {
        //                    StatusDetail myStatus;
        //                    myStatus = db.StatusDetails.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
        //                    id = myStatus == null ? 0 : myStatus.Id;
        //                    if (id != 0)
        //                        myStatus = db.StatusDetails.Where(t => t.Id.Equals(id) && t.StatusName.Trim().Equals(_FieldValue)).FirstOrDefault();
        //                    if (myStatus == null || id == 0)
        //                    {
        //                        myStatus = new StatusDetail();
        //                        myStatus.FlightId = flightId;
        //                        myStatus.StatusName = item.FieldValue.Trim();
        //                        myStatus.DateModified = DateTime.Now;
        //                        myStatus.Mgha = "ACV";
        //                        db.StatusDetails.Add(myStatus);
        //                        await db.SaveChangesAsync();
        //                    }
        //                }
        //                else if (item.FieldName.Trim().ToUpper() == "AIBT")
        //                {
        //                    Aibt myAibt;
        //                    myAibt = db.Aibts.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
        //                    id = myAibt == null ? 0 : myAibt.Id;
        //                    if (id != 0)
        //                        myAibt = db.Aibts.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
        //                    if (myAibt == null || id == 0)
        //                    {
        //                        myAibt = new Aibt();
        //                        myAibt.FlightId = flightId;
        //                        myAibt.Time = item.FieldValue.Trim();
        //                        myAibt.DateModified = DateTime.Now;
        //                        myAibt.Mgha = "ACV";
        //                        db.Aibts.Add(myAibt);
        //                        await db.SaveChangesAsync();
        //                    }
        //                }
        //                else if (item.FieldName.Trim().ToUpper() == "ACGT")
        //                {
        //                    Acgt myAcgt;
        //                    myAcgt = db.Acgts.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
        //                    id = myAcgt == null ? 0 : myAcgt.Id;
        //                    if (id != 0)
        //                        myAcgt = db.Acgts.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
        //                    if (myAcgt == null || id == 0)
        //                    {
        //                        myAcgt = new Acgt();
        //                        myAcgt.FlightId = flightId;
        //                        myAcgt.Time = item.FieldValue.Trim();
        //                        myAcgt.DateModified = DateTime.Now;
        //                        myAcgt.Mgha = "ACV";
        //                        db.Acgts.Add(myAcgt);
        //                        await db.SaveChangesAsync();
        //                    }
        //                }
        //                else if (item.FieldName.Trim().ToUpper() == "ASBT")
        //                {
        //                    Asbt myAsbt;
        //                    myAsbt = db.Asbts.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
        //                    id = myAsbt == null ? 0 : myAsbt.Id;
        //                    if (id != 0)
        //                        myAsbt = db.Asbts.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
        //                    if (myAsbt == null || id == 0)
        //                    {
        //                        myAsbt = new Asbt();
        //                        myAsbt.FlightId = flightId;
        //                        myAsbt.Time = item.FieldValue.Trim();
        //                        myAsbt.DateModified = DateTime.Now;
        //                        myAsbt.Mgha = "ACV";
        //                        db.Asbts.Add(myAsbt);
        //                        await db.SaveChangesAsync();
        //                    }
        //                }
        //                else if (item.FieldName.Trim().ToUpper() == "AEGT")
        //                {
        //                    Aegt myAegt;
        //                    myAegt = db.Aegts.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
        //                    id = myAegt == null ? 0 : myAegt.Id;
        //                    if (id != 0)
        //                        myAegt = db.Aegts.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
        //                    if (myAegt == null || id == 0)
        //                    {
        //                        myAegt = new Aegt();
        //                        myAegt.FlightId = flightId;
        //                        myAegt.Time = item.FieldValue.Trim();
        //                        myAegt.DateModified = DateTime.Now;
        //                        myAegt.Mgha = "ACV";
        //                        db.Aegts.Add(myAegt);
        //                        await db.SaveChangesAsync();
        //                    }
        //                }
        //                else if (item.FieldName.Trim().ToUpper() == "EOBT")
        //                {
        //                    Eobt myEobt;
        //                    myEobt = db.Eobts.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
        //                    id = myEobt == null ? 0 : myEobt.Id;
        //                    if (id != 0)
        //                        myEobt = db.Eobts.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
        //                    if (myEobt == null || id == 0)
        //                    {
        //                        myEobt = new Eobt();
        //                        myEobt.FlightId = flightId;
        //                        myEobt.Time = item.FieldValue.Trim();
        //                        myEobt.DateModified = DateTime.Now;
        //                        myEobt.UserName = "ACV";
        //                        db.Eobts.Add(myEobt);
        //                        await db.SaveChangesAsync();
        //                    }
        //                }
        //                else if (item.FieldName.Trim().ToUpper() == "ARDT")
        //                {
        //                    Ardt myArdt;
        //                    myArdt = db.Ardts.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
        //                    id = myArdt == null ? 0 : myArdt.Id;
        //                    if (id != 0)
        //                        myArdt = db.Ardts.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
        //                    if (myArdt == null || id == 0)
        //                    {
        //                        myArdt = new Ardt();
        //                        myArdt.FlightId = flightId;
        //                        myArdt.Time = item.FieldValue.Trim();
        //                        myArdt.DateModified = DateTime.Now;
        //                        myArdt.Mgha = "ACV";
        //                        db.Ardts.Add(myArdt);
        //                        await db.SaveChangesAsync();
        //                    }
        //                }
        //                else if (item.FieldName.Trim().ToUpper() == "AEGT")
        //                {
        //                    Aegt myAegt;
        //                    myAegt = db.Aegts.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
        //                    id = myAegt == null ? 0 : myAegt.Id;
        //                    if (id != 0)
        //                        myAegt = db.Aegts.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
        //                    if (myAegt == null || id == 0)
        //                    {
        //                        myAegt = new Aegt();
        //                        myAegt.FlightId = flightId;
        //                        myAegt.Time = item.FieldValue.Trim();
        //                        myAegt.DateModified = DateTime.Now;
        //                        myAegt.Mgha = "ACV";
        //                        db.Aegts.Add(myAegt);
        //                        await db.SaveChangesAsync();
        //                    }
        //                }
        //                else if (item.FieldName.Trim().ToUpper() == "AOBT")
        //                {
        //                    Aobt myAobt;
        //                    myAobt = db.Aobts.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
        //                    id = myAobt == null ? 0 : myAobt.Id;
        //                    if (id != 0)
        //                        myAobt = db.Aobts.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
        //                    if (myAobt == null || id == 0)
        //                    {
        //                        myAobt = new Aobt();
        //                        myAobt.FlightId = flightId;
        //                        myAobt.Time = item.FieldValue.Trim();
        //                        myAobt.DateModified = DateTime.Now;
        //                        myAobt.Mgha = "ACV";
        //                        db.Aobts.Add(myAobt);
        //                        await db.SaveChangesAsync();
        //                    }
        //                }
        //                else if (item.FieldName.Trim().ToUpper() == "BOOKING")
        //                {
        //                    Booking myBooking;
        //                    myBooking = db.Bookings.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.id).FirstOrDefault();
        //                    id = myBooking == null ? 0 : myBooking.id;
        //                    int _pax = 0;
        //                    Int32.TryParse(_FieldValue, out _pax);
        //                    if (id != 0)
        //                        myBooking = db.Bookings.Where(t => t.id.Equals(id) && t.Pax == _pax).FirstOrDefault();
        //                    if (myBooking == null || id == 0)
        //                    {
        //                        myBooking = new Booking();
        //                        myBooking.FlightId = flightId;
        //                        myBooking.Pax = _pax;
        //                        myBooking.DateModified = DateTime.Now;
        //                        myBooking.MGHA = "ACV";
        //                        db.Bookings.Add(myBooking);
        //                        await db.SaveChangesAsync();
        //                    }
        //                }
        //            }
        //            response = Ok(new { message = "Save successful" });
        //        }
        //        catch
        //        {
        //            return response;
        //        }
        //        return response;
        //    }
        //}

        #endregion
        [Authorize]
        [HttpPost("SaveDataFromTwoWay")]
        public async Task<IActionResult> SaveDataFromTwoWay(FlightUpdateModel model)
        {
            IActionResult response = Unauthorized();
            List<Flight> myListFlight = new List<Flight>();
            List<FlightUpdateModel> ListData = new List<FlightUpdateModel>();
            Flight flightFound, fnt;
            int fntId = 0;
            FlightUpdateModel curModel = null;
            DateTime combinedDateTime;
            string flightNo, flightDate, route;
            Boolean isFound = false;
            Boolean ChangeName = false;
            combinedDateTime = DateTime.Now;
            flightNo = model == null ? "" : model.FlightNo.Trim();
            route = model == null ? "" : model.Route.Trim();
            flightDate = model == null ? "" : model.FlightDate.ToString("dd/MM/yyyy");

            string EobtTime = "";
            string time = "";
            //lay danh sach tat ca chuyen bay trong ngay
            ListData = GetItemsAsync(model.FlightDate.ToString("yyyy-MM-dd")).Result;
            //tim thong tin chuyen bay trung ten trong danh sach
            foreach (FlightUpdateModel item in ListData)
            {
                if (item.FlightNo.Trim() == model.FlightNo.Trim() && item.FlightDate.ToString("dd/MM/yyyy") == model.FlightDate.ToString("dd/MM/yyyy") && item.Route.Trim() == model.Route.Trim())
                {
                    curModel = item;
                    break;
                }
            }
            if (curModel == null)
                return response;




            List<FlightDataUpdateModel> listDataModel = new List<FlightDataUpdateModel>();

            using (var db = new HMIS_BKKContext())
            {
                //1. kiem tra xem co ton tai chuyen bay trung so hieu chuyen bay, chang bay va ngay bay khong?
                flightFound = db.Flights.Where(f => f.FlightNo.Trim().Replace("D", ".") == flightNo.Trim().Replace("D", ".") && f.RouteFlight.Trim() == route.Trim() && f.FlightDate == flightDate).FirstOrDefault();
                if (flightFound != null)
                {
                    listDataModel = model.FlightData;
                    foreach (FlightDataUpdateModel item in listDataModel)
                    {
                        if (item.FieldName.Trim() == "EOBT")
                        {
                            EobtTime = item.FieldValue.Trim();
                        }
                    }
                    fntId = flightFound.FlightId.Value;
                    fnt = db.Flights.Where(t => t.FlightId == fntId && t.FlightNo.Trim() == flightNo.Trim()).FirstOrDefault();
                    if (fnt != null)
                        ChangeName = false;
                    else
                        ChangeName = true;
                    isFound = true;
                    Boolean kq = await saveToDatabase(fntId, isFound, curModel, EobtTime, ChangeName);
                }
                else
                {
                    listDataModel = model.FlightData;
                    foreach (FlightDataUpdateModel item in listDataModel)
                    {
                        if (item.FieldName.Trim() == "SOBT")
                        {
                            time = item.FieldValue.Trim();
                            break;
                        }
                        if (item.FieldName.Trim() == "SIBT")
                        {
                            time = item.FieldValue.Trim();
                            break;
                        }
                    }

                    if (time != "")
                    {
                        myListFlight = db.Flights.FromSqlRaw($"EXEC SPFindFlightInDay '{flightNo}','{flightDate}','{route}','{time}'").ToList();
                        if (myListFlight.Count > 0)
                        {
                            flightFound = myListFlight[0];
                            fntId = flightFound.FlightId.Value;
                            isFound = false;
                            Boolean kq = await saveToDatabase(fntId, isFound, curModel, "", true);
                        }
                        else
                        {
                            int hour = DateTime.Now.Hour;
                            if (hour >= 8 && hour <= 17)
                            {
                                return response;
                            }
                            isFound = false;
                            //goi storedprocedure lay chuyen bay ngay hom truoc co ngay bay, so hieu chuyen bay (khong co ky tu "., D"), chang bay 
                            myListFlight = db.Flights.FromSqlRaw($"EXEC SPFindFlightFromACDMUpdated '{flightNo}','{flightDate}','{route}'").ToList();
                            if (myListFlight.Count > 0)
                            {
                                flightFound = myListFlight[0];
                                Boolean kq = await saveToDatabase(flightFound.FlightId.Value, isFound, curModel, "", false);
                            }
                            else//khong ton tai chuyen bay
                            {
                                return response;
                            }

                        }

                    }
                    else
                    {
                        int hour = DateTime.Now.Hour;
                        if (hour >= 8 && hour <= 17)
                        {
                            return response;
                        }
                        isFound = false;
                        //goi storedprocedure lay chuyen bay ngay hom truoc co ngay bay, so hieu chuyen bay (khong co ky tu "., D"), chang bay 
                        myListFlight = db.Flights.FromSqlRaw($"EXEC SPFindFlightFromACDMUpdated '{flightNo}','{flightDate}','{route}'").ToList();
                        if (myListFlight.Count > 0)
                        {
                            flightFound = myListFlight[0];
                            Boolean kq = await saveToDatabase(flightFound.FlightId.Value, isFound, curModel, "", false);
                        }
                        else//khong ton tai chuyen bay
                        {
                            return response;
                        }
                    }
                }
            }
            response = Ok(new { message = "Save successful" });
            return response;
        }
        public async Task<bool> saveToDatabaseFromRabitMQ(int myFlightId, FlightUpdateModel model)
        {
            Flight myFlight;
            using (var db = new HMIS_BKKContext())
            {
                myFlight = db.Flights.Where(f => f.FlightId == myFlightId).FirstOrDefault();
            }
            if (myFlight == null)
                return false;
            string flightNo, flightDate, route;
            int flightId = myFlight.FlightId.Value;
            flightNo = model == null ? "" : model.FlightNo.Trim();
            route = model == null ? "" : model.Route.Trim();
            flightDate = model == null ? "" : model.FlightDate.ToString("dd/MM/yyyy");
            string _FieldValue = "";
            int id = 0;
            string time = "";
            try
            {
                using (var db = new HMIS_BKKContext())
                {

                    if (myFlight.FlightDate != flightDate)
                    {
                        if (model.Route.Contains("HAN-"))
                        {
                            foreach (var subitem in model.FlightData)
                            {
                                if (subitem.FieldName.Trim() == "SOBT")
                                {
                                    time = subitem.FieldValue.Trim();
                                    break;
                                }
                            }
                        }
                        else if (model.Route.Contains("-HAN"))
                        {
                            foreach (var subitem in model.FlightData)
                            {
                                if (subitem.FieldName.Trim() == "SIBT")
                                {
                                    time = subitem.FieldValue.Trim();
                                    break;
                                }
                            }
                        }
                        var b = await db.Database.ExecuteSqlRawAsync("EXEC HMIS_BKK.dbo.SPSaveFlightNoChangeUpdated '" + model.FlightNo.Trim() + "','" + model.FlightDate.ToString("dd/MM/yyyy") + "','" + time.Trim() + "'," + flightId.ToString());
                    }
                    else if (myFlight.FlightNo.Trim() != flightNo.Trim())
                    {
                        var b = await db.Database.ExecuteSqlRawAsync("EXEC HMIS_BKK.dbo.SPSaveFlightNo '" + model.FlightNo.Trim() + "'," + flightId.ToString());
                    }
                    foreach (FlightDataUpdateModel item in model.FlightData)
                    {
                        _FieldValue = item.FieldValue == null ? "" : item.FieldValue.Trim();
                        if (item.FieldName.Trim() == "ALDT")
                        {
                            Aldt myAldt;
                            myAldt = db.Aldts.Where(a => a.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myAldt == null ? 0 : myAldt.Id;
                            if (id != 0)
                                myAldt = db.Aldts.Where(a => a.Id.Equals(id) && a.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myAldt == null || id == 0)
                            {
                                myAldt = new Aldt();
                                myAldt.FlightId = flightId;
                                myAldt.Time = item.FieldValue.Trim();
                                myAldt.TimeReceive = DateTime.Now;
                                myAldt.Mgha = "NIA";
                                db.Aldts.Add(myAldt);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim() == "ELDT")
                        {
                            Eldt myEldt;
                            myEldt = db.Eldts.Where(a => a.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myEldt == null ? 0 : myEldt.Id;
                            if (id != 0)
                                myEldt = db.Eldts.Where(a => a.Id.Equals(id) && a.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myEldt == null || id == 0)
                            {
                                myEldt = new Eldt();
                                myEldt.FlightId = flightId;
                                myEldt.Time = item.FieldValue.Trim();
                                myEldt.TimeReceive = DateTime.Now;
                                myEldt.Mgha = "NIA";
                                db.Eldts.Add(myEldt);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim() == "EIBT")
                        {
                            Eibt myEibt;
                            myEibt = db.Eibts.Where(a => a.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myEibt == null ? 0 : myEibt.Id;
                            if (id != 0)
                                myEibt = db.Eibts.Where(a => a.Id.Equals(id) && a.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myEibt == null || id == 0)
                            {
                                myEibt = new Eibt();
                                myEibt.FlightId = flightId;
                                myEibt.Time = item.FieldValue.Trim();
                                myEibt.TimeReceive = DateTime.Now;
                                myEibt.Mgha = "NIA";
                                db.Eibts.Add(myEibt);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim() == "TOBT")
                        {
                            Tobt myTOBT;
                            myTOBT = db.Tobts.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myTOBT == null ? 0 : myTOBT.Id;
                            if (id != 0)
                                myTOBT = db.Tobts.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myTOBT == null || id == 0)
                            {
                                myTOBT = new Tobt();
                                myTOBT.FlightId = flightId;
                                myTOBT.Time = item.FieldValue.Trim();
                                myTOBT.Mgha = "NIA";
                                myTOBT.DateModified = DateTime.Now;
                                db.Tobts.Add(myTOBT);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim() == "TSAT")
                        {
                            Tsat myTsat;
                            myTsat = db.Tsats.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myTsat == null ? 0 : myTsat.Id;

                            if (id != 0)
                                myTsat = db.Tsats.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myTsat == null || id == 0)
                            {
                                myTsat = new Tsat();
                                myTsat.FlightId = flightId;
                                myTsat.Time = item.FieldValue.Trim();
                                myTsat.TimeReceive = DateTime.Now;
                                myTsat.Mgha = "NIA";
                                db.Tsats.Add(myTsat);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim() == "ATOT")
                        {
                            ATOT myAtot;
                            myAtot = db.ATOTs.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myAtot == null ? 0 : myAtot.Id;

                            if (id != 0)
                                myAtot = db.ATOTs.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myAtot == null || id == 0)
                            {
                                myAtot = new ATOT();
                                myAtot.FlightId = flightId;
                                myAtot.Time = item.FieldValue.Trim();
                                myAtot.TimeReceive = DateTime.Now;
                                myAtot.Mgha = "NIA";
                                db.ATOTs.Add(myAtot);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim() == "TTOT")
                        {
                            Ttot myTtot;
                            myTtot = db.Ttots.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myTtot == null ? 0 : myTtot.Id;
                            if (id != 0)
                                myTtot = db.Ttots.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myTtot == null || id == 0)
                            {
                                myTtot = new Ttot();
                                myTtot.FlightId = flightId;
                                myTtot.Time = item.FieldValue.Trim();
                                myTtot.TimeReceive = DateTime.Now;
                                myTtot.Mgha = "NIA";
                                db.Ttots.Add(myTtot);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim().ToUpper() == "BELT")
                        {
                            Belt mybel;
                            mybel = db.Belts.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = mybel == null ? 0 : mybel.Id;
                            if (id != 0)
                                mybel = db.Belts.Where(t => t.Id.Equals(id) && t.BeltNo.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (mybel == null || id == 0)
                            {
                                mybel = new Belt();
                                mybel.FlightId = flightId;
                                mybel.BeltNo = item.FieldValue.Trim();
                                mybel.TimeReceive = DateTime.Now;
                                mybel.Mgha = "NIA";
                                db.Belts.Add(mybel);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim() == "DGATE")
                        {
                            Gate myGate;
                            myGate = db.Gates.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myGate == null ? 0 : myGate.Id;
                            if (id != 0)
                                myGate = db.Gates.Where(t => t.Id.Equals(id) && t.Dpark.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myGate == null || id == 0)
                            {
                                myGate = new Gate();
                                myGate.FlightId = flightId;
                                myGate.Dpark = item.FieldValue.Trim();
                                myGate.TimeReceive = DateTime.Now;
                                myGate.Mgha = "NIA";
                                db.Gates.Add(myGate);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim() == "DPRK")
                        {
                            DPOS myDpost;
                            myDpost = db.DPOSs.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myDpost == null ? 0 : myDpost.Id;
                            if (id != 0)
                                myDpost = db.DPOSs.Where(t => t.Id.Equals(id) && t.Dposition.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myDpost == null || id == 0)
                            {
                                myDpost = new DPOS();
                                myDpost.FlightId = flightId;
                                myDpost.Dposition = item.FieldValue.Trim();
                                myDpost.TimeReceive = DateTime.Now;
                                myDpost.Mgha = "NIA";
                                db.DPOSs.Add(myDpost);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim() == "APRK")
                        {
                            Position myPosition;
                            myPosition = db.Positions.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myPosition == null ? 0 : myPosition.Id;
                            if (id != 0)
                                myPosition = db.Positions.Where(t => t.Id.Equals(id) && t.Apark.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myPosition == null || id == 0)
                            {
                                myPosition = new Position();
                                myPosition.FlightId = flightId;
                                myPosition.Apark = item.FieldValue.Trim();
                                myPosition.TimeReceive = DateTime.Now;
                                myPosition.Mgha = "NIA";
                                db.Positions.Add(myPosition);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim().ToUpper() == "STATUS")
                        {
                            StatusDetail myStatus;
                            myStatus = db.StatusDetails.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myStatus == null ? 0 : myStatus.Id;
                            if (id != 0)
                                myStatus = db.StatusDetails.Where(t => t.Id.Equals(id) && t.StatusName.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myStatus == null || id == 0)
                            {
                                myStatus = new StatusDetail();
                                myStatus.FlightId = flightId;
                                myStatus.StatusName = item.FieldValue.Trim();
                                myStatus.DateModified = DateTime.Now;
                                myStatus.Mgha = "NIA";
                                db.StatusDetails.Add(myStatus);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim().ToUpper() == "AIBT")
                        {
                            Aibt myAibt;
                            myAibt = db.Aibts.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myAibt == null ? 0 : myAibt.Id;
                            if (id != 0)
                                myAibt = db.Aibts.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myAibt == null || id == 0)
                            {
                                myAibt = new Aibt();
                                myAibt.FlightId = flightId;
                                myAibt.Time = item.FieldValue.Trim();
                                myAibt.DateModified = DateTime.Now;
                                myAibt.Mgha = "NIA";
                                myAibt.Remark = "";
                                db.Aibts.Add(myAibt);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim().ToUpper() == "ACGT")
                        {
                            Acgt myAcgt;
                            myAcgt = db.Acgts.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myAcgt == null ? 0 : myAcgt.Id;
                            if (id != 0)
                                myAcgt = db.Acgts.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myAcgt == null || id == 0)
                            {
                                myAcgt = new Acgt();
                                myAcgt.FlightId = flightId;
                                myAcgt.Time = item.FieldValue.Trim();
                                myAcgt.DateModified = DateTime.Now;
                                myAcgt.Mgha = "NIA";
                                myAcgt.Remark = "";
                                db.Acgts.Add(myAcgt);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim().ToUpper() == "ASBT")
                        {
                            Asbt myAsbt;
                            myAsbt = db.Asbts.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myAsbt == null ? 0 : myAsbt.Id;
                            if (id != 0)
                                myAsbt = db.Asbts.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myAsbt == null || id == 0)
                            {
                                myAsbt = new Asbt();
                                myAsbt.FlightId = flightId;
                                myAsbt.Time = item.FieldValue.Trim();
                                myAsbt.DateModified = DateTime.Now;
                                myAsbt.Mgha = "NIA";
                                myAsbt.Remark = "";
                                db.Asbts.Add(myAsbt);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim().ToUpper() == "AEGT")
                        {
                            Aegt myAegt;
                            myAegt = db.Aegts.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myAegt == null ? 0 : myAegt.Id;
                            if (id != 0)
                                myAegt = db.Aegts.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myAegt == null || id == 0)
                            {
                                myAegt = new Aegt();
                                myAegt.FlightId = flightId;
                                myAegt.Time = item.FieldValue.Trim();
                                myAegt.DateModified = DateTime.Now;
                                myAegt.Mgha = "NIA";
                                myAegt.Remark = "";
                                db.Aegts.Add(myAegt);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim().ToUpper() == "EOBT")
                        {
                            Eobt myEobt;
                            myEobt = db.Eobts.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myEobt == null ? 0 : myEobt.Id;
                            if (id != 0)
                                myEobt = db.Eobts.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myEobt == null || id == 0)
                            {
                                myEobt = new Eobt();
                                myEobt.FlightId = flightId;
                                myEobt.Time = item.FieldValue.Trim();
                                myEobt.DateModified = DateTime.Now;
                                myEobt.UserName = "NIA";
                                db.Eobts.Add(myEobt);
                                await db.SaveChangesAsync();
                            }
                        }
                        //else if (EobtTime.Trim() != "" && isChange == true)
                        //{
                        //    Eobt myEobt;
                        //    myEobt = db.Eobts.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                        //    id = myEobt == null ? 0 : myEobt.Id;
                        //    if (id != 0)
                        //        myEobt = db.Eobts.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
                        //    if (myEobt == null || id == 0)
                        //    {
                        //        myEobt = new Eobt();
                        //        myEobt.FlightId = flightId;
                        //        myEobt.Time = EobtTime.Trim();
                        //        myEobt.DateModified = DateTime.Now;
                        //        myEobt.UserName = "ACV";
                        //        db.Eobts.Add(myEobt);
                        //        await db.SaveChangesAsync();
                        //    }
                        //}
                        else if (item.FieldName.Trim().ToUpper() == "ARDT")
                        {
                            Ardt myArdt;
                            myArdt = db.Ardts.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myArdt == null ? 0 : myArdt.Id;
                            if (id != 0)
                                myArdt = db.Ardts.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myArdt == null || id == 0)
                            {
                                myArdt = new Ardt();
                                myArdt.FlightId = flightId;
                                myArdt.Time = item.FieldValue.Trim();
                                myArdt.DateModified = DateTime.Now;
                                myArdt.Mgha = "NIA";
                                myArdt.Remark = "";
                                db.Ardts.Add(myArdt);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim().ToUpper() == "AOBT")
                        {
                            Aobt myAobt;
                            myAobt = db.Aobts.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myAobt == null ? 0 : myAobt.Id;
                            if (id != 0)
                                myAobt = db.Aobts.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myAobt == null || id == 0)
                            {
                                myAobt = new Aobt();
                                myAobt.FlightId = flightId;
                                myAobt.Time = item.FieldValue.Trim();
                                myAobt.DateModified = DateTime.Now;
                                myAobt.Mgha = "NIA";
                                myAobt.Remark = "";
                                db.Aobts.Add(myAobt);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim().ToUpper() == "BOOKING")
                        {
                            Booking myBooking;
                            myBooking = db.Bookings.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.id).FirstOrDefault();
                            id = myBooking == null ? 0 : myBooking.id;
                            int _pax = 0;
                            Int32.TryParse(_FieldValue, out _pax);
                            if (id != 0)
                                myBooking = db.Bookings.Where(t => t.id.Equals(id) && t.Pax == _pax).FirstOrDefault();
                            if (myBooking == null || id == 0)
                            {
                                myBooking = new Booking();
                                myBooking.FlightId = flightId;
                                myBooking.Pax = _pax;
                                myBooking.DateModified = DateTime.Now;
                                myBooking.MGHA = "NIA";
                                db.Bookings.Add(myBooking);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim().ToUpper() == "SIBT")
                        {
                            Sibt mySibt;
                            mySibt = db.Sibts.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = mySibt == null ? 0 : mySibt.Id;
                            if (id != 0)
                                mySibt = db.Sibts.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (mySibt == null || id == 0)
                            {
                                mySibt = new Sibt();
                                mySibt.FlightId = flightId;
                                mySibt.Time = item.FieldValue.Trim();
                                mySibt.DateModified = DateTime.Now;
                                mySibt.UserName = "NIA";
                                mySibt.Acvstatus = true;
                                mySibt.Acvtime = DateTime.Now;
                                mySibt.FlightDate = model.FlightDate.ToString("dd/MM/yyyy");
                                db.Sibts.Add(mySibt);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim().ToUpper() == "SOBT")
                        {
                            Sobt mySobt;
                            mySobt = db.Sobts.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = mySobt == null ? 0 : mySobt.Id;
                            if (id != 0)
                                mySobt = db.Sobts.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (mySobt == null || id == 0)
                            {
                                mySobt = new Sobt();
                                mySobt.FlightId = flightId;
                                mySobt.Time = item.FieldValue.Trim();
                                mySobt.DateModified = DateTime.Now;
                                mySobt.UserName = "NIA";
                                mySobt.Acvstatus = true;
                                mySobt.Acvtime = DateTime.Now;
                                mySobt.FlightDate = model.FlightDate.ToString("dd/MM/yyyy");
                                db.Sobts.Add(mySobt);
                                await db.SaveChangesAsync();
                            }
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        public async Task<bool> saveToDatabase(int flightId, Boolean isChange, FlightUpdateModel model, string EobtTime, Boolean isChangeName)
        {
            string time = "";
            string _FieldValue = "";
            int id = 0;
            if (model.Route.Contains("HAN-"))
            {
                foreach (var subitem in model.FlightData)
                {
                    if (subitem.FieldName.Trim() == "SOBT")
                    {
                        time = subitem.FieldValue.Trim();
                        break;
                    }
                }
            }
            else if (model.Route.Contains("-HAN"))
            {
                foreach (var subitem in model.FlightData)
                {
                    if (subitem.FieldName.Trim() == "SIBT")
                    {
                        time = subitem.FieldValue.Trim();
                        break;
                    }
                }
            }

            try
            {
                using (var db = new HMIS_BKKContext())
                {
                    if (isChange == false)
                    {
                        var b = await db.Database.ExecuteSqlRawAsync("EXEC HMIS_BKK.dbo.SPSaveFlightNoChangeUpdated '" + model.FlightNo.Trim() + "','" + model.FlightDate.ToString("dd/MM/yyyy") + "','" + time.Trim() + "'," + flightId.ToString());
                    }
                    if (isChange == true && isChangeName == true)
                    {
                        var b = await db.Database.ExecuteSqlRawAsync("EXEC HMIS_BKK.dbo.SPSaveFlightNo '" + model.FlightNo.Trim() + "'," + flightId.ToString());
                    }
                    foreach (FlightDataUpdateModel item in model.FlightData)
                    {
                        _FieldValue = item.FieldValue == null ? "" : item.FieldValue.Trim();
                        if (item.FieldName.Trim() == "ALDT")
                        {
                            Aldt myAldt;
                            myAldt = db.Aldts.Where(a => a.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myAldt == null ? 0 : myAldt.Id;
                            if (id != 0)
                                myAldt = db.Aldts.Where(a => a.Id.Equals(id) && a.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myAldt == null || id == 0)
                            {
                                myAldt = new Aldt();
                                myAldt.FlightId = flightId;
                                myAldt.Time = item.FieldValue.Trim();
                                myAldt.TimeReceive = DateTime.Now;
                                myAldt.Mgha = "ACV";
                                db.Aldts.Add(myAldt);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim() == "ELDT")
                        {
                            Eldt myEldt;
                            myEldt = db.Eldts.Where(a => a.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myEldt == null ? 0 : myEldt.Id;
                            if (id != 0)
                                myEldt = db.Eldts.Where(a => a.Id.Equals(id) && a.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myEldt == null || id == 0)
                            {
                                myEldt = new Eldt();
                                myEldt.FlightId = flightId;
                                myEldt.Time = item.FieldValue.Trim();
                                myEldt.TimeReceive = DateTime.Now;
                                myEldt.Mgha = "ACV";
                                db.Eldts.Add(myEldt);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim() == "EIBT")
                        {
                            Eibt myEibt;
                            myEibt = db.Eibts.Where(a => a.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myEibt == null ? 0 : myEibt.Id;
                            if (id != 0)
                                myEibt = db.Eibts.Where(a => a.Id.Equals(id) && a.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myEibt == null || id == 0)
                            {
                                myEibt = new Eibt();
                                myEibt.FlightId = flightId;
                                myEibt.Time = item.FieldValue.Trim();
                                myEibt.TimeReceive = DateTime.Now;
                                myEibt.Mgha = "ACV";
                                db.Eibts.Add(myEibt);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim() == "TOBT")
                        {
                            Tobt myTOBT;
                            myTOBT = db.Tobts.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myTOBT == null ? 0 : myTOBT.Id;
                            if (id != 0)
                                myTOBT = db.Tobts.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myTOBT == null || id == 0)
                            {
                                myTOBT = new Tobt();
                                myTOBT.FlightId = flightId;
                                myTOBT.Time = item.FieldValue.Trim();
                                myTOBT.Mgha = "ACV";
                                myTOBT.DateModified = DateTime.Now;
                                db.Tobts.Add(myTOBT);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim() == "TSAT")
                        {
                            Tsat myTsat;
                            myTsat = db.Tsats.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myTsat == null ? 0 : myTsat.Id;

                            if (id != 0)
                                myTsat = db.Tsats.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myTsat == null || id == 0)
                            {
                                myTsat = new Tsat();
                                myTsat.FlightId = flightId;
                                myTsat.Time = item.FieldValue.Trim();
                                myTsat.TimeReceive = DateTime.Now;
                                myTsat.Mgha = "ACV";
                                db.Tsats.Add(myTsat);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim() == "ATOT")
                        {
                            ATOT myAtot;
                            myAtot = db.ATOTs.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myAtot == null ? 0 : myAtot.Id;

                            if (id != 0)
                                myAtot = db.ATOTs.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myAtot == null || id == 0)
                            {
                                myAtot = new ATOT();
                                myAtot.FlightId = flightId;
                                myAtot.Time = item.FieldValue.Trim();
                                myAtot.TimeReceive = DateTime.Now;
                                myAtot.Mgha = "ACV";
                                db.ATOTs.Add(myAtot);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim() == "TTOT")
                        {
                            Ttot myTtot;
                            myTtot = db.Ttots.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myTtot == null ? 0 : myTtot.Id;
                            if (id != 0)
                                myTtot = db.Ttots.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myTtot == null || id == 0)
                            {
                                myTtot = new Ttot();
                                myTtot.FlightId = flightId;
                                myTtot.Time = item.FieldValue.Trim();
                                myTtot.TimeReceive = DateTime.Now;
                                myTtot.Mgha = "ACV";
                                db.Ttots.Add(myTtot);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim().ToUpper() == "BELT")
                        {
                            Belt mybel;
                            mybel = db.Belts.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = mybel == null ? 0 : mybel.Id;
                            if (id != 0)
                                mybel = db.Belts.Where(t => t.Id.Equals(id) && t.BeltNo.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (mybel == null || id == 0)
                            {
                                mybel = new Belt();
                                mybel.FlightId = flightId;
                                mybel.BeltNo = item.FieldValue.Trim();
                                mybel.TimeReceive = DateTime.Now;
                                mybel.Mgha = "ACV";
                                db.Belts.Add(mybel);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim() == "DGATE")
                        {
                            Gate myGate;
                            myGate = db.Gates.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myGate == null ? 0 : myGate.Id;
                            if (id != 0)
                                myGate = db.Gates.Where(t => t.Id.Equals(id) && t.Dpark.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myGate == null || id == 0)
                            {
                                myGate = new Gate();
                                myGate.FlightId = flightId;
                                myGate.Dpark = item.FieldValue.Trim();
                                myGate.TimeReceive = DateTime.Now;
                                myGate.Mgha = "ACV";
                                db.Gates.Add(myGate);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim() == "DPRK")
                        {
                            DPOS myDpost;
                            myDpost = db.DPOSs.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myDpost == null ? 0 : myDpost.Id;
                            if (id != 0)
                                myDpost = db.DPOSs.Where(t => t.Id.Equals(id) && t.Dposition.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myDpost == null || id == 0)
                            {
                                myDpost = new DPOS();
                                myDpost.FlightId = flightId;
                                myDpost.Dposition = item.FieldValue.Trim();
                                myDpost.TimeReceive = DateTime.Now;
                                myDpost.Mgha = "ACV";
                                db.DPOSs.Add(myDpost);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim() == "APRK")
                        {
                            Position myPosition;
                            myPosition = db.Positions.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myPosition == null ? 0 : myPosition.Id;
                            if (id != 0)
                                myPosition = db.Positions.Where(t => t.Id.Equals(id) && t.Apark.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myPosition == null || id == 0)
                            {
                                myPosition = new Position();
                                myPosition.FlightId = flightId;
                                myPosition.Apark = item.FieldValue.Trim();
                                myPosition.TimeReceive = DateTime.Now;
                                myPosition.Mgha = "ACV";
                                db.Positions.Add(myPosition);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim().ToUpper() == "STATUS")
                        {
                            StatusDetail myStatus;
                            myStatus = db.StatusDetails.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myStatus == null ? 0 : myStatus.Id;
                            if (id != 0)
                                myStatus = db.StatusDetails.Where(t => t.Id.Equals(id) && t.StatusName.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myStatus == null || id == 0)
                            {
                                myStatus = new StatusDetail();
                                myStatus.FlightId = flightId;
                                myStatus.StatusName = item.FieldValue.Trim();
                                myStatus.DateModified = DateTime.Now;
                                myStatus.Mgha = "ACV";
                                db.StatusDetails.Add(myStatus);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim().ToUpper() == "AIBT")
                        {
                            Aibt myAibt;
                            myAibt = db.Aibts.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myAibt == null ? 0 : myAibt.Id;
                            if (id != 0)
                                myAibt = db.Aibts.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myAibt == null || id == 0)
                            {
                                myAibt = new Aibt();
                                myAibt.FlightId = flightId;
                                myAibt.Time = item.FieldValue.Trim();
                                myAibt.DateModified = DateTime.Now;
                                myAibt.Mgha = "ACV";
                                myAibt.Remark = "";
                                db.Aibts.Add(myAibt);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim().ToUpper() == "ACGT")
                        {
                            Acgt myAcgt;
                            myAcgt = db.Acgts.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myAcgt == null ? 0 : myAcgt.Id;
                            if (id != 0)
                                myAcgt = db.Acgts.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myAcgt == null || id == 0)
                            {
                                myAcgt = new Acgt();
                                myAcgt.FlightId = flightId;
                                myAcgt.Time = item.FieldValue.Trim();
                                myAcgt.DateModified = DateTime.Now;
                                myAcgt.Mgha = "ACV";
                                myAcgt.Remark = "";
                                db.Acgts.Add(myAcgt);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim().ToUpper() == "ASBT")
                        {
                            Asbt myAsbt;
                            myAsbt = db.Asbts.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myAsbt == null ? 0 : myAsbt.Id;
                            if (id != 0)
                                myAsbt = db.Asbts.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myAsbt == null || id == 0)
                            {
                                myAsbt = new Asbt();
                                myAsbt.FlightId = flightId;
                                myAsbt.Time = item.FieldValue.Trim();
                                myAsbt.DateModified = DateTime.Now;
                                myAsbt.Mgha = "ACV";
                                myAsbt.Remark = "";
                                db.Asbts.Add(myAsbt);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim().ToUpper() == "AEGT")
                        {
                            Aegt myAegt;
                            myAegt = db.Aegts.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myAegt == null ? 0 : myAegt.Id;
                            if (id != 0)
                                myAegt = db.Aegts.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myAegt == null || id == 0)
                            {
                                myAegt = new Aegt();
                                myAegt.FlightId = flightId;
                                myAegt.Time = item.FieldValue.Trim();
                                myAegt.DateModified = DateTime.Now;
                                myAegt.Mgha = "ACV";
                                myAegt.Remark = "";
                                db.Aegts.Add(myAegt);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim().ToUpper() == "EOBT" && isChange == false)
                        {
                            Eobt myEobt;
                            myEobt = db.Eobts.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myEobt == null ? 0 : myEobt.Id;
                            if (id != 0)
                                myEobt = db.Eobts.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myEobt == null || id == 0)
                            {
                                myEobt = new Eobt();
                                myEobt.FlightId = flightId;
                                myEobt.Time = item.FieldValue.Trim();
                                myEobt.DateModified = DateTime.Now;
                                myEobt.UserName = "ACV";
                                db.Eobts.Add(myEobt);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (EobtTime.Trim() != "" && isChange == true)
                        {
                            Eobt myEobt;
                            myEobt = db.Eobts.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myEobt == null ? 0 : myEobt.Id;
                            if (id != 0)
                                myEobt = db.Eobts.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myEobt == null || id == 0)
                            {
                                myEobt = new Eobt();
                                myEobt.FlightId = flightId;
                                myEobt.Time = EobtTime.Trim();
                                myEobt.DateModified = DateTime.Now;
                                myEobt.UserName = "ACV";
                                db.Eobts.Add(myEobt);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim().ToUpper() == "ARDT")
                        {
                            Ardt myArdt;
                            myArdt = db.Ardts.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myArdt == null ? 0 : myArdt.Id;
                            if (id != 0)
                                myArdt = db.Ardts.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myArdt == null || id == 0)
                            {
                                myArdt = new Ardt();
                                myArdt.FlightId = flightId;
                                myArdt.Time = item.FieldValue.Trim();
                                myArdt.DateModified = DateTime.Now;
                                myArdt.Mgha = "ACV";
                                myArdt.Remark = "";
                                db.Ardts.Add(myArdt);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim().ToUpper() == "AOBT")
                        {
                            Aobt myAobt;
                            myAobt = db.Aobts.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myAobt == null ? 0 : myAobt.Id;
                            if (id != 0)
                                myAobt = db.Aobts.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myAobt == null || id == 0)
                            {
                                myAobt = new Aobt();
                                myAobt.FlightId = flightId;
                                myAobt.Time = item.FieldValue.Trim();
                                myAobt.DateModified = DateTime.Now;
                                myAobt.Mgha = "ACV";
                                myAobt.Remark = "";
                                db.Aobts.Add(myAobt);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim().ToUpper() == "BOOKING")
                        {
                            Booking myBooking;
                            myBooking = db.Bookings.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.id).FirstOrDefault();
                            id = myBooking == null ? 0 : myBooking.id;
                            int _pax = 0;
                            Int32.TryParse(_FieldValue, out _pax);
                            if (id != 0)
                                myBooking = db.Bookings.Where(t => t.id.Equals(id) && t.Pax == _pax).FirstOrDefault();
                            if (myBooking == null || id == 0)
                            {
                                myBooking = new Booking();
                                myBooking.FlightId = flightId;
                                myBooking.Pax = _pax;
                                myBooking.DateModified = DateTime.Now;
                                myBooking.MGHA = "ACV";
                                db.Bookings.Add(myBooking);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim().ToUpper() == "SIBT")
                        {
                            Sibt mySibt;
                            mySibt = db.Sibts.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = mySibt == null ? 0 : mySibt.Id;
                            if (id != 0)
                                mySibt = db.Sibts.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (mySibt == null || id == 0)
                            {
                                mySibt = new Sibt();
                                mySibt.FlightId = flightId;
                                mySibt.Time = item.FieldValue.Trim();
                                mySibt.DateModified = DateTime.Now;
                                mySibt.UserName = "ACV";
                                mySibt.Acvstatus = true;
                                mySibt.Acvtime = DateTime.Now;
                                mySibt.FlightDate = model.FlightDate.ToString("dd/MM/yyyy");
                                db.Sibts.Add(mySibt);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim().ToUpper() == "SOBT")
                        {
                            Sobt mySobt;
                            mySobt = db.Sobts.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = mySobt == null ? 0 : mySobt.Id;
                            if (id != 0)
                                mySobt = db.Sobts.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (mySobt == null || id == 0)
                            {
                                mySobt = new Sobt();
                                mySobt.FlightId = flightId;
                                mySobt.Time = item.FieldValue.Trim();
                                mySobt.DateModified = DateTime.Now;
                                mySobt.UserName = "ACV";
                                mySobt.Acvstatus = true;
                                mySobt.Acvtime = DateTime.Now;
                                mySobt.FlightDate = model.FlightDate.ToString("dd/MM/yyyy");
                                db.Sobts.Add(mySobt);
                                await db.SaveChangesAsync();
                            }
                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> saveToDatabaseed(int flightId, Boolean isChange, FlightUpdateModel model, DateTime combinedDateTime, string timeChange)
        {
            string _FieldValue = "";
            int id = 0;

            try
            {
                using (var db = new HMIS_BKKContext())
                {
                    if (!isChange)
                    {
                        var b = await db.Database.ExecuteSqlRawAsync("EXEC HMIS_BKK.dbo.SPSaveFlightNoChange '" + model.FlightNo.Trim() + "','" + model.FlightDate.ToString("dd/MM/yyyy") + "','" + timeChange.Trim() + "'," + flightId.ToString());
                    }
                    foreach (FlightDataUpdateModel item in model.FlightData)
                    {
                        _FieldValue = item.FieldValue == null ? "" : item.FieldValue.Trim();
                        if (item.FieldName.Trim() == "ALDT")
                        {
                            Aldt myAldt;
                            myAldt = db.Aldts.Where(a => a.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myAldt == null ? 0 : myAldt.Id;
                            if (id != 0)
                                myAldt = db.Aldts.Where(a => a.Id.Equals(id) && a.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myAldt == null || id == 0)
                            {
                                myAldt = new Aldt();
                                myAldt.FlightId = flightId;
                                myAldt.Time = item.FieldValue.Trim();
                                myAldt.TimeReceive = DateTime.Now;
                                myAldt.Mgha = "ACV";
                                db.Aldts.Add(myAldt);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim() == "ELDT")
                        {
                            Eldt myEldt;
                            myEldt = db.Eldts.Where(a => a.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myEldt == null ? 0 : myEldt.Id;
                            if (id != 0)
                                myEldt = db.Eldts.Where(a => a.Id.Equals(id) && a.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myEldt == null || id == 0)
                            {
                                myEldt = new Eldt();
                                myEldt.FlightId = flightId;
                                myEldt.Time = item.FieldValue.Trim();
                                myEldt.TimeReceive = DateTime.Now;
                                myEldt.Mgha = "ACV";
                                db.Eldts.Add(myEldt);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim() == "EIBT")
                        {
                            Eibt myEibt;
                            myEibt = db.Eibts.Where(a => a.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myEibt == null ? 0 : myEibt.Id;
                            if (id != 0)
                                myEibt = db.Eibts.Where(a => a.Id.Equals(id) && a.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myEibt == null || id == 0)
                            {
                                myEibt = new Eibt();
                                myEibt.FlightId = flightId;
                                myEibt.Time = item.FieldValue.Trim();
                                myEibt.TimeReceive = DateTime.Now;
                                myEibt.Mgha = "ACV";
                                db.Eibts.Add(myEibt);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim() == "TOBT")
                        {
                            Tobt myTOBT;
                            myTOBT = db.Tobts.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myTOBT == null ? 0 : myTOBT.Id;
                            if (id != 0)
                                myTOBT = db.Tobts.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myTOBT == null || id == 0)
                            {
                                myTOBT = new Tobt();
                                myTOBT.FlightId = flightId;
                                myTOBT.Time = item.FieldValue.Trim();
                                myTOBT.Mgha = "ACV";
                                myTOBT.DateModified = DateTime.Now;
                                db.Tobts.Add(myTOBT);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim() == "TSAT")
                        {
                            Tsat myTsat;
                            myTsat = db.Tsats.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myTsat == null ? 0 : myTsat.Id;

                            if (id != 0)
                                myTsat = db.Tsats.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myTsat == null || id == 0)
                            {
                                myTsat = new Tsat();
                                myTsat.FlightId = flightId;
                                myTsat.Time = item.FieldValue.Trim();
                                myTsat.TimeReceive = DateTime.Now;
                                myTsat.Mgha = "ACV";
                                db.Tsats.Add(myTsat);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim() == "ATOT")
                        {
                            ATOT myAtot;
                            myAtot = db.ATOTs.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myAtot == null ? 0 : myAtot.Id;

                            if (id != 0)
                                myAtot = db.ATOTs.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myAtot == null || id == 0)
                            {
                                myAtot = new ATOT();
                                myAtot.FlightId = flightId;
                                myAtot.Time = item.FieldValue.Trim();
                                myAtot.TimeReceive = DateTime.Now;
                                myAtot.Mgha = "ACV";
                                db.ATOTs.Add(myAtot);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim() == "TTOT")
                        {
                            Ttot myTtot;
                            myTtot = db.Ttots.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myTtot == null ? 0 : myTtot.Id;
                            if (id != 0)
                                myTtot = db.Ttots.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myTtot == null || id == 0)
                            {
                                myTtot = new Ttot();
                                myTtot.FlightId = flightId;
                                myTtot.Time = item.FieldValue.Trim();
                                myTtot.TimeReceive = DateTime.Now;
                                myTtot.Mgha = "ACV";
                                db.Ttots.Add(myTtot);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim().ToUpper() == "BELT")
                        {
                            Belt mybel;
                            mybel = db.Belts.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = mybel == null ? 0 : mybel.Id;
                            if (id != 0)
                                mybel = db.Belts.Where(t => t.Id.Equals(id) && t.BeltNo.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (mybel == null || id == 0)
                            {
                                mybel = new Belt();
                                mybel.FlightId = flightId;
                                mybel.BeltNo = item.FieldValue.Trim();
                                mybel.TimeReceive = DateTime.Now;
                                mybel.Mgha = "ACV";
                                db.Belts.Add(mybel);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim() == "DGATE")
                        {
                            Gate myGate;
                            myGate = db.Gates.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myGate == null ? 0 : myGate.Id;
                            if (id != 0)
                                myGate = db.Gates.Where(t => t.Id.Equals(id) && t.Dpark.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myGate == null || id == 0)
                            {
                                myGate = new Gate();
                                myGate.FlightId = flightId;
                                myGate.Dpark = item.FieldValue.Trim();
                                myGate.TimeReceive = DateTime.Now;
                                myGate.Mgha = "ACV";
                                db.Gates.Add(myGate);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim() == "DPRK")
                        {
                            DPOS myDpost;
                            myDpost = db.DPOSs.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myDpost == null ? 0 : myDpost.Id;
                            if (id != 0)
                                myDpost = db.DPOSs.Where(t => t.Id.Equals(id) && t.Dposition.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myDpost == null || id == 0)
                            {
                                myDpost = new DPOS();
                                myDpost.FlightId = flightId;
                                myDpost.Dposition = item.FieldValue.Trim();
                                myDpost.TimeReceive = DateTime.Now;
                                myDpost.Mgha = "ACV";
                                db.DPOSs.Add(myDpost);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim() == "APRK")
                        {
                            Position myPosition;
                            myPosition = db.Positions.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myPosition == null ? 0 : myPosition.Id;
                            if (id != 0)
                                myPosition = db.Positions.Where(t => t.Id.Equals(id) && t.Apark.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myPosition == null || id == 0)
                            {
                                myPosition = new Position();
                                myPosition.FlightId = flightId;
                                myPosition.Apark = item.FieldValue.Trim();
                                myPosition.TimeReceive = DateTime.Now;
                                myPosition.Mgha = "ACV";
                                db.Positions.Add(myPosition);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim().ToUpper() == "STATUS")
                        {
                            StatusDetail myStatus;
                            myStatus = db.StatusDetails.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myStatus == null ? 0 : myStatus.Id;
                            if (id != 0)
                                myStatus = db.StatusDetails.Where(t => t.Id.Equals(id) && t.StatusName.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myStatus == null || id == 0)
                            {
                                myStatus = new StatusDetail();
                                myStatus.FlightId = flightId;
                                myStatus.StatusName = item.FieldValue.Trim();
                                myStatus.DateModified = DateTime.Now;
                                myStatus.Mgha = "ACV";
                                db.StatusDetails.Add(myStatus);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim().ToUpper() == "AIBT")
                        {
                            Aibt myAibt;
                            myAibt = db.Aibts.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myAibt == null ? 0 : myAibt.Id;
                            if (id != 0)
                                myAibt = db.Aibts.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myAibt == null || id == 0)
                            {
                                myAibt = new Aibt();
                                myAibt.FlightId = flightId;
                                myAibt.Time = item.FieldValue.Trim();
                                myAibt.DateModified = DateTime.Now;
                                myAibt.Mgha = "ACV";
                                db.Aibts.Add(myAibt);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim().ToUpper() == "ACGT")
                        {
                            Acgt myAcgt;
                            myAcgt = db.Acgts.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myAcgt == null ? 0 : myAcgt.Id;
                            if (id != 0)
                                myAcgt = db.Acgts.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myAcgt == null || id == 0)
                            {
                                myAcgt = new Acgt();
                                myAcgt.FlightId = flightId;
                                myAcgt.Time = item.FieldValue.Trim();
                                myAcgt.DateModified = DateTime.Now;
                                myAcgt.Mgha = "ACV";
                                db.Acgts.Add(myAcgt);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim().ToUpper() == "ASBT")
                        {
                            Asbt myAsbt;
                            myAsbt = db.Asbts.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myAsbt == null ? 0 : myAsbt.Id;
                            if (id != 0)
                                myAsbt = db.Asbts.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myAsbt == null || id == 0)
                            {
                                myAsbt = new Asbt();
                                myAsbt.FlightId = flightId;
                                myAsbt.Time = item.FieldValue.Trim();
                                myAsbt.DateModified = DateTime.Now;
                                myAsbt.Mgha = "ACV";
                                db.Asbts.Add(myAsbt);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim().ToUpper() == "AEGT")
                        {
                            Aegt myAegt;
                            myAegt = db.Aegts.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myAegt == null ? 0 : myAegt.Id;
                            if (id != 0)
                                myAegt = db.Aegts.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myAegt == null || id == 0)
                            {
                                myAegt = new Aegt();
                                myAegt.FlightId = flightId;
                                myAegt.Time = item.FieldValue.Trim();
                                myAegt.DateModified = DateTime.Now;
                                myAegt.Mgha = "ACV";
                                db.Aegts.Add(myAegt);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim().ToUpper() == "EOBT")
                        {
                            Eobt myEobt;
                            myEobt = db.Eobts.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myEobt == null ? 0 : myEobt.Id;
                            if (id != 0)
                                myEobt = db.Eobts.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myEobt == null || id == 0)
                            {
                                myEobt = new Eobt();
                                myEobt.FlightId = flightId;
                                myEobt.Time = item.FieldValue.Trim();
                                myEobt.DateModified = DateTime.Now;
                                myEobt.UserName = "ACV";
                                db.Eobts.Add(myEobt);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim().ToUpper() == "ARDT")
                        {
                            Ardt myArdt;
                            myArdt = db.Ardts.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myArdt == null ? 0 : myArdt.Id;
                            if (id != 0)
                                myArdt = db.Ardts.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myArdt == null || id == 0)
                            {
                                myArdt = new Ardt();
                                myArdt.FlightId = flightId;
                                myArdt.Time = item.FieldValue.Trim();
                                myArdt.DateModified = DateTime.Now;
                                myArdt.Mgha = "ACV";
                                db.Ardts.Add(myArdt);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim().ToUpper() == "AEGT")
                        {
                            Aegt myAegt;
                            myAegt = db.Aegts.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myAegt == null ? 0 : myAegt.Id;
                            if (id != 0)
                                myAegt = db.Aegts.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myAegt == null || id == 0)
                            {
                                myAegt = new Aegt();
                                myAegt.FlightId = flightId;
                                myAegt.Time = item.FieldValue.Trim();
                                myAegt.DateModified = DateTime.Now;
                                myAegt.Mgha = "ACV";
                                db.Aegts.Add(myAegt);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim().ToUpper() == "AOBT")
                        {
                            Aobt myAobt;
                            myAobt = db.Aobts.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.Id).FirstOrDefault();
                            id = myAobt == null ? 0 : myAobt.Id;
                            if (id != 0)
                                myAobt = db.Aobts.Where(t => t.Id.Equals(id) && t.Time.Trim().Equals(_FieldValue)).FirstOrDefault();
                            if (myAobt == null || id == 0)
                            {
                                myAobt = new Aobt();
                                myAobt.FlightId = flightId;
                                myAobt.Time = item.FieldValue.Trim();
                                myAobt.DateModified = DateTime.Now;
                                myAobt.Mgha = "ACV";
                                db.Aobts.Add(myAobt);
                                await db.SaveChangesAsync();
                            }
                        }
                        else if (item.FieldName.Trim().ToUpper() == "BOOKING")
                        {
                            Booking myBooking;
                            myBooking = db.Bookings.Where(t => t.FlightId.Equals(flightId)).OrderByDescending(b => b.id).FirstOrDefault();
                            id = myBooking == null ? 0 : myBooking.id;
                            int _pax = 0;
                            Int32.TryParse(_FieldValue, out _pax);
                            if (id != 0)
                                myBooking = db.Bookings.Where(t => t.id.Equals(id) && t.Pax == _pax).FirstOrDefault();
                            if (myBooking == null || id == 0)
                            {
                                myBooking = new Booking();
                                myBooking.FlightId = flightId;
                                myBooking.Pax = _pax;
                                myBooking.DateModified = DateTime.Now;
                                myBooking.MGHA = "ACV";
                                db.Bookings.Add(myBooking);
                                await db.SaveChangesAsync();
                            }
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        static async Task<List<FlightUpdateModel>> GetItemsAsync(string selectedDate)
        {
            HttpClient httpClient = new HttpClient();
            string token = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYWE3MmYzYWMtMTM0OC00N2M1LTk3MjUtNTkzZGFkZWViOGFjIiwiRnVsbE5hbWUiOiIiLCJCYXNlIjoiSEFOIiwiU291cmNlIjoiSEdTIiwiRGV2aWNlSWQiOiIyNzhmOTMxNS0zNjhjLTRlZDEtYmYwNy01ZTE5ZTlmMWI2NzciLCJleHAiOjI2NTIxNDA0NDYsImlzcyI6IkFDVkFQSS5TZXJ2ZXIiLCJhdWQiOiJBQ1ZBUEkuQ2xpZW50In0.b5nm_JKANiN7UnatkrnTcvE6XbYkeY1TO-wE-2GFS3XLvNh_3XD_Hl951z-0RH2z3fzmNqpE8Ki8U8wW0lfSuw";
            // Add the bearer token to the Authorization header of the HTTP request
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            // Make an HTTP GET request to the API endpoint
            HttpResponseMessage response = await httpClient.GetAsync("https://apiflight.noibaiairport.vn/GetFlightFDE?FlightDate=" + selectedDate);
            response.EnsureSuccessStatusCode();
            // Read the response content as a string
            string responseContent = await response.Content.ReadAsStringAsync();
            // Deserialize the JSON string into a list of objects
            List<FlightUpdateModel> ListData = JsonConvert.DeserializeObject<List<FlightUpdateModel>>(responseContent);
            return ListData;
        }
        public async Task<FlightInforModel> CallApiGetMethodAsync(RequestObject request)
        {
            string InternetApiUrl = "https://apiflight.noibaiairport.vn/GetFlightFDE?FlightDate";

            HttpClient httpClient = new HttpClient();
            string token = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYWE3MmYzYWMtMTM0OC00N2M1LTk3MjUtNTkzZGFkZWViOGFjIiwiRnVsbE5hbWUiOiIiLCJCYXNlIjoiSEFOIiwiU291cmNlIjoiSEdTIiwiRGV2aWNlSWQiOiIyNzhmOTMxNS0zNjhjLTRlZDEtYmYwNy01ZTE5ZTlmMWI2NzciLCJleHAiOjI2NTIxNDA0NDYsImlzcyI6IkFDVkFQSS5TZXJ2ZXIiLCJhdWQiOiJBQ1ZBUEkuQ2xpZW50In0.b5nm_JKANiN7UnatkrnTcvE6XbYkeY1TO-wE-2GFS3XLvNh_3XD_Hl951z-0RH2z3fzmNqpE8Ki8U8wW0lfSuw";
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            // Serialize the object to JSON

            string jsonRequest = JsonConvert.SerializeObject(request);

            // Encode the JSON data and include it in the URL
            string encodedData = System.Net.WebUtility.UrlEncode(jsonRequest);
            string queryString = $"?jsonData={encodedData}";

            try
            {
                // Send the GET request
                HttpResponseMessage response = await httpClient.GetAsync(InternetApiUrl + queryString);

                // Handle the response
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();

                    // Deserialize the response content to your response model
                    FlightInforModel responseData = JsonConvert.DeserializeObject<FlightInforModel>(responseContent);

                    return responseData;
                }
                else
                {
                    // Handle the error response
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

    }
}

