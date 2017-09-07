using System;
using System.Windows.Forms;

namespace Instagram2VK
{
    public interface IMain
    {
        WebBrowser Browser { get; }
        string ExpiresIn { set; }
        string InstagramPage { get; }
        string IOwner { set; }
        string IToken { set; }
        string QueryId { get; }
        TabControl TabContainer { get; }
        bool TogleBtnGenerateTocken { set; }
        bool TogleBtnGetToken { set; }
        bool TogleBtnLoadContent { set; }
        string Token { set; }
        string UserId { set; }

        event EventHandler BGenerateTocken;
        event EventHandler BGetTocken;
        event EventHandler BLoadContent;
    }
}