using MauiBlazorAppDemo.Data;
using System.Collections.ObjectModel;

namespace MauiBlazorAppDemo.Views;

public partial class RecentChats : ContentPage
{
	public ObservableCollection<ChatItem> Items;
	public RecentChats()
	{
		InitializeComponent();

		Task.Run(() => {
			Items = new ObservableCollection<ChatItem>();
			Items.Add(GetItem("Sufyan Umar", true, true, "03321122344", "#616E7F"));
			Items.Add(GetItem("Hasan Shahid", false, false, "", "#FF4D3D"));
			Items.Add(GetItem("Chat#291", false, true, "+98442234242", "#616E7F"));
			Items.Add(GetItem("Chat#991", true, false, "+98442234242", "#FF4D3D"));
			Items.Add(GetItem("Chat#645", true, false, "+98442234242", "#616E7F"));
			Items.Add(GetItem("Chat#773", false, false, "+98442234242", "#0075E7"));
			Items.Add(GetItem("John", false, true, "", "#616E7F"));
			Items.Add(GetItem("Chat#965", true, false, "", "#FF4D3D"));
			Items.Add(GetItem("+9988234244", true, true, "+98442234242", "#0075E7"));

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