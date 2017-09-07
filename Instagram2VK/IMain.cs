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
        TabControl TabContainer { get; }
        bool ToggleBtnGenerateTocken { set; }
        bool ToggleBtnGetToken { set; }
        bool ToggleBtnLoadContent { set; }
        bool ToggleBtnPostToVK { set; }
        string Token { set; }
        string UserId { set; }

        event EventHandler BGenerateTockenEvent;
        event EventHandler BGetTockenEvent;
        event EventHandler BLoadContentEvent;
        event EventHandler BPostToVKEvent;
    }
}