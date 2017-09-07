namespace Instagram2VK
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tCMainContainer = new System.Windows.Forms.TabControl();
            this.tabBrowser = new System.Windows.Forms.TabPage();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.tabOptions = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.bGenerateTocken = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tBToken = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tBQueryId = new System.Windows.Forms.TextBox();
            this.tBInstagramPage = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tBVkGroup = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.bLoadContent = new System.Windows.Forms.Button();
            this.tBUserId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tBExpiresIn = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tBIToken = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tBOwner = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.bGetToken = new System.Windows.Forms.Button();
            this.bPostToVK = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.tBTimeFrom = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tBTimeTo = new System.Windows.Forms.TextBox();
            this.tCMainContainer.SuspendLayout();
            this.tabBrowser.SuspendLayout();
            this.tabOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // tCMainContainer
            // 
            this.tCMainContainer.Controls.Add(this.tabBrowser);
            this.tCMainContainer.Controls.Add(this.tabOptions);
            this.tCMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tCMainContainer.Location = new System.Drawing.Point(0, 0);
            this.tCMainContainer.Name = "tCMainContainer";
            this.tCMainContainer.SelectedIndex = 0;
            this.tCMainContainer.Size = new System.Drawing.Size(884, 561);
            this.tCMainContainer.TabIndex = 0;
            // 
            // tabBrowser
            // 
            this.tabBrowser.Controls.Add(this.webBrowser1);
            this.tabBrowser.Location = new System.Drawing.Point(4, 22);
            this.tabBrowser.Name = "tabBrowser";
            this.tabBrowser.Padding = new System.Windows.Forms.Padding(3);
            this.tabBrowser.Size = new System.Drawing.Size(876, 535);
            this.tabBrowser.TabIndex = 0;
            this.tabBrowser.Text = "Browser";
            this.tabBrowser.UseVisualStyleBackColor = true;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(3, 3);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(870, 529);
            this.webBrowser1.TabIndex = 0;
            // 
            // tabOptions
            // 
            this.tabOptions.Controls.Add(this.tBTimeTo);
            this.tabOptions.Controls.Add(this.label12);
            this.tabOptions.Controls.Add(this.label11);
            this.tabOptions.Controls.Add(this.tBTimeFrom);
            this.tabOptions.Controls.Add(this.label10);
            this.tabOptions.Controls.Add(this.bPostToVK);
            this.tabOptions.Controls.Add(this.bGetToken);
            this.tabOptions.Controls.Add(this.tBOwner);
            this.tabOptions.Controls.Add(this.label9);
            this.tabOptions.Controls.Add(this.tBIToken);
            this.tabOptions.Controls.Add(this.label8);
            this.tabOptions.Controls.Add(this.tBExpiresIn);
            this.tabOptions.Controls.Add(this.label7);
            this.tabOptions.Controls.Add(this.tBUserId);
            this.tabOptions.Controls.Add(this.label6);
            this.tabOptions.Controls.Add(this.bLoadContent);
            this.tabOptions.Controls.Add(this.tBInstagramPage);
            this.tabOptions.Controls.Add(this.label4);
            this.tabOptions.Controls.Add(this.tBVkGroup);
            this.tabOptions.Controls.Add(this.label5);
            this.tabOptions.Controls.Add(this.tBQueryId);
            this.tabOptions.Controls.Add(this.label3);
            this.tabOptions.Controls.Add(this.tBToken);
            this.tabOptions.Controls.Add(this.label2);
            this.tabOptions.Controls.Add(this.bGenerateTocken);
            this.tabOptions.Controls.Add(this.label1);
            this.tabOptions.Location = new System.Drawing.Point(4, 22);
            this.tabOptions.Name = "tabOptions";
            this.tabOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabOptions.Size = new System.Drawing.Size(876, 535);
            this.tabOptions.TabIndex = 1;
            this.tabOptions.Text = "Options";
            this.tabOptions.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(8, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Опции";
            // 
            // bGenerateTocken
            // 
            this.bGenerateTocken.Location = new System.Drawing.Point(15, 54);
            this.bGenerateTocken.Name = "bGenerateTocken";
            this.bGenerateTocken.Size = new System.Drawing.Size(108, 29);
            this.bGenerateTocken.TabIndex = 1;
            this.bGenerateTocken.Text = "Создать токен";
            this.bGenerateTocken.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(558, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Token:";
            // 
            // tBToken
            // 
            this.tBToken.Enabled = false;
            this.tBToken.Location = new System.Drawing.Point(638, 96);
            this.tBToken.Name = "tBToken";
            this.tBToken.Size = new System.Drawing.Size(230, 20);
            this.tBToken.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "QueryId:";
            // 
            // tBQueryId
            // 
            this.tBQueryId.Location = new System.Drawing.Point(92, 122);
            this.tBQueryId.Name = "tBQueryId";
            this.tBQueryId.Size = new System.Drawing.Size(230, 20);
            this.tBQueryId.TabIndex = 5;
            // 
            // tBInstagramPage
            // 
            this.tBInstagramPage.Location = new System.Drawing.Point(92, 200);
            this.tBInstagramPage.Name = "tBInstagramPage";
            this.tBInstagramPage.Size = new System.Drawing.Size(230, 20);
            this.tBInstagramPage.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "InstagramPage:";
            // 
            // tBVkGroup
            // 
            this.tBVkGroup.Location = new System.Drawing.Point(92, 171);
            this.tBVkGroup.Name = "tBVkGroup";
            this.tBVkGroup.Size = new System.Drawing.Size(230, 20);
            this.tBVkGroup.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "VkGroup:";
            // 
            // bLoadContent
            // 
            this.bLoadContent.Enabled = false;
            this.bLoadContent.Location = new System.Drawing.Point(328, 191);
            this.bLoadContent.Name = "bLoadContent";
            this.bLoadContent.Size = new System.Drawing.Size(120, 29);
            this.bLoadContent.TabIndex = 10;
            this.bLoadContent.Text = "Загрузать контент";
            this.bLoadContent.UseVisualStyleBackColor = true;
            // 
            // tBUserId
            // 
            this.tBUserId.Enabled = false;
            this.tBUserId.Location = new System.Drawing.Point(640, 122);
            this.tBUserId.Name = "tBUserId";
            this.tBUserId.Size = new System.Drawing.Size(230, 20);
            this.tBUserId.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(560, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "UserId:";
            // 
            // tBExpiresIn
            // 
            this.tBExpiresIn.Enabled = false;
            this.tBExpiresIn.Location = new System.Drawing.Point(640, 148);
            this.tBExpiresIn.Name = "tBExpiresIn";
            this.tBExpiresIn.Size = new System.Drawing.Size(230, 20);
            this.tBExpiresIn.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(560, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "ExpiresIn:";
            // 
            // tBIToken
            // 
            this.tBIToken.Enabled = false;
            this.tBIToken.Location = new System.Drawing.Point(640, 174);
            this.tBIToken.Name = "tBIToken";
            this.tBIToken.Size = new System.Drawing.Size(230, 20);
            this.tBIToken.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(560, 181);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "IToken:";
            // 
            // tBOwner
            // 
            this.tBOwner.Enabled = false;
            this.tBOwner.Location = new System.Drawing.Point(640, 200);
            this.tBOwner.Name = "tBOwner";
            this.tBOwner.Size = new System.Drawing.Size(230, 20);
            this.tBOwner.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(560, 207);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Owner:";
            // 
            // bGetToken
            // 
            this.bGetToken.Enabled = false;
            this.bGetToken.Location = new System.Drawing.Point(214, 54);
            this.bGetToken.Name = "bGetToken";
            this.bGetToken.Size = new System.Drawing.Size(108, 29);
            this.bGetToken.TabIndex = 19;
            this.bGetToken.Text = "Получить токен";
            this.bGetToken.UseVisualStyleBackColor = true;
            // 
            // bPostToVK
            // 
            this.bPostToVK.Enabled = false;
            this.bPostToVK.Location = new System.Drawing.Point(384, 253);
            this.bPostToVK.Name = "bPostToVK";
            this.bPostToVK.Size = new System.Drawing.Size(108, 29);
            this.bPostToVK.TabIndex = 20;
            this.bPostToVK.Text = "POST to VK";
            this.bPostToVK.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 261);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(139, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Время между постами от:";
            // 
            // tBTimeFrom
            // 
            this.tBTimeFrom.Location = new System.Drawing.Point(160, 258);
            this.tBTimeFrom.Name = "tBTimeFrom";
            this.tBTimeFrom.Size = new System.Drawing.Size(40, 20);
            this.tBTimeFrom.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(206, 261);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(22, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "до:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(285, 261);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "минут";
            // 
            // tBTimeTo
            // 
            this.tBTimeTo.Location = new System.Drawing.Point(234, 258);
            this.tBTimeTo.Name = "tBTimeTo";
            this.tBTimeTo.Size = new System.Drawing.Size(40, 20);
            this.tBTimeTo.TabIndex = 26;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.tCMainContainer);
            this.Name = "Main";
            this.Text = "Instagram2VK";
            this.tCMainContainer.ResumeLayout(false);
            this.tabBrowser.ResumeLayout(false);
            this.tabOptions.ResumeLayout(false);
            this.tabOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tCMainContainer;
        private System.Windows.Forms.TabPage tabBrowser;
        private System.Windows.Forms.TabPage tabOptions;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBToken;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bGenerateTocken;
        private System.Windows.Forms.TextBox tBQueryId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bLoadContent;
        private System.Windows.Forms.TextBox tBInstagramPage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tBVkGroup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tBUserId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tBExpiresIn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tBOwner;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tBIToken;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button bGetToken;
        private System.Windows.Forms.Button bPostToVK;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tBTimeFrom;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tBTimeTo;
        private System.Windows.Forms.Label label12;
    }
}

