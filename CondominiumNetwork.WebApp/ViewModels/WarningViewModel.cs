using AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;

namespace CondominiumNetwork.WebApp.ViewModels
{
    public class WarningViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime PublishDateTime { get; set; }

        [Required(ErrorMessage = "The {0} field is required")]
        public string Content { get; set; }
        public ProfileViewModel Profile { get; set; }
    }
}
