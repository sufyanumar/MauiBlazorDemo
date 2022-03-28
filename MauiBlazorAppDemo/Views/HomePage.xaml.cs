namespace MauiBlazorAppDemo.Views;

public partial class HomePage : TabbedPage
{
	public HomePage()
	{
		InitializeComponent();
	}
    protected override bool OnBackButtonPressed()
    {
        Application.Current.MainPage.Navigation.PushAsync(new NavigationPage(new LoginPage()));
        return true;
    }
}