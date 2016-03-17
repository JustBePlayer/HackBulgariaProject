using SchoolEntities;
using SchoolRegister.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq;

namespace SchoolRegister.Web.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        #region Database Quaries

        private IEnumerable<GradeModel> GetUserGrades (int subjectId)
        {
            using (var context = new SchoolEntityContainerContainer()) 
            {
                IEnumerable<GradeModel> models =
                    from u in context.Grades
                    where u.Subject.Id == subjectId
                    select new GradeModel
                    {
                        Id = u.Id,
                        Mark = u.Mark
                    };

                return models;
            }
        }

        private IEnumerable<SubjectModel> GetUserSubjects(ClassModel classParam)
        {
            using (var context = new SchoolEntityContainerContainer())
            {
                IEnumerable<SubjectModel> models =
                    from u in context.Subjects
                    where u.Class.Id == classParam.Id
                    select new SubjectModel
                    {
                        Id = u.Id,
                        Description = u.Description,
                        Grades = GetUserGrades(u.Id),
                    };

                return models;
            }
        }

        private ClassModel GetUserClass(SchoolModel school)
        {
            using(var context = new SchoolEntityContainerContainer())
            {
                IEnumerable<ClassModel> models =
                    from u in context.Classes
                    where u.School.Id == school.Id
                    select new ClassModel
                    {
                        Id = u.Id,
                        Letter = u.Letter,
                        Number = u.Number,
                    };
            }
        }

        #endregion
    }
}   