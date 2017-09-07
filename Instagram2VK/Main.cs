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
            bLoadContent.Click += BLoadContent_Click;
            bPostToVK.Click += BPostToVK_Click;
        }

        #region Events
        private void BPostToVK_Click(object sender, EventArgs e)
        {
            BPostToVKEvent?.Invoke(this, EventArgs.Empty);
        }

        private void BGetToken_Click(object sender, EventArgs e)
        {
            BGetTockenEvent?.Invoke(this, EventArgs.Empty);
        }

        private void BGenerateTocken_Click(object sender, EventArgs e)
        {
            BGenerateTockenEvent?.Invoke(this, EventArgs.Empty);
        }

        private void BLoadContent_Click(object sender, EventArgs e)
        {
            BLoadContentEvent?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region IMain
        public event EventHandler BLoadContentEvent;
        public event EventHandler BGetTockenEvent;
        public event EventHandler BGenerateTockenEvent;
        public event EventHandler BPostToVKEvent;

        public WebBrowser Browser => webBrowser1;

        public TabControl TabContainer => tCMainContainer;

        public string QueryId => tBQueryId.Text;
        public string InstagramPage => tBInstagramPage.Text;
        public string VkGroup => tBVkGroup.Text;
        public string TimeFrom => tBTimeFrom.Text;
        public string TimeTo => tBTimeTo.Text;

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

        public string BtnLoadContentText
        {
            set
            {
                var settextAction = new Action(() => { bLoadContent.Text = value; });

                if (bLoadContent.InvokeRequired)
                    bLoadContent.Invoke(settextAction);
                else
                    settextAction();
            }
        }

        public bool ToggleBtnGetToken
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

        public bool ToggleBtnGenerateTocken
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

        public bool ToggleBtnLoadContent
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

        public bool ToggleBtnPostToVK
        {
            set
            {
                var settextAction = new Action(() => { bPostToVK.Enabled = value; });

                if (bPostToVK.InvokeRequired)
                    bPostToVK.Invoke(settextAction);
                else
                    settextAction();
            }
        }

        public string SetMessageProgress
        {
            set
            {
                var settextAction = new Action(() => { lPostingProgress.Text = value; });

                if (lPostingProgress.InvokeRequired)
                    lPostingProgress.Invoke(settextAction);
                else
                    settextAction();
            }
        }

        public int SetMessageMaxValue
        {
            set
            {
                var settextAction = new Action(() => { pBPostingProgress.Maximum = value; });

                if (pBPostingProgress.InvokeRequired)
                    pBPostingProgress.Invoke(settextAction);
                else
                    settextAction();
            }
        }

        public int SetMessageValue
        {
            set
            {
                var settextAction = new Action(() => { pBPostingProgress.Value = value; });

                if (pBPostingProgress.InvokeRequired)
                    pBPostingProgress.Invoke(settextAction);
                else
                    settextAction();
            }
        }
        #endregion
    }
}
