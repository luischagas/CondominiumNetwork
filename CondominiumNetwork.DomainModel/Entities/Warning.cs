using System;

namespace CondominiumNetwork.DomainModel.Entities
{
    public class Warning : EntityBase
    {
        public Guid ProfileId { get; set; }
        public DateTime PublishDateTime { get; set; }
        public string Content { get; set; }
        public Profile Profile { get; set; }
    }
}
