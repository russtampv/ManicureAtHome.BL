using ManicureAtHome.BL.EF;

namespace ManicureAtHome.BL
{
    public class ClientToEF
    {
        public static ManicureSaloonContext Context { get; set; }
        public IWorker<Client> ClientWorker { get; }
        public IWorker<Supplier> SupplierWorker { get; }
        public IRecord<RecordToSpecialist> RecordsWorker { get; }


        /// <summary>
        /// Создаем клиента для взаимодействия с EntityFramework
        /// </summary>
        public ClientToEF()
        {
            Context = new ManicureSaloonContext();
            ClientWorker = new WorkToClient();
            SupplierWorker = new WorkToSupplier(Context);
            RecordsWorker = new RecordToManicure();
        }
    }
}
