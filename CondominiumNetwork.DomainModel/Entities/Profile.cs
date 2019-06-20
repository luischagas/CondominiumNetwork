using System;
using System.Collections.Generic;
using System.Text;

namespace CondominiumNetwork.DomainModel.Entities
{
    public class Profile : EntityBase<Guid>
    {
        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        public string Address { get; set; }

        public string PhotoUrl { get; set; }

        public string Country { get; set; }
    }
}
