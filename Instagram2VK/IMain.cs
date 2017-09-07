using System;
using System.Windows.Forms;

namespace Instagram2VK
{
    public interface IMain
    {
        WebBrowser Browser { get; }
        bool TogleBtnGenerateTocken { set; }
        bool TogleBtnGetToken { set; }
        string InstagramPage { get; }
        string QueryId { get; }
        TabControl TabContainer { get; }

        event EventHandler BGenerateTocken;
        event EventHandler BGetTocken;
        event EventHandler BLoadContent;
    }
}