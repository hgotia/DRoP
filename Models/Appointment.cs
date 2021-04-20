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
        public DateTime Date { get; set; }
        [DataType(DataType.Time)]
        
        public TimeSpan Time { get; set; }

        public virtual Donor Donor { get; set; }
    }
}
