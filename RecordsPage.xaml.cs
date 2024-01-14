using Aplicatie.Models;
using System.Security.Cryptography;

namespace Aplicatie
{
    public partial class RecordsPage : ContentPage
    {
        Appointment sl;

        public RecordsPage(Appointment slist)
        {
            InitializeComponent(); // Pass the instance of the page itself to InitializeComponent
            sl = slist;
            BindingContext = sl;
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var records = (Records)BindingContext;
            await App.Database.SaveRecordsForAppointmentAsync(sl, records);
            listView.ItemsSource = await App.Database.GetRecordsAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var records = (Records)BindingContext;
            await App.Database.DeleteRecordsForAppointmentAsync(sl, records);
            listView.ItemsSource = await App.Database.GetRecordsAsync();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetRecordsAsync();
        }
        async void OnChooseButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RecordsPage((Appointment)this.BindingContext)
            {
                BindingContext = new Records()
            });
        }

        async void OnAddButtonClicked(object sender, EventArgs e)
        {
            Records p;
            if (listView.SelectedItem != null)
            {
                p = listView.SelectedItem as Records;
                var lp = new RecordsList()
                {
                    AppointmentID = sl.ID,
                    RecordsID = p.ID
                };
                await App.Database.SaveRecordsListAsync(lp);
                p.RecordsList = new List<RecordsList> { lp };
                await Navigation.PopAsync();
            }
        }
    }
}
