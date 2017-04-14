using System;
using System.Windows.Forms;

namespace XInputBatteryMeter
{
    public class Program
    {
        public Program()
        {
        }

        public static void Main()
        {
            Console.WriteLine("Initializing.");

            var poller = new BatteryStatusPoller();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BatteryMeterApplicationContext(poller.Controllers));

        }
    }
}
