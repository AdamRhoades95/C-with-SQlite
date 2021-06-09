using App4.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App4
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void Login_Clicked(object sender, EventArgs e)
        {
            PersonData person = new PersonData();
            person.UserName = UserName.Text;
            person.Password = Password.Text;
            string text = UserName.Text;
            PersonData check = new PersonData();
            check = await App.Database.GetPersonAsync(person.UserName);
            try
            {
                if (check.Password == person.Password)
                {
                    text = check.FirstName.ToString() + " " + check.LastName.ToString();
                    await Navigation.PushAsync(new HomePage(text));
                }
                else
                {
                    await DisplayAlert("Alert", "Please enter a valid User ID and password.", "OK");
                }
            }
            catch 
            {
                await DisplayAlert("Alert", "Please enter a valid User ID and password.", "OK");
            }
        }

        async void Register_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }
    }
}
