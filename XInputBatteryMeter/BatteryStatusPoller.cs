using SharpDX.XInput;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;

namespace XInputBatteryMeter
{
    public class BatteryStatusPoller
    {
        // Public properties
        public List<Controller> Controllers { get; set; }

        // Private fields
        private Timer _pollTimer;
        private int _pollCount;

        public BatteryStatusPoller()
        {
            Controllers = new List<Controller>
            {
                new Controller(UserIndex.One),
                new Controller(UserIndex.Two),
                new Controller(UserIndex.Three),
                new Controller(UserIndex.Four)
            };

            foreach (Controller controller in Controllers)
                Trace.WriteLine($"Controller {controller.UserIndex.ToString()}" + (controller.IsConnected ? " Is Connected" : " Is Not Connected"));

            _pollCount = 0;

            _pollTimer = new Timer()
            {
                Interval = Convert.ToInt32(TimeSpan.FromSeconds(1).TotalMilliseconds)
            };

            _pollTimer.Elapsed += new ElapsedEventHandler(PollTimer_Elapsed);

            _pollTimer.Start();
        }

        // This will run when the timer expires.
        public void PollTimer_Elapsed(Object myObject, EventArgs mytEventArgs)
        {
            _pollTimer.Stop();

            foreach (Controller controller in Controllers)
            {
                if (controller.IsConnected)
                {
                    var battery = controller.GetBatteryInformation(BatteryDeviceType.Gamepad);
                    Trace.WriteLine($"Controller {controller.UserIndex.ToString()}: {battery.BatteryType.ToString()} {battery.BatteryLevel.ToString()}");
                }
            }

            _pollCount += 1;
            _pollTimer.Enabled = true;
        }
    }
}
