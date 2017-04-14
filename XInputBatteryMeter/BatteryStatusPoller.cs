using SharpDX.XInput;
using System;
using System.Collections.Generic;
using System.Timers;

namespace XInputBatteryMeter
{
    public class BatteryStatusPoller
    {
        // Public properties
        public List<Controller> Controllers { get; set; }
        public Dictionary<UserIndex, BatteryInformation> ControllerBatteryInformation { get; set; }
        public EventHandler<UserIndex> Controller_Connected;
        public EventHandler<UserIndex> Controller_Disconnected;
        public EventHandler<UserIndex> Controller_BatteryLow;
        public EventHandler<UserIndex> Controller_BatteryInformationUpdated;

        // Private fields
        private Timer _pollTimer;
        private int _pollCount;
        private Dictionary<UserIndex, bool> _connectedControllers;
        private Dictionary<UserIndex, bool> _connectedControllers_BatteryLow;

        public BatteryStatusPoller()
        {
            // Initialize the List of Controllers.
            Controllers = new List<Controller>
            {
                new Controller(UserIndex.One),
                new Controller(UserIndex.Two),
                new Controller(UserIndex.Three),
                new Controller(UserIndex.Four)
            };

            // Initialize the Battery Information Dictionary.
            ControllerBatteryInformation = new Dictionary<UserIndex, BatteryInformation>();

            _connectedControllers = new Dictionary<UserIndex, bool>();
            _connectedControllers_BatteryLow = new Dictionary<UserIndex, bool>();

            foreach (Controller controller in Controllers)
            {
                _connectedControllers[controller.UserIndex] = controller.IsConnected;
                _connectedControllers_BatteryLow[controller.UserIndex] = false;
            }

            _pollCount = 0;

            _pollTimer = new Timer()
            {
                Interval = Convert.ToInt32(TimeSpan.FromSeconds(2.5).TotalMilliseconds)
            };

            _pollTimer.Elapsed += new ElapsedEventHandler(PollTimer_Elapsed);

            _pollTimer.Start();
        }

        // This will run when the timer expires.
        public void PollTimer_Elapsed(Object myObject, EventArgs mytEventArgs)
        {
            _pollTimer.Stop();

            if(_pollCount == 0)
            {
                Controllers = new List<Controller>
                {
                    new Controller(UserIndex.One),
                    new Controller(UserIndex.Two),
                    new Controller(UserIndex.Three),
                    new Controller(UserIndex.Four)
                };
            }

            foreach (Controller controller in Controllers)
            {
                if (controller.IsConnected)
                {
                    // Check if this controller is a newly connected controller.
                    if (_connectedControllers[controller.UserIndex] != true)
                    {
                        Controller_Connected(this, controller.UserIndex);
                        _connectedControllers[controller.UserIndex] = true;
                    }

                    // Check if this controller has a low battery, where it wasn't previously low.
                    var battery = controller.GetBatteryInformation(BatteryDeviceType.Gamepad);
                    if (_connectedControllers_BatteryLow[controller.UserIndex] != true && battery.BatteryLevel == BatteryLevel.Low)
                    {
                        Controller_BatteryLow(this, controller.UserIndex);
                        _connectedControllers_BatteryLow[controller.UserIndex] = true;
                    }

                    // Make the battery information publicly available.
                    ControllerBatteryInformation[controller.UserIndex] = battery;
                    Controller_BatteryInformationUpdated(this, controller.UserIndex);
                }else
                {
                    // Check if this controller was a previously connected controller.
                    if (_connectedControllers[controller.UserIndex] == true)
                    {
                        Controller_Disconnected(this, controller.UserIndex);
                        _connectedControllers[controller.UserIndex] = false;
                    }
                }
            }

            if (_pollCount % 5 == 0) GC.Collect();

            _pollCount += 1;
            _pollTimer.Enabled = true;
        }
    }
}
