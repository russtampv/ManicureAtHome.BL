using System;
using System.Collections.Generic;
using System.Text;

namespace ManicureAtHome.BL.EF
{
    public class RecordToSpecialist
    {
        public int Id { get; set; }
        public List<Service> Services { get; set; }
        public DateTime TimeOfReceipt { get; set; }
        public Client Client { get; set; }
        public DateTime DateOfReceipt { get; set; }
        public string Comment { get; set; }
        public int ClientId { get; set; }
    }
}
