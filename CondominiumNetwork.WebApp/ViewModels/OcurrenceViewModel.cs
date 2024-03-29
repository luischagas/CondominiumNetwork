﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CondominiumNetwork.WebApp.ViewModels
{
    public class OcurrenceViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime PublishDateTime { get; set; }

        [Required(ErrorMessage = "The {0} field is required")]
        public string Content { get; set; }

        [Required(ErrorMessage = "The {0} field is required")]
        public string Category { get; set; }
        public ProfileViewModel Profile { get; set; }
        public IEnumerable<AnswerViewModel> Answers { get; set; }
    }
}
