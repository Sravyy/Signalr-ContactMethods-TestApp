using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using MVVMTestApp.Server.Models;

namespace MVVMTestApp.Server
{
    [HubName("MyHub")]
    public class MyHub : Hub
    {
       
        public IEnumerable<SmsContactState> GetContacts(string jsonMessage)
        {
            var Contacts = new List<SmsContactState>
            {
                new SmsContactState {ContactName ="Mosh", ContactMobileNumber= 1134230342, LastMessageOn="Hello"},
                new SmsContactState {ContactName ="Bob", ContactMobileNumber= 1134230542, LastMessageOn="Hi"},
                new SmsContactState {ContactName ="Dan", ContactMobileNumber= 1134232342, LastMessageOn="Whatup"},
                new SmsContactState {ContactName ="Jhon", ContactMobileNumber= 1134209762, LastMessageOn="Hey"}

            };

             return Contacts; 
        }

        //public IEnumerable<SmsMessage> MessagesRecent(Guid smsContactId, int seconds = 10)
        //{

        //}

        public override Task OnConnected()
        {
            return base.OnConnected();
        }
    }

   
}