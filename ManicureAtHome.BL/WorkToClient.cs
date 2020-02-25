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
            var contacts = ClientToEF.Context.Contacts.ToList();
            if (contacts.Any(contact => contact.Mail == record.Contact.Mail))
            {
                return ("Клиент с таким адресом почты уже существует", false);
            }
            else if (contacts.Any(contact => contact.PhoneNumber == record.Contact.PhoneNumber))
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
            var clients = ClientToEF.Context.Clients.Where(client => !client.Contact.IsSupplier);
            return clients;
        }

        public bool Remove(int Id)
        {
            var client = ClientToEF.Context.Clients.Find(Id);
            if (client != null)
            {
                ClientToEF.Context.Clients.Remove(client);
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