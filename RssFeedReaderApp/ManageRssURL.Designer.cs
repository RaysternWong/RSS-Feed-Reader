﻿namespace RssFeedReaderApp
{
    partial class ManageRssURL
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txt_RssURL = new System.Windows.Forms.TextBox();
            this.lb_RssUrlStore = new System.Windows.Forms.ListBox();
            this.btn_addUrl = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "RSS URL :";
            // 
            // txt_RssURL
            // 
            this.txt_RssURL.Location = new System.Drawing.Point(89, 17);
            this.txt_RssURL.Name = "txt_RssURL";
            this.txt_RssURL.Size = new System.Drawing.Size(258, 20);
            this.txt_RssURL.TabIndex = 1;
            // 
            // lb_RssUrlStore
            // 
            this.lb_RssUrlStore.FormattingEnabled = true;
            this.lb_RssUrlStore.Location = new System.Drawing.Point(26, 74);
            this.lb_RssUrlStore.Name = "lb_RssUrlStore";
            this.lb_RssUrlStore.Size = new System.Drawing.Size(435, 199);
            this.lb_RssUrlStore.TabIndex = 2;
            // 
            // btn_addUrl
            // 
            this.btn_addUrl.Location = new System.Drawing.Point(363, 17);
            this.btn_addUrl.Name = "btn_addUrl";
            this.btn_addUrl.Size = new System.Drawing.Size(75, 23);
            this.btn_addUrl.TabIndex = 3;
            this.btn_addUrl.Text = "Add";
            this.btn_addUrl.UseVisualStyleBackColor = true;
            this.btn_addUrl.Click += new System.EventHandler(this.btn_addUrl_Click);
            // 
            // ManageRssURL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 299);
            this.Controls.Add(this.btn_addUrl);
            this.Controls.Add(this.lb_RssUrlStore);
            this.Controls.Add(this.txt_RssURL);
            this.Controls.Add(this.label1);
            this.Name = "ManageRssURL";
            this.Text = "ManageRssURL";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_RssURL;
        private System.Windows.Forms.ListBox lb_RssUrlStore;
        private System.Windows.Forms.Button btn_addUrl;
    }
}