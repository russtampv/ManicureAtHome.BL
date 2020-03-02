using System.ComponentModel.DataAnnotations;

namespace ManicureAtHome.BL.EF
{
    /// <summary>
    /// Поставщик материалов
    /// </summary>
    public class Supplier
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
        /// <summary>
        /// Адрес в инстаграм
        /// </summary>
        public string InstagrammAddress { get; set; }
        /// <summary>
        /// Адрес почты
        /// </summary>
        [MaxLength(300)]
        [RegularExpression(@"\S+@[a-zA-Z0-9]+\.[a-zA-Z]{2,4}",
            ErrorMessage = "Адрес почты не сообветствует формату!")]
        public string Mail { get; set; }
        /// <summary>
        /// Наименование организации поставщика
        /// </summary>
        public string OrganizationName { get; set; }
        /// <summary>
        /// Адрес поставщика
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Указывает, есть ли у поставщика доставка
        /// </summary>
        public bool IsDelivery { get; set; }
    }
}