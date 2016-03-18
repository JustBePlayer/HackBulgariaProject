using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolWeb.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Egn { get; set; }
        public string SchoolName { get; set; }

        public ClassModel Class { get; set; }

        public IEnumerable<StudentDatas> Datas { get; set; }
        //public IEnumerable<GradeModel> Grades { get; set; }
    }
}