using System;

namespace CondominiumNetwork.DomainModel.Entities
{
    public class Answer : EntityBase
    {
        public DateTime PublishDateTime { get; set; }
        public string Content { get; set; }
        public Guid OcurrenceId { get; set; }
        public Guid ProfileId { get; set; }
        public Ocurrence Ocurrence { get; set; }
        public Profile Profile { get; set; }
    }
}
