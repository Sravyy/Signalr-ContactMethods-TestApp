using System;
using System.Collections.Generic;
using System.Text;

namespace MVVMTestApp.Models
{
    public class SmsMessage
    {
        public string ParentContactName { get; set; }
        public int ParentNumber { get; set; }
        public string Body { get; set; }
      
    }
}
