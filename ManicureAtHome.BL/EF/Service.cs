using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManicureAtHome.BL.EF
{
    /// <summary>
    /// Услуга
    /// </summary>
    public class Service
    {
        /// <summary>
        /// Идентификатор улсуги
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название услуги
        /// </summary>
        [MaxLength(350)]
        public string ManicureName { get; set; }
        /// <summary>
        /// Специалист выполняющий работы
        /// </summary>
        [MaxLength(200)]
        public string Worker { get; set; }
        /// <summary>
        /// Список материалов необходимых для оказания услуги
        /// </summary>
        public List<Material> Materials {get;set;}
        /// <summary>
        /// Цена улсуги
        /// </summary>
        [Column(TypeName = "numeric(10,2)")]
        public decimal Price { get; set; }
        /// <summary>
        /// Время работы
        /// </summary>
        [Required]
        public TimeSpan WorkTime { get; set; }


    }
}
