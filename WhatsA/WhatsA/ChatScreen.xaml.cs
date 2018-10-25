using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhatsA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatScreen : ContentPage
    {
        public SignalRClient SignalRClient = new SignalRClient();
        public ChatScreen()
        {
            InitializeComponent();
            BindingContext = this;
            SignalRClient.Start();
            SignalRClient.OnMessageReceived += (username, message) =>
              {
                  TextContainer.Add(new MessageText { Text = username + ":" + message });
              };
        }

        private void New_Group_Clicked(object sender, EventArgs E)
        {

        }
        private void New_Broadcast_Clicked(object sender, EventArgs E)
        {

        }
        private void WhatsApp_Web_Clicked(object sender, EventArgs E)
        {

        }
        private void Starred_Messages_Clicked(object sender, EventArgs E)
        {

        }
        private void Settings_Clicked(object sender, EventArgs E)
        {

        }
        private void Search_Clicked(object sender, EventArgs E)
        {

        }


        public ObservableCollection<MessageText> TextContainer { get; set; } = new ObservableCollection<MessageText>();
        public void AddText(string text)
        {
            TextContainer.Add(new MessageText { Text = text });
        }
        
        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                
                var messageSent = TypeMessage.Text;
                if (messageSent != null)
                {
                    AddText(messageSent);
                    SignalRClient.SendMessage
                        ("Me :", messageSent);
                }

                TypeMessage.Text = string.Empty;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                DisplayAlert("Couldn't send Message","Error in Sending", "Cancel");
            }



             using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<MessageText>();
                var numberofRows = conn.Insert(MessageText);

                //if (numberofRows > 0)
                //    DisplayAlert("Message sent");
                //else
                //    DisplayAlert("");
            }
        }
    }

    public class MessageText
    {
        public string Text { get;  set; }
    }
}