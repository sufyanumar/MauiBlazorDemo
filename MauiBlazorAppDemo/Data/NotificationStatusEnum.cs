using System;
namespace MauiBlazorAppDemo.Data
{
  
    public enum NotificationStatusEnum
    {
        /// <summary>
        /// The chat has been initiated by the visitor, but not picked up by the operator
        /// </summary>
        NotPicked = 1,
        /// <summary>
        /// The chat has been picked up by an operator
        /// </summary>
        Picked = 2,
        /// <summary>
        /// All users have left the chat
        /// </summary>
        Missed = 3,
        /// <summary>
        /// The chat has been rejected by operator
        /// </summary>
        Rejected = 4,

    }
}
