using MvvmHelpers;
using System;

namespace MauiBlazorAppDemo.Data
{
    public class ChatNotificationItem : ObservableObject
    {
        public int Id { get; set; }

        public int? ChatId { get; set; }

        public int UserId { get; set; }

        public string DeviceToken { get; set; }

        public string DevicePlatform { get; set; }

        public string NotificationPriority { get; set; }

        public int NotificationPickedStatus { get; set; }

        public int NotificationStatus { get; set; }

        public int ChatStatus { get; set; }

        public string NotificationStatusString { get; set; }

        public DateTime ExpireOn { get; set; }

        public string NotificationTitle { get; set; }

        public string NotificationText { get; set; }

        public string PhoneNumber { get; set; }

        private DateTime _sentOn;

        public DateTime SentOn
        {
            get { 
                return _sentOn; 
            }
            set
            {
                _sentOn = value;
                OnPropertyChanged("SentOn");
            }
        }

        public string NotificationData { get; set; }
 
        public string ChatPickedBy { get; set; }

        public DateTime ChatStartedAt { get; set; }

        public DateTime? ChatEndedAt { get; set; }
        public bool IsActive { get; set; }

        public string Location { get; set; }

        public string ChatType { get; set; }

        public string ChatTransferType { get; set; }
        
        //public VisitorChatInfo VisitorInfo { get; set; }

        public string ContainsUnknownLocation(string location)
        {
            return location.ToLower().Contains("unknown") ? string.Empty : location;
        }
    }
}
