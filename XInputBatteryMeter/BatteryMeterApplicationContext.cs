using SharpDX.XInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace XInputBatteryMeter
{
    public class BatteryMeterApplicationContext : ApplicationContext
    {
        private NotifyIcon _notifyIcon;
        private BatteryStatusPoller _poller;

        public BatteryMeterApplicationContext(BatteryStatusPoller poller)
        {
            _poller = poller;
            poller.Controller_Connected += Controller_Connected;
            poller.Controller_BatteryLow += Controller_BatteryLow;

            _notifyIcon = new NotifyIcon()
            {
                Icon = Properties.Resources.AppIcon,
                ContextMenu = new ContextMenu(),
                Visible = true
            };

            _notifyIcon.ContextMenu.Popup += ContextMenu_Popup;

            foreach (var controller in _poller.Controllers)
            {
                var mainMenuItem = new MenuItem() { Name = $"Controller{controller.UserIndex}_Main" };
                var batteryTypeMenuItem = new MenuItem() { Enabled = false, Name = $"Controller{controller.UserIndex}_BatteryType" };
                var batteryLevelMenuItem = new MenuItem() { Enabled = false, Name = $"Controller{controller.UserIndex}_BatteryLevel" };

                UpdateControllerStatus(controller, ref mainMenuItem, ref batteryTypeMenuItem, ref batteryLevelMenuItem);
                
                _notifyIcon.ContextMenu.MenuItems.Add(mainMenuItem);
                _notifyIcon.ContextMenu.MenuItems.Add(batteryTypeMenuItem);
                _notifyIcon.ContextMenu.MenuItems.Add(batteryLevelMenuItem);
                _notifyIcon.ContextMenu.MenuItems.Add("-");
            }

            MenuItem aboutItem = new MenuItem("About", new EventHandler(About_Clicked)) { Name = "About" };
            MenuItem exitItem = new MenuItem("Exit", new EventHandler(Exit_Clicked)) { Name = "Exit" };

            _notifyIcon.ContextMenu.MenuItems.Add(aboutItem);
            _notifyIcon.ContextMenu.MenuItems.Add(exitItem);
        }


        private void ContextMenu_Popup(object sender, EventArgs e)
        {
            // Refresh the controller information.
            foreach (var controller in _poller.Controllers)
            {
                var menuItems = _notifyIcon.ContextMenu.MenuItems.Cast<MenuItem>();

                var mainMenuItem = menuItems.FirstOrDefault(x => x.Name.Equals($"Controller{controller.UserIndex}_Main"));
                var batteryTypeMenuItem = menuItems.FirstOrDefault(x => x.Name.Equals($"Controller{controller.UserIndex}_BatteryType"));
                var batteryLevelMenuItem = menuItems.FirstOrDefault(x => x.Name.Equals($"Controller{controller.UserIndex}_BatteryLevel"));

                UpdateControllerStatus(controller, ref mainMenuItem, ref batteryTypeMenuItem, ref batteryLevelMenuItem);
            }
        }

        /// <summary>
        /// Updates the specified menu item parameters with the latest Battery information for the specified Controller.
        /// </summary>
        /// <param name="controller">The controller to query Battery Information for.</param>
        /// <param name="mainMenuItem">The Main Menu Item for the controller.</param>
        /// <param name="batteryTypeMenuItem">The Battery Type Menu Item for the controller.</param>
        /// <param name="batteryLevelMenuItem">The Battery Level Menu Item for the controller.</param>
        private void UpdateControllerStatus(Controller controller, ref MenuItem mainMenuItem, ref MenuItem batteryTypeMenuItem, ref MenuItem batteryLevelMenuItem)
        {
            if (controller.IsConnected && _poller.ControllerBatteryInformation.ContainsKey(controller.UserIndex))
            {
                var batteryInfo = _poller.ControllerBatteryInformation[controller.UserIndex];
                mainMenuItem.Text = $"Controller {controller.UserIndex}";
                batteryTypeMenuItem.Text = $"Battery Type: {batteryInfo.BatteryType.ToString()}";
                batteryLevelMenuItem.Text = $"Battery Level: {batteryInfo.BatteryLevel.ToString()}";
                mainMenuItem.Enabled = true;
                batteryTypeMenuItem.Visible = true;
                batteryLevelMenuItem.Visible = true;
            }
            else
            {
                mainMenuItem.Text = $"Controller {controller.UserIndex} is not connected.";
                mainMenuItem.Enabled = false;
                batteryTypeMenuItem.Visible = false;
                batteryLevelMenuItem.Visible = false;
            }
        }

        private void About_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Exit_Clicked(object sender, EventArgs e)
        {
            _notifyIcon.Visible = false;
            Application.Exit();
        }

        private void Controller_BatteryLow(object sender, UserIndex e)
        {
            _notifyIcon.ShowBalloonTip(0, "Battery Low", $"The battery in controller {e} is low.", ToolTipIcon.None);
        }

        private void Controller_Connected(object sender, UserIndex e)
        {
            _notifyIcon.ShowBalloonTip(0, "Controller Connected", $"Controller {e} has been connected.", ToolTipIcon.None);
        }
    }
}
