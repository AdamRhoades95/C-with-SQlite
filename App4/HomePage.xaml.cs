using App4.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        EventData myEventData = new EventData();
        private string text;

        public HomePage()
        {
            InitializeComponent();
        }

        public HomePage(string text)
        {
            InitializeComponent();
            this.text = text;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            eventList.ItemsSource = await App.Database.GetEventsAsync();
        }

        void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            myEventData = (EventData)e.SelectedItem;
            Navigation.PushAsync(new EventDetailPage(text , myEventData));
        }

        private void New_Event(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateEvent(text));
        }
        private void Logout(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        private void Event_Details(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EventDetailPage(text, myEventData));
        }
    }
}