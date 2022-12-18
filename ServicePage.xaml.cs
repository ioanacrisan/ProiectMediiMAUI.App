using ProiectMediiMAUI.Models;

namespace ProiectMediiMAUI;

public partial class ServicePage : ContentPage
{
    SalonList sl;
    public ServicePage(SalonList slist)
	{
		InitializeComponent();
        sl = slist;
    }

    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Service p;
        if (listView.SelectedItem != null)
        {
            p = listView.SelectedItem as Service;
            var lp = new ListService()
            {
                SalonListID = sl.ID,
                ServiceID = p.ID
            };
            await App.Database.SaveListServiceAsync(lp);
            p.ListServices = new List<ListService> { lp };
            await Navigation.PopAsync();
        }
    }
        async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var service = (Service)BindingContext;
        await App.Database.SaveServiceAsync(service);
        listView.ItemsSource = await App.Database.GetServicesAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var service = (Service)BindingContext;
        await App.Database.DeleteServiceAsync(service);
        listView.ItemsSource = await App.Database.GetServicesAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetServicesAsync();
    }
}