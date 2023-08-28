using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Sql;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SkillShare.Controllers
{
    [EnableCors("*", "*", "*")]
    public class StudentController : ApiController
    {
        [HttpPost]
        [Route("api/Student/Create")]
        public HttpResponseMessage CreateStudent(StudentDTO studentDTO)
        {
            try
            {
                if (StudentService.CreateStudent(studentDTO))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Created" });
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Not Created" });
            }
            catch(Exception ex) { return Request.CreateResponse(HttpStatusCode.BadRequest, ex); }
        }
        [HttpGet]
        [Route("api/Student/AllStudents")]
        public HttpResponseMessage GetAllStudents()
        {
            try
            {
                var data = StudentService.GetAllStudents().ToList();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch(Exception ex ) { return Request.CreateResponse(HttpStatusCode.BadRequest, ex); }
        }
        [HttpPost]
        [Route("api/Student/EditStudent")]
        public HttpResponseMessage ModifyStudent(StudentDTO studentDTO)
        {
            try
            {
                if(StudentService.ModifyStudent(studentDTO))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Modified" });
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Not Modified" });
            }
            catch(Exception ex ) { return Request.CreateResponse(HttpStatusCode.BadRequest, ex); }
        }
        [HttpPost]
        [Route("api/Student/DeleteStudent")]
        public HttpResponseMessage DeleteStudent(StudentDTO studentDTO)
        {
            try
            {
                if (StudentService.DeleteStudent(studentDTO))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Student Deleted" });
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Not Deleted" });
            }
            catch (Exception ex) { return Request.CreateResponse(HttpStatusCode.BadRequest, ex); }
        }
        [HttpGet]
        [Route("api/Student/EnabledStudent")]
        public HttpResponseMessage GetEnableStudents()
        {
            try
            {
                var data = StudentService.GetEnableStudents().ToList();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex) { return Request.CreateResponse(HttpStatusCode.BadRequest, ex); }
        }


        [HttpPost]
        [Route("api/login")]
        public HttpResponseMessage Login(BLL.LoginModel login)
        {
            try
            {
                var token = AuthService.Login(login.Username, login.Password);
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
    }
}
