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
        [HttpPost]
        [Route("api/Course/Create")]
        public HttpResponseMessage CreateCourse(CourseDTO courseDTO)
        {
            try
            {
                if (CourseService.CreateCourse(courseDTO))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new {Msg = "Course Created"});
                }
                return Request.CreateResponse(HttpStatusCode.NotFound , new { Msg = "Course Not Created" });
            }
            catch (Exception ex) { return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message); }
        }

        [HttpGet]
        [Route("api/Course/GetAll")]
        public HttpResponseMessage GetAllCourse()
        {
            try
            {
                var data = CourseService.GetAll().ToList();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }catch(Exception ex) { return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message); }
        }

        [HttpPost]
        [Route("api/Course/Update")]
        public HttpResponseMessage UpdateCourse(CourseDTO courseDTO)
        {
            try
            {
                if (CourseService.UpdateCourse(courseDTO))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Course Modified" });
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Unable to Modified" });
            }catch( Exception ex) { return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message); } 
        }

        [HttpPost]
        [Route("api/Course/Delete")]
        public HttpResponseMessage DeleteCourse(CourseDTO courseDTO)
        {
            try
            {
                if (CourseService.DeleteCourse(courseDTO))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Course Disabledled" });
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Unsuccessfull" });
            }catch(Exception ex) { return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message); }
        }

        [HttpGet]
        [Route("api/Course/EnabledCourse")]
        public HttpResponseMessage GetEnabledCourse()
        {
            try
            {
                var data = CourseService.GetAll().Where(item => item.CourseStauts == "Enable");
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }catch(Exception e) { return Request.CreateResponse(HttpStatusCode.BadRequest, new { Msg = "Bad Requesrt" }); }
        }

        [HttpPost]
        [Route("api/CourseSection/AddSection")]
        public HttpResponseMessage CreateCourseSection(List<CourseSectionDTO> courseSectionDTO)
        {
            try
            {
                if (CourseService.AddCourseSection(courseSectionDTO))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Course Section added" });
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Some section not added" });
            }catch(Exception ex) { return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message); }
        }

        [HttpPost]
        [Route("api/CourseSection/DeleteSection")]
        public HttpResponseMessage DeleteCourseSection(List<CourseSectionDTO> courseSectionDTO)
        {
            try
            {
                if (CourseService.DeleteCourseSection(courseSectionDTO))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { MSS = "good" });
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, new { MSS = "not good" });
            }catch(Exception ex) { return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message); }  
        }

        [HttpPost]
        [Route("api/CourseSection/SectionByCourse")]
        public HttpResponseMessage SectionByCourse(CourseDTO courseDTO)
        {
            try
            {
                var data = CourseService.SectionByCourse(courseDTO);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch(Exception ex) { return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message); }
        }

        [HttpPost]
        [Route("api/CourseSection/SectionSpaceByCourse/{num}")]
        public HttpResponseMessage SectionSpaceByCourse(CourseDTO courseDTO, int num)
        {
            try
            {
                var data = CourseService.CourseSectionBySpace(courseDTO, num);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex) { return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message); }
        }

        [HttpPost]
        [Route("api/CourseSection/AddStudents")]
        public HttpResponseMessage AddStudentsAtSection(List<CourseSectionAndStudentDTO> courseSectionAndStudent)
        {
            try
            {
                if (CourseService.CourseSectionAddStudents(courseSectionAndStudent))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { MSG = "Students Registered" });
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, new { MSG = "Some Students are not Registered" });
            }catch(Exception ex) { return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message); }
        }

        [HttpPost]
        [Route("api/Course/StudentsInCourse/{id}")]
        public HttpResponseMessage StudentsInCourse(int id)
        {
            try
            {
                var data = CourseService.StudentsInCourse(id);
                return Request.CreateResponse(HttpStatusCode.OK,data);
            }catch(Exception ex) { return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message); }
        }

        [HttpPost]
        [Route("api/Course/StudentInCourses")]
        public HttpResponseMessage StudentInCourses(int id)
        {
            try
            {
                var data = CourseService.StudentInCourses(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }catch(Exception ex) { return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message); }
        }

        [HttpPost]
        [Route("api/Course/MentionTag/{tag}/MentionDifficulty/{diff}")]
        public HttpResponseMessage SearchCourseByTagAndDificulty(string tag, string diff)
        {
            try
            {
                var data = CourseService.CourseByTagAndDifficuly(tag, diff);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception e) { return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message); }
        }
    }
}
