using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolRegister.Web.Models
{
    public class SubjectModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Description { get; set; }

        public IEnumerable<GradeModel> Grades { get; set; }
    }
}