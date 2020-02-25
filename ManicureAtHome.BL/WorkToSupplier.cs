using ManicureAtHome.BL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManicureAtHome.BL
{
    public class WorkToSupplier : IWorker<Supplier>
    {
        private ManicureSaloonContext _context;
        public WorkToSupplier(ManicureSaloonContext context)
        {
            _context = context;
        }
        public (string desc, bool isAdded) Add(Supplier record)
        {
            if (_context.Suppliers.All(rec => rec.Contact != record.Contact))
            {
                _context.Suppliers.Add(record);
                _context.SaveChanges();
                return ("Поставщик успешно добавлен", true);
            }
            else if (_context.Suppliers.Any(rec => rec.Contact == record.Contact))
                return ("Поставщик был добавлен ранее", false);
            return ("Возникли проблемы при добавлении поставщика", false);
        }

        public Supplier Find(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Supplier> GetAll()
        {
            return ClientToEF.Context.Suppliers.Where(item => item.Contact.IsSupplier);
        }

        public bool Remove(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
