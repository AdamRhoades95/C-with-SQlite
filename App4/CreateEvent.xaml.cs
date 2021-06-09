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
    public partial class CreateEvent : ContentPage
    {
        private string text;
        public CreateEvent(string text)
        {
            this.text = text;
            InitializeComponent();
        }
        private async void Submit_Event(object sender, EventArgs e)
        {
            int Success;
            EventData events = new EventData
            {
                Name = EventTitle.Text,
                Host = Host.Text,
                Address = Address.Text,
                County = County.Text,
                Zipcode = Zipcode.Text,
                State = State.Text,
                Date = Date.Text,
                Time = Time.Text,
                Description = Description.Text
            };

            Success = await App.Database.SaveEventAsync(events);
            await Navigation.PushAsync(new HomePage());
        }
        private void Cancel_Event(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HomePage(text));
        }
    }
}