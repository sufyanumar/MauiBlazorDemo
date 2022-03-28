using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using MauiBlazorAppDemo.Data;
using MvvmHelpers;

namespace MauiBlazorAppDemo.Data;

public class ChatItem : ObservableObject
{
    public ChatItem()
    {
        //ChatTranscript = new ObservableCollection<ChatResponse>();
        //ChatTranscript.CollectionChanged += ChatTranscript_CollectionChanged;
    }

    //private void ChatTranscript_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    //{
    //    var output = string.Empty;

    //    if (ChatTranscript != null && ChatTranscript.Count > 0)
    //    {
    //        var log = ChatTranscript.LastOrDefault(c => c.ParticipantId != -1);
    //        if (log != null)
    //        {
    //            log.Response = ExtensionMethods.GetEmailFromHtml(log.Response); //check if email exist in html format, then extract and returns email address
    //        }
    //        output = log != null ? log.ToString() : string.Empty;
    //    }
    //    ChatText = output;
    //}

    string _Id;
    public string Id
    {
        get { return _Id; }
        set { SetProperty(ref _Id, value); }
    }
    int _participantId;
    public int ParticipantId
    {
        get { return _participantId; }
        set { SetProperty(ref _participantId, value); }
    }



    string _chatStatusText;
    public string chatStatusText
    {
        get { return _chatStatusText; }
        set { SetProperty(ref _chatStatusText, value); }
    }
    int _chatStatusValue;
    public int chatStatusValue
    {
        get { return _chatStatusValue; }
        set { SetProperty(ref _chatStatusValue, value); }
    }

    bool _isChatEnded;
    public bool isChatEnded
    {
        get { return _isChatEnded; }
        set { SetProperty(ref _isChatEnded, value); }
    }


    public Color ColorCode { get; set; }
    public bool IsActiveChat
    {
        get => Status == ChatStatusEnum.Active;
        set
        {
            if (value)
                Status = ChatStatusEnum.Active;
            else
                Status = ChatStatusEnum.Inactive;
        }
    }

    private DateTime _chatStartedAt;
    public DateTime ChatStartedAt
    {
        get => _chatStartedAt;
        set => SetProperty(ref _chatStartedAt, value);
    }


    private DateTime? _chatEndedAt;
    public DateTime? ChatEndedAt
    {
        get => _chatEndedAt;
        set => SetProperty(ref _chatEndedAt, value);
    }

    DateTime _ChatUpdateTime;
    public DateTime ChatUpdateTime
    {
        get => _ChatUpdateTime;
        set => SetProperty(ref _ChatUpdateTime, value);
    }

    int _ChatId;
    public int ChatId { get { return _ChatId; } set { SetProperty(ref _ChatId, value); } }

    int _LeadType;
    public int LeadType { get { return _LeadType; } set { SetProperty(ref _LeadType, value); } }

    int _LeadId = -1;
    public int LeadId { get { return _LeadId; } set { SetProperty(ref _LeadId, value); } }

    long _VisitorId;
    public long VisitorId { get { return _VisitorId; } set { SetProperty(ref _VisitorId, value); } }

    bool _IsRead;
    public bool IsRead
    {
        get { return _IsRead; }
        set { SetProperty(ref _IsRead, value); }
    }
    int _UnreadMessageCount;
    public int UnreadMessageCount { get { return _UnreadMessageCount; } set { SetProperty(ref _UnreadMessageCount, value); } }
    //public ObservableCollection<ChatResponse> ChatTranscript { get; set; }
    public string ChatTranscriptHtml { get; set; }
    string _chatText = string.Empty;
    public string ChatText
    {
        get
        {
            return _chatText;
        }
        set { SetProperty(ref _chatText, value); }
    }

    // This is the default title of Chat title 
    string _visitorTitle = string.Empty;
    public string VisitorTitle
    {
        get
        {
            return _visitorTitle;
        }
        set { SetProperty(ref _visitorTitle, value); }
    }
    string _nameInitial = string.Empty;
    public string NameInitial
    {
        get
        {
            var nameInitial = string.Empty;
            if (!string.IsNullOrEmpty(VisitorTitle))
            {
                nameInitial = VisitorTitle.Substring(0, 1).ToUpper();
            }
            else if (!string.IsNullOrEmpty(VisitorPhoneNumber))
            {
                nameInitial = VisitorPhoneNumber.Substring(0, 1);
            }
            NameInitial = nameInitial;
            return nameInitial;
        }
        private set { SetProperty(ref _nameInitial, value); }
    }

    public bool IsFacebook
    {
        get
        {
            var isFacebook = false;
            if (InitiatedBy == (int)ChatInitiatedBy.FacebookMessenger)
            {
                isFacebook = true;
            }
            return isFacebook;
        }
    }

    public bool IsExitPopup
    {
        get
        {
            var isExitPopup = false;
            if (InitiatedBy == (int)ChatInitiatedBy.ExitPopup)
            {
                isExitPopup = true;
            }
            return isExitPopup;
        }
    }

    public bool IsStatic
    {
        get
        {
            var isStatic = false;
            if (InitiatedBy == (int)ChatInitiatedBy.Static)
            {
                isStatic = true;
            }
            return isStatic;
        }
    }
    public bool IsPrechat
    {
        get
        {
            var isPrechat = false;
            if (InitiatedBy == (int)ChatInitiatedBy.PreChat)
            {
                isPrechat = true;
            }
            return isPrechat;
        }
    }

    public bool IsDesktop
    {
        get
        {
            var isDesktop = false;
            if (!IsSMS && !IsPhone && !IsTablet &&
                (InitiatedBy == (int)ChatInitiatedBy.Unknown ||
                InitiatedBy == (int)ChatInitiatedBy.Bar ||
                InitiatedBy == (int)ChatInitiatedBy.Standard ||
                InitiatedBy == (int)ChatInitiatedBy.Tab))
            {
                isDesktop = true;
            }
            return isDesktop;
        }
    }

