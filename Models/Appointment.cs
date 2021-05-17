using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Drop.Web.models
{
    public partial class Appointment
    {
        public int AppointmentId { get; set; }
        [Required(ErrorMessage = "First name required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="Last name required")]
        public string LastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Telephone Number Required")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]

        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please select a date")]
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Please select a time")]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}")]
        [DataType(DataType.Time)]
        
        public TimeSpan Time { get; set; }
    }
}
