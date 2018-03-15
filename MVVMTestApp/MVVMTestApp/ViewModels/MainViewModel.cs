using MVVMTestApp.Models;
using MVVMTestApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MVVMTestApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
     
        private readonly SignalRClient signalR;

        private List<SmsContactState> _contactList;
        public List<SmsContactState> ContactList
        {
            get { return _contactList; }
            set
            {
                _contactList = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            signalR = new SignalRClient();

            //var contactServices = new SmsContactStateServices();
            //ContactList = contactServices.GetContacts();
        }

       #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        
    }
}
