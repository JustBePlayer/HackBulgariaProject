using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolWeb.Models
{
    public class StudentDatas
    {
        public string SubjectName { get; set; }
        public IEnumerable<int> Marks { get; set; }

        public string MarksToString()
        {
            string result = "";
            foreach (int item in Marks)
            {
                result += string.Format(" {0}", item);
            }
            return result;
        }
    }
}