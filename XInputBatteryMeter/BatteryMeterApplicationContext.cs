using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using XInputBatteryMeter.Models;
using XInputBatteryMeter.Properties;

namespace XInputBatteryMeter
{
    public partial class BatteryMeterApplicationContext : ApplicationContext
    {
        private readonly NotifyIcon _notifyIcon;
        private readonly BatteryStatusPoller _poller;
        private IntPtr? _activeController;
        private uint? _activeControllerIndex;

        [DllImport("xinput1_4.dll")]
        private static extern uint XInputGetBatteryInformation(IntPtr hDevice, byte devType, ref XInputBatteryInformation pBatteryInformation);

        [DllImport("xinput1_4.dll")]
        private static extern uint XInputGetState(uint dwUserIndex, ref XINPUT_STATE pState);

#if DEBUG
        private const string _primaryUpdateUrl = "http://localhost:3000/xinput-battery-meter-update/update.xml";
#else
        private const string _primaryUpdateUrl = "https://matracey.github.io/xinput-battery-meter-update/update.xml";
#endif

        /// <summary>
        /// Creates a new BatteryMeterApplicationContext instance using the specified BatteryStatusPoller.
        /// </summary>
        /// <param name="poller">The BatteryStatusPoller that will query battery status.</param>
        public BatteryMeterApplicationContext(BatteryStatusPoller poller)
        {
            // Set up the poller values.
            _poller = poller;
            poller.ControllerConnected += Controller_Connected;
            poller.ControllerDisconnected += Controller_Disconnected;
            poller.ControllerBatteryLow += Controller_BatteryLow;
            poller.ControllerBatteryInformationUpdated += Controller_BatteryInformationUpdated;

            // Set up the Notification icon.
            _notifyIcon = new NotifyIcon
            {
                Icon = Resources.AppIcon,
                ContextMenuStrip = new ContextMenuStrip(),
                Visible = true,
                Text = Resources.AppName
            };

            _notifyIcon.ContextMenuStrip.Opening += new CancelEventHandler(ContextMenu_Opening);

            foreach (var controller in _poller.Controllers)
            {
                var mainMenuItem = new ToolStripMenuItem { Name = $"Controller{controller.UserIndex}_Main" };
                var batteryTypeMenuItem = new ToolStripMenuItem { Enabled = false, Name = $"Controller{controller.UserIndex}_BatteryType" };
                var batteryLevelMenuItem = new ToolStripMenuItem { Enabled = false, Name = $"Controller{controller.UserIndex}_BatteryLevel" };
                mainMenuItem.Click += MainMenuItem_Click;

                var updateMethod = (MethodInvoker)delegate { UpdateControllerStatus(controller, ref mainMenuItem, ref batteryTypeMenuItem, ref batteryLevelMenuItem); };
                if (_notifyIcon.ContextMenuStrip.InvokeRequired)
                {
                    _notifyIcon.ContextMenuStrip.Invoke(updateMethod);
                }
                else
                {
                    updateMethod();
                }

                _notifyIcon.ContextMenuStrip.Items.Add(mainMenuItem);
                _notifyIcon.ContextMenuStrip.Items.Add(batteryTypeMenuItem);
                _notifyIcon.ContextMenuStrip.Items.Add(batteryLevelMenuItem);
                _notifyIcon.ContextMenuStrip.Items.Add("-");
            }

            var aboutItem = new ToolStripMenuItem(Resources.AboutMenuItem, null, About_Clicked) { Name = "About" };
            var exitItem = new ToolStripMenuItem(Resources.ExitMenuItem, null, Exit_Clicked) { Name = "Exit" };

            _notifyIcon.ContextMenuStrip.Items.Add(aboutItem);
            _notifyIcon.ContextMenuStrip.Items.Add(exitItem);

            UpdateActiveController();

            AutoUpdaterDotNET.AutoUpdater.Start(_primaryUpdateUrl);
        }

