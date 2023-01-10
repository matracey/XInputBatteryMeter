using System.Runtime.InteropServices;

namespace XInputBatteryMeter.Models
{
    [StructLayout(LayoutKind.Sequential)]
    struct XINPUT_STATE
    {
        public uint dwPacketNumber;
        public XINPUT_GAMEPAD Gamepad;
    }
}