using SharpDX.XInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XInputBatteryMeter
{
    public class BatteryMeterApplicationContext : ApplicationContext
    {
        private NotifyIcon _notifyIcon;
        private List<Controller> _controllers;

        public BatteryMeterApplicationContext(List<Controller> controllers)
        {
            _controllers = controllers;
            
            MenuItem exitItem = new MenuItem("Exit", new EventHandler(Exit));

            _notifyIcon = new NotifyIcon()
            {
                Icon = Properties.Resources.AppIcon,
                ContextMenu = new ContextMenu(new MenuItem[] { exitItem }),
                Visible = true
            };
        }
        private void Exit(object sender, EventArgs e)
        {
            _notifyIcon.Visible = false;
            Application.Exit();
        }
    }
}
