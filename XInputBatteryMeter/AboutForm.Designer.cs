namespace XInputBatteryMeter
{
    partial class AboutForm
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
            this.headerPanel = new System.Windows.Forms.Panel();
            this.appLogo = new System.Windows.Forms.PictureBox();
            this.titlePanel = new System.Windows.Forms.Panel();
            this.versionLabel = new System.Windows.Forms.Label();
            this.subtitleLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.licenseGroupBox = new System.Windows.Forms.GroupBox();
            this.copyrightPanel = new System.Windows.Forms.Panel();
            this.licenseLabel = new System.Windows.Forms.Label();
            this.acknowledgementsPanel = new System.Windows.Forms.Panel();
            this.sharpDxLicenseLabel = new System.Windows.Forms.Label();
            this.sharpDxLinkLabel = new System.Windows.Forms.LinkLabel();
            this.controllerIconAcknowledgement = new System.Windows.Forms.Label();
            this.controllerIconLicenseLinkLabel = new System.Windows.Forms.LinkLabel();
            this.controllerIconTitleLinkLabel = new System.Windows.Forms.LinkLabel();
            this.acknowledgementsTitle = new System.Windows.Forms.Label();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Button();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appLogo)).BeginInit();
            this.titlePanel.SuspendLayout();
            this.licenseGroupBox.SuspendLayout();
            this.copyrightPanel.SuspendLayout();
            this.acknowledgementsPanel.SuspendLayout();
            this.footerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.White;
            this.headerPanel.Controls.Add(this.appLogo);
            this.headerPanel.Controls.Add(this.titlePanel);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(764, 190);
            this.headerPanel.TabIndex = 0;
            // 
            // appLogo
            // 
            this.appLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.appLogo.Location = new System.Drawing.Point(548, 12);
            this.appLogo.Name = "appLogo";
            this.appLogo.Size = new System.Drawing.Size(204, 175);
            this.appLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.appLogo.TabIndex = 3;
            this.appLogo.TabStop = false;
            // 
            // titlePanel
            // 
            this.titlePanel.Controls.Add(this.versionLabel);
            this.titlePanel.Controls.Add(this.subtitleLabel);
            this.titlePanel.Controls.Add(this.titleLabel);
            this.titlePanel.Location = new System.Drawing.Point(12, 12);
            this.titlePanel.Name = "titlePanel";
            this.titlePanel.Size = new System.Drawing.Size(530, 175);
            this.titlePanel.TabIndex = 2;
            // 
            // versionLabel
            // 
            this.versionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.versionLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionLabel.Location = new System.Drawing.Point(0, 107);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.versionLabel.Size = new System.Drawing.Size(530, 68);
            this.versionLabel.TabIndex = 2;
            this.versionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // subtitleLabel
            // 
            this.subtitleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.subtitleLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtitleLabel.Location = new System.Drawing.Point(0, 64);
            this.subtitleLabel.Name = "subtitleLabel";
            this.subtitleLabel.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.subtitleLabel.Size = new System.Drawing.Size(530, 43);
            this.subtitleLabel.TabIndex = 1;
            // 
            // titleLabel
            // 
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI Light", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(0, 0);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(530, 64);
            this.titleLabel.TabIndex = 0;
            // 
            // licenseGroupBox
            // 
            this.licenseGroupBox.AutoSize = true;
            this.licenseGroupBox.Controls.Add(this.copyrightPanel);
            this.licenseGroupBox.Controls.Add(this.acknowledgementsPanel);
            this.licenseGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.licenseGroupBox.Location = new System.Drawing.Point(0, 190);
            this.licenseGroupBox.Name = "licenseGroupBox";
            this.licenseGroupBox.Size = new System.Drawing.Size(764, 372);
            this.licenseGroupBox.TabIndex = 6;
            this.licenseGroupBox.TabStop = false;
            // 
            // copyrightPanel
            // 
            this.copyrightPanel.Controls.Add(this.licenseLabel);
            this.copyrightPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.copyrightPanel.Location = new System.Drawing.Point(3, 157);
            this.copyrightPanel.Margin = new System.Windows.Forms.Padding(15);
            this.copyrightPanel.Name = "copyrightPanel";
            this.copyrightPanel.Padding = new System.Windows.Forms.Padding(20, 8, 20, 8);
            this.copyrightPanel.Size = new System.Drawing.Size(758, 212);
            this.copyrightPanel.TabIndex = 6;
            // 
            // licenseLabel
            // 
            this.licenseLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.licenseLabel.Location = new System.Drawing.Point(20, 8);
            this.licenseLabel.Name = "licenseLabel";
            this.licenseLabel.Size = new System.Drawing.Size(718, 196);
            this.licenseLabel.TabIndex = 2;
            this.licenseLabel.Text = "LICENSE";
            // 
            // acknowledgementsPanel
            // 
            this.acknowledgementsPanel.Controls.Add(this.sharpDxLicenseLabel);
            this.acknowledgementsPanel.Controls.Add(this.sharpDxLinkLabel);
            this.acknowledgementsPanel.Controls.Add(this.controllerIconAcknowledgement);
            this.acknowledgementsPanel.Controls.Add(this.controllerIconLicenseLinkLabel);
            this.acknowledgementsPanel.Controls.Add(this.controllerIconTitleLinkLabel);
            this.acknowledgementsPanel.Controls.Add(this.acknowledgementsTitle);
            this.acknowledgementsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.acknowledgementsPanel.Location = new System.Drawing.Point(3, 16);
            this.acknowledgementsPanel.Name = "acknowledgementsPanel";
            this.acknowledgementsPanel.Size = new System.Drawing.Size(758, 141);
            this.acknowledgementsPanel.TabIndex = 5;
            // 
            // sharpDxLicenseLabel
            // 
            this.sharpDxLicenseLabel.AutoSize = true;
            this.sharpDxLicenseLabel.Location = new System.Drawing.Point(85, 97);
            this.sharpDxLicenseLabel.Name = "sharpDxLicenseLabel";
            this.sharpDxLicenseLabel.Padding = new System.Windows.Forms.Padding(5);
            this.sharpDxLicenseLabel.Size = new System.Drawing.Size(10, 23);
            this.sharpDxLicenseLabel.TabIndex = 5;
            // 
            // sharpDxLinkLabel
            // 
            this.sharpDxLinkLabel.AutoSize = true;
            this.sharpDxLinkLabel.Location = new System.Drawing.Point(16, 97);
            this.sharpDxLinkLabel.Name = "sharpDxLinkLabel";
            this.sharpDxLinkLabel.Padding = new System.Windows.Forms.Padding(5);
            this.sharpDxLinkLabel.Size = new System.Drawing.Size(10, 23);
            this.sharpDxLinkLabel.TabIndex = 4;
            this.sharpDxLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SharpDxLinkLabel_LinkClicked);
            // 
            // controllerIconAcknowledgement
            // 
            this.controllerIconAcknowledgement.AutoSize = true;
            this.controllerIconAcknowledgement.Location = new System.Drawing.Point(16, 74);
            this.controllerIconAcknowledgement.Name = "controllerIconAcknowledgement";
            this.controllerIconAcknowledgement.Padding = new System.Windows.Forms.Padding(5);
            this.controllerIconAcknowledgement.Size = new System.Drawing.Size(10, 23);
            this.controllerIconAcknowledgement.TabIndex = 3;
            // 
            // controllerIconLicenseLinkLabel
            // 
            this.controllerIconLicenseLinkLabel.AutoSize = true;
            this.controllerIconLicenseLinkLabel.Location = new System.Drawing.Point(170, 51);
            this.controllerIconLicenseLinkLabel.Name = "controllerIconLicenseLinkLabel";
            this.controllerIconLicenseLinkLabel.Padding = new System.Windows.Forms.Padding(5);
            this.controllerIconLicenseLinkLabel.Size = new System.Drawing.Size(10, 23);
            this.controllerIconLicenseLinkLabel.TabIndex = 2;
            this.controllerIconLicenseLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.CreativeCommonsLinkLabel_LinkClicked);
            // 
            // controllerIconTitleLinkLabel
            // 
            this.controllerIconTitleLinkLabel.AutoSize = true;
            this.controllerIconTitleLinkLabel.Location = new System.Drawing.Point(16, 51);
            this.controllerIconTitleLinkLabel.Name = "controllerIconTitleLinkLabel";
            this.controllerIconTitleLinkLabel.Padding = new System.Windows.Forms.Padding(5);
            this.controllerIconTitleLinkLabel.Size = new System.Drawing.Size(10, 23);
            this.controllerIconTitleLinkLabel.TabIndex = 0;
            this.controllerIconTitleLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ControllerIconLinkLabel_LinkClicked);
            // 
            // acknowledgementsTitle
            // 
            this.acknowledgementsTitle.AutoSize = true;
            this.acknowledgementsTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acknowledgementsTitle.Location = new System.Drawing.Point(15, 7);
            this.acknowledgementsTitle.Name = "acknowledgementsTitle";
            this.acknowledgementsTitle.Padding = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.acknowledgementsTitle.Size = new System.Drawing.Size(93, 44);
            this.acknowledgementsTitle.TabIndex = 1;
            this.acknowledgementsTitle.Text = "License";
            // 
            // footerPanel
            // 
            this.footerPanel.Controls.Add(this.closeButton);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(0, 576);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Padding = new System.Windows.Forms.Padding(0, 5, 15, 15);
            this.footerPanel.Size = new System.Drawing.Size(764, 65);
            this.footerPanel.TabIndex = 8;
            // 
            // closeButton
            // 
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.closeButton.Location = new System.Drawing.Point(621, 5);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(128, 45);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // AboutForm
            // 
            this.ClientSize = new System.Drawing.Size(764, 641);
            this.Controls.Add(this.footerPanel);
            this.Controls.Add(this.licenseGroupBox);
            this.Controls.Add(this.headerPanel);
            this.Name = "AboutForm";
            this.headerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.appLogo)).EndInit();
            this.titlePanel.ResumeLayout(false);
            this.licenseGroupBox.ResumeLayout(false);
            this.copyrightPanel.ResumeLayout(false);
            this.acknowledgementsPanel.ResumeLayout(false);
            this.acknowledgementsPanel.PerformLayout();
            this.footerPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.PictureBox appLogo;
        private System.Windows.Forms.Panel titlePanel;
        private System.Windows.Forms.Label subtitleLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.GroupBox licenseGroupBox;
        private System.Windows.Forms.Panel acknowledgementsPanel;
        private System.Windows.Forms.Label sharpDxLicenseLabel;
        private System.Windows.Forms.LinkLabel sharpDxLinkLabel;
        private System.Windows.Forms.Label controllerIconAcknowledgement;
        private System.Windows.Forms.LinkLabel controllerIconLicenseLinkLabel;
        private System.Windows.Forms.LinkLabel controllerIconTitleLinkLabel;
        private System.Windows.Forms.Panel copyrightPanel;
        private System.Windows.Forms.Label licenseLabel;
        private System.Windows.Forms.Label acknowledgementsTitle;
        private System.Windows.Forms.Panel footerPanel;
        private System.Windows.Forms.Button closeButton;
    }
}