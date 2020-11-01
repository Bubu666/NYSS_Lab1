using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook
{
    public interface IRecordManager
    {
        void AddRecord(Record record);

        bool RemoveRecordById(int id);

        Record GetRecordByIdOrNull(int id);

        List<Record> GetAllRecords();
    }
}
