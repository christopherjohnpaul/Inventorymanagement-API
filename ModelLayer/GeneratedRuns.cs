using System;
using System.Collections.Generic;
using System.Data;

namespace ModelLayer
{
    public class GeneratedRuns
    {
        public int RunNumber { get; set; }
        public string DriverName { get; set; }
        public string DriverEmail { get; set; }
        public string DriverMobileNumber { get; set; }
        public double Total { get; set; }
        public DateTime OrdeeDate { get; set; }
        public long OrderId { get; set; }
        public List<List<string>> RunData { get; set; }
        public DataTable RunDataTable{ get; set; }
    }
}
