using Plugin.LocalNotification;
using ProiectMediiMAUI.Models;

namespace ProiectMediiMAUI;

public partial class SalonPage : ContentPage
{
	public SalonPage()
	{
		InitializeComponent();
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var shop = (Salon)BindingContext;
        await App.Database.SaveSalonAsync(shop);
        await Navigation.PopAsync();
    }


    async void OnShowMapButtonClicked(object sender, EventArgs e)
    {
        var shop = (Salon)BindingContext;
        var address = shop.Adress;
        var locations = await Geocoding.GetLocationsAsync(address);
        var options = new MapLaunchOptions
        {
            Name = "Salonul meu preferat" };
        var location = locations?.FirstOrDefault();
        // var myLocation = await Geolocation.GetLocationAsync();
        var myLocation = new Location(46.7731796289, 23.6213886738);

        var distance = myLocation.CalculateDistance(location,
DistanceUnits.Kilometers);
        if (distance < 4)
        {
            var request = new NotificationRequest
            {
                Title = "Ai un salon in apropiere!",
                Description = address,
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddSeconds(1)
                }
            };
            LocalNotificationCenter.Current.Show(request);
        }

        await Map.OpenAsync(location, options);
    }




}