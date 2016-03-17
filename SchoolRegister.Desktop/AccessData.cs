using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolEntities;

namespace SchoolRegister.Desktop
{
    static class AccessData
    {
        static SchoolEntityContainerContainer context = new SchoolEntityContainerContainer();

        public static SchoolEntityContainerContainer Context { get { return context; } }
        public static int Teacherid { get; set; }

        public static void SaveChanges()
        {
            context.SaveChanges();
        }

        public static void AddGrade()
        {
            context.Grades.Create();
        }

        public static List<Subject> GetAllSubjectsForTheTeacher()
        {
            return context.Subjects.Where(x => x.Class.Teacher.Id == Teacherid).ToList();
        }

        //public static List<Class> GetAllClassesForTheTeacher()
        //{
        //    return context.Classes.Where(x => x. == Teacherid).ToList();
        //}
    }
}
