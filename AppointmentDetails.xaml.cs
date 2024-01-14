using Aplicatie;
using Aplicatie.Models;
using Microsoft.Maui.Controls;
using System;

namespace Aplicatie
{
    public partial class AppointmentDetails : ContentPage
    {
        public AppointmentDetails()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var slist = (Appointment)BindingContext;
            slist.Date = DateTime.UtcNow;
            await App.Database.SaveAppointmentAsync(slist);
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var slist = (Appointment)BindingContext;
            await App.Database.DeleteAppointmentAsync(slist);
            await Navigation.PopAsync();
        }

        async void OnChooseButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RecordsPage((Appointment)this.BindingContext)
            {
                BindingContext = new Records()
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var shopl = (Appointment)BindingContext;

            // Assuming listView is defined in your XAML or you need to create it here
            // listView.ItemsSource = await App.Database.GetRecordsListAsync(shopl.ID);
        }
    }
}
