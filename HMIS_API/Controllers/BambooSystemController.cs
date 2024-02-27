using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HMIS_API.Repository.QH;
using Microsoft.AspNetCore.Authorization;
using HMIS_API.Repository.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace HMIS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BambooSystemController : ControllerBase
    {
        private readonly HMIS_BKKContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BambooSystemController(IHttpContextAccessor httpContextAccessor)
        {
            _context = new HMIS_BKKContext();
            _httpContextAccessor = httpContextAccessor;
        }

        //Department
        [Authorize]
        [HttpGet("getListDepartment")]
        public IActionResult getListDepartment()
        {
            //kiem tra role
            var claims = _httpContextAccessor.HttpContext.User.Claims;
            string UserRole = claims.FirstOrDefault(c => c.Type == "RoleCode").ToString();
            UserRole = UserRole.Replace("RoleCode:", "");

            string UserArea = claims.FirstOrDefault(c => c.Type == "AreaName").ToString();
            UserArea = UserArea.Replace("AreaName:", "");

            if (UserRole.Trim() == "Admin" && UserArea.Trim() == "System")
            {
                List<Department> listDept = _context.Departments.OrderBy(d => d.DeptName).ToList();
                return Ok(new DepartmenAPI
                {
                    Success = true,
                    Message = "Authenticate Success",
                    Data = listDept
                });
            }
            else
                return Ok(new DepartmenAPI
                {
                    Success = false,
                    Message = "User Not allow to get data",
                    Data = null
                });
        }
        [Authorize]
        [HttpPost("updateDepartment")]
        public IActionResult updateDepartment(Department deptInserted)
        {
            //kiem tra role
            var claims = _httpContextAccessor.HttpContext.User.Claims;
            string UserRole = claims.FirstOrDefault(c => c.Type == "RoleCode").ToString();
            UserRole = UserRole.Replace("RoleCode:", "");

            string UserArea = claims.FirstOrDefault(c => c.Type == "AreaName").ToString();
            UserArea = UserArea.Replace("AreaName:", "");

            if (UserRole.Trim() == "Admin" && UserArea.Trim() == "System")
            {
                Department Dept = null;
                Dept = _context.Departments.Where(d => d.Id.Equals(deptInserted.Id) ).FirstOrDefault();
                if (Dept == null)
                {
                    return Ok(new DepartmenAPI
                    {
                        Success = false,
                        Message = "information to be updated not exists",
                        Data = null
                    }); 
                }
                Dept.DeptCode = deptInserted.DeptCode.Trim();
                Dept.DeptName = deptInserted.DeptName.Trim();
                _context.SaveChanges();
                List<Department> listDept = _context.Departments.OrderBy(d => d.DeptName).ToList();
                return Ok(new DepartmenAPI
                {
                    Success = true,
                    Message = "Authenticate Success",
                    Data = listDept
                }) ;
            }
            else
                return Ok(new DepartmenAPI
                {
                    Success = false,
                    Message = "User Not allow to get data",
                    Data = null
                });
        }
        [Authorize]
        [HttpPost("InsertDepartment")]
        public IActionResult InsertDepartment(Department deptInserted)
        {
            //kiem tra role
            var claims = _httpContextAccessor.HttpContext.User.Claims;
            string UserRole = claims.FirstOrDefault(c => c.Type == "RoleCode").ToString();
            UserRole = UserRole.Replace("RoleCode:", "");

            string UserArea = claims.FirstOrDefault(c => c.Type == "AreaName").ToString();
            UserArea = UserArea.Replace("AreaName:", "");

            if (UserRole.Trim() == "Admin" && UserArea.Trim() == "System")
            {
                Department Dept = null;
                Dept = _context.Departments.Where(d => d.DeptName.Trim().Equals(deptInserted.DeptName.Trim()) || d.DeptCode.Trim().Equals(deptInserted.DeptCode.Trim())).FirstOrDefault();
                if (Dept != null)
                {
                    return Ok(new DepartmenAPI
                    {
                        Success = false,
                        Message = "information to be added already exists",
                        Data = null
                    });
                }
                _context.Departments.Add(deptInserted);
                _context.SaveChanges();
                List<Department> listDept = _context.Departments.OrderBy(d => d.DeptName).ToList();
                return Ok(new DepartmenAPI
                {
                    Success = true,
                    Message = "Authenticate Success",
                    Data = listDept
                });
            }
            else
                return Ok(new DepartmenAPI
                {
                    Success = false,
                    Message = "User Not allow to get data",
                    Data = null
                });
        }
        [Authorize]
        [HttpPost("deleteDepartment")]
        public IActionResult deleteDepartment(deleteModal deptModal)
        {
            //kiem tra role
            var claims = _httpContextAccessor.HttpContext.User.Claims;
            string UserRole = claims.FirstOrDefault(c => c.Type == "RoleCode").ToString();
            UserRole = UserRole.Replace("RoleCode:", "");

            string UserArea = claims.FirstOrDefault(c => c.Type == "AreaName").ToString();
            UserArea = UserArea.Replace("AreaName:", "");

            if (UserRole.Trim() == "Admin" && UserArea.Trim() == "System")
            {
                Department Dept = null;
                Dept = _context.Departments.Where(d => d.Id == deptModal.depetedId).FirstOrDefault();
                if (Dept == null)
                {
                    return Ok(new DepartmenAPI
                    {
                        Success = false,
                        Message = "information to be deleted not exists",
                        Data = null
                    });
                }
                _context.Departments.Remove(Dept);
                _context.SaveChanges();
                List<Department> listDept = _context.Departments.OrderBy(d => d.DeptName).ToList();
                return Ok(new DepartmenAPI
                {
                    Success = true,
                    Message = "Authenticate Success",
                    Data = listDept
                });
            }
            else
                return Ok(new DepartmenAPI
                {
                    Success = false,
                    Message = "User Not allow to get data",
                    Data = null
                });
        }

        //DocumentType
        [Authorize]
        [HttpGet("getListDocumentType")]
        public IActionResult getListDocumentType()
        {
            //kiem tra role
            var claims = _httpContextAccessor.HttpContext.User.Claims;
            string UserRole = claims.FirstOrDefault(c => c.Type == "RoleCode").ToString();
            UserRole = UserRole.Replace("RoleCode:", "");

            string UserArea = claims.FirstOrDefault(c => c.Type == "AreaName").ToString();
            UserArea = UserArea.Replace("AreaName:", "");

            if (UserRole.Trim() == "Admin" && UserArea.Trim() == "System")
            {
                List<DocumentType> listDocType = _context.DocumentTypes.OrderBy(d => d.DocumentTypeName).ToList();
                return Ok(new DocumentTypeAPI
                {
                    Success = true,
                    Message = "Authenticate Success",
                    Data = listDocType
                });
            }
            else
                return Ok(new DocumentTypeAPI
                {
                    Success = false,
                    Message = "User Not allow to get data",
                    Data = null
                });
        }
        [Authorize]
        [HttpPost("InertDepartment")]
        public IActionResult InertDocumentType(DocumentType docTypeInserted)
        {
            //kiem tra role
            var claims = _httpContextAccessor.HttpContext.User.Claims;
            string UserRole = claims.FirstOrDefault(c => c.Type == "RoleCode").ToString();
            UserRole = UserRole.Replace("RoleCode:", "");

            string UserArea = claims.FirstOrDefault(c => c.Type == "AreaName").ToString();
            UserArea = UserArea.Replace("AreaName:", "");

            if (UserRole.Trim() == "Admin" && UserArea.Trim() == "System")
            {
                DocumentType DocType = null;
                DocType = _context.DocumentTypes.Where(d => d.DocumentTypeName.Trim().Equals(docTypeInserted.DocumentTypeName.Trim()) ).FirstOrDefault();
                if (DocType != null)
                {
                    return Ok(new DepartmenAPI
                    {
                        Success = false,
                        Message = "information to be added already exists",
                        Data = null
                    });
                }
                _context.DocumentTypes.Add(docTypeInserted);
                _context.SaveChanges();
                List<Department> listDept = _context.Departments.OrderBy(d => d.DeptName).ToList();
                return Ok(new DepartmenAPI
                {
                    Success = true,
                    Message = "Authenticate Success",
                    Data = listDept
                });
            }
            else
                return Ok(new DepartmenAPI
                {
                    Success = false,
                    Message = "User Not allow to get data",
                    Data = null
                });
        }
        [Authorize]
        [HttpPost("updateDocumentType")]
        public IActionResult updateDocumentType(DocumentType docTypeInserted)
        {
            //kiem tra role
            var claims = _httpContextAccessor.HttpContext.User.Claims;
            string UserRole = claims.FirstOrDefault(c => c.Type == "RoleCode").ToString();
            UserRole = UserRole.Replace("RoleCode:", "");

            string UserArea = claims.FirstOrDefault(c => c.Type == "AreaName").ToString();
            UserArea = UserArea.Replace("AreaName:", "");

            if (UserRole.Trim() == "Admin" && UserArea.Trim() == "System")
            {
                DocumentType DocType = null;
                DocType = _context.DocumentTypes.Where(d => d.DocumentTypeId.Equals(docTypeInserted.DocumentTypeId)).FirstOrDefault();
                if (DocType == null)
                {
                    return Ok(new DocumentTypeAPI
                    {
                        Success = false,
                        Message = "information to be updated not exists",
                        Data = null
                    });
                }
                DocType.DocumentTypeName = docTypeInserted.DocumentTypeName.Trim();
                _context.SaveChanges();
                List<DocumentType> listDocType = _context.DocumentTypes.OrderBy(d => d.DocumentTypeName).ToList();
                return Ok(new DocumentTypeAPI
                {
                    Success = true,
                    Message = "Authenticate Success",
                    Data = listDocType
                });
            }
            else
                return Ok(new DocumentTypeAPI
                {
                    Success = false,
                    Message = "User Not allow to get data",
                    Data = null
                });
        }
        [Authorize]
        [HttpPost("deleteDocumentType")]
        public IActionResult deleteDocumentType(deleteModal deptModal)
        {
            //kiem tra role
            var claims = _httpContextAccessor.HttpContext.User.Claims;
            string UserRole = claims.FirstOrDefault(c => c.Type == "RoleCode").ToString();
            UserRole = UserRole.Replace("RoleCode:", "");

            string UserArea = claims.FirstOrDefault(c => c.Type == "AreaName").ToString();
            UserArea = UserArea.Replace("AreaName:", "");

            if (UserRole.Trim() == "Admin" && UserArea.Trim() == "System")
            {
                DocumentType docType = null;
                docType = _context.DocumentTypes.Where(d => d.DocumentTypeId == deptModal.depetedId).FirstOrDefault();
                if (docType == null)
                {
                    return Ok(new DocumentTypeAPI
                    {
                        Success = false,
                        Message = "information to be deleted not exists",
                        Data = null
                    });
                }
                _context.DocumentTypes.Remove(docType);
                _context.SaveChanges();
                List<DocumentType> listDocType = _context.DocumentTypes.OrderBy(d => d.DocumentTypeName).ToList();
                return Ok(new DocumentTypeAPI
                {
                    Success = true,
                    Message = "Authenticate Success",
                    Data = listDocType
                });
            }
            else
                return Ok(new DocumentTypeAPI
                {
                    Success = false,
                    Message = "User Not allow to get data",
                    Data = null
                });
        }

        //Mail System
        [Authorize]
        [HttpGet("getMailSystem")]
        public IActionResult getMailSystem()
        {
            //kiem tra role
            var claims = _httpContextAccessor.HttpContext.User.Claims;
            string UserRole = claims.FirstOrDefault(c => c.Type == "RoleCode").ToString();
            UserRole = UserRole.Replace("RoleCode:", "");

            string UserArea = claims.FirstOrDefault(c => c.Type == "AreaName").ToString();
            UserArea = UserArea.Replace("AreaName:", "");

            if (UserRole.Trim() == "Admin" && UserArea.Trim() == "System")
            {
                MailSystem listDocType = _context.MailSystems.OrderByDescending(m=>m.Id).FirstOrDefault();
                return Ok(new MailSystemAPI
                {
                    Success = true,
                    Message = "Authenticate Success",
                    Data = listDocType
                });
            }
            else
                return Ok(new DocumentTypeAPI
                {
                    Success = false,
                    Message = "User Not allow to get data",
                    Data = null
                });
        }
        [Authorize]
        [HttpPost("InertMailSystem")]
        public IActionResult InertMailSystem(MailSystem maiSystemInserted)
        {
            //kiem tra role
            var claims = _httpContextAccessor.HttpContext.User.Claims;
            string UserRole = claims.FirstOrDefault(c => c.Type == "RoleCode").ToString();
            UserRole = UserRole.Replace("RoleCode:", "");

            string UserArea = claims.FirstOrDefault(c => c.Type == "AreaName").ToString();
            UserArea = UserArea.Replace("AreaName:", "");

            if (UserRole.Trim() == "Admin" && UserArea.Trim() == "System")
            {
                List<MailSystem> mailSystem = new List<MailSystem>();
                mailSystem = _context.MailSystems.ToList();
                if (mailSystem.Count()>0)
                {
                    return Ok(new MailSystemAPI
                    {
                        Success = false,
                        Message = "Mail already exists in the system. Make sure all emails are deleted before adding",
                        Data = null
                    });
                }
                _context.MailSystems.Add(maiSystemInserted);
                _context.SaveChanges();
                MailSystem mailSystemResult = _context.MailSystems.FirstOrDefault();
                return Ok(new MailSystemAPI
                {
                    Success = true,
                    Message = "Authenticate Success",
                    Data = mailSystemResult
                });
            }
            else
                return Ok(new MailSystemAPI
                {
                    Success = false,
                    Message = "User Not allow to get data",
                    Data = null
                });
        }
        [Authorize]
        [HttpPost("updateDocumentType")]
        public IActionResult updateMailSystem(MailSystem mailSystem)
        {
            //kiem tra role
            var claims = _httpContextAccessor.HttpContext.User.Claims;
            string UserRole = claims.FirstOrDefault(c => c.Type == "RoleCode").ToString();
            UserRole = UserRole.Replace("RoleCode:", "");

            string UserArea = claims.FirstOrDefault(c => c.Type == "AreaName").ToString();
            UserArea = UserArea.Replace("AreaName:", "");

            if (UserRole.Trim() == "Admin" && UserArea.Trim() == "System")
            {
                MailSystem mailSystemChecked = null;
                mailSystemChecked = _context.MailSystems.Where(d => d.Id.Equals(mailSystem.Id)).FirstOrDefault();
                if (mailSystemChecked == null)
                {
                    return Ok(new MailSystemAPI
                    {
                        Success = false,
                        Message = "Mail to be updated not exists",
                        Data = null
                    });
                }
                mailSystemChecked.MailName = mailSystem.MailName.Trim();
                mailSystemChecked.PassWord = mailSystem.PassWord.Trim();
                _context.SaveChanges();
                mailSystemChecked = _context.MailSystems.FirstOrDefault();
                return Ok(new MailSystemAPI
                {
                    Success = true,
                    Message = "Authenticate Success",
                    Data = mailSystemChecked
                });
            }
            else
                return Ok(new DocumentTypeAPI
                {
                    Success = false,
                    Message = "User Not allow to get data",
                    Data = null
                });
        }
        [Authorize]
        [HttpPost("deleteDocumentType")]
        public IActionResult deleteMailSystem(deleteModal deptModal)
        {
            //kiem tra role
            var claims = _httpContextAccessor.HttpContext.User.Claims;
            string UserRole = claims.FirstOrDefault(c => c.Type == "RoleCode").ToString();
            UserRole = UserRole.Replace("RoleCode:", "");

            string UserArea = claims.FirstOrDefault(c => c.Type == "AreaName").ToString();
            UserArea = UserArea.Replace("AreaName:", "");

            if (UserRole.Trim() == "Admin" && UserArea.Trim() == "System")
            {
                MailSystem mailSystemChecked = null;
                mailSystemChecked = _context.MailSystems.Where(d => d.Id == deptModal.depetedId).FirstOrDefault();
                if (mailSystemChecked == null)
                {
                    return Ok(new MailSystemAPI
                    {
                        Success = false,
                        Message = "Mail to be deleted not exists",
                        Data = null
                    });
                }
                _context.MailSystems.Remove(mailSystemChecked);
                _context.SaveChanges();
                mailSystemChecked = _context.MailSystems.FirstOrDefault();
                return Ok(new MailSystemAPI
                {
                    Success = true,
                    Message = "Authenticate Success",
                    Data = mailSystemChecked
                });
            }
            else
                return Ok(new MailSystemAPI
                {
                    Success = false,
                    Message = "User Not allow to get data",
                    Data = null
                });
        }


        //Management User
        [Authorize]
        [HttpGet("getListUser")]
        public IActionResult getListUser()
        {
            //kiem tra role
            var claims = _httpContextAccessor.HttpContext.User.Claims;
            string UserRole = claims.FirstOrDefault(c => c.Type == "RoleCode").ToString();
            UserRole = UserRole.Replace("RoleCode:", "");

            string UserArea = claims.FirstOrDefault(c => c.Type == "AreaName").ToString();
            UserArea = UserArea.Replace("AreaName:", "");

            if (UserRole.Trim() == "Admin" && UserArea.Trim() == "System")
            {
                List<User> listUser = _context.Users.OrderBy(d => d.DeptId).ToList();
                return Ok(new UserAPI
                {
                    Success = true,
                    Message = "Authenticate Success",
                    Data = listUser
                });
            }
            else
                return Ok(new UserAPI
                {
                    Success = false,
                    Message = "User Not allow to get data",
                    Data = null
                });
        }
        [Authorize]
        [HttpPost("updateUser")]
        public IActionResult updateUser(User userUpdated)
        {
            //kiem tra role
            var claims = _httpContextAccessor.HttpContext.User.Claims;
            string UserRole = claims.FirstOrDefault(c => c.Type == "RoleCode").ToString();
            UserRole = UserRole.Replace("RoleCode:", "");

            string UserArea = claims.FirstOrDefault(c => c.Type == "AreaName").ToString();
            UserArea = UserArea.Replace("AreaName:", "");

            if (UserRole.Trim() == "Admin" && UserArea.Trim() == "System")
            {
                User user = null;
                user = _context.Users.Where(d => d.Id.Equals(userUpdated.Id)).FirstOrDefault();
                if (user == null)
                {
                    return Ok(new UserAPI
                    {
                        Success = false,
                        Message = "User to be updated not exists",
                        Data = null
                    });
                }
                user.FullName = userUpdated.FullName.Trim();
                user.UserName = userUpdated.UserName.Trim();
                user.PassWord = userUpdated.PassWord.Trim();
                user.Email = userUpdated.Email.Trim();
                user.PhoneNumber = userUpdated.PhoneNumber.Trim();
                user.DeptId = userUpdated.DeptId;
                user.RolesId = userUpdated.RolesId;
                user.ListStation = userUpdated.ListStation.Trim();
                user.UserStatus = userUpdated.UserStatus;
                user.DOB = userUpdated.DOB;
                _context.SaveChanges();
                List<User> listUser = _context.Users.OrderBy(d => d.DeptId).ToList();
                return Ok(new UserAPI
                {
                    Success = true,
                    Message = "Authenticate Success",
                    Data = listUser
                });
            }
            else
                return Ok(new UserAPI
                {
                    Success = false,
                    Message = "User Not allow to get data",
                    Data = null
                });
        }
        [Authorize]
        [HttpPost("InsertUser")]
        public IActionResult InsertUser(User userinserted)
        {
            //kiem tra role
            var claims = _httpContextAccessor.HttpContext.User.Claims;
            string UserRole = claims.FirstOrDefault(c => c.Type == "RoleCode").ToString();
            UserRole = UserRole.Replace("RoleCode:", "");

            string UserArea = claims.FirstOrDefault(c => c.Type == "AreaName").ToString();
            UserArea = UserArea.Replace("AreaName:", "");

            if (UserRole.Trim() == "Admin" && UserArea.Trim() == "System")
            {
                User user = null;
                user = _context.Users.Where(d => d.UserName.Trim().Equals(userinserted.UserName.Trim()) || d.Email.Trim().Equals(userinserted.Email.Trim())).FirstOrDefault();
                if (user != null)
                {
                    return Ok(new UserAPI
                    {
                        Success = false,
                        Message = "UserName or Email of user information to be added already exists",
                        Data = null
                    });
                }
                _context.Users.Add(userinserted);
                _context.SaveChanges();
                List<User> listUser = _context.Users.OrderBy(d => d.DeptId).ToList();
                return Ok(new UserAPI
                {
                    Success = true,
                    Message = "Authenticate Success",
                    Data = listUser
                });
            }
            else
                return Ok(new UserAPI
                {
                    Success = false,
                    Message = "User Not allow to get data",
                    Data = null
                });
        }
        [Authorize]
        [HttpPost("deleteUser")]
        public IActionResult deleteUser(deleteModal deptModal)
        {
            //kiem tra role
            var claims = _httpContextAccessor.HttpContext.User.Claims;
            string UserRole = claims.FirstOrDefault(c => c.Type == "RoleCode").ToString();
            UserRole = UserRole.Replace("RoleCode:", "");

            string UserArea = claims.FirstOrDefault(c => c.Type == "AreaName").ToString();
            UserArea = UserArea.Replace("AreaName:", "");

            if (UserRole.Trim() == "Admin" && UserArea.Trim() == "System")
            {
                User user = null;
                user = _context.Users.Where(d => d.Id == deptModal.depetedId).FirstOrDefault();
                if (user == null)
                {
                    return Ok(new UserAPI
                    {
                        Success = false,
                        Message = "User information to be deleted not exists",
                        Data = null
                    });
                }
                _context.Users.Remove(user);
                _context.SaveChanges();
                List<User> listUser = _context.Users.OrderBy(d => d.DeptId).ToList();
                return Ok(new UserAPI
                {
                    Success = true,
                    Message = "Authenticate Success",
                    Data = listUser
                });
            }
            else
                return Ok(new UserAPI
                {
                    Success = false,
                    Message = "User Not allow to get data",
                    Data = null
                });
        }
    }
}
