using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingAssessments
{
    public class MyStore
    {
        public string RecordId { get; set; }
        public string StoreName { get; set; }
        public string StoreLocation { get; set; }
        public MyStore(string recordId, string storeName, string storeLocation)
        {
            RecordId = recordId;
            StoreName = storeName;
            StoreLocation = storeLocation;
        }
    }
}
