//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchoolRegisterEntities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student : User
    {
        public Student()
        {
            this.Grades = new HashSet<Grades>();
        }
    
        public string Egn { get; set; }
        public string Class { get; set; }
    
        public virtual ICollection<Grades> Grades { get; set; }
    }
}
