using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SharpDX.XInput;

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

            var poller = new XInputWrapperBatteryStatusPoller();

            while (true)
            {

            }

        }
    }
}