    string _location;
    public string Location { get { return _location; } set { SetProperty(ref _location, value); } }

    string _notes;
    public string Notes { get { return _notes; } set { SetProperty(ref _notes, value); } }

    string _needs;
    public string Needs { get { return _needs; } set { SetProperty(ref _needs, value); } }

    string _visitorName;
    public string VisitorName
    {
        get
        {
            return _visitorName;
        }
        set
        {
            SetProperty(ref _visitorName, value);
            //Check if the visitor name is null or empty, then assign to visitor title
            //else visitor title logic takes into account if the chat is based on SMS.
            VisitorTitle = string.IsNullOrWhiteSpace(VisitorName) ? ChatId +" "+VisitorPhoneNumber : VisitorName;
        }
    }
    string _visitorPhoneNumber;
    public string VisitorPhoneNumber { get { return _visitorPhoneNumber; } set { SetProperty(ref _visitorPhoneNumber, value); } }
    string _visitorEmail;
    public string VisitorEmail { get { return _visitorEmail; } set { SetProperty(ref _visitorEmail, value); } }

    bool _isFavourite;
    public bool IsFavourite { get { return _isFavourite; } set { SetProperty(ref _isFavourite, value); } }
    string _devicePlatform;
    public string DevicePlatform { get { return _devicePlatform; } set { SetProperty(ref _devicePlatform, value); } }
    string _deviceToken;
    public string DeviceToken { get { return _deviceToken; } set { SetProperty(ref _deviceToken, value); } }
    string _pickedUpBy;
    public string PickedUpBy { get { return _pickedUpBy; } set { SetProperty(ref _pickedUpBy, value); } }
    string _transferredTo;
    public string TransferredTo { get { return _transferredTo; } set { SetProperty(ref _transferredTo, value); } }
    long _requestedTransfereeId;
    public long RequestedTransfereeId { get { return _requestedTransfereeId; } set { SetProperty(ref _requestedTransfereeId, value); } }
    bool isTransferRequested;
    public bool IsTransferRequested { get { return isTransferRequested; } set { SetProperty(ref isTransferRequested, value); } }
    bool _isSMS;
    public bool IsSMS
    {
        get { return _isSMS; }
        set
        {
            SetProperty(ref _isSMS, value);
            //Set _isPhone as false when the chat source is SMS, this will just show SMS
            if (value) { SetProperty(ref _isPhone, !value); }
        }
    }
    bool _isPhone;
    public bool IsPhone { get { return _isPhone; } set { SetProperty(ref _isPhone, value); } }
    bool _isTablet = false; //Default false need to pull from service
    public bool IsTablet { get { return _isTablet; } set { SetProperty(ref _isTablet, value); } }
    int _initiatedBy;
    public int InitiatedBy { get { return _initiatedBy; } set { SetProperty(ref _initiatedBy, value); } }

    bool _showUnreadMessageCount;
    public bool ShowUnreadMessageCount { get { return _showUnreadMessageCount; } set { SetProperty(ref _showUnreadMessageCount, value); } }

    Color _backgroundColor;
    public Color BackgroundColor { get { return _backgroundColor; } set { SetProperty(ref _backgroundColor, value); } }

    ChatStatusEnum _status;
    public ChatStatusEnum Status { get { return _status; } set { SetProperty(ref _status, value); } }
    bool _showTypingOnActiveChats;
    public bool ShowTypingOnActiveChats { get { return _showTypingOnActiveChats; } set { SetProperty(ref _showTypingOnActiveChats, value); } }

}


public class AppNotification
{
    public int Id { get; set; }

    public int? ChatId { get; set; }

    public int UserId { get; set; }

    public string DeviceToken { get; set; }

    public string DevicePlatform { get; set; }

    public string NotificationPriority { get; set; }

    public int NotificationPickedStatus { get; set; }

    public int NotificationStatus { get; set; }

    public string NotificationTitle { get; set; }

    public string NotificationText { get; set; }

    public DateTime SentOn { get; set; }

    public string NotificationData { get; set; }

    public string ChatPickedBy { get; set; }

    public DateTime ChatStartedAt { get; set; }

    public DateTime? ChatEndedAt { get; set; }
    public bool IsActive { get; set; }
}
public enum ChatStatusEnum
{
    /// <summary>
    /// The chat has been initiated by the visitor, but not picked up by the agent
    /// </summary>
    AwaitingPickup = 1,
    /// <summary>
    /// The chat has been picked up by an agent
    /// </summary>
    Active = 2,
    /// <summary>
    /// All users have left the chat
    /// </summary>
    Inactive = 3,
    /// <summary>
    /// A chat instance has triggered, but we don't want to show in the dash yet
    /// </summary>
    Requested = 4,
    /// <summary>
    /// The chat is currently being handled by the Virtual Assistant
    /// </summary>
    BotHandling = 5,
    /// <summary>
    /// The chat is currently being handled by the Script Bot
    /// </summary>
    ScriptBotHandling = 6,
    /// <summary>
    /// The chat is idled for certain amount of time (which is less then chat end time) is marked as shelved
    /// </summary>
    Shelved = 7
}
public enum ChatInitiatedBy
{
    Unknown = 0,
    Bar = 1,
    [Obsolete]
    Dom = 2,
    [Obsolete]
    Window = 3,
    Static = 4,
    Standard = 5,
    Tab = 6,
    ExitPopup = 7,
    SmsStatic = 8,
    SmsContainer = 9,
    FacebookMessenger = 10,
    Video = 11,
    PreChat = 12
}
