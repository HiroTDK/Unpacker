using System;
using System.Windows.Forms;

namespace Unpacker
{
    static class Program
	{
		public static bool DEBUG = true;

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UnpackWindow());
        }
    }

}