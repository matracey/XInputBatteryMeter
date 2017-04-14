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
        private List<Controller> _controllers;

        public BatteryMeterApplicationContext(List<Controller> controllers)
        {
            _controllers = controllers;

            _notifyIcon = new NotifyIcon()
            {
                Icon = Properties.Resources.AppIcon,
                ContextMenu = new ContextMenu(),
                Visible = true
            };

            foreach (var controller in _controllers)
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

        /// <summary>
        /// Updates the specified menu item parameters with the latest Battery information for the specified Controller.
        /// </summary>
        /// <param name="controller">The controller to query Battery Information for.</param>
        /// <param name="mainMenuItem">The Main Menu Item for the controller.</param>
        /// <param name="batteryTypeMenuItem">The Battery Type Menu Item for the controller.</param>
        /// <param name="batteryLevelMenuItem">The Battery Level Menu Item for the controller.</param>
        private void UpdateControllerStatus(Controller controller, ref MenuItem mainMenuItem, ref MenuItem batteryTypeMenuItem, ref MenuItem batteryLevelMenuItem)
        {
            if (controller.IsConnected)
            {
                var batteryInfo = controller.GetBatteryInformation(BatteryDeviceType.Gamepad);
                mainMenuItem.Text = $"Controller {controller.UserIndex}";
                batteryTypeMenuItem.Text = $"Battery Type: {batteryInfo.BatteryType.ToString()}";
                batteryLevelMenuItem.Text = $"Battery Level: {batteryInfo.BatteryLevel.ToString()}";
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
    }
}
