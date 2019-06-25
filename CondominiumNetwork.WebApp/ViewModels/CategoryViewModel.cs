
using CondominiumNetwork.DomainModel.Entities;
using CondominiumNetwork.DomainModel.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CondominiumNetwork.WebApp.ViewModels
{
    public class CategoryViewModel
    {
        public IEnumerable<Category> Category { get; set; }
    }
}
