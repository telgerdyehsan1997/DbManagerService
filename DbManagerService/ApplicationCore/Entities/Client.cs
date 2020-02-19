using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class Client : BaseEntity
    {
        public string Username { get; set; }
        public string HashedPassword { get; set; }
        public DateTime RegisterationDate { get; set; }

        public ICollection<EntityRecord> AccessedRanges { get; set; }
    }
}
