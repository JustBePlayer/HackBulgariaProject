using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolWeb.Models
{
    public class ClassModel
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Letter { get; set; }
        public SchoolModel School { get; set; }
        public IEnumerable<SubjectModel> Subjects { get; set; }
    }
}