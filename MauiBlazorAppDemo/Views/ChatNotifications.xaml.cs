using MauiBlazorAppDemo.Data;
using System.Collections.ObjectModel;

namespace MauiBlazorAppDemo.Views;

public partial class ChatNotifications : ContentPage
{
	public ObservableCollection<ChatNotificationItem> chatNotificationItems;
	public ChatNotifications()
	{
		InitializeComponent();
		Task.Run(() => { 
		chatNotificationItems = new ObservableCollection<ChatNotificationItem>();
			chatNotificationItems.Add(GetNotification(4353, "Desktop", (int)NotificationStatusEnum.Missed, (int)TextChatStatus.End, (int)ChatStatusEnum.Active, "Agent", true));
			chatNotificationItems.Add(GetNotification(8563, "Mobile", (int)NotificationStatusEnum.NotPicked, (int)TextChatStatus.VisitorLeft, (int)ChatStatusEnum.Active, "Operator", false));
			chatNotificationItems.Add(GetNotification(2342, "Web Chat", (int)NotificationStatusEnum.Rejected, (int)TextChatStatus.End, (int)ChatStatusEnum.Inactive, "Agent", false));
			chatNotificationItems.Add(GetNotification(2342, "Web Chat", (int)NotificationStatusEnum.Picked, (int)TextChatStatus.End, (int)ChatStatusEnum.AwaitingPickup, "Sufyan", false));

			ItemsListView.ItemsSource = chatNotificationItems;
		});
	}
	private ChatNotificationItem GetNotification(int chatId, string devicePlatform, int notifPickStatus, int notifStatus, int chatStatus, string chatPickedBy, bool isActive)
	{
		return new ChatNotificationItem()
		{
			ChatId = chatId,
			Location = "Karachi, PK",
			ChatType = "transferrequest",
			DevicePlatform = devicePlatform,
			NotificationTitle = devicePlatform,
			NotificationPickedStatus = notifPickStatus,
			NotificationStatus = notifStatus,
			ChatStatus = chatStatus,
			ChatPickedBy = chatPickedBy,
			IsActive = isActive
		};
	}
}