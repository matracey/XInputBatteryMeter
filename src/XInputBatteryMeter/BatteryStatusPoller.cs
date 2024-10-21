using System;
using System.Collections.Generic;
using System.Timers;

using SharpDX.XInput;

namespace XInputBatteryMeter;

public class BatteryStatusPoller
{
    private readonly Dictionary<UserIndex, bool> _connectedControllers;
    private readonly Dictionary<UserIndex, bool> _connectedControllersBatteryLow;
    private readonly Timer _pollTimer;

    // Private fields
    private int _pollCount;
    public EventHandler<UserIndexEventArgs> ControllerBatteryInformationUpdated;
    public EventHandler<UserIndexEventArgs> ControllerBatteryLow;
    public EventHandler<UserIndexEventArgs> ControllerConnected;
    public EventHandler<UserIndexEventArgs> ControllerDisconnected;

    public BatteryStatusPoller()
    {
        // Initialize the List of Controllers.
        Controllers = new List<Controller>
        {
            new(UserIndex.One),
            new(UserIndex.Two),
            new(UserIndex.Three),
            new(UserIndex.Four)
        };

        // Initialize the Battery Information Dictionary.
        ControllerBatteryInformation = new Dictionary<UserIndex, BatteryInformation>();

        _connectedControllers = new Dictionary<UserIndex, bool>();
        _connectedControllersBatteryLow = new Dictionary<UserIndex, bool>();

        foreach (var controller in Controllers)
        {
            _connectedControllers[controller.UserIndex] = controller.IsConnected;
            _connectedControllersBatteryLow[controller.UserIndex] = false;
        }

        _pollCount = 0;

        _pollTimer = new Timer
        {
            Interval = Convert.ToInt32(TimeSpan.FromSeconds(2.5).TotalMilliseconds)
        };

        _pollTimer.Elapsed += PollTimer_Elapsed;

        _pollTimer.Start();
    }

    // Public properties
    public List<Controller> Controllers { get; set; }
    public Dictionary<UserIndex, BatteryInformation> ControllerBatteryInformation { get; set; }

    // This will run when the timer expires.
    public void PollTimer_Elapsed(object myObject, EventArgs mytEventArgs)
    {
        _pollTimer.Stop();

        if (_pollCount == 0)
        {
            Controllers = new List<Controller>
            {
                new(UserIndex.One),
                new(UserIndex.Two),
                new(UserIndex.Three),
                new(UserIndex.Four)
            };
        }

        foreach (var controller in Controllers)
        {
            if (controller.IsConnected)
            {
                // Check if this controller is a newly connected controller.
                if (_connectedControllers[controller.UserIndex] != true)
                {
                    ControllerConnected(this, new UserIndexEventArgs(controller.UserIndex));
                    _connectedControllers[controller.UserIndex] = true;
                }

                // Check if this controller has a low battery, where it wasn't previously low.
                var battery = controller.GetBatteryInformation(BatteryDeviceType.Gamepad);
                if (_connectedControllersBatteryLow[controller.UserIndex] != true && battery.BatteryLevel == BatteryLevel.Low)
                {
                    ControllerBatteryLow(this, new UserIndexEventArgs(controller.UserIndex));
                    _connectedControllersBatteryLow[controller.UserIndex] = true;
                }

                // Make the battery information publicly available.
                ControllerBatteryInformation[controller.UserIndex] = battery;
                ControllerBatteryInformationUpdated(this, new UserIndexEventArgs(controller.UserIndex));
            }
            else
            {
                // Check if this controller was a previously connected controller.
                if (!_connectedControllers[controller.UserIndex])
                {
                    continue;
                }

                ControllerDisconnected(this, new UserIndexEventArgs(controller.UserIndex));
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
