//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace sendeoxu.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Review
    {
        public int id { get; set; }
        public Nullable<int> like_count { get; set; }
        public Nullable<int> dislike_count { get; set; }
        public int user_id { get; set; }
        public int topic_id { get; set; }
    
        public virtual Source Source { get; set; }
        public virtual User User { get; set; }
    }
}