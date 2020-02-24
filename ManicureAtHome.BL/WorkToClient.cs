using ManicureAtHome.BL.EF;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public void Add(Client record)
        {
            ClientToEF.Context.Clients.Add(record);
            SaveChange();
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