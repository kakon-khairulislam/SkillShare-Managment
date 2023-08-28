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
    public class CourseController : ApiController
    {
        [HttpGet]
        [Route("api/Course/GetCourse/{id}")]
        public HttpResponseMessage GetCourse(int id)
        {
            try
            {
                var data = CourseService.GetCourse(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/Course/GetALLCourse")]
        public HttpResponseMessage GetALLCourse()
        {
            try
            {
                var data = CourseService.GetAllCourse();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPost]
        [Route("api/Course/CreateCourse")]
        public HttpResponseMessage CreateCourse(CourseDTO cor)
        {
            try
            {
                var data = CourseService.CreateCourse(cor);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPut]
        [Route("api/Course/UpdateCourse")]
        public HttpResponseMessage UpdateCourse(CourseDTO cor)
        {
            try
            {
                var data = CourseService.UpdateCourse(cor);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpDelete]
        [Route("api/Course/DeleteCourse/{id}")]
        public HttpResponseMessage DeleteCourse(int id)
        {
            try
            {
                var data = CourseService.DeleteCourse(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        //Feature API

        [HttpGet]
        [Route("api/Course/GetCourseByInsId/{id}")]
        public HttpResponseMessage GetCourseByInsId(int id)
        {
            try
            {
                var data = CourseService.GetALLCourseByInstructor(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
