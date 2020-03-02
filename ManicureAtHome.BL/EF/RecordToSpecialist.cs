using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ManicureAtHome.BL.EF
{
    /// <summary>
    /// Запись к специалисту
    /// </summary>
    public class RecordToSpecialist
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Список выбранных, клиентом, услуг
        /// </summary>
        public List<Service> Services { get; set; }
        /// <summary>
        /// Время записи
        /// </summary>
        public DateTime? AppointmentTime { get; set; }
        /// <summary>
        /// Клиент 
        /// </summary>
        public Client Client { get; set; }
        /// <summary>
        /// Дата записи
        /// </summary>
        public DateTime AppointmentDate { get; set; }
        /// <summary>
        /// Комментарии
        /// </summary>
        [MaxLength(500)]
        public string Comment { get; set; }
        /// <summary>
        /// Внешний ключ, идентификатор клиента
        /// </summary>
        public int ClientId { get; set; }
    }
}
