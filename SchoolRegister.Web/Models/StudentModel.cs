using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolRegister.Web.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public SchoolModel School { get; set; }
        //public IEnumerable<GradeModel> Grades { get; set; }
    }
}