        /// <summary>
        /// Handles the Context Menu popup event, refreshing the battery information in each of the menu items.
        /// </summary>
        /// <param name="sender">The object that triggered this event.</param>
        /// <param name="e">The EventArgs.</param>
        private void ContextMenu_Opening(object sender, EventArgs e)
        {
            // Refresh the controller information.
            foreach (var controller in _poller.Controllers)
            {
                var menuItems = _notifyIcon.ContextMenuStrip.Items.Cast<ToolStripItem>();

                var mainMenuItem = menuItems.FirstOrDefault(x => x.Name.Equals($"Controller{controller.UserIndex}_Main")) as ToolStripMenuItem;
                var batteryTypeMenuItem = menuItems.FirstOrDefault(x => x.Name.Equals($"Controller{controller.UserIndex}_BatteryType")) as ToolStripMenuItem;
                var batteryLevelMenuItem = menuItems.FirstOrDefault(x => x.Name.Equals($"Controller{controller.UserIndex}_BatteryLevel")) as ToolStripMenuItem;

                var updateMethod = (MethodInvoker)delegate { UpdateControllerStatus(controller, ref mainMenuItem, ref batteryTypeMenuItem, ref batteryLevelMenuItem); };
                if (_notifyIcon.ContextMenuStrip.InvokeRequired)
                {
                    _notifyIcon.ContextMenuStrip.Invoke(updateMethod);
                }
                else
                {
                    updateMethod();
                }
            }
        }

        /// <summary>
        /// Updates the specified menu item parameters with the latest Battery information for the specified Controller.
        /// </summary>
        /// <param name="controller">The controller to query Battery Information for.</param>
        /// <param name="mainMenuItem">The Main Menu Item for the controller.</param>
        /// <param name="batteryTypeMenuItem">The Battery Type Menu Item for the controller.</param>
        /// <param name="batteryLevelMenuItem">The Battery Level Menu Item for the controller.</param>
        private void UpdateControllerStatus(IntPtr controller, ref ToolStripMenuItem mainMenuItem, ref ToolStripMenuItem batteryTypeMenuItem, ref ToolStripMenuItem batteryLevelMenuItem)
        {
            var batteryInformation = new XInputBatteryInformation();
            var result = XInputGetBatteryInformation(controller, (byte)BatteryDeviceType.Gamepad, ref batteryInformation);

            if (result == 0)
            {
                mainMenuItem.Text = $"Controller {(uint)controller}";
                batteryTypeMenuItem.Text = $"Battery Type: {batteryInformation.BatteryType}";
                batteryLevelMenuItem.Text = $"Battery Level: {batteryInformation.BatteryLevel}";
            }
            else
            {
                mainMenuItem.Text = $"Controller {(uint)controller} (Not Connected)";
                batteryTypeMenuItem.Enabled = false;
                batteryLevelMenuItem.Enabled = false;
            }
        }

        private void About_Clicked(object sender, EventArgs e)
        {
            var about = new AboutForm();
            about.Show();
        }

        private void Exit_Clicked(object sender, EventArgs e)
        {
            _notifyIcon.Visible = false;
            Application.Exit();
        }

        private void Controller_BatteryLow(object sender, UserIndexEventArgs e)
        {
            _notifyIcon.ShowBalloonTip(0, Resources.BatteryLowTitle, Resources.BatteryLowDescription.Replace(Resources.UserIndexPlaceholder, e.UserIndex.ToString()), ToolTipIcon.None);
        }

        private void Controller_Connected(object sender, UserIndexEventArgs e)
        {
            UpdateActiveController();
            _notifyIcon.ShowBalloonTip(0, Resources.ControllerConnectedTitle, Resources.ControllerConnectedDescription.Replace(Resources.UserIndexPlaceholder, e.UserIndex.ToString()), ToolTipIcon.None);
        }

        private void Controller_Disconnected(object sender, UserIndexEventArgs e)
        {
            UpdateActiveController();
            _notifyIcon.ShowBalloonTip(0, Resources.ControllerDisconnectedTitle, Resources.ControllerDisconnectedDescription.Replace(Resources.UserIndexPlaceholder, e.UserIndex.ToString()), ToolTipIcon.None);
        }

