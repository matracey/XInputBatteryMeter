using System.Runtime.InteropServices;

namespace XInputBatteryMeter.Models
{
    [StructLayout(LayoutKind.Sequential)]
    struct XINPUT_GAMEPAD
     {
        public ushort wButtons;
        public byte bLeftTrigger;
        public byte bRightTrigger;
        public short sThumbLX;
        public short sThumbLY;
        public short sThumbRX;
        public short sThumbRY;
    }
}