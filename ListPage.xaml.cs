using ProiectMediiMAUI.Models;

namespace ProiectMediiMAUI;

public partial class ListPage : ContentPage
{
	public ListPage()
	{
		InitializeComponent();
	}

    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ServicePage((SalonList)
        this.BindingContext)
        {
            BindingContext = new Service()
        });
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (SalonList)BindingContext;
        await App.Database.SaveSalonListAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (SalonList)BindingContext;
        await App.Database.DeleteSalonListAsync(slist);
        await Navigation.PopAsync();
    }

    async void OnDeleteServiceButtonClicked(object sender, EventArgs e)
    {
        var service = (Service)BindingContext;
        await App.Database.DeleteServiceAsync(service);
        listView.ItemsSource = await App.Database.GetServicesAsync();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var shopl = (SalonList)BindingContext;
        listView.ItemsSource = await App.Database.GetListServicesAsync(shopl.ID);
    }
}