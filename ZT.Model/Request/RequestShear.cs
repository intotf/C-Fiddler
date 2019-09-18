using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZT.Model.Request
{
    public class RequestShear
    {
        public string userId { get; set; }
        public string schoolId { get; set; }
        public string childId { get; set; }
        public int actionType { get; set; }
        public string studentId { get; set; }
        public string taskNumber { get; set; }
        public string appType { get; set; }
        public string repeatData { get; set; }
        public string classId { get; set; }
    }
}
