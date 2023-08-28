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
    public class StudentGroupController : ApiController
    {
        [HttpPost]
        [Route("api/StudentGroup/Create")]
        public HttpResponseMessage CreateStudentGroup(StudentGroupDTO studentGroupDTO)
        {
            try
            {
                if (StudentGroupService.CreateStudentGroup(studentGroupDTO))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Created" });
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Not Created" });
            }
            catch (Exception ex) { return Request.CreateResponse(HttpStatusCode.BadRequest, ex); }
        }

        [HttpPost]
        [Route("api/StudentGroup/AddingStudents")]
        public HttpResponseMessage AddStudents(List<StudentAndStudentGroupDTO> studentAndStudentGroupDTO)
        {
            try
            {
                if (StudentAndStudentGroupService.CreateStudentAndStudentGroupList(studentAndStudentGroupDTO))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Students Added" });
                }
                else { return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Student not added Or the student is already added to the group or student limit is reached" }); }
            }
            catch (Exception ex) { return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message); } 
        }

        [HttpPost]
        [Route("api/StudentGroup/DeleteStudents")]
        public HttpResponseMessage DeleteStudents(List<StudentAndStudentGroupDTO> studentAndStudentGroupDTOs)
        {
            try
            {
                if (StudentAndStudentGroupService.DeleteStudentAndStudentGroup(studentAndStudentGroupDTOs))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Students Deleted from Group" });
                }
                else { return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Some Students selected does not exist in data base" }); }
            }catch(Exception ex) { return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message); }
        }

        [HttpGet]
        [Route("api/StudentGroup/AllStudentGroups")]
        public HttpResponseMessage GetAllStudentGroups()
        {
            try
            {
                var data = StudentGroupService.GetAllStudentGroups().ToList();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex) { return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message); }
        }

        [HttpPost]
        [Route("api/StudentGroup/StudentsOfGroup/{id}")]
        public HttpResponseMessage StudentListOfGroup(int id)
        {
            try
            {
                var data = StudentGroupService.StudentsOfGroupById(id).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }catch(Exception ex) { return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message); }
        }

        [HttpPost]
        [Route("api/StudentGroup/EditStudentGroup")]
        public HttpResponseMessage ModifyStudentGroup(StudentGroupDTO studentGroupDTO)
        {
            try
            {
                if (StudentGroupService.ModifyStudentGroup(studentGroupDTO))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Modified" });
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Not Modified" });
            }
            catch (Exception ex) { return Request.CreateResponse(HttpStatusCode.BadRequest, ex); }
        }

        [HttpPost]
        [Route("api/StudentGroup/DeleteStudentGroup")]
        public HttpResponseMessage DeleteStudentGroup(StudentGroupDTO studentGroupDTO)
        {
            try
            {
                if (StudentGroupService.DeleteStudentGroup(studentGroupDTO))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Student Group Deleted" });
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Not Deleted" });
            }
            catch (Exception ex) { return Request.CreateResponse(HttpStatusCode.BadRequest, ex); }
        }

        [HttpGet]
        [Route("api/StudentGroup/EnabledStudentGroups")]
        public HttpResponseMessage GetEnableStudentGroups()
        {
            try
            {
                var data = StudentGroupService.GetEnableStudentGroups().ToList();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex) { return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message); }
        }

        [HttpPost]
        [Route("api/StudentGroup/AllStudentsPresenceInGroup/{id}")]
        public HttpResponseMessage AllStudentsPresenceInGroup(int id)
        {
            try
            {
                var reply = StudentGroupService.AllStudentsPresence(id);
                return Request.CreateResponse(HttpStatusCode.OK, reply);
            }catch(Exception ex) { return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message); }
        }

        [HttpPost]
        [Route("api/StudentGroup/FindStudentGroupByName/{name}")]
        public HttpResponseMessage FindStudentGroupByName(string name)
        {
            try
            {
                var data = StudentGroupService.GetStudentGroupsByName(name);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }catch(Exception e) { return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message); }
        }
    }
}
