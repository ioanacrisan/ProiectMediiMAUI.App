using ProiectMediiMAUI.Models;

namespace ProiectMediiMAUI;

public partial class ListPage : ContentPage
{
	public ListPage()
	{
		InitializeComponent();
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
}