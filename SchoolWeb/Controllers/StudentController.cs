
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
        private static SchoolEntityContainerContainer context = new SchoolEntityContainerContainer();
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
        public ActionResult Subjects(EnterModel paramModel)
        {
            //StudentModel model = InitializeComponents();
            StudentModel model = GetUser(paramModel.SchoolName, paramModel.Egn, paramModel.ClassNumber, paramModel.ClassLetter);
            return View(model);
        }

        [HttpPost]
        public ActionResult Enter(EnterModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Subjects", model);
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
        /*
        private IEnumerable<GradeModel> GetUserGrades(int subjectId)
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
            
        }*/

        private IEnumerable<GradeModel> GetUserGrades(int subjectId)
        {

            IEnumerable<Grade> models =
                from u in context.Grades
                where u.Subject.Id == subjectId
                select u;

            //List<Grade> grades = models.ToList();
            List<GradeModel> model = new List<GradeModel>();
            foreach (var item in models)
            {
                model.Add(new GradeModel
                {
                    Id = item.Id,
                    Mark = item.Mark
                });
            }

            return model.ToArray();
        }


        private IEnumerable<SubjectModel> GetUserSubjects(int classId)
        {
            //List<StudentModel> model;

            IEnumerable<SubjectModel> models =
                from u in context.Subjects
                where u.Class.Id == classId
                select new SubjectModel
                {
                    Id = u.Id,
                    Description = u.Description,
                    //Grades = GetUserGrades(u.Id),
                };

            return models;

        }



        /*
        private StudentModel GetUser(string schoolName, string egn, int classNumber, string letter)
        {
            using (var context = new SchoolEntityContainerContainer())
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
        }*/

        private IEnumerable<int> GetUserMarks(int userId, int subjectId)
        {
            List<int> model = new List<int>();
            IEnumerable<Grade> marks = from u in context.Grades
                                       where u.Student.Id == userId && u.Subject.Id == subjectId
                                       select u;
            foreach (var item in marks)
            {
                model.Add(item.Mark);
            }
            return model.ToArray();
        }

        private IEnumerable<StudentDatas> GetUserDatas(int classId, int userId)
        {
            IEnumerable<Subject> subjects =
                from u in context.Subjects
                where u.Class.Id == classId
                select u;

            List<StudentDatas> datas = new List<StudentDatas>();
            foreach (var item in subjects)
            {
                datas.Add(new StudentDatas 
                {
                    SubjectName = item.Description,
                    Marks = GetUserMarks(userId, item.Id)
                });
            }
            return datas.ToArray();
        }


        private StudentModel GetUser(string schoolName, string egn, int classNumber, string letter)
        {
            IEnumerable<Student> students =
                from u in context.Users.OfType<Student>()
                where u.Class.School.Name == schoolName && u.Egn == egn &&
                    //u.School.Classes.Select(p => (p.Number == classNumber && p.Letter == letter)).Any()
                    u.Class.Number == classNumber && u.Class.Letter == letter
                select u;
            

            Student student = students.FirstOrDefault();
            StudentModel model = new StudentModel();
            model.Id = student.Id;
            model.Egn = student.Egn;
            model.Email = student.Email;
            model.FirstName = student.FirstName;
            model.LastName = student.LastName;
            model.Address = student.Address;

            model.SchoolName = student.Class.School.Name;

            model.Datas = GetUserDatas(student.Class.Id,student.Id);
            //ClassModel classModel = new ClassModel();
            //model.Class = classModel;
            //model.ClassName = model.Class.N
            // model.Class.Subjects = GetUserSubjects(model.Class.Id);
            List<int> marks = model.Datas.First().Marks.ToList();
            //bool l = model.Class.Subjects.Any();

            return model;
        }

        private StudentModel ExampleQuery(string egn)
        {
            IEnumerable<Student> st =
                from u in context.Users.OfType<Student>()
                where u.Egn == egn
                select u;
            Student student = st.FirstOrDefault();
            StudentModel model = new StudentModel();
            model.Address = student.Address;
            model.Egn = student.Egn;
            model.FirstName = student.FirstName;
            return model;
        }

        private SchoolModel GetUserSchool(int classId)
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
        #endregion
    }
}
