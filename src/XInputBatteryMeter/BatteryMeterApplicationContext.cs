using System.ComponentModel;

using AutoUpdaterDotNET;

using SharpDX.XInput;

using XInputBatteryMeter.Helpers;
using XInputBatteryMeter.Properties;
using XInputBatteryMeter.Views;

namespace XInputBatteryMeter;

public class BatteryMeterApplicationContext : ApplicationContext
{
    private readonly NotifyIcon _notifyIcon;
    private readonly BatteryStatusPoller _poller;
    private Controller? _activeController;

#if DEBUG
    private const string PrimaryUpdateUrl = "http://localhost:3000/xinput-battery-meter-update/update.xml";
#else
    private const string PrimaryUpdateUrl = "https://matracey.github.io/xinput-battery-meter-update/update.xml";
#endif

    /// <summary>
    ///     Creates a new BatteryMeterApplicationContext instance using the specified BatteryStatusPoller.
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
        _notifyIcon = new NotifyIcon { Icon = Resources.AppIcon, ContextMenuStrip = new ContextMenuStrip(), Visible = true, Text = Resources.AppName };

        _notifyIcon.ContextMenuStrip.Opening += ContextMenu_Opening;

        foreach (Controller controller in _poller.Controllers)
        {
            ToolStripMenuItem mainMenuItem = new() { Name = $"Controller{controller.UserIndex}_Main" };
            ToolStripMenuItem batteryTypeMenuItem = new() { Enabled = false, Name = $"Controller{controller.UserIndex}_BatteryType" };
            ToolStripMenuItem batteryLevelMenuItem = new() { Enabled = false, Name = $"Controller{controller.UserIndex}_BatteryLevel" };
            mainMenuItem.Click += MainMenuItem_Click;

            if (_notifyIcon.ContextMenuStrip.InvokeRequired)
            {
                _notifyIcon.ContextMenuStrip.Invoke((MethodInvoker)delegate { UpdateControllerStatus(controller, ref mainMenuItem, ref batteryTypeMenuItem, ref batteryLevelMenuItem); });
            }
            else
            {
                UpdateControllerStatus(controller, ref mainMenuItem, ref batteryTypeMenuItem, ref batteryLevelMenuItem);
            }

            _notifyIcon.ContextMenuStrip.Items.Add(mainMenuItem);
            _notifyIcon.ContextMenuStrip.Items.Add(batteryTypeMenuItem);
            _notifyIcon.ContextMenuStrip.Items.Add(batteryLevelMenuItem);
            _notifyIcon.ContextMenuStrip.Items.Add("-");
        }

        ToolStripMenuItem aboutItem = new(Resources.AboutMenuItem, null, About_Clicked) { Name = "About" };
        ToolStripMenuItem exitItem = new(Resources.ExitMenuItem, null, Exit_Clicked) { Name = "Exit" };

        _notifyIcon.ContextMenuStrip.Items.Add(aboutItem);
        _notifyIcon.ContextMenuStrip.Items.Add(exitItem);

        UpdateActiveController();

