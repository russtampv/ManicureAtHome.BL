using ManicureAtHome.BL.EF;
using System.Collections.Generic;
using System.Linq;

namespace ManicureAtHome.BL
{
    /// <summary>
    /// Класс для работы с клиентами
    /// </summary>
    internal class WorkToClient : IWorker<Client>
    {
        public WorkToClient()
        {
            ClientToEF.Context = new ManicureSaloonContext();
        }
        public (string desc, bool isAdded) Add(Client record)
        {
            var contacts = ClientToEF.Context.Clients.ToList();
            if (contacts.Any(contact => contact.Mail == record.Mail))
            {
                return ("Клиент с таким адресом почты уже существует", false);
            }
            else if (contacts.Any(contact => contact.PhoneNumber == record.PhoneNumber))
            {
                return ("Клиент с таким номером телефона уже существует", false);
            }
            else
            {
                ClientToEF.Context.Clients.Add(record);
                SaveChange();
                return ("Клиент успешно добавлен", true);
            }
        }

        public Client Find(int Id)
        {
            return ClientToEF.Context.Clients.Find(Id);
        }

        public IEnumerable<Client> GetAll()
        {
            var clients = ClientToEF.Context.Clients;
            return clients;
        }

        public bool Remove(int Id)
        {
            var client = ClientToEF.Context.Clients.FindAsync(Id);
            if (client != null)
            {
                ClientToEF.Context.Entry<Client>(client.Result).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                SaveChange();
                return true;
            }
            else
            {
                return false;
            }
            
        }

        /// <summary>
        /// Сохранение изменений
        /// </summary>
        public void SaveChange()
        {
            ClientToEF.Context.SaveChanges();
        }
    }
}