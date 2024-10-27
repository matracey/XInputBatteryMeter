using System.Diagnostics;
using System.Reflection;

using XInputBatteryMeter.Properties;

namespace XInputBatteryMeter.Views;

public partial class AboutForm : Form
{
    public AboutForm()
    {
        InitializeComponent();

        SetResources();

        MaximizeBox = false;
        MinimizeBox = false;
        FormBorderStyle = FormBorderStyle.FixedSingle;

        appLogo.BackgroundImage = Resources.ControllerIcon;
        appLogo.BackgroundImageLayout = ImageLayout.Zoom;
    }

    private void SetResources()
    {
        Text = Resources.AboutPageTitle;
        Icon = Resources.AppIcon;
        titleLabel.Text = Resources.AppName;
        subtitleLabel.Text = Resources.AppDescription;
        versionLabel.Text = Resources.VersionString + FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;

        acknowledgementsTitle.Text = Resources.AcknowledgementsTitle;

        controllerIconTitleLinkLabel.Text = Resources.AcknowledgementsControllerIconTitle;
        controllerIconLicenseLinkLabel.Text = Resources.AcknowledgementsControllerIconLicense;
        controllerIconAcknowledgement.Text = Resources.AcknowledgementsControllerIconAck;

        sharpDxLinkLabel.Text = Resources.AcknowledgementsSharpDxTitle;
        sharpDxLicenseLabel.Text = Resources.AcknowledgementsSharpDxLicense;

        licenseLabel.Text = Resources.LicenseText;

        closeButton.Text = Resources.CloseButtonText;
    }

    private void ControllerIconLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        Process.Start(Resources.ControllerIconUrl);
    }

    private void CreativeCommonsLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        Process.Start(Resources.CreativeCommonsUrl);
    }

    private void SharpDxLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        Process.Start(Resources.SharpdxLicenseUrl);
    }

    private void CloseButton_Click(object sender, EventArgs e)
    {
        Close();
    }
}