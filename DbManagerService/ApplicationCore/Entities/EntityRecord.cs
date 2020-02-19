using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class EntityRecord : BaseEntity
    {
        public EntityRecord()
        {

        }
        public long StartRange { get; set; }
        public long EndRange { get; set; }
        public int DbId { get; set; }
        public int ClientId { get; set; }
        public string EntityType { get; set; }
        public Client client { get; set; }
        public DatabaseItem database { get; set; }
    }
}
