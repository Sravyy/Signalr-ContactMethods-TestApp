using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace MVVMTestApp.Services
{
    public class SignalRClient : INotifyPropertyChanged
    {
        public HubConnection _hub;
        public IHubProxy _smsHubProxy;

        public HubConnection Hub { get { return _hub; } }

        public SignalRClient()
        {
            Debug.WriteLine("SignalR Initialized...");
            InitializeSignalR().ContinueWith(task =>
            {
                Debug.WriteLine("SignalR Started...");
            });
        }

        public async Task InitializeSignalR()
        {
            _hub = new HubConnection("http://192.168.1.67");
            _smsHubProxy = _hub.CreateHubProxy("MyHub");

            _hub.StateChanged += state =>
            {
                Console.WriteLine("Connection State Changed From {0} To {1}", state.OldState, state.NewState);
                if (state.NewState == ConnectionState.Disconnected)
                {
                    Console.WriteLine("Reconnecting in 500 ms");
                    Thread.Sleep(500);
                    _hub.Start(); 
                }
            };

            _hub.Error += E => Console.WriteLine(E.Message);

            _hub.TraceLevel = TraceLevels.All;
            _hub.TraceWriter = Console.Out;

            await _hub.Start();
        }

        public async Task GetContacts(SmsContactState smsContactState)
        {
            _smsHubProxy.Invoke<string>("GetContacts", jsonMessage =>
            {

            });

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
