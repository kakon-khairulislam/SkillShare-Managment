using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.ApplicationServices;
using System.Web.Http;

namespace SkillShare.Controllers
{
    public class InstructorController : ApiController
    {
        [HttpPost]
        [Route("api/Instructor/CreateIns")]
        public HttpResponseMessage CreateIns(InstructorDTO ins)
        {
            try
            {
                var data= InstructorService.CreateIns(ins);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/Instructor/GetIns/{id}")]
        public HttpResponseMessage GetIns(int id)
        {
            try
            {
                var data = InstructorService.GetIns(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/Instructor/GetALLIns")]
        public HttpResponseMessage GetALLIns()
        {
            try
            {
                var data = InstructorService.GetALLIns();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPut]
        [Route("api/Instructor/UpdateIns")]
        public HttpResponseMessage UpdateIns(InstructorDTO ins)
        {
            try
            {
                var data = InstructorService.UpdateIns(ins);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpDelete]
        [Route("api/Instructor/DeleteIns/{id}")]
        public HttpResponseMessage DeleteIns(int id)
        {
            try
            {
                var data = InstructorService.DeleteIns(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        //Feature API

        [HttpGet]
        [Route("api/Instructor/GetInsByCourse/{id}")]
        public HttpResponseMessage GetInsByCourse(int id)
        {
            try
            {
                var data = InstructorService.GetALLInsByCourse(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/Instructor/GetStudentbyIns/{id}")]
        public HttpResponseMessage GetStudentbyIns(int id)
        {
            try
            {
                var data = InstructorService.GetNumberOfSudentInCourse(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/Instructor/login")]
        public HttpResponseMessage login(BLL.LoginModel lm)
        {
            try
            {
                var token = AuthService.Login(lm.Username, lm.Password);
                if (token != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, token);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Username or password invalid" });
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }
        [HttpGet]
        [Route("api/Instructor/GetCourseFeedback/{id}")]
        public HttpResponseMessage GetCourseFeedback(int id)
        {
            try
            {
                var data = InstructorService.GetCourseFeedback(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }

    }
}
