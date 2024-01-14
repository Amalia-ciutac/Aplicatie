using Aplicatie;
using Aplicatie.Models;
using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;

namespace Aplicatie
{
    public partial class AppointmentsPage : ContentPage
    {
        public AppointmentsPage()
        {
            InitializeComponent();
            OnAppearing();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            appointmentsListView.ItemsSource = await App.Database.GetAppointmentsAsync();
        }

        private async void OnAppointmentAddedClicked(object sender, EventArgs e)
        {
            var newAppointment = new Appointment
            {
                Description = "Default Description" // Set a default value for the Description property
            };

            await Navigation.PushAsync(new AppointmentDetails
            {
                BindingContext = newAppointment
            });
        }


        private async void OnAppointmentSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Appointment selectedAppointment)
            {
                await Navigation.PushAsync(new AppointmentDetails
                {
                    BindingContext = selectedAppointment
                });
            }
        }
    }
}
