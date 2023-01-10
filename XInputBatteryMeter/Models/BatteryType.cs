namespace XInputBatteryMeter.Models
{
    public enum BatteryType
    {
        Disconnected = 0x00,
        Wired = 0x01,
        Alkaline = 0x02,
        Nimh = 0x03,
        Unknown = 0xFF,
    }
}