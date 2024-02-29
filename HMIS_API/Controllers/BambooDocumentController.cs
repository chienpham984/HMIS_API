using HMIS_API.Repository.Models;
using HMIS_API.Repository.QH;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HMIS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BambooDocumentController : ControllerBase
    {
        private readonly HMIS_BKKContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BambooDocumentController(IHttpContextAccessor httpContextAccessor)
        {
            _context = new HMIS_BKKContext();
            _httpContextAccessor = httpContextAccessor;
        }

        [Authorize]
        [HttpGet("getListDocumentByFlight")]
        public IActionResult getListDocumentByFlight(deleteModal deptModal)
        {
            //kiem tra role
            var claims = _httpContextAccessor.HttpContext.User.Claims;
            string UserRole = claims.FirstOrDefault(c => c.Type == "RoleCode").ToString();
            UserRole = UserRole.Replace("RoleCode:", "");

            string UserArea = claims.FirstOrDefault(c => c.Type == "AreaName").ToString();
            UserArea = UserArea.Replace("AreaName:", "");
            string UserIdString = claims.FirstOrDefault(c => c.Type == "ID").ToString();
            UserArea = UserArea.Replace("ID:", "");
            int id = 0;
            try
            {
                id = Int32.Parse(UserIdString.Trim());
            }
            catch {
                return Ok(new DepartmenAPI
                {
                    Success = false,
                    Message = "User information does not exist",
                    Data = null
                });
            }

            if (UserArea.Trim() == "Document")
            {
                List<ListDocument> listDoc = _context.ListDocuments.FromSqlRaw($"EXEC SPGetDocumentBamboo {id.ToString()},{deptModal.depetedId.ToString()}").ToList();
                
                return Ok(new ListDocumentAPI
                {
                    Success = true,
                    Message = "Authenticate Success",
                    Data = listDoc
                });
            }
            else
                return Ok(new ListDocumentAPI
                {
                    Success = false,
                    Message = "User Not allow to get data",
                    Data = null
                });
        }
        
        //documenttype by user
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
            string UserIdString = claims.FirstOrDefault(c => c.Type == "ID").ToString();
            UserArea = UserArea.Replace("ID:", "");
            int id = 0;
            try
            {
                id = Int32.Parse(UserIdString.Trim());
            }
            catch
            {
                return Ok(new DepartmenAPI
                {
                    Success = false,
                    Message = "User information does not exist",
                    Data = null
                });
            }

            if (UserArea.Trim() == "Document")
            {
                List<DocumentType> listDocType = _context.DocumentTypes.FromSqlRaw($"EXEC SPGetListDocumentTypeBamboo {id.ToString()}").ToList();

                return Ok(new DocumentTypeAPI
                {
                    Success = true,
                    Message = "Authenticate Success",
                    Data = listDocType
                });
            }
            else
                return Ok(new ListDocumentAPI
                {
                    Success = false,
                    Message = "User Not allow to get data",
                    Data = null
                });
        }


        //document by user
        [Authorize]
        [HttpPost("InsertDocument")]
        public IActionResult InsertDocument(Document doc)
        {
            //kiem tra role
            var claims = _httpContextAccessor.HttpContext.User.Claims;
            string UserRole = claims.FirstOrDefault(c => c.Type == "RoleCode").ToString();
            UserRole = UserRole.Replace("RoleCode:", "");

            string UserArea = claims.FirstOrDefault(c => c.Type == "AreaName").ToString();
            UserArea = UserArea.Replace("AreaName:", "");
            string UserIdString = claims.FirstOrDefault(c => c.Type == "ID").ToString();
            UserArea = UserArea.Replace("ID:", "");
            int id = 0;
            try
            {
                id = Int32.Parse(UserIdString.Trim());
            }
            catch
            {
                return Ok(new DepartmenAPI
                {
                    Success = false,
                    Message = "User information does not exist",
                    Data = null
                });
            }
            UserFunction userFunction = _context.UserFunctions.Where(f => f.UserId == id).FirstOrDefault();
            string listInsert = userFunction == null ? "" : userFunction.ListInsert == null ? "" : userFunction.ListInsert.Trim();

            if (UserArea.Trim() == "Document" && listInsert.Contains("Document"))
            {
                doc.DateModified = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                _context.Documents.Add(doc);
                _context.SaveChanges();
                List<ListDocument> listDoc = _context.ListDocuments.FromSqlRaw($"EXEC SPGetDocumentBamboo {id.ToString()},{doc.FlightID.ToString()}").ToList();
                return Ok(new ListDocumentAPI
                {
                    Success = true,
                    Message = "Authenticate Success",
                    Data = listDoc
                });
               
            }
            else
                return Ok(new ListDocumentAPI
                {
                    Success = false,
                    Message = "User Not allow to get data",
                    Data = null
                });
        }
        [Authorize]
        [HttpPost("UpdateDocument")]
        public IActionResult UpdateDocument(Document doc)
        {
            //kiem tra role
            var claims = _httpContextAccessor.HttpContext.User.Claims;
            string UserRole = claims.FirstOrDefault(c => c.Type == "RoleCode").ToString();
            UserRole = UserRole.Replace("RoleCode:", "");

            string UserArea = claims.FirstOrDefault(c => c.Type == "AreaName").ToString();
            UserArea = UserArea.Replace("AreaName:", "");
            string UserIdString = claims.FirstOrDefault(c => c.Type == "ID").ToString();
            UserArea = UserArea.Replace("ID:", "");
            int id = 0;
            try
            {
                id = Int32.Parse(UserIdString.Trim());
            }
            catch
            {
                return Ok(new DepartmenAPI
                {
                    Success = false,
                    Message = "User information does not exist",
                    Data = null
                });
            }
            UserFunction userFunction = _context.UserFunctions.Where(f => f.UserId == id).FirstOrDefault();
            string listView = userFunction == null ? "" : userFunction.ListUpdate == null ? "" : userFunction.ListUpdate.Trim();

            if (UserArea.Trim() == "Document" && listView.Contains("Document"))
            {
                //kiem tra ton tai
                Document curDoc = _context.Documents.Where(d => d.DocumentId == doc.DocumentId && d.UserId == id).FirstOrDefault();
                if (curDoc == null)
                {
                    return Ok(new ListDocumentAPI
                    {
                        Success = false,
                        Message = "Document to be updated not exist or You are not the creator of the selected file",
                        Data = null
                    });
                }
                curDoc.DocumentName = doc.DocumentName.Trim();
                curDoc.DocumentTypeId = doc.DocumentTypeId;
                curDoc.DocumentSize = doc.DocumentSize;
                curDoc.FullPath = doc.FullPath.Trim();
                curDoc.DateModified = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                _context.SaveChanges();
                List<ListDocument> listDoc = _context.ListDocuments.FromSqlRaw($"EXEC SPGetDocumentBamboo {id.ToString()},{doc.FlightID.ToString()}").ToList();
                return Ok(new ListDocumentAPI
                {
                    Success = true,
                    Message = "Authenticate Success",
                    Data = listDoc
                });

            }
            else
                return Ok(new ListDocumentAPI
                {
                    Success = false,
                    Message = "User Not allow to get data",
                    Data = null
                });
        }

        [Authorize]
        [HttpPost("DeleteDocument")]
        public IActionResult DeleteDocument(Document doc)
        {
            //kiem tra role
            var claims = _httpContextAccessor.HttpContext.User.Claims;
            string UserRole = claims.FirstOrDefault(c => c.Type == "RoleCode").ToString();
            UserRole = UserRole.Replace("RoleCode:", "");

            string UserArea = claims.FirstOrDefault(c => c.Type == "AreaName").ToString();
            UserArea = UserArea.Replace("AreaName:", "");
            string UserIdString = claims.FirstOrDefault(c => c.Type == "ID").ToString();
            UserArea = UserArea.Replace("ID:", "");
            int id = 0;
            try
            {
                id = Int32.Parse(UserIdString.Trim());
            }
            catch
            {
                return Ok(new DepartmenAPI
                {
                    Success = false,
                    Message = "User information does not exist",
                    Data = null
                });
            }
            UserFunction userFunction = _context.UserFunctions.Where(f => f.UserId == id).FirstOrDefault();
            string listUpdate = userFunction == null ? "" : userFunction.ListUpdate == null ? "" : userFunction.ListUpdate.Trim();

            if (UserArea.Trim() == "Document" && listUpdate.Contains("Document"))
            {
                //kiem tra ton tai
                Document curDoc = _context.Documents.Where(d => d.DocumentId == doc.DocumentId && d.UserId == id).FirstOrDefault();
                if (curDoc == null)
                {
                    return Ok(new ListDocumentAPI
                    {
                        Success = false,
                        Message = "Document to be updated not exist or You are not the creator of the selected file",
                        Data = null
                    });
                }
                _context.Remove(curDoc);
                _context.SaveChanges();
                List<ListDocument> listDoc = _context.ListDocuments.FromSqlRaw($"EXEC SPGetDocumentBamboo {id.ToString()},{doc.FlightID.ToString()}").ToList();
                return Ok(new ListDocumentAPI
                {
                    Success = true,
                    Message = "Authenticate Success",
                    Data = listDoc
                });

            }
            else
                return Ok(new ListDocumentAPI
                {
                    Success = false,
                    Message = "User Not allow to get data",
                    Data = null
                });
        }


    }
}
