using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ManicureAtHome.BL.EF
{
    /// <summary>
    /// Характеристика материала 
    /// </summary>
    [Table("Materials")]
    public class Material
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Required]
        public int Id { get; set; }
        /// <summary>
        /// Наименование материала
        /// </summary>
        [MaxLength(200)]
        public string materialName { get; set; }
        /// <summary>
        /// Производитель
        /// </summary>
        [MaxLength(200)]
        public string Maker { get; set; }
        /// <summary>
        /// Цена 
        /// </summary>
        [Column(TypeName ="numeric(10,2)")]
        public decimal Price { get; set; }
        /// <summary>
        /// Уровень материала (качество)
        /// </summary>
        public int? QualityLevel { get; set; }
        /// <summary>
        /// Страна производства
        /// </summary>
        [MaxLength(200)]
        public string MadeIn { get; set; }
        /// <summary>
        /// Дополнительная информация по материалу
        /// </summary>
        [MaxLength(700)]
        public string DopInfo { get; set; }
        public WareHouse WareHouse { get; set; }
        
    }
}
