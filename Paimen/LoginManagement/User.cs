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
    
    public partial class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public Nullable<int> Year { get; set; }
        public string Type { get; set; }
        public Nullable<int> RegNumber { get; set; }
        public Nullable<int> Section { get; set; }
        public int Profile { get; set; }
    
        public virtual Profile Profile1 { get; set; }
        public virtual Section Section1 { get; set; }
    }
}