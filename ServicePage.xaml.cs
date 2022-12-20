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

    async void OnShowMapButtonClicked(object sender, EventArgs e)
    {
        var salon = (Salon)BindingContext;
        var address = salon.Adress;
        var locations = await Geocoding.GetLocationsAsync(address);
        var options = new MapLaunchOptions
        {
            Name = "Salonul meu preferat" };
        var location = locations?.FirstOrDefault();
        // var myLocation = await Geolocation.GetLocationAsync();
        var myLocation = new Location(46.7731796289, 23.6213886738);
        await Map.OpenAsync(location, options);
    }
}