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
        Salon selectedSalon = (SalonPicker.SelectedItem as Salon);
        slist.SalonID = selectedSalon.ID;
        await App.Database.SaveSalonListAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (SalonList)BindingContext;
        await App.Database.DeleteSalonListAsync(slist);
        await Navigation.PopAsync();
    }



    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var items = await App.Database.GetSalonsAsync();
        SalonPicker.ItemsSource = (System.Collections.IList)items;
        SalonPicker.ItemDisplayBinding = new Binding("SalonDetails");

        var shopl = (SalonList)BindingContext;
        listView.ItemsSource = await App.Database.GetListServicesAsync(shopl.ID);
    }
}