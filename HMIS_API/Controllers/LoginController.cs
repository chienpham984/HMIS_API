using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HMIS_API.Repository.Models;
using HMIS_API.Repository.ModelView;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using System.Globalization;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace HMIS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost]
        public IActionResult Login(UserModel userinfor)
        {
            IActionResult response = Unauthorized();
            //var tokenStr = GenerateJsonWebToken(login);
            //response = Ok(new { Success=true, Message="Login Successfully", data = tokenStr });
            //return response;
            List<UserModeDetail> listUser = new List<UserModeDetail>();
            UserModeDetail user = null;
            using (var db = new HMIS_BKKContext())
            {
                listUser = db.UserModeDetails.FromSqlRaw($"EXEC SPLoginBamboo '{userinfor.UserName.Trim()}','{userinfor.PassWord.Trim()}','{userinfor.AreaName.Trim()}'").ToList();
            }
            if (listUser.Count > 0)
            {
                user = listUser[0];
            }

            var sercurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["jwt:key"]));
            var credentials = new SigningCredentials(sercurityKey, SecurityAlgorithms.HmacSha256);
            if (user != null)
            {
                var claims = new[] {
                new Claim("ID", user.UserName),
                new Claim("FullName", user.FullName.Trim()),
                new Claim("Email", user.Email.Trim()),
                new Claim("PhoneNumber", user.PhoneNumber.Trim()),
                new Claim("DeptCode", user.DeptCode.Trim()),
                new Claim("RoleCode", user.RoleCode.Trim()),
                new Claim("ListDocument", user.ListDocument.Trim()),
                new Claim("AreaName", user.AreaName.Trim()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
                var tocken = new JwtSecurityToken(
                    issuer: _config["jwt:Issuer"],
                    audience: _config["jwt:Issuer"],
                    claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: credentials);

                var encodeToken = new JwtSecurityTokenHandler().WriteToken(tocken);
                return Ok(new { Success = true, Message = "Login Successfully", data = encodeToken }); 
            }
            else
                return response;

        }

        private string GenerateJsonWebToken(UserModel userinfor)
        {
            List<UserModeDetail> listUser = new List<UserModeDetail>();
            UserModeDetail user = null;
            using (var db = new HMIS_BKKContext())
            {
                listUser = db.UserModeDetails.FromSqlRaw($"EXEC SPLoginBamboo '{userinfor.UserName.Trim()}','{userinfor.PassWord.Trim()}','{userinfor.AreaName.Trim()}'").ToList();
            }
            if (listUser.Count > 0)
            {
                user = listUser[0];
            }

            var sercurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["jwt:key"]));
            var credentials = new SigningCredentials(sercurityKey, SecurityAlgorithms.HmacSha256);
            if (user != null)
            {
                var claims = new[] {
                new Claim("ID", user.UserName),
                new Claim("FullName", user.FullName.Trim()),
                new Claim("Email", user.Email.Trim()),
                new Claim("PhoneNumber", user.PhoneNumber.Trim()),
                new Claim("DeptCode", user.DeptCode.Trim()),
                new Claim("RoleCode", user.RoleCode.Trim()),
                new Claim("ListDocument", user.ListDocument.Trim()),
                new Claim("AreaName", user.AreaName.Trim()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
                var tocken = new JwtSecurityToken(
                    issuer: _config["jwt:Issuer"],
                    audience: _config["jwt:Issuer"],
                    claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: credentials);

                var encodeToken = new JwtSecurityTokenHandler().WriteToken(tocken);
                return encodeToken;
            }
            else
                return "";

        }

        [HttpPost("getPassWord")]
        public IActionResult getPassWord(UserModel login)
        {
            User myInfor = null;
            using (var db = new HMIS_BKKContext())
            {
                var query = from User in db.Users
                            join UserAreaDetail in db.UserAreaDetails
                            on User.Id equals UserAreaDetail.UserId
                            join Area in db.Areas
                            on UserAreaDetail.AreaId equals Area.Id
                            where User.UserName.Trim() == login.UserName.Trim() && Area.AreaName.ToString() == login.AreaName.Trim()
                            select new
                            {
                                UserName = User.UserName,
                                PassWord = User.PassWord,
                                Email = User.Email
                            };
                //return Ok(new { Success = true, Message = "Login Successfully", data = query.FirstOrDefault() });
                return Ok(query.FirstOrDefault());
            }
            
        }

        [Authorize]
        [HttpPost("Post")]
        public string Post()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            var userName = claim[0].Value;
            return "Welcome To : " + userName;

        }

        [Authorize]
        [HttpGet("GetValue")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2", "value3" };
        }

        [Authorize]
        [HttpGet("GetFlightInfor")]
        public IActionResult GetFlightInfor(string flightDate)
        {
            //duyet tung cbay
            List<Flight> listFlight = new List<Flight>();
            List<_flight> Result = new List<_flight>();
            _flight _result;
            DateTime _Date;
            Aibt newAIBT;
            Sibt newSIBT;
            StatusDetail newStatus;
            Sobt newSOBT;
            Eobt newEOBT;
            Acgt newACGT;
            Asbt newASBT;
            Ardt newARDT;
            Aegt newAEGT;
            Tobt newTOBT;
            Aobt newAOBT;
            Etttdetail newEttt;
            IActionResult response = Unauthorized();
            using (var db = new HMIS_BKKContext())
            {
                listFlight = db.Flights.Where(f => f.FlightDate.Equals(flightDate)).OrderBy(f => Convert.ToInt32(f.FlightTime)).ToList();
                if (listFlight.Count > 0)
                {
                    foreach (Flight item in listFlight)
                    {
                        //luu header
                        _result = new _flight();
                        _result.FlightNo = item.FlightNo.Trim();
                        _Date = DateTime.ParseExact(item.FlightDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        _result.FlightDate = _Date;
                        _result.Route = item.RouteFlight;
                        _result.FlightId = item.FlightId.Value;
                        _result.ArrDep = item.ArrDep;
                        _result.MGHA = "HGS";
                        _result.Base = "NIA";
                        newStatus = new StatusDetail();
                        newStatus = db.StatusDetails.Where(f => f.FlightId.Equals(item.FlightId)).OrderByDescending(f => f.Id).FirstOrDefault();
                        if (newStatus != null)
                        {
                            _result.AIBT = newStatus.StatusName == null ? "" : newStatus.StatusName.Trim();
                        }
                        if (item.ArrDep == "A")
                        {

                            newAIBT = new Aibt();
                            newAIBT = db.Aibts.Where(f => f.FlightId.Equals(item.FlightId)).OrderByDescending(f => f.Id).FirstOrDefault();
                            if (newAIBT != null)
                            {
                                _result.AIBT = newAIBT.Time == null ? "" : newAIBT.Time.Trim();
                            }

                            newSIBT = new Sibt();
                            newSIBT = db.Sibts.Where(f => f.FlightId.Equals(item.FlightId)).OrderByDescending(f => f.Id).FirstOrDefault();
                            if (newSIBT != null)
                            {
                                _result.AIBT = newSIBT.Time == null ? "" : newSIBT.Time.Trim();
                            }
                        }
                        else if (item.ArrDep == "D")
                        {
                            newSOBT = new Sobt();
                            newSOBT = db.Sobts.Where(f => f.FlightId.Equals(item.FlightId)).OrderByDescending(f => f.Id).FirstOrDefault();
                            if (newSOBT != null)
                            {
                                _result.AIBT = newSOBT.Time == null ? "" : newSOBT.Time.Trim();
                            }
                            newEOBT = new Eobt();
                            newEOBT = db.Eobts.Where(f => f.FlightId.Equals(item.FlightId)).OrderByDescending(f => f.Id).FirstOrDefault();
                            if (newEOBT != null)
                            {
                                _result.AIBT = newEOBT.Time == null ? "" : newEOBT.Time.Trim();
                            }

                            newEttt = new Etttdetail();
                            newEttt = db.Etttdetails.Where(f => f.FlightId.Equals(item.FlightId)).OrderByDescending(f => f.Id).FirstOrDefault();
                            if (newEttt != null)
                            {
                                _result.ETTT = newEttt.Time == null ? 0 : newEttt.Time.Value;
                            }

                            newACGT = new Acgt();
                            newACGT = db.Acgts.Where(f => f.FlightId.Equals(item.FlightId)).OrderByDescending(f => f.Id).FirstOrDefault();
                            if (newACGT != null)
                            {
                                _result.ACGT = newACGT.Time == null ? "" : newACGT.Time.Trim();
                            }

                            newASBT = new Asbt();
                            newASBT = db.Asbts.Where(f => f.FlightId.Equals(item.FlightId)).OrderByDescending(f => f.Id).FirstOrDefault();
                            if (newASBT != null)
                            {
                                _result.ASBT = newASBT.Time == null ? "" : newASBT.Time.Trim();
                            }

                            newARDT = new Ardt();
                            newARDT = db.Ardts.Where(f => f.FlightId.Equals(item.FlightId)).OrderByDescending(f => f.Id).FirstOrDefault();
                            if (newARDT != null)
                            {
                                _result.ARDT = newARDT.Time == null ? "" : newARDT.Time.Trim();
                            }

                            newAEGT = new Aegt();
                            newAEGT = db.Aegts.Where(f => f.FlightId.Equals(item.FlightId)).OrderByDescending(f => f.Id).FirstOrDefault();
                            if (newAEGT != null)
                            {
                                _result.AEGT = newAEGT.Time == null ? "" : newAEGT.Time.Trim();
                            }

                            newTOBT = new Tobt();
                            newTOBT = db.Tobts.Where(f => f.FlightId.Equals(item.FlightId)).OrderByDescending(f => f.Id).FirstOrDefault();
                            if (newTOBT != null)
                            {
                                _result.TOBT = newTOBT.Time == null ? "" : newTOBT.Time.Trim();
                            }

                            newAOBT = new Aobt();
                            newAOBT = db.Aobts.Where(f => f.FlightId.Equals(item.FlightId)).OrderByDescending(f => f.Id).FirstOrDefault();
                            if (newAOBT != null)
                            {
                                _result.AOBT = newAOBT.Time == null ? "" : newAOBT.Time.Trim();
                            }
                        }
                        Result.Add(_result);
                    }
                    response = Ok(new { data = Result });
                }

            }
            //voi moi cbay 


            return response;
        }
    }
}
