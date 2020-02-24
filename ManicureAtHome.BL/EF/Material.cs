using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ManicureAtHome.BL.EF
{
    /// <summary>
    /// Характеристика материалов 
    /// </summary>
    [Table("Materials")]
    public class Material
    {
        [Required]
        public int Id { get; set; }
        [MaxLength(200)]
        public string materialName { get; set; }
        [MaxLength(200)]
        public string Maker { get; set; }
        public decimal Price { get; set; }
        public int? QualityLevel { get; set; }
        [MaxLength(200)]
        public string MadeIn { get; set; }
        public int Count { get; set; }
        public int WareHouseId{get;set;}
        public WareHouse WareHouse { get; set; }
    }
}
