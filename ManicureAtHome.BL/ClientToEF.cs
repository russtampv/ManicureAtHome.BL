using ManicureAtHome.BL.EF;

namespace ManicureAtHome.BL
{
    public class ClientToEF
    {
        public static ManicureSaloonContext Context { get; set; }
        public IWorker<Client> WorkToClient { get; }

        /// <summary>
        /// Создаем клиента для взаимодействия с EntityFramework
        /// </summary>
        public ClientToEF()
        {
            Context = new ManicureSaloonContext();
            WorkToClient = new WorkToClient();
        }
    }
}
