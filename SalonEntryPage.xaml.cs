using ProiectMediiMAUI.Models;

namespace ProiectMediiMAUI;

public partial class SalonEntryPage : ContentPage
{
	public SalonEntryPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetSalonsAsync();
    }
    async void OnSalonAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SalonPage
        {
            BindingContext = new Salon()
        });
    }
    async void OnListViewItemSelected(object sender,
    SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new SalonPage
            {
                BindingContext = e.SelectedItem as Salon
            });
        }
    }
}