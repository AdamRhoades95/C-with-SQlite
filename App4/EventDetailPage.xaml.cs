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
    public partial class EventDetailPage : ContentPage
    {
        PersonEvent myPersonData = new PersonEvent();
        private EventData myEventData;
        private string text;

        public EventDetailPage()
        {
            InitializeComponent();
            
        }
        

        public EventDetailPage(string text, EventData myEventData)
        {
            InitializeComponent();
            this.myEventData = myEventData;
            this.text = text;
            EventDetailsAsync();
        }

        private void EventDetailsAsync() 
        {
            EventTitle.Text = myEventData.Name;
            Host.Text = myEventData.Host;
            Date.Text = myEventData.Date;
            Time.Text = myEventData.Time;
            Location.Text = myEventData.Address + " " + myEventData.County + ", " + myEventData.State + myEventData.Zipcode;
            Description.Text = myEventData.Description;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            eventList.ItemsSource = await App.Database.GetPeopleEventAsync(myEventData.Name);
            
        }
       
        private async void Yes_Event(object sender, EventArgs e)
        {
            int Success;
            PersonEvent events = new PersonEvent();
            events.EventTitle = myEventData.Name;
            events.PersonName = text;
            events.RSVPResponse = "YES";

            Success = await App.Database.SavePersonEventAsync(events);
            submit();
        }

        private void submit()
        {
            Navigation.PushAsync(new HomePage(text));
        }

        void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            myEventData = (EventData)e.SelectedItem;
            Navigation.PushAsync(new EventDetailPage(text, myEventData));
        }

        private void No_Event(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HomePage(text));
        }
    }
}