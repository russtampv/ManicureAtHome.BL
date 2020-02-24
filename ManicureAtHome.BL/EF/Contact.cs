using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace ManicureAtHome.BL.EF
{

    /// <summary>
    /// Контакты поставщика
    /// </summary>
    public class Contact
    {
        public int Id { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        [MaxLength(300)]
        public string FirstName { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        [Required]
        [MaxLength(300)]
        [RegularExpression("[a-zA-Zа-яА-Я]+", 
            ErrorMessage ="Это поле не может содержать цифры")]
        public string LastName { get; set; }
        /// <summary>
        /// Номер телефона
        /// </summary>
        [RegularExpression(@"^[+7|8]\d{10}", 
            ErrorMessage ="Неверно указан номер телефона")]
        public string PhoneNumber { get; set; }
        public string InstagrammAddress { get; set; }
        [RegularExpression(@"[a-zA-Z0-9._%]+@[a-zA-Z]+\.[A-Z]{2,4}", 
            ErrorMessage ="Адрес почты не сообветствует формату!")]
        public string Mail { get; set; }
        public bool IsSupplier { get; set; }

    }
}