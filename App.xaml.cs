namespace jculcayT6;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        //MainPage = new Views.Vestudiante();
        MainPage = new NavigationPage(new Views.Vestudiante());

    }
}
