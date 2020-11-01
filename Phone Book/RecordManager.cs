using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneBook
{
    public class RecordManager : IRecordManager
    {
        private Dictionary<int, Record> records = new Dictionary<int, Record>();


        public void AddRecord(Record record)
        {
            records.TryAdd(record.Id, record);
        }

        public List<Record> GetAllRecords()
        {
            return records.Values.ToList();
        }

        public Record GetRecordByIdOrNull(int id)
        {
            return records.TryGetValue(id, out var record) 
                ? record 
                : null;
        }

        public bool RemoveRecordById(int id)
        {
            return records.Remove(id);
        }
    }
}
