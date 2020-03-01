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
        /// <summary>
        /// Фамилия
        /// </summary>
        [MaxLength(300)]
        [RegularExpression("[a-zA-Zа-яА-Я]+",
            ErrorMessage = "Это поле не может содержать цифры")]
        public string FirstName { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        [Required]
        [MaxLength(300)]
        [RegularExpression("[a-zA-Zа-яА-Я]+",
            ErrorMessage = "Это поле не может содержать цифры")]
        public string LastName { get; set; }
        /// <summary>
        /// Номер телефона
        /// </summary>
        [MaxLength(15)]
        [RegularExpression(@"(\+)*[7|8|1|2]{1}\d{10}",
            ErrorMessage = "Неверно указан номер телефона")]
        public string PhoneNumber { get; set; }
        public string InstagrammAddress { get; set; }
        [MaxLength(300)]
        [RegularExpression(@"\S+@[a-zA-Z0-9]+\.[a-zA-Z]{2,4}",
            ErrorMessage = "Адрес почты не сообветствует формату!")]
        public string Mail { get; set; }

        public RecordToSpecialist Records { get; set; }
        public SoldService Sold { get; set; }
    }
}
