using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScreenCaptureApp.Infrastructure
{
    class Storage
    {
        public const string SCREEN_CAPTURE_APP_FOLDER = "ScreenCapture";
        public const string FILE = "Screenshot_";

        public static string GetAppFolder()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\" + SCREEN_CAPTURE_APP_FOLDER + @"\";
        }

        public static string GetRandomFileName()
        {
            return FILE + DateTime.UtcNow.ToString("ddMMyyyy_HHmmssf") + ".png";
        }
    }
}
