using CondominiumNetwork.DomainModel.Entities;
using CondominiumNetwork.DomainModel.ValueObjects;
using System;

namespace CondominiumNetwork.Infrastructure.DataAcess.Context.Model
{
    public class DbCategory : EntityBase
    {
        public Category Category { get; set; }
    }
}
