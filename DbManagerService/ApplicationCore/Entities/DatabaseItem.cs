using ApplicationCore.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class DatabaseItem : BaseEntity
    {
        public string ConnectionString { get; set; }
        public DatabaseStatusEnum Status { get; set; }

        public ICollection<EntityRecord> ContainedRanges { get; set; }
    }
}