        private void Controller_BatteryInformationUpdated(object sender, UserIndexEventArgs e)
        {
            if (_activeControllerIndex != e.UserIndex) return;
            UpdateAppTrayIcon(_poller.ControllerBatteryInformation[e.UserIndex]);
            UpdateAppTrayText(_poller.Controllers.FirstOrDefault(c => c.UserIndex == e.UserIndex), _poller.ControllerBatteryInformation[e.UserIndex]);
        }

        private void MainMenuItem_Click(object sender, EventArgs e)
        {
            var menuItem = (ToolStripItem)sender;
            UpdateActiveController(_poller.Controllers.FirstOrDefault(c => menuItem.Name == $"Controller{c.UserIndex}_Main"));
        }

        private static uint? GetControllerUserIndex(IntPtr controller)
        {
            var state = new XINPUT_STATE();
            var result = XInputGetState((uint)controller, ref state);
            if (result == 0)
            {
                return state.dwPacketNumber;
            }
            else
            {
                // TODO: Handle the error
                return null;
            }
        }

        private void UpdateActiveController(IntPtr? selectedController = null)
        {
            // Will be null if no controllers connected.
            selectedController ??= _poller.Controllers.FirstOrDefault(c => c.IsConnected);

            if (selectedController.HasValue)
            {
                var selectedControllerIndex = GetControllerUserIndex(selectedController.Value);
                if (_activeController != null && _activeControllerIndex == selectedControllerIndex) return;
                UpdateSelected<ToolStripMenuItem>(false);
                _activeController = selectedController;
                _activeControllerIndex = selectedControllerIndex;

                UpdateSelected<ToolStripMenuItem>(true, x => x.Name.Equals($"Controller{selectedControllerIndex}_Main"));

                if (!_poller.ControllerBatteryInformation.ContainsKey(selectedControllerIndex)) return;
                UpdateAppTrayIcon(_poller.ControllerBatteryInformation[selectedControllerIndex]);
                UpdateAppTrayText(selectedController, _poller.ControllerBatteryInformation[selectedControllerIndex]);
            }
            else
            {
                UpdateSelected<ToolStripMenuItem>(false);
                _activeController = null;
                _activeControllerIndex = null;
                ResetAppTrayIcon();
            }
        }

        private void ResetAppTrayIcon()
        {
            _notifyIcon.Icon = Resources.AppIcon;
        }

        private void UpdateAppTrayText(IntPtr controller, XInputBatteryInformation batteryInformation)
        {
            _notifyIcon.Text = Resources.NotificationIconText
                .Replace(Resources.UserIndexPlaceholder, controller.UserIndex.ToString())
                .Replace(Resources.BatteryTypePlaceholder, batteryInformation.BatteryType.ToString())
                .Replace(Resources.BatteryLevelPlaceholder, batteryInformation.BatteryLevel.ToString());
        }

        private void UpdateSelected<T>(bool isSelected, Func<T, bool> scopePredicate = null) where T : ToolStripMenuItem
        {
            var items = _notifyIcon.ContextMenuStrip.Items.OfType<T>();
            if (scopePredicate != null)
            {
                items = items.Where(scopePredicate);
            }

            var run = (MethodInvoker)delegate
            {
                foreach (var item in items)
                {
                    item.Checked = isSelected;
                }
            };

            if (_notifyIcon.ContextMenuStrip.InvokeRequired)
            {
                _notifyIcon.ContextMenuStrip.Invoke(run);
            }
            else
            {
                run();
            }
        }

        private void UpdateAppTrayIcon(XInputBatteryInformation batteryInformation)
        {
            _notifyIcon.Icon = batteryInformation.BatteryLevel switch
            {
                BatteryLevel.Empty => Resources.batteryIcon_0,
                BatteryLevel.Low => Resources.batteryIcon_33,
                BatteryLevel.Medium => Resources.batteryIcon_66,
                BatteryLevel.Full => Resources.batteryIcon_100,
                _ => Resources.AppIcon,
            };
        }
    }
}