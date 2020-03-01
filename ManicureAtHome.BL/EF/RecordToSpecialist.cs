using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ManicureAtHome.BL.EF
{
    public class RecordToSpecialist
    {
        public int Id { get; set; }
        public List<Service> Services { get; set; }
        public DateTime? AppointmentTime { get; set; }
        public Client Client { get; set; }
        public DateTime AppointmentDate { get; set; }
        [MaxLength(500)]
        public string Comment { get; set; }
        public int ClientId { get; set; }
    }
}
