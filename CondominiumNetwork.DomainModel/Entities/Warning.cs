using System;
using System.Collections.Generic;
using System.Text;

namespace CondominiumNetwork.DomainModel.Entities
{
    public class Warning : EntityBase<Guid>
    {
        public Profile Sender { get; set; }

        public DateTime PublishDateTime { get; set; }

        public string Content { get; set; }
    }
}
