using ManicureAtHome.BL.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManicureAtHome.BL
{
    public class RecordToManicure : IRecord<RecordToSpecialist>
    {
        public string Description { get; set; }

        public bool Add(RecordToSpecialist record)
        {
            using (ClientToEF.Context = new ManicureSaloonContext())
            {

                if (ClientToEF.Context.Records.Any(rec => rec.AppointmentDate == record.AppointmentDate
                && rec.AppointmentTime == record.AppointmentTime))
                {
                    Description = "Данное время уже занято";
                    return false;
                }
                else if (ClientToEF.Context.Records.Any(rec => rec.AppointmentDate == record.AppointmentDate
                && !string.IsNullOrEmpty(record.AppointmentTime.ToString())))
                {
                    Description = "Клиент записан, но лучше уточнить информацию";
                    return true;
                }
                else
                {
                    ClientToEF.Context.Records.Add(record);
                    ClientToEF.Context.SaveChanges();
                    Description = "Клиент успешно записан на встречу";
                    return true;
                }
            }
        }

        public IEnumerable<RecordToSpecialist> GetAllRecords()
        {
            return ClientToEF.Context.Records.Include(c => c.Services);
        }

        public IEnumerable<RecordToSpecialist> RecordFind(string phone=null, string firstName=null, string lastName=null)
        {
            if (phone==null)
            {
                if (firstName == null)
                    return ClientToEF.Context.Records.Where(record => record.Client.LastName == lastName);
                else
                    return ClientToEF.Context.Records.Where(record => record.Client.FirstName == firstName || record.Client.LastName == lastName);
            }
            else if (phone!=null)
            {
                return ClientToEF.Context.Records.Where(record => record.Client.PhoneNumber == phone);
            }
            return null;
        }

        public RecordToSpecialist RecordFind(string mail)
        {
            var record = ClientToEF.Context.Records.Find(mail);
            if (record.Client != null)
                return record;
            return null;
        }

        public RecordToSpecialist RecordFind(int recordId)
        {
            throw new NotImplementedException();
        }

        public void Remove(int recordId)
        {
            throw new NotImplementedException();
        }

        public async void UpdateRecord(RecordToSpecialist record)
        {
            ClientToEF.Context.Records.Update(record);
           await ClientToEF.Context.SaveChangesAsync();
        }
    }
}
