using System;
using System.Windows.Forms;

namespace Instagram2VK
{
    public interface IMain
    {
        WebBrowser Browser { get; }
        string BtnLoadContentText { set; }
        string ExpiresIn { set; }
        string InstagramPage { get; }
        string IOwner { set; }
        string IToken { set; }
        string QueryId { get; }
        int SetMessageMaxValue { set; }
        string SetMessageProgress { set; }
        int SetMessageValue { set; }
        TabControl TabContainer { get; }
        string TimeFrom { get; }
        string TimeTo { get; }
        bool ToggleBtnGenerateTocken { set; }
        bool ToggleBtnGetToken { set; }
        bool ToggleBtnLoadContent { set; }
        bool ToggleBtnPostToVK { set; }
        string Token { set; }
        string UserId { set; }
        string VkGroup { get; }

        event EventHandler BGenerateTockenEvent;
        event EventHandler BGetTockenEvent;
        event EventHandler BLoadContentEvent;
        event EventHandler BPostToVKEvent;
    }
}