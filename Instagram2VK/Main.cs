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
    public partial class Main : Form, IMain
    {
        public Main()
        {
            InitializeComponent();

            tCMainContainer.SelectTab("tabOptions");
            bGenerateTocken.Click += BGenerateTocken_Click;
            bGetToken.Click += BGetToken_Click;
            bLoadContent.Click += BLoadContent_Click; ;
        }

        private void BGetToken_Click(object sender, EventArgs e)
        {
            BGetTocken?.Invoke(this, EventArgs.Empty);
        }

        private void BGenerateTocken_Click(object sender, EventArgs e)
        {
            BGenerateTocken?.Invoke(this, EventArgs.Empty);
        }

        #region Events
        private void BLoadContent_Click(object sender, EventArgs e)
        {
            BLoadContent?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region IMain
        public event EventHandler BLoadContent;
        public event EventHandler BGetTocken;
        public event EventHandler BGenerateTocken;

        public WebBrowser Browser => webBrowser1;

        public TabControl TabContainer => tCMainContainer;

        public string QueryId => tBQueryId.Text;
        public string InstagramPage => tBInstagramPage.Text;

        public string Token
        {
            set
            {
                var settextAction = new Action(() => { tBToken.Text = value; });

                if (tBToken.InvokeRequired)
                    tBToken.Invoke(settextAction);
                else
                    settextAction();
            }
        }

        public string UserId
        {
            set
            {
                var settextAction = new Action(() => { tBUserId.Text = value; });

                if (tBUserId.InvokeRequired)
                    tBUserId.Invoke(settextAction);
                else
                    settextAction();
            }
        }

        public string ExpiresIn
        {
            set
            {
                var settextAction = new Action(() => { tBExpiresIn.Text = value; });

                if (tBExpiresIn.InvokeRequired)
                    tBExpiresIn.Invoke(settextAction);
                else
                    settextAction();
            }
        }

        public string IToken
        {
            set
            {
                var settextAction = new Action(() => { tBIToken.Text = value; });

                if (tBIToken.InvokeRequired)
                    tBIToken.Invoke(settextAction);
                else
                    settextAction();
            }
        }

        public string IOwner
        {
            set
            {
                var settextAction = new Action(() => { tBOwner.Text = value; });

                if (tBOwner.InvokeRequired)
                    tBOwner.Invoke(settextAction);
                else
                    settextAction();
            }
        }

        public bool TogleBtnGetToken
        {
            set
            {
                var settextAction = new Action(() => { bGetToken.Enabled = value; });

                if (bGetToken.InvokeRequired)
                    bGetToken.Invoke(settextAction);
                else
                    settextAction();
            }
        }

        public bool TogleBtnGenerateTocken
        {
            set
            {
                var settextAction = new Action(() => { bGenerateTocken.Enabled = value; });

                if (bGenerateTocken.InvokeRequired)
                    bGenerateTocken.Invoke(settextAction);
                else
                    settextAction();
            }
        }

        public bool TogleBtnLoadContent
        {
            set
            {
                var settextAction = new Action(() => { bLoadContent.Enabled = value; });

                if (bLoadContent.InvokeRequired)
                    bLoadContent.Invoke(settextAction);
                else
                    settextAction();
            }
        }
        #endregion
    }
}
