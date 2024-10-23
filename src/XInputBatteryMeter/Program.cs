using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using XInputBatteryMeter.Properties;

[assembly: InternalsVisibleTo("XInputBatteryMeter.UnitTests")]

namespace XInputBatteryMeter;

/// <summary>Represents the main entry point of the application.</summary>
internal static class Program
{
    /// <summary>The main entry point for the application.</summary>
    /// <remarks>The STAThread attribute is required to use Windows Forms.</remarks>
    [STAThread]
    internal static void Main()
    {
        Console.WriteLine(@"Initializing.");

        var xinput13 = IsLibraryInstalled("xinput1_3.dll");
        //var xinput910 = IsLibraryInstalled("xinput9_1_0.dll");

        if (!xinput13)
        {
            MessageBox.Show(
                Resources.XInputNotFoundText,
                Resources.XInputNotFoundCaption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }
        else
        {
            var poller = new BatteryStatusPoller();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BatteryMeterApplicationContext(poller));
        }
    }

    /// <summary>Loads the specified module into the address space of the calling process.</summary>
    /// <param name="lpFileName">
    ///     The <see cref="string" /> filename of the module. This can be either a library module (a .dll
    ///     file) or an executable module (an .exe file).
    /// </param>
    /// <returns>If the function succeeds, a handle to the module; otherwise <see langword="null" />.</returns>
    /// <remarks><b>Note:</b> The specified module may cause other modules to be loaded.</remarks>
    [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Unicode)]
    internal static extern IntPtr LoadLibrary([MarshalAs(UnmanagedType.LPWStr)] string lpFileName);

    /// <summary>Checks if the specified Library is installed on the system.</summary>
    /// <param name="fileName">
    ///     The <see cref="string" /> filename of the module to search for. This can be either a library
    ///     module (a .dll file) or an executable module (an .exe file).
    /// </param>
    /// <returns><see langword="true" /> if the library is found; otherwise <see langword="false" />.</returns>
    internal static bool IsLibraryInstalled(string fileName)
    {
        return LoadLibrary(fileName) != IntPtr.Zero;
    }
}