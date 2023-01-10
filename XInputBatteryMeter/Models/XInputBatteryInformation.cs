using System.Runtime.InteropServices;

namespace XInputBatteryMeter.Models
{
    [StructLayout(LayoutKind.Sequential)]
    public struct XInputBatteryInformation
    {
        public BatteryType BatteryType;
        public BatteryLevel BatteryLevel;
    }
}