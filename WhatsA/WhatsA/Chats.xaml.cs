using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhatsA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Chats : ContentPage
    {
        List<string> colors = new List<string>
            {
                "Ozil", "Monreal", "Kovacic","Modric","Isco"
            };
        public Chats()
        {
            InitializeComponent();
            string[] Chat =
            {
                "Ozil", "Monreal", "Kovacic","Modric","Isco"
            };
            Contacts.ItemsSource = Chat;
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

        private void ColorSearch_SearchButtonPressed(object sender, EventArgs e)
        {

        }

        private void ColorSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = ColorSearch.Text;
            var suggestions = colors.Where(c => c.ToLower().Contains(keyword.ToLower()));

            Contacts.ItemsSource = suggestions;
        }

        private void Contacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new ChatScreen());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<MessageText>();
                var books = conn.Table<MessageText>().ToList();
                Contacts.ItemsSource = books;

            }
        }

        
    }
}