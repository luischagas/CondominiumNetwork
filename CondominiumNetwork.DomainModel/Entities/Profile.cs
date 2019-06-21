using System;
using System.Collections;
using System.Collections.Generic;

namespace CondominiumNetwork.DomainModel.Entities
{
    public class Profile : EntityBase<Guid>
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string BlockApartment { get; set; }
        public string PhotoUrl { get; set; }
        public IEnumerable<Ocurrence> Ocurrences { get; set; }
        public IEnumerable<Answer> Answers { get; set; }
        public IEnumerable<Warning> Warnings { get; set; }

    }
}
