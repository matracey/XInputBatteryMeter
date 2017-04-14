using SharpDX.XInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace XInputBatteryMeter
{
    public class XInputWrapperBatteryStatusPoller
    {
        List<Controller> Controllers { get; set; }

        public Timer PollTimer { get; set; }

        public int PollCount { get; set; }

        public XInputWrapperBatteryStatusPoller()
        {
            Controllers = new List<Controller>
            {
                new Controller(UserIndex.One),
                new Controller(UserIndex.Two),
                new Controller(UserIndex.Three),
                new Controller(UserIndex.Four)
            };

            foreach (Controller controller in Controllers)
                Console.WriteLine($"Controller {controller.UserIndex.ToString()}" + (controller.IsConnected ? " Is Connected" : " Is Not Connected"));

            PollCount = 0;

            PollTimer = new Timer()
            {
                Interval = Convert.ToInt32(TimeSpan.FromSeconds(1).TotalMilliseconds)
            };

            PollTimer.Elapsed += new ElapsedEventHandler(WriteBatteryState);

            PollTimer.Start();
        }

        // This will run when the timer expires.
        public void WriteBatteryState(Object myObject, EventArgs mytEventArgs)
        {
            PollTimer.Stop();

            foreach (Controller controller in Controllers)
            {
                if (controller.IsConnected)
                {
                    var battery = controller.GetBatteryInformation(BatteryDeviceType.Gamepad);
                    Console.WriteLine($"Controller {controller.UserIndex.ToString()}: {battery.BatteryType.ToString()} {battery.BatteryLevel.ToString()}");
                }
            }

            PollCount += 1;
            PollTimer.Enabled = true;
        }
    }
}
