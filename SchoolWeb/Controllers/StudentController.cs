
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using SchoolWeb.Models;
using SchoolEntities;

namespace SchoolWeb.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            StudentModel student = InitializeComponents();
            return View();
        }

        
        [HttpGet]
        public ActionResult Enter()
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult Subjects()
        {
            StudentModel model = InitializeComponents();
            return View(model);
        }

        [HttpPost]
        public ActionResult Enter(EnterModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Subjects");
            }
            else
                return View(model);
            
        }

        private StudentModel InitializeComponents()
        {

            List<GradeModel> grades = new List<GradeModel>();
            grades.Add(new GradeModel 
            {
                Mark = 6,
                Id = 12
            });

            List<SubjectModel> subjects = new List<SubjectModel>();
            subjects.Add(new SubjectModel
            {
                Description = "Math",
                Id = 5,
                Grades = grades.ToArray()
            });
         
            return new StudentModel
            {
                Id = 1,
                Address = "Sofia",
                Egn = "000000",
                Email = "momcheto14@abv.bg",
                FirstName = "Aleydin",
                LastName = "Karaimin",
                Class = new ClassModel
                {
                    Id = 6,
                    Number = 4,
                    Letter = "b",
                    School = new SchoolModel
                    {
                        Address = "Sofia",
                        Id = 5,
                        Name = "PMG"
                    },
                    Subjects = subjects.ToArray()
                }
            };
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

        private IEnumerable<SubjectModel> GetUserSubjects(int classId)
        {
            using (var context = new SchoolEntityContainerContainer())
            {
                IEnumerable<SubjectModel> models =
                    from u in context.Subjects
                    where u.Class.Id == classId
                    select new SubjectModel
                    {
                        Id = u.Id,
                        Description = u.Description,
                        Grades = GetUserGrades(u.Id),
                    };

                return models;
            }
        }

        
        private StudentModel GetUser(string schoolName, string egn, int classNumber, string letter)
        {
            using(var context = new SchoolEntityContainerContainer())
            {
                IEnumerable<StudentModel> students = 
                    from u in context.Users.OfType<Student>() 
                    where u.Class.School.Name == schoolName && u.Egn == egn && 
                        //u.School.Classes.Select(p => (p.Number == classNumber && p.Letter == letter)).Any()
                        u.Class.Number == classNumber && u.Class.Letter == letter
                    select new StudentModel
                    {
                        Address = u.Address,
                        FirstName = u.FirstName,
                        Email = u.Email,
                        Egn = u.Egn,
                        Id = u.Id,
                        LastName = u.LastName,
                        Class = new ClassModel
                        {
                            Id = u.Class.Id,
                            Letter = u.Class.Letter,
                            Number = u.Class.Number,
                            Subjects = GetUserSubjects(u.Class.Id),
                            School = GetUserSchool(u.Class.Id)
                        }
                    };

                return students.FirstOrDefault();
            }
        }

        private SchoolModel GetUserSchool(int classId)
        {
            using (var context = new SchoolEntityContainerContainer())
            {
                IEnumerable<SchoolModel> schools =
                        from u in context.Classes
                        where u.School.Id == classId
                        select new SchoolModel
                        {
                            Address = u.School.Address,
                            Name = u.School.Name,
                            Id = u.Id
                        };

                return schools.FirstOrDefault();
            }
        }
        #endregion
    }
}   