        AutoUpdater.Start(PrimaryUpdateUrl);
    }

    /// <summary>
    ///     Handles the Context Menu popup event, refreshing the battery information in each of the menu items.
    /// </summary>
    /// <param name="sender">The object that triggered this event.</param>
    /// <param name="cancelEventArgs">The EventArgs.</param>
    private void ContextMenu_Opening(object? sender, CancelEventArgs cancelEventArgs)
    {
        ToolStripItem[] menuItems = _notifyIcon.ContextMenuStrip?.Items.Cast<ToolStripItem>().ToArray() ?? [];
        // Refresh the controller information.
        foreach (Controller controller in _poller.Controllers)
        {
            ToolStripMenuItem? mainMenuItem = menuItems.FirstMenuItemWithName($"Controller{controller.UserIndex}_Main");
            ToolStripMenuItem? batteryTypeMenuItem = menuItems.FirstMenuItemWithName($"Controller{controller.UserIndex}_BatteryType");
            ToolStripMenuItem? batteryLevelMenuItem = menuItems.FirstMenuItemWithName($"Controller{controller.UserIndex}_BatteryLevel");

            if (mainMenuItem == null || batteryTypeMenuItem == null || batteryLevelMenuItem == null)
            {
                continue;
            }

            if (_notifyIcon.ContextMenuStrip?.InvokeRequired ?? false)
            {
                _notifyIcon.ContextMenuStrip.Invoke((MethodInvoker)delegate
                {
                    UpdateControllerStatus(controller, ref mainMenuItem, ref batteryTypeMenuItem, ref batteryLevelMenuItem);
                });
            }
            else
            {
                UpdateControllerStatus(controller, ref mainMenuItem, ref batteryTypeMenuItem, ref batteryLevelMenuItem);
            }
        }
    }

    /// <summary>
    ///     Updates the specified menu item parameters with the latest Battery information for the specified Controller.
    /// </summary>
    /// <param name="controller">The controller to query Battery Information for.</param>
    /// <param name="mainMenuItem">The Main Menu Item for the controller.</param>
    /// <param name="batteryTypeMenuItem">The Battery Type Menu Item for the controller.</param>
    /// <param name="batteryLevelMenuItem">The Battery Level Menu Item for the controller.</param>
    private void UpdateControllerStatus(Controller controller, ref ToolStripMenuItem mainMenuItem, ref ToolStripMenuItem batteryTypeMenuItem, ref ToolStripMenuItem batteryLevelMenuItem)
    {
        if (controller.IsConnected && _poller.ControllerBatteryInformation.TryGetValue(controller.UserIndex, out BatteryInformation batteryInfo))
        {
            mainMenuItem.Text = Resources.ControllerDescriptor + controller.UserIndex;
            batteryTypeMenuItem.Text = Resources.BatteryTypeDescriptor + batteryInfo.BatteryType;
            batteryLevelMenuItem.Text = Resources.BatteryLevelDescriptor + batteryInfo.BatteryLevel;
            mainMenuItem.Enabled = true;
            batteryTypeMenuItem.Visible = true;
            batteryLevelMenuItem.Visible = true;
        }
        else
        {
            mainMenuItem.Text = Resources.ControllerDescriptor + controller.UserIndex + Resources.NotConnected;
            mainMenuItem.Enabled = false;
            batteryTypeMenuItem.Visible = false;
            batteryLevelMenuItem.Visible = false;
        }
    }

    private static void About_Clicked(object? sender, EventArgs e)
    {
        AboutForm about = new();
        about.Show();
    }

    private void Exit_Clicked(object? sender, EventArgs e)
    {
        _notifyIcon.Visible = false;
        Application.Exit();
    }

    private void Controller_BatteryLow(object? sender, UserIndexEventArgs e)
    {
        _notifyIcon.ShowBalloonTip(0, Resources.BatteryLowTitle, Resources.BatteryLowDescription.Replace(Resources.UserIndexPlaceholder, e.UserIndex.ToString()), ToolTipIcon.None);
    }

    private void Controller_Connected(object? sender, UserIndexEventArgs e)
    {
        UpdateActiveController();
        _notifyIcon.ShowBalloonTip(0, Resources.ControllerConnectedTitle, Resources.ControllerConnectedDescription.Replace(Resources.UserIndexPlaceholder, e.UserIndex.ToString()), ToolTipIcon.None);
    }

    private void Controller_Disconnected(object? sender, UserIndexEventArgs e)
    {
        UpdateActiveController();
        _notifyIcon.ShowBalloonTip(0, Resources.ControllerDisconnectedTitle, Resources.ControllerDisconnectedDescription.Replace(Resources.UserIndexPlaceholder, e.UserIndex.ToString()), ToolTipIcon.None);
    }

    private void Controller_BatteryInformationUpdated(object? sender, UserIndexEventArgs e)
    {
        if (_activeController?.UserIndex != e.UserIndex)
        {
            return;
        }

        UpdateAppTrayIcon(_poller.ControllerBatteryInformation[e.UserIndex]);
        UpdateAppTrayText(_poller.Controllers.FirstOrDefault(c => c.UserIndex == e.UserIndex), _poller.ControllerBatteryInformation[e.UserIndex]);
    }

    private void MainMenuItem_Click(object? sender, EventArgs e)
    {
        ToolStripItem? menuItem = sender as ToolStripItem;
        UpdateActiveController(_poller.Controllers.FirstOrDefault(c => menuItem?.Name == $"Controller{c.UserIndex}_Main"));
    }

    private void UpdateActiveController(Controller? selectedController = null)
    {
        // Will be null if no controllers connected.
        selectedController ??= _poller.Controllers.FirstOrDefault(c => c.IsConnected);

        if (selectedController != null)
        {
            if (_activeController != null && _activeController.UserIndex == selectedController.UserIndex)
            {
                return;
            }

            UpdateSelected<ToolStripMenuItem>(false);
            _activeController = selectedController;

            UpdateSelected<ToolStripMenuItem>(true, x => x.Name?.Equals($"Controller{selectedController.UserIndex}_Main") ?? false);

            if (!_poller.ControllerBatteryInformation.ContainsKey(selectedController.UserIndex))
            {
                return;
            }

            UpdateAppTrayIcon(_poller.ControllerBatteryInformation[selectedController.UserIndex]);
            UpdateAppTrayText(selectedController, _poller.ControllerBatteryInformation[selectedController.UserIndex]);
        }
        else
        {
            UpdateSelected<ToolStripMenuItem>(false);
            _activeController = null;
            ResetAppTrayIcon();
        }
    }

    private void ResetAppTrayIcon()
    {
        _notifyIcon.Icon = Resources.AppIcon;
    }

    private void UpdateAppTrayText(Controller? controller, BatteryInformation batteryInformation)
    {
        if (controller == null)
        {
            return;
        }

        _notifyIcon.Text = Resources.NotificationIconText
            .Replace(Resources.UserIndexPlaceholder, controller.UserIndex.ToString())
            .Replace(Resources.BatteryTypePlaceholder, batteryInformation.BatteryType.ToString())
            .Replace(Resources.BatteryLevelPlaceholder, batteryInformation.BatteryLevel.ToString());
    }

    private void UpdateSelected<T>(bool isSelected, Func<T, bool>? scopePredicate = null) where T : ToolStripMenuItem
    {
        IEnumerable<T>? items = _notifyIcon.ContextMenuStrip?.Items.OfType<T>();
        if (scopePredicate != null)
        {
            items = items?.Where(scopePredicate);
        }

        if (_notifyIcon.ContextMenuStrip?.InvokeRequired ?? false)
        {
            _notifyIcon.ContextMenuStrip.Invoke((MethodInvoker)delegate
            {
                foreach (T item in items ?? [])
                {
                    item.Checked = isSelected;
                }
            });
        }
        else
        {
            foreach (T item in items ?? [])
            {
                item.Checked = isSelected;
            }
        }
    }

    private void UpdateAppTrayIcon(BatteryInformation batteryInformation)
    {
        _notifyIcon.Icon = batteryInformation.BatteryLevel switch
        {
            BatteryLevel.Empty => Resources.batteryIcon_0,
            BatteryLevel.Low => Resources.batteryIcon_33,
            BatteryLevel.Medium => Resources.batteryIcon_66,
            BatteryLevel.Full => Resources.batteryIcon_100,
            _ => Resources.AppIcon
        };
    }
}