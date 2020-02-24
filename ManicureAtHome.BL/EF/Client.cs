using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ManicureAtHome.BL.EF
{
    /// <summary>
    /// Клиент
    /// </summary>
    public class Client
    {
        public int Id { get; set; }

        public RecordToSpecialist Records { get; set; }
        public SoldService Sold { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}
