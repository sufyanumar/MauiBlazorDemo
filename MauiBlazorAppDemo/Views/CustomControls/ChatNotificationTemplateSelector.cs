
using MauiBlazorAppDemo.Data;

namespace MauiBlazorAppDemo.Views.CustomControls
{
    
    public class ChatNotificationTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ActiveNotification { get; set; }
        public DataTemplate InactiveNotification { get; set; }
        
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var status = ((ChatNotificationItem)item).NotificationPickedStatus;
            var notificationStatus = ((ChatNotificationItem)item).NotificationStatus;
            var chatStatus = ((ChatNotificationItem)item).ChatStatus;
            var chatPickedBy = ((ChatNotificationItem)item).ChatPickedBy;

            if (String.IsNullOrEmpty(chatPickedBy) && chatStatus == (int)ChatStatusEnum.AwaitingPickup && status != (int)NotificationStatusEnum.Rejected || (notificationStatus == (int)TextChatStatus.TransferRequest && status == (int)NotificationStatusEnum.NotPicked && chatStatus == (int)ChatStatusEnum.Active))
            {
                return ActiveNotification;
            }
            else
            {
                return InactiveNotification;
            }
        }
    }
}
