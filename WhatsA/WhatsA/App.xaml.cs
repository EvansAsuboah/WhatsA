using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace WhatsA
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new TabbedPage
            {
                Children =
                {
                    new Camera(),
                     new Chats(),
                     new Status(),
                     new Calls(),

                }
            });
        }
        public App(string DB_Path)

        {

            InitializeComponent();

            DB_PATH = DB_Path;

            MainPage = new NavigationPage(new ChatScreen());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
