using System;
using System.Collections.Generic;
using System.Text;

namespace ManicureAtHome.BL.EF
{
    public class WareHouse
    {
        public int Id { get; set; }
        public string ProductType { get; set; }
        public string ProductName { get; set; }
        public int ProductCount { get; set; }
        public Material Material { get; set; }
        public Supplier Suplier { get; set; }
        public int SupplierId { get; set; }
    }
}
