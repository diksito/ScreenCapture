using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing.Imaging;
using System.Drawing;
using System.Windows.Forms;
using ScreenCaptureApp.Infrastructure;
using System.Diagnostics;
using Gma.System.MouseKeyHook;

namespace ScreenCaptureApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IKeyboardMouseEvents m_GlobalHook;

        public MainWindow()
        {
            InitializeComponent();
            Subscribe();
        }

        private void TakeScreenshort_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                ScreenCapture screenshot = new ScreenCapture();
            }
            catch(Exception exc)
            {
                System.Windows.MessageBox.Show(exc.Message,"Error");
            }
        }

        private void OpenFolder_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(Storage.GetAppFolder());
        }

        private void Listen_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.S)
                System.Windows.MessageBox.Show(e.Key.ToString());
        }

        public void Subscribe()
        {
            // Note: for the application hook, use the Hook.AppEvents() instead
            m_GlobalHook = Hook.GlobalEvents();
            
            //m_GlobalHook.MouseDownExt += GlobalHookMouseDownExt;
            m_GlobalHook.KeyPress += GlobalHookKeyPress;
        }
        private void GlobalHookKeyPress(object sender, KeyPressEventArgs e)
        {
            //System.Windows.MessageBox.Show("MouseDown:  " + e.KeyChar.ToString());
            if(e.KeyChar.ToString().ToLower() == Key.S.ToString().ToLower())
            {
                try
                {
                    ScreenCapture screenshot = new ScreenCapture();
                }
                catch (Exception exc)
                {
                    System.Windows.MessageBox.Show(exc.Message, "Error");
                }
            }
        }
        private void GlobalHookMouseDownExt(object sender, MouseEventExtArgs e)
        {
            Console.WriteLine("MouseDown: \t{0}; \t System Timestamp: \t{1}", e.Button, e.Timestamp);

            // uncommenting the following line will suppress the middle mouse button click
            // if (e.Buttons == MouseButtons.Middle) { e.Handled = true; }
        }
        public void Unsubscribe()
        {
            m_GlobalHook.MouseDownExt -= GlobalHookMouseDownExt;
            m_GlobalHook.KeyPress -= GlobalHookKeyPress;

            //It is recommened to dispose it
            m_GlobalHook.Dispose();
        }


    }
}
