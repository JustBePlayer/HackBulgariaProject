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
    
    public partial class Grades
    {
        public int Id { get; set; }
        public int Mark { get; set; }
        public int SubjectId { get; set; }
        public int TeacherId { get; set; }
        public int TeacherId1 { get; set; }
    
        public virtual Subject Subject { get; set; }
        public virtual Student Student { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}