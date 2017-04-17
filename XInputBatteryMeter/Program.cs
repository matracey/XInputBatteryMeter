using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using XInputBatteryMeter.Properties;

namespace XInputBatteryMeter
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine(@"Initializing.");

            var xinput13 = IsLibraryInstalled("xinput1_3.dll");
            //var xinput910 = IsLibraryInstalled("xinput9_1_0.dll");

            if (!xinput13)
            {
                MessageBox.Show(Resources.XInputNotFoundText, Resources.XInputNotFoundCaption, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                var poller = new BatteryStatusPoller();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new BatteryMeterApplicationContext(poller));
            }

        }

        /// <summary>
        /// Loads the specified module into the address space of the calling process. The specified module may cause other modules to be loaded.
        /// </summary>
        /// <param name="lpFileName">
        /// <para>The name of the module. This can be either a library module (a .dll file) or an executable module (an .exe file).</para>
        /// </param>
        /// <returns>
        /// <para>If the function succeeds, the return value is a handle to the module.</para>
        /// <para>If the function fails, the return value is NULL.</para>
        /// </returns>
        [DllImport("kernel32", SetLastError = true)]
        private static extern IntPtr LoadLibrary(string lpFileName);

        /// <summary>
        /// Checks if the specified Library is installed.
        /// </summary>
        /// <param name="fileName">The file to search for. This can be either a library module (a .dll file) or an executable module (an .exe file).</param>
        /// <returns>true if the library is found; otherwise false.</returns>
        private static bool IsLibraryInstalled(string fileName)
        {
            return LoadLibrary(fileName) != IntPtr.Zero;
        }

    }
}
