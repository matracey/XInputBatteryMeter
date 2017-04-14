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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.headerPanel = new System.Windows.Forms.Panel();
            this.appLogo = new System.Windows.Forms.PictureBox();
            this.titlePanel = new System.Windows.Forms.Panel();
            this.versionLabel = new System.Windows.Forms.Label();
            this.subtitleLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.copyrightLine1Label = new System.Windows.Forms.Label();
            this.copyrightLine2Label = new System.Windows.Forms.Label();
            this.copyrightPanel = new System.Windows.Forms.Panel();
            this.copyrightLine4Label = new System.Windows.Forms.Label();
            this.copyrightLine3Label = new System.Windows.Forms.Label();
            this.acknowledgementsPanel = new System.Windows.Forms.Panel();
            this.sharpDxLicenseLabel = new System.Windows.Forms.Label();
            this.sharpDxLinkLabel = new System.Windows.Forms.LinkLabel();
            this.controllerIconAcknowledgement = new System.Windows.Forms.Label();
            this.controllerIconLicenseLinkLabel = new System.Windows.Forms.LinkLabel();
            this.controllerIconLinkLabel = new System.Windows.Forms.LinkLabel();
            this.acknowledgementsTitle = new System.Windows.Forms.Label();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appLogo)).BeginInit();
            this.titlePanel.SuspendLayout();
            this.copyrightPanel.SuspendLayout();
            this.acknowledgementsPanel.SuspendLayout();
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
            this.appLogo.Location = new System.Drawing.Point(588, 12);
            this.appLogo.Name = "appLogo";
            this.appLogo.Size = new System.Drawing.Size(164, 175);
            this.appLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
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
            this.versionLabel.Size = new System.Drawing.Size(530, 68);
            this.versionLabel.TabIndex = 2;
            this.versionLabel.Text = "Version 1.0";
            this.versionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // subtitleLabel
            // 
            this.subtitleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.subtitleLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtitleLabel.Location = new System.Drawing.Point(0, 64);
            this.subtitleLabel.Name = "subtitleLabel";
            this.subtitleLabel.Size = new System.Drawing.Size(530, 43);
            this.subtitleLabel.TabIndex = 1;
            this.subtitleLabel.Text = "Displays a battery meter for connected XInput controller devices in the Windows t" +
    "askbar.";
            // 
            // titleLabel
            // 
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI Light", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(0, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(530, 64);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "XInput Battery Meter";
            // 
            // copyrightLine1Label
            // 
            this.copyrightLine1Label.Dock = System.Windows.Forms.DockStyle.Top;
            this.copyrightLine1Label.Location = new System.Drawing.Point(8, 8);
            this.copyrightLine1Label.Name = "copyrightLine1Label";
            this.copyrightLine1Label.Size = new System.Drawing.Size(748, 23);
            this.copyrightLine1Label.TabIndex = 2;
            this.copyrightLine1Label.Text = "Copyright © 2017 Martin Tracey";
            // 
            // copyrightLine2Label
            // 
            this.copyrightLine2Label.Dock = System.Windows.Forms.DockStyle.Top;
            this.copyrightLine2Label.Location = new System.Drawing.Point(8, 31);
            this.copyrightLine2Label.Name = "copyrightLine2Label";
            this.copyrightLine2Label.Size = new System.Drawing.Size(748, 63);
            this.copyrightLine2Label.TabIndex = 1;
            this.copyrightLine2Label.Text = resources.GetString("copyrightLine2Label.Text");
            // 
            // copyrightPanel
            // 
            this.copyrightPanel.Controls.Add(this.copyrightLine4Label);
            this.copyrightPanel.Controls.Add(this.copyrightLine3Label);
            this.copyrightPanel.Controls.Add(this.copyrightLine2Label);
            this.copyrightPanel.Controls.Add(this.copyrightLine1Label);
            this.copyrightPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.copyrightPanel.Location = new System.Drawing.Point(0, 331);
            this.copyrightPanel.Margin = new System.Windows.Forms.Padding(15);
            this.copyrightPanel.Name = "copyrightPanel";
            this.copyrightPanel.Padding = new System.Windows.Forms.Padding(8);
            this.copyrightPanel.Size = new System.Drawing.Size(764, 193);
            this.copyrightPanel.TabIndex = 3;
            // 
            // copyrightLine4Label
            // 
            this.copyrightLine4Label.Dock = System.Windows.Forms.DockStyle.Top;
            this.copyrightLine4Label.Location = new System.Drawing.Point(8, 131);
            this.copyrightLine4Label.Name = "copyrightLine4Label";
            this.copyrightLine4Label.Size = new System.Drawing.Size(748, 62);
            this.copyrightLine4Label.TabIndex = 4;
            this.copyrightLine4Label.Text = resources.GetString("copyrightLine4Label.Text");
            // 
            // copyrightLine3Label
            // 
            this.copyrightLine3Label.Dock = System.Windows.Forms.DockStyle.Top;
            this.copyrightLine3Label.Location = new System.Drawing.Point(8, 94);
            this.copyrightLine3Label.Name = "copyrightLine3Label";
            this.copyrightLine3Label.Size = new System.Drawing.Size(748, 37);
            this.copyrightLine3Label.TabIndex = 3;
            this.copyrightLine3Label.Text = "The above copyright notice and this permission notice shall be included in all co" +
    "pies or substantial portions of the Software.";
            // 
            // acknowledgementsPanel
            // 
            this.acknowledgementsPanel.Controls.Add(this.sharpDxLicenseLabel);
            this.acknowledgementsPanel.Controls.Add(this.sharpDxLinkLabel);
            this.acknowledgementsPanel.Controls.Add(this.controllerIconAcknowledgement);
            this.acknowledgementsPanel.Controls.Add(this.controllerIconLicenseLinkLabel);
            this.acknowledgementsPanel.Controls.Add(this.controllerIconLinkLabel);
            this.acknowledgementsPanel.Controls.Add(this.acknowledgementsTitle);
            this.acknowledgementsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.acknowledgementsPanel.Location = new System.Drawing.Point(0, 190);
            this.acknowledgementsPanel.Name = "acknowledgementsPanel";
            this.acknowledgementsPanel.Size = new System.Drawing.Size(764, 141);
            this.acknowledgementsPanel.TabIndex = 4;
            // 
            // sharpDxLicenseLabel
            // 
            this.sharpDxLicenseLabel.AutoSize = true;
            this.sharpDxLicenseLabel.Location = new System.Drawing.Point(88, 107);
            this.sharpDxLicenseLabel.Name = "sharpDxLicenseLabel";
            this.sharpDxLicenseLabel.Padding = new System.Windows.Forms.Padding(5);
            this.sharpDxLicenseLabel.Size = new System.Drawing.Size(76, 23);
            this.sharpDxLicenseLabel.TabIndex = 5;
            this.sharpDxLicenseLabel.Text = "MIT License";
            // 
            // sharpDxLinkLabel
            // 
            this.sharpDxLinkLabel.AutoSize = true;
            this.sharpDxLinkLabel.Location = new System.Drawing.Point(19, 107);
            this.sharpDxLinkLabel.Name = "sharpDxLinkLabel";
            this.sharpDxLinkLabel.Padding = new System.Windows.Forms.Padding(5);
            this.sharpDxLinkLabel.Size = new System.Drawing.Size(63, 23);
            this.sharpDxLinkLabel.TabIndex = 4;
            this.sharpDxLinkLabel.TabStop = true;
            this.sharpDxLinkLabel.Text = "SharpDX:";
            this.sharpDxLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SharpDxLinkLabel_LinkClicked);
            // 
            // controllerIconAcknowledgement
            // 
            this.controllerIconAcknowledgement.AutoSize = true;
            this.controllerIconAcknowledgement.Location = new System.Drawing.Point(19, 84);
            this.controllerIconAcknowledgement.Name = "controllerIconAcknowledgement";
            this.controllerIconAcknowledgement.Padding = new System.Windows.Forms.Padding(5);
            this.controllerIconAcknowledgement.Size = new System.Drawing.Size(293, 23);
            this.controllerIconAcknowledgement.TabIndex = 3;
            this.controllerIconAcknowledgement.Text = "Video Game Controller by Uriel Sosa from the Noun Project";
            // 
            // controllerIconLicenseLinkLabel
            // 
            this.controllerIconLicenseLinkLabel.AutoSize = true;
            this.controllerIconLicenseLinkLabel.Location = new System.Drawing.Point(173, 61);
            this.controllerIconLicenseLinkLabel.Name = "controllerIconLicenseLinkLabel";
            this.controllerIconLicenseLinkLabel.Padding = new System.Windows.Forms.Padding(5);
            this.controllerIconLicenseLinkLabel.Size = new System.Drawing.Size(84, 23);
            this.controllerIconLicenseLinkLabel.TabIndex = 2;
            this.controllerIconLicenseLinkLabel.TabStop = true;
            this.controllerIconLicenseLinkLabel.Text = "CC BY 3.0 US";
            this.controllerIconLicenseLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.CreativeCommonsLinkLabel_LinkClicked);
            // 
            // controllerIconLinkLabel
            // 
            this.controllerIconLinkLabel.AutoSize = true;
            this.controllerIconLinkLabel.Location = new System.Drawing.Point(19, 61);
            this.controllerIconLinkLabel.Name = "controllerIconLinkLabel";
            this.controllerIconLinkLabel.Padding = new System.Windows.Forms.Padding(5);
            this.controllerIconLinkLabel.Size = new System.Drawing.Size(148, 23);
            this.controllerIconLinkLabel.TabIndex = 0;
            this.controllerIconLinkLabel.TabStop = true;
            this.controllerIconLinkLabel.Text = "Video Game Controller icon:";
            this.controllerIconLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ControllerIconLinkLabel_LinkClicked);
            // 
            // acknowledgementsTitle
            // 
            this.acknowledgementsTitle.AutoSize = true;
            this.acknowledgementsTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acknowledgementsTitle.Location = new System.Drawing.Point(18, 7);
            this.acknowledgementsTitle.Name = "acknowledgementsTitle";
            this.acknowledgementsTitle.Padding = new System.Windows.Forms.Padding(5, 15, 5, 15);
            this.acknowledgementsTitle.Size = new System.Drawing.Size(203, 54);
            this.acknowledgementsTitle.TabIndex = 1;
            this.acknowledgementsTitle.Text = "Acknowledgements";
            // 
            // footerPanel
            // 
            this.footerPanel.BackColor = System.Drawing.Color.White;
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Location = new System.Drawing.Point(0, 542);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(764, 58);
            this.footerPanel.TabIndex = 5;
            // 
            // AboutForm
            // 
            this.ClientSize = new System.Drawing.Size(764, 600);
            this.Controls.Add(this.footerPanel);
            this.Controls.Add(this.copyrightPanel);
            this.Controls.Add(this.acknowledgementsPanel);
            this.Controls.Add(this.headerPanel);
            this.Name = "AboutForm";
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appLogo)).EndInit();
            this.titlePanel.ResumeLayout(false);
            this.copyrightPanel.ResumeLayout(false);
            this.acknowledgementsPanel.ResumeLayout(false);
            this.acknowledgementsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.PictureBox appLogo;
        private System.Windows.Forms.Panel titlePanel;
        private System.Windows.Forms.Label subtitleLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label copyrightLine1Label;
        private System.Windows.Forms.Label copyrightLine2Label;
        private System.Windows.Forms.Panel copyrightPanel;
        private System.Windows.Forms.Label copyrightLine3Label;
        private System.Windows.Forms.Label copyrightLine4Label;
        private System.Windows.Forms.Panel acknowledgementsPanel;
        private System.Windows.Forms.Label controllerIconAcknowledgement;
        private System.Windows.Forms.LinkLabel controllerIconLicenseLinkLabel;
        private System.Windows.Forms.LinkLabel controllerIconLinkLabel;
        private System.Windows.Forms.Label acknowledgementsTitle;
        private System.Windows.Forms.Label sharpDxLicenseLabel;
        private System.Windows.Forms.LinkLabel sharpDxLinkLabel;
        private System.Windows.Forms.Panel footerPanel;
    }
}