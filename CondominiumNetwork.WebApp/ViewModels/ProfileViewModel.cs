﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CondominiumNetwork.WebApp.ViewModels
{
    public class ProfileViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The {0} field is required")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "The {0} field is required")]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "The {0} field is required")]
        public string BlockApartment { get; set; }

        public string PhotoUrl { get; set; }
        public IEnumerable<OcurrenceViewModel> Ocurrences { get; set; }
    }
}
