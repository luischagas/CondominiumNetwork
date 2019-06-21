using CondominiumNetwork.DomainModel.ValueObjects;
using System;

namespace CondominiumNetwork.Infrastructure.DataAcess.Context.Model
{
    public class DbCategory
    {
        public Guid Id { get; set; }
        public Category Category { get; set; }
    }
}
