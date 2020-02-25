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


        public IEnumerable<RecordToSpecialist> GetAllRecords()
        {
            throw new NotImplementedException();
        }

        public RecordToSpecialist RecordFind(string firstName, string lastName)
        {
            throw new NotImplementedException();
        }

        public RecordToSpecialist RecordFind(int recordId)
        {
            throw new NotImplementedException();
        }


        public void Remove(string firstName, string LastName)
        {
            throw new NotImplementedException();
        }

        public void UpdateRecord(int recordId)
        {
            throw new NotImplementedException();
        }

        public void UpdateRecord(string mail)
        {
            throw new NotImplementedException();
        }

        bool IRecord<RecordToSpecialist>.Add(RecordToSpecialist record)
        {
            using (ClientToEF.Context = new ManicureSaloonContext())
            {

                if (ClientToEF.Context.Records.Any(rec => rec.AppointmentDate == record.AppointmentDate
                && rec.AppointmentTime == record.AppointmentTime))
                {
                    Description = "Данное время уже занято";
                    return  false;
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
                    return  true;
                }
            }
        }
        void IRecord<RecordToSpecialist>.Remove(int recordId)
        {
            //var result = ClientToEF.Context.Records.Include(r=>r.Id)
            //if (records.fi)
        }
    }
}
