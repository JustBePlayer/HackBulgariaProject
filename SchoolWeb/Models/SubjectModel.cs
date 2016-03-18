using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolWeb.Models
{
    public class SubjectModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Description { get; set; }

        public IEnumerable<GradeModel> Grades { get; set; }

        public string TeacherName { get; set; }

        public string GradesToString()
        {
            string result = "";
            foreach (GradeModel  item in Grades)
            {
                result += string.Format(" {0}", item.Mark);
            }
            return result;
        }
    }
}