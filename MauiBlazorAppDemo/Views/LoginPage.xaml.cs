namespace MauiBlazorAppDemo.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
		LoginButton.Clicked += (s, e) => 
		{
            if (Application.Current.MainPage.GetType() != typeof(LoginPage))
            {
				Application.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
				Application.Current.MainPage = new NavigationPage(new HomePage());
			}
		};
	}
}