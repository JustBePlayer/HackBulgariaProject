using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolRegister.Web.Models
{
    public class ClassModel
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Letter { get; set; }
        public IEnumerable<SubjectModel> subjects { get; set; }
    }
}