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
            if (_context.Suppliers.All(rec => rec.Mail != record.Mail && rec.PhoneNumber != rec.PhoneNumber))
            {
                _context.Suppliers.Add(record);
                _context.SaveChanges();
                return ("Поставщик успешно добавлен", true);
            }
            else if (_context.Suppliers.Any(rec => rec.Mail == record.Mail||rec.PhoneNumber==rec.PhoneNumber))
                return ("Поставщик был добавлен ранее", false);
            return ("Возникли проблемы при добавлении поставщика", false);
        }

        public Supplier Find(int Id)
        {
            return _context.Suppliers.Find(Id);
        }

        public IEnumerable<Supplier> GetAll()
        {
            return _context.Suppliers;
        }

        public bool Remove(int supplierId)
        {
            var supplier = _context.Suppliers.Find(supplierId);
            if (_context.Suppliers.Any(sup => sup.Id == supplierId))
            {
                _context.Entry<Supplier>(supplier).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                return true;
            }
            return false;
        }
    }
}
