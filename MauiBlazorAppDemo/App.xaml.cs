using MauiBlazorAppDemo.Views;
using MauiBlazorAppDemo.Views.Handlers;

namespace MauiBlazorAppDemo;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		MainPage = new LoginPage();

		//remove underline from entry
		new CustomEntryHandler().RemoveEntryUnderline();
	}
}
