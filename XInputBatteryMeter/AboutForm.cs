using System.Diagnostics;
using System.Windows.Forms;
using XInputBatteryMeter.Properties;

namespace XInputBatteryMeter
{
    public partial class AboutForm : Form
    {
        private const string ControllerIconUrl = "https://thenounproject.com/term/video-game-controller/8357/";
        private const string CreativeCommonsUrl = "https://creativecommons.org/licenses/by/3.0/us/";
        private const string SharpdxLicenseUrl = "http://sharpdx.org/License.txt";
        //private const string CONTROLLER_ICON_URL = "";

        public AboutForm()
        {
            InitializeComponent();
            appLogo.BackgroundImage = Resources.ControllerIcon;
            appLogo.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void ControllerIconLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(ControllerIconUrl);
        }

        private void CreativeCommonsLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(CreativeCommonsUrl);
        }

        private void SharpDxLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(SharpdxLicenseUrl);
        }
    }
}