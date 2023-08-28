using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using DAL.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CourseService
    {
        public static bool CreateCourse(CourseDTO courseDTO)
        {
            return DataAccessFactory.CourseDataAccess().Create(ConvertingClass<CourseDTO,Course>.Convert(courseDTO));
        }

        public static bool UpdateCourse(CourseDTO courseDTO)
        {
            return DataAccessFactory.CourseDataAccess().Update(ConvertingClass<CourseDTO, Course>.Convert(courseDTO));
        }

        public static bool DeleteCourse(CourseDTO courseDTO)
        {
            return DataAccessFactory.CourseDataAccess().Delete(courseDTO.CourseId);
        }

        public static List<CourseDTO> GetAll()
        {
            return ConvertingClass<Course, CourseDTO>.Convert(DataAccessFactory.CourseDataAccess().GetALL()).ToList();
        }

        public static bool AddCourseSection(List<CourseSectionDTO> courseSections)
        {
            foreach(var courseSection in courseSections)
            {
                if(!DataAccessFactory.CourseSectionDataAccess().Create(ConvertingClass<CourseSectionDTO, CourseSection>.Convert(courseSection)))
                {
                    return false;
                }
            }
            
            return true;
        }

        public static bool DeleteCourseSection(List<CourseSectionDTO> courseSections)
        {
            foreach(var courseSection in courseSections)
            {
                if (!DataAccessFactory.CourseSectionDataAccess().Delete(courseSection.CourseSectionId))
                {
                    return false;
                }
            }
            return true;
        }

        public static List<CourseSectionDTO> SectionByCourse(CourseDTO courseDTO)
        {
            return ConvertingClass<CourseSection, CourseSectionDTO>.Convert(DataAccessFactory.CourseSectionDataAccess().GetALL().Where(item=> item.CourseId == courseDTO.CourseId).ToList());
        }

        public static List<CourseSectionDTO> CourseSectionBySpace(CourseDTO courseDTO, int num)
        {
            return SectionByCourse(courseDTO).Where(item=>item.CourseSectionStudentLimit >= num).ToList();
        }

        public static int AvailableCourseSectionSpace(CourseSectionAndStudentDTO courseSectionAndStudentDTO)
        {
            var amount = DataAccessFactory.CourseSectionAndStudentDataAccess().GetALL().Where(item => item.CourseSectionId == courseSectionAndStudentDTO.CourseSectionId).Count();
            var course = (int)(DataAccessFactory.CourseSectionDataAccess().Get(courseSectionAndStudentDTO.CourseSectionId).CourseSectionStudentLimit);
            return course-amount;
        }
        public static bool CourseSectionAddStudents(List<CourseSectionAndStudentDTO> courseSectionAndStudent)
        {
            foreach(var courseSection in courseSectionAndStudent)
            {
                if (AvailableCourseSectionSpace(courseSection) <= 0) { return false; }
                if(!DataAccessFactory.CourseSectionAndStudentDataAccess().Create(ConvertingClass<CourseSectionAndStudentDTO, CourseSectionAndStudent>.Convert(courseSection)))
                {
                    return false;
                }
            }
            return true;
        }

        public static List<StudentDTO> StudentsInCourse(int id)
        {
            var data = DataAccessFactory.CourseSectionAndStudentDataAccess().GetALL().Where(item=>item.CourseSection.CourseId == id).ToList();
            
            List<StudentDTO> students = new List<StudentDTO>();
            
            foreach(var student in data)
            {
                students.Add(ConvertingClass<Student,StudentDTO>.Convert(student.Student));
            }
            return students;
        }

        public static List<CourseDTO> StudentInCourses(int id)
        {
            var data = DataAccessFactory.CourseSectionAndStudentDataAccess().GetALL().Where(item => item.StudentId == id);
            List<CourseDTO> courses = new List<CourseDTO>();
            foreach(var course in data)
            {
                courses.Add(ConvertingClass<Course, CourseDTO>.Convert(course.CourseSection.Course));
            }
            return courses;
        }

        public static List<CourseDTO> CourseByTagAndDifficuly(string tag,string difficulty)
        {
            return ConvertingClass<Course,CourseDTO>.Convert(DataAccessFactory.CourseDataAccess().GetALL().Where(item => item.Tag.Contains(tag) && item.Difficulty.Contains(difficulty)).ToList());
        }

        public static bool RemoveStudentFromCourse(List<StudentDTO> studentsDTO)
        {
            var students = ConvertingClass<StudentDTO, Student>.Convert(studentsDTO);
            foreach (var student in students)
            {
                if (!(DataAccessFactory.CourseSectionAndStudentDataAccess().Delete(student.StudentId)))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool AddCourseChapter(List<CourseChapterDTO> courseChapters)
        {
            foreach(var course in courseChapters)
            {
                if (!DataAccessFactory.CourseChapterDataAccess().Create(ConvertingClass<CourseChapterDTO,CourseChapter>.Convert(course)))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool AddCourseChapterAndStudent(List<CourseChapterAndStudentDTO> courseChapters)
        {
            foreach (var course in courseChapters)
            {
                if (!DataAccessFactory.CourseChapterAndStudentDataAccess().Create(ConvertingClass<CourseChapterAndStudentDTO, CourseChapterAndStudent>.Convert(course)))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool CourseStatusOfStudent(CourseDTO courseDTO, int id)
        {
            var data = DataAccessFactory.CourseChapterAndStudentDataAccess().GetALL().Where(item => item.CourseChapter.CourseId == courseDTO.CourseId && item.StudentId == id && item.CourseChapterStudentProgression == "Finished").Count();
            var comp = DataAccessFactory.CourseChapterDataAccess().GetALL().Where(item=>item.CourseId == courseDTO.CourseId).Count();
            return data == comp;
        }
    }
}
