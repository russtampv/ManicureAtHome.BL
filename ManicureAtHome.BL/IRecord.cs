using ManicureAtHome.BL.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManicureAtHome.BL
{
    public interface IRecord<T> where T : class 
    {
        string Description { get; set; }
        bool Add(T record);
        IEnumerable<T> RecordFind(string phone = null, string firstName = null, string lastName = null);
        T RecordFind(string mail);
        T RecordFind(int recordId);
        void Remove(int recordId);
        void UpdateRecord(T record);
        IEnumerable<T> GetAllRecords();
    }
}
