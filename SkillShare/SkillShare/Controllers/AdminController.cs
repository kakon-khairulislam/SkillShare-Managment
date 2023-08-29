using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SkillShare.Controllers
{
    public class AdminController : ApiController
    {
        [HttpPost]
        [Route("api/Admin/CreateAdmin")]
        public HttpResponseMessage CreateAdmin(AdminDTO ad)
        {
            try
            {
                var data = AdminService.CreateAdmin(ad);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/Admin/GetAdmin/{id}")]
        public HttpResponseMessage GetAdmin(int id)
        {
            try
            {
                var data = AdminService.GetAdmin(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/Admin/GetAllAdmin")]
        public HttpResponseMessage GetAllAdmin()
        {
            try
            {
                var data = AdminService.GetAllAdmin();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPut]
        [Route("api/Admin/UpdateAdmin")]
        public HttpResponseMessage UpdateAdmin(AdminDTO ad)
        {
            try
            {
                var data = AdminService.UpdateAdmin(ad);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpDelete]
        [Route("api/Admin/DeleteAdmin/{id}")]
        public HttpResponseMessage DeleteAdmin(int id)
        {
            try
            {
                var data = AdminService.DeleteAdmin(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
       
       
        
    }
}
