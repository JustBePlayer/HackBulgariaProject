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
            //StudentModel student = InitializeComponents();
            return View();
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
            List<ClassModel> classes = new List<ClassModel>();
            classes.Add(new ClassModel 
            {
                Id = 3,
                Letter = "a",
                Number = 2,
                subjects = subjects.ToArray()
            });

            return new StudentModel
            {
                Id = 1,
                Address = "Sofia",
                Egn = "000000",
                Email = "momcheto14@abv.bg",
                FirstName = "Aleydin",
                LastName = "Karaimin",
                School = new SchoolModel
                {
                    Address = "Sofia",
                    Id = 2,
                    Name = "PMG",
                    Classes = classes.ToArray()
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

        private ClassModel GetUserClass(int schoolId)
        {
            using(var context = new SchoolEntityContainerContainer())
            {
                IEnumerable<ClassModel> models =
                    from u in context.Classes
                    where u.School.Id == schoolId
                    select new ClassModel
                    {
                        Id = u.Id,
                        Letter = u.Letter,
                        Number = u.Number,
                        subjects = GetUserSubjects(u.Id)
                    };
                    return models.FirstOrDefault();
            }
        }



        private StudentModel GetUser(int id)
        {
            using(var context = new SchoolEntityContainerContainer())
            {
                IEnumerable<StudentModel> students = 
                    from u in context.Users.OfType<Student>() 
                    where u.Id == id
                    select new StudentModel
                    {
                        Address = u.Address,
                        FirstName = u.FirstName,
                        Email = u.Email,
                        Egn = u.Egn,
                        Id = u.Id,
                        LastName = u.LastName,
                        School = GetUserSchool(u.Id)
                    };

                return students.FirstOrDefault();
            }
        }

        private SchoolModel GetUserSchool(int userId)
        {
            using (var context = new SchoolEntityContainerContainer())
            {
                IEnumerable<SchoolModel> schools =
                        from u in context.Users.OfType<Student>()
                        where u.School.Id == userId
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