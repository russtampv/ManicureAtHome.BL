
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManicureAtHome.BL.EF
{
    /// <summary>
    /// Склад
    /// </summary>
    public class WareHouse
    { 
        /// <summary>
        /// Идентификатор товара
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Тип товара
        /// </summary>
        [MaxLength(100)]
        public string ProductType { get; set; }
        /// <summary>
        /// Наименование товара
        /// </summary>
        [MaxLength(200)]
        public string ProductName { get; set; }
        /// <summary>
        /// Количество товара
        /// </summary>
        
        public int ProductCount { get; set; }
        /// <summary>
        /// Внешний ключ на материал
        /// </summary>
        
        public Material Material { get; set; }
        /// <summary>
        /// Внешний ключ на поставщика
        /// </summary>
        [ForeignKey("SupplierId")]
        public Supplier Suplier { get; set; }
        public int SupplierId { get; set; }

    }
}
