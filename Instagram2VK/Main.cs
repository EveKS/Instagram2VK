using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Instagram2VK
{
    public interface IMain
    {
        string QueryId { get; }
        string InstagramPage { get; }

        event EventHandler BLoadContent;
    }

    public partial class Main : Form, IMain
    {
        public Main()
        {
            InitializeComponent();

            tCMainContainer.SelectTab("tabOptions");
            bLoadContent.Click += BLoadContent_Click; ;
        }

        #region Events
        private void BLoadContent_Click(object sender, EventArgs e)
        {
            BLoadContent?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region IMain
        public event EventHandler BLoadContent;

        public WebBrowser Browser => webBrowser1;

        public TabControl TabContainer => tCMainContainer;

        public string QueryId => tBQueryId.Text;
        public string InstagramPage => tBInstagramPage.Text;
        #endregion
    }
}
