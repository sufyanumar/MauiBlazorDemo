using MauiBlazorAppDemo.Data;
using System.Collections.ObjectModel;

namespace MauiBlazorAppDemo.Views;

public partial class ActiveChats : ContentPage
{
	public ObservableCollection<ChatItem> Items;
	public ActiveChats()
	{
		InitializeComponent();

		Task.Run(() => {
			Items = new ObservableCollection<ChatItem>();
			Items.Add(GetItem("John", false, true, "", "#616E7F"));
			Items.Add(GetItem("Chat#645", true, false, "+98442234242", "#616E7F"));
			Items.Add(GetItem("Chat#773", false, false, "+98442234242", "#0075E7"));
			Items.Add(GetItem("Chat#965", true, false, "", "#FF4D3D"));
			Items.Add(GetItem("Sufyan Umar", true, true, "03321122344", "#616E7F"));

			ItemsListView.ItemsSource = Items;
		});
	}
	private ChatItem GetItem(string name, bool active, bool facebook, string phone, string bg)
	{
		ChatItem item = new ChatItem();
		item.BackgroundColor = Color.Parse(bg);
		item.ChatText = "Hello there! How may I help you?";
		item.ChatStartedAt = DateTime.Now;
		item.ChatEndedAt = DateTime.Now;
		item.VisitorName = name;
		item.IsActiveChat = active;
		item.InitiatedBy = facebook ? 10 : 12;
		item.VisitorPhoneNumber = phone;

		return item;
	}
}