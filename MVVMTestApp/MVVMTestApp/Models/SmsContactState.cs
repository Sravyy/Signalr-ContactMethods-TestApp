using System;
using System.Collections.Generic;
using System.Text;

namespace MVVMTestApp.Models
{
    public class SmsContactState
    {
        public string ContactName { get; set; }
        public int ContactMobileNumber { get; set; }
        public string LastMessageOn { get; set; }
        public virtual ICollection<SmsMessage> Messages { get; set; }
    }
}
