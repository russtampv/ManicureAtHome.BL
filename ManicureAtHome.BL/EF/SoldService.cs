using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ManicureAtHome.BL.EF
{
    /// <summary>
    /// Предоставленные услуги
    /// </summary>
    public class SoldService
    {
        [NotMapped]
        private List<Service> services = new List<Service>();
        public int Id { get; set; }
        /// <summary>
        /// Список предоставленных услуг
        /// </summary>
        public List<Service> Services { get; set; }
        /// <summary>
        /// Общая цена 
        /// </summary>
        [Column(TypeName = "numeric(10,2)")]
        public decimal Total { get; set; }
        /// <summary>
        /// Идентификатор клиента
        /// </summary>
        public int ClientId { get; set; }
        /// <summary>
        /// Клинет
        /// </summary>
        [ForeignKey("ClientId")]
        public Client Client { get; set; }
        /// <summary>
        /// Общее время работы
        /// </summary>
        public TimeSpan? TotalTime { 
            get { return GetTotalTime(services); }
            set { GetTotalTime(services); } }
        
        public SoldService()
        {
            services = Services;
        }
        /// <summary>
        /// Вычисление общего времени, которое будет потрачено на все услуги
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public TimeSpan? GetTotalTime(List<Service> services )
        {
            var dateTime = 0.0;
            var timeList = services.Select(service => service.WorkTime);
            foreach(var time in timeList)
            {
                if (time == null)
                    continue;
                dateTime += time.TotalMilliseconds;
            }
            return TimeSpan.FromMilliseconds(dateTime);
        }
    }
}
