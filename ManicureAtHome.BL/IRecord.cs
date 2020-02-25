using ManicureAtHome.BL.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManicureAtHome.BL
{
    public interface IRecord<T> where T : RecordToSpecialist 
    {
        string Description { get; set; }
        bool Add(RecordToSpecialist record);
        RecordToSpecialist RecordFind(string firstName, string lastName);
        RecordToSpecialist RecordFind(int recordId);
        void Remove(string firstName, string LastName);
        void Remove(int recordId);
        void UpdateRecord(int recordId);
        void UpdateRecord(string mail);
        IEnumerable<RecordToSpecialist> GetAllRecords();
    }
}
