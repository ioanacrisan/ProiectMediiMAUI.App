using System;
using ProiectMediiMAUI.Data;
using System.IO;

namespace ProiectMediiMAUI;

public partial class App : Application
{
    static SalonListDatabase database;
    public static SalonListDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new
                SalonListDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                LocalApplicationData), "SalonList.db3"));
            }
            return database;
        }
    }
    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
