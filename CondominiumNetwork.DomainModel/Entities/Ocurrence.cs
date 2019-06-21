using CondominiumNetwork.DomainModel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominiumNetwork.DomainModel.Entities
{
    public class Ocurrence : EntityBase<Guid>
    {
        public DateTime PublishDateTime { get; set; }
        public string Content { get; set; }
        public Guid ProfileId { get; set; }
        public string Category { get; set; }
        public Profile Profile { get; set; }
        public IEnumerable<Answer> Answers { get; set; }
    }
}
