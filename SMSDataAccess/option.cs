//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SMSDataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class option
    {
        public int oid { get; set; }
        public string title { get; set; }
        public Nullable<int> qid { get; set; }
    
        public virtual question question { get; set; }
    }
}