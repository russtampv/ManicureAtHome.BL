using ManicureAtHome.BL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManicureAtHome.BL
{
    public class WorkToSupplier : IWorker<Supplier>
    {
        public void Add(Supplier record)
        {
            ClientToEF.Context = new ManicureSaloonContext();
        }

        public Supplier Find(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Supplier> GetAll()
        {
            return ClientToEF.Context.Suppliers.Where(item=>item.Contact.IsSupplier);
        }

        public bool Remove(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
