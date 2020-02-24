using ManicureAtHome.BL.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManicureAtHome.BL
{
    /// <summary>
    /// Интерфейс для работы с объектами EntityFramework
    /// </summary>
    public interface IWorker<T> where T : class
    {
        /// <summary>
        /// Добавление запись
        /// </summary>
        /// <param name="contact">запись добавляемая в таблицу</param>
        void Add(T record);
       
        /// <summary>
        /// Выбрать клиента
        /// </summary>
        /// <param name="Id">идентификатор</param>
        /// <returns></returns>
        T Find(int Id);

        /// <summary>
        /// Показать список всех клиентов
        /// </summary>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Удалить запись из таблицы
        /// </summary>
        /// <param name="Id">идентификатор клиента</param>
        /// <returns></returns>
        bool Remove(int Id);


    }
}
