using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScreenCaptureApp.Infrastructure
{
    class ScreenCapture
    {
        public ScreenCapture()
        {
            //Create a new bitmap.
            var bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                           Screen.PrimaryScreen.Bounds.Height,
                                           System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            // Create a graphics object from the bitmap.
            var gfxScreenshot = Graphics.FromImage(bmpScreenshot);

            // Take the screenshot from the upper left corner to the right bottom corner.
            gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                        Screen.PrimaryScreen.Bounds.Y,
                                        0,
                                        0,
                                        Screen.PrimaryScreen.Bounds.Size,
                                        CopyPixelOperation.SourceCopy);

            // Save the screenshot to the specified path that the user has chosen.
            if (System.IO.Directory.Exists(Storage.GetAppFolder()))
            {
                bmpScreenshot.Save(Storage.GetAppFolder() + Storage.GetRandomFileName(), ImageFormat.Png);
            }
            else
            {
                try
                {
                    System.IO.Directory.CreateDirectory(Storage.GetAppFolder());
                    bmpScreenshot.Save(Storage.GetAppFolder() + Storage.GetRandomFileName(), ImageFormat.Png);
                }
                catch(Exception) { }
            }
        }
    }
}
