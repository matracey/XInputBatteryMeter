using SharpDX.XInput;

using Timer = System.Windows.Forms.Timer;

namespace XInputBatteryMeter;

public class BatteryStatusPoller
{
    private readonly Dictionary<UserIndex, bool> _connectedControllers;
    private readonly Dictionary<UserIndex, bool> _connectedControllersBatteryLow;
    private readonly Timer _pollTimer;

    // Private fields
    private int _pollCount;
    public EventHandler<UserIndexEventArgs>? ControllerBatteryInformationUpdated;
    public EventHandler<UserIndexEventArgs>? ControllerBatteryLow;
    public EventHandler<UserIndexEventArgs>? ControllerConnected;
    public EventHandler<UserIndexEventArgs>? ControllerDisconnected;

    public BatteryStatusPoller()
    {
        // Initialize the List of Controllers.
        Controllers =
        [
            new Controller(UserIndex.One),
            new Controller(UserIndex.Two),
            new Controller(UserIndex.Three),
            new Controller(UserIndex.Four)
        ];

        // Initialize the Battery Information Dictionary.
        ControllerBatteryInformation = new Dictionary<UserIndex, BatteryInformation>();

        _connectedControllers = new Dictionary<UserIndex, bool>();
        _connectedControllersBatteryLow = new Dictionary<UserIndex, bool>();

        foreach (Controller controller in Controllers)
        {
            _connectedControllers[controller.UserIndex] = controller.IsConnected;
            _connectedControllersBatteryLow[controller.UserIndex] = false;
        }

        _pollCount = 0;

        _pollTimer = new Timer
        {
            Interval = Convert.ToInt32(TimeSpan.FromSeconds(2.5).TotalMilliseconds)
        };

        _pollTimer.Tick += PollTimer_Tick;

        _pollTimer.Start();
    }

    // Public properties
    public List<Controller> Controllers { get; set; }
    public Dictionary<UserIndex, BatteryInformation> ControllerBatteryInformation { get; set; }

    // This will run when the timer expires.
    private void PollTimer_Tick(object? myObject, EventArgs mytEventArgs)
    {
        _pollTimer.Stop();

        if (_pollCount == 0)
        {
            Controllers =
            [
                new Controller(UserIndex.One),
                new Controller(UserIndex.Two),
                new Controller(UserIndex.Three),
                new Controller(UserIndex.Four)
            ];
        }

        foreach (Controller controller in Controllers)
        {
            if (controller.IsConnected)
            {
                // Check if this controller is a newly connected controller.
                if (_connectedControllers[controller.UserIndex] != true)
                {
                    ControllerConnected?.Invoke(this, new UserIndexEventArgs(controller.UserIndex));
                    _connectedControllers[controller.UserIndex] = true;
                }

                // Check if this controller has a low battery, where it wasn't previously low.
                BatteryInformation battery = controller.GetBatteryInformation(BatteryDeviceType.Gamepad);
                if (_connectedControllersBatteryLow[controller.UserIndex] != true && battery.BatteryLevel == BatteryLevel.Low)
                {
                    ControllerBatteryLow?.Invoke(this, new UserIndexEventArgs(controller.UserIndex));
                    _connectedControllersBatteryLow[controller.UserIndex] = true;
                }

                // Make the battery information publicly available.
                ControllerBatteryInformation[controller.UserIndex] = battery;
                ControllerBatteryInformationUpdated?.Invoke(this, new UserIndexEventArgs(controller.UserIndex));
            }
            else
            {
                // Check if this controller was a previously connected controller.
                if (!_connectedControllers[controller.UserIndex])
                {
                    continue;
                }

                ControllerDisconnected?.Invoke(this, new UserIndexEventArgs(controller.UserIndex));
                _connectedControllers[controller.UserIndex] = false;
            }
        }

        if (_pollCount % 5 == 0)
        {
            GC.Collect();
        }

        _pollCount += 1;
        _pollTimer.Enabled = true;
    }
}

public class UserIndexEventArgs : EventArgs
{
    public UserIndexEventArgs(UserIndex userIndex)
    {
        UserIndex = userIndex;
    }

    public UserIndex UserIndex { get; set; }
}