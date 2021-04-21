using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Drop.Web.models
{
    public partial class Appointment
    {
        public int AppointmentId { get; set; }
        public int DonorId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        public DateTime Date { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}")]
        
        public TimeSpan Time { get; set; }

        public virtual Donor Donor { get; set; }
    }
}
