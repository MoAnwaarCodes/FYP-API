//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LernSpace.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PersonTestCollection
    {
        public int test_collection_person { get; set; }
        public Nullable<int> personId { get; set; }
        public Nullable<int> personTestId { get; set; }
        public Nullable<int> op1 { get; set; }
        public Nullable<int> op2 { get; set; }
        public Nullable<int> op3 { get; set; }
    
        public virtual person person { get; set; }
        public virtual person person1 { get; set; }
        public virtual person person2 { get; set; }
        public virtual person person3 { get; set; }
        public virtual PersonTest PersonTest { get; set; }
    }
}
