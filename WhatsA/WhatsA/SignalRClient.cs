using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WhatsA
{
    public class SignalRClient : INotifyPropertyChanged
    {
        private HubConnection Connection;
        private IHubProxy ChatHubProxy;

        public delegate void MessageReceived(string username, string message);
        public event MessageReceived OnMessageReceived;

        public SignalRClient()
        {
            Connection = new HubConnection("http://testchatserver.azurewebsites.net/");
            Connection.StateChanged += Connection_StateChanged; 
            ChatHubProxy = Connection.CreateHubProxy("WhatsAppHub");
            ChatHubProxy.On<string, string>("MessageRecieved", (username, text) =>
            {
                OnMessageReceived?.Invoke(username, text);
            });
        }
        public Task Start()
        {
            return Connection.Start();
        }
        public void SendMessage(string username, string text)
        {
            ChatHubProxy.Invoke("SendMessage", username, text);
        }

        private void Connection_StateChanged(StateChange obj)
        {
            OnPropertyChanged("ConnectionState");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
