using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManicureAtHome.BL.EF
{
    public class Service
    {
        
        public int Id { get; set; }
        [MaxLength(350)]
        public string manicureName { get; set; }
        [MaxLength(200)]
        public string Worker { get; set; }
        public List<Material> Materials {get;set;}
        public decimal Price { get; set; }
        [Required]
        public DateTime? WorkTime { get; set; }


    }
}
