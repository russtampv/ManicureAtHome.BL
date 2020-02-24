using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ManicureAtHome.BL.EF
{
    /// <summary>
    /// Предоставленные услуги
    /// </summary>
    public class SoldService
    {
        public int Id { get; set; }
        public List<Service> Services { get; set; }
        public decimal Price { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public List<WareHouse> Materials { get; set; }
        public DateTime? TimeToWork { get; set; }
    }
}
