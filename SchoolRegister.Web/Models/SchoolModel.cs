using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolRegister.Web.Models
{
    public class SchoolModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public IEnumerable<ClassModel> Classes { get; set; }
    }
}