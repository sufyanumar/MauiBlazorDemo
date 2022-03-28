using MauiBlazorAppDemo.Data;
using System.Collections.ObjectModel;

namespace MauiBlazorAppDemo.Views;

public partial class RecentChats : ContentPage
{
	public ObservableCollection<ChatItem> Items;
	public RecentChats()
	{
		InitializeComponent();

		Items = new ObservableCollection<ChatItem>();
		Items.Add(GetItem("Sufyan Umar", true, true, "03321122344"));
		Items.Add(GetItem("Hasan Shahid", false, false, ""));
		Items.Add(GetItem("Chat#291", false, true, "+98442234242"));
		Items.Add(GetItem("Chat#991", true, false, "+98442234242"));
		Items.Add(GetItem("Chat#645", true, false, "+98442234242"));
		Items.Add(GetItem("Chat#773", false, false, "+98442234242"));
		Items.Add(GetItem("John", false, true, ""));
		Items.Add(GetItem("Chat#965", true, false, ""));
		Items.Add(GetItem("+9988234244", true, true, "+98442234242"));

		ItemsListView.ItemsSource = Items;
	}
	private ChatItem GetItem(string name, bool active, bool facebook, string phone)
	{
		ChatItem item = new ChatItem();
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