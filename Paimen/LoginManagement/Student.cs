//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LoginManagement
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student
    {
        public int Student_Id { get; set; }
        public string Name { get; set; }
        public string FisrtName { get; set; }
        public string YearResult { get; set; }
        public Nullable<int> Section_Section_Id { get; set; }
    
        public virtual Section Section { get; set; }
    }
}
