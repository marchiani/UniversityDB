using System;
using System.Collections.Generic;
using MemLand.Models.Account;

namespace MemLand.Models.FunnyImages
{
    public class Mem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }

        public bool PostMem { get; set; }

        public DateTime PostedOn { get; set; }
        public DateTime? Modified { get; set; }
        
        public Category Category { get; set; }
        public string CategoryName { get; set; }
        
        public int Like { get; set; }
        public string PathImg { get; set; }


        public int UserId { get; set; }
        public User User { get; set; }


        public IList<Tag> Tag { get; set; }

    }
}