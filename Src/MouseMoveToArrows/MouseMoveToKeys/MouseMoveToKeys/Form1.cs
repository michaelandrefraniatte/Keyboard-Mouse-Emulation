using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using GlobalLowLevelHooks;
namespace MouseMoveToKeys
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static Point Position;
        MouseHook mouseHook = new MouseHook();
        public static float WidthS, HeightS;
        public static int WDleft, WUleft, WDright, WUright, WDup, WUup, WDdown, WUdown;
        public void Form1_Load(object sender, EventArgs e)
        {
            WidthS = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width / 2;
            HeightS = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height / 2;
            mouseHook.MouseMove += new MouseHook.MouseHookCallback(mouseHook_MouseMove);
            mouseHook.Install();
        }
        private void mouseHook_MouseMove(MouseHook.MSLLHOOKSTRUCT mouseStruct)
        {
            //textBox1.Text = mouseStruct.pt.x.ToString();
            if (mouseStruct.pt.x - WidthS > 100)
            {
                if (WDright <= 1)
                    WDright = WDright + 1;
                WUright = 0;
            }
            else
            {
                if (WUright <= 1)
                    WUright = WUright + 1;
                WDright = 0;
            }
            if (WDright == 1)
            {
                if (comboBox1.Text == "WASD")
                    SimulateKeyDown(0x44, 0x20);
                if (comboBox1.Text == "ZQSD")
                    SimulateKeyDown(0x44, 0x20);
                if (comboBox1.Text == "arrow keys")
                    SimulateKeyDownArrows(0x27, 0xCD);
            }
            if (WUright == 1)
            {
                if (comboBox1.Text == "WASD")
                    SimulateKeyUp(0x44, 0x20);
                if (comboBox1.Text == "ZQSD")
                    SimulateKeyUp(0x44, 0x20);
                if (comboBox1.Text == "arrow keys")
                    SimulateKeyUpArrows(0x27, 0xCD);
            }
            if (mouseStruct.pt.x - WidthS < -100)
            {
                if (WDleft <= 1)
                    WDleft = WDleft + 1;
                WUleft = 0;
            }
            else
            {
                if (WUleft <= 1)
                    WUleft = WUleft + 1;
                WDleft = 0;
            }
            if (WDleft == 1)
            {
                if (comboBox1.Text == "WASD")
                    SimulateKeyDown(0x41, 0x1E);
                if (comboBox1.Text == "ZQSD")
                    SimulateKeyDown(0x51, 0x10);
                if (comboBox1.Text == "arrow keys")
                    SimulateKeyDownArrows(0x25, 0xCB);
            }
            if (WUleft == 1)
            {
                if (comboBox1.Text == "WASD")
                    SimulateKeyUp(0x41, 0x1E);
                if (comboBox1.Text == "ZQSD")
                    SimulateKeyUp(0x51, 0x10);
                if (comboBox1.Text == "arrow keys")
                    SimulateKeyUpArrows(0x25, 0xCB);
            }
            if (mouseStruct.pt.y - HeightS < -100)
            {
                if (WDup <= 1)
                    WDup = WDup + 1;
                WUup = 0;
            }
            else
            {
                if (WUup <= 1)
                    WUup = WUup + 1;
                WDup = 0;
            }
            if (WDup == 1)
            {
                if (comboBox1.Text == "WASD")
                    SimulateKeyDown(0x57, 0x11);
                if (comboBox1.Text == "ZQSD")
                    SimulateKeyDown(0x5A, 0x2C);
                if (comboBox1.Text == "arrow keys")
                    SimulateKeyDownArrows(0x26, 0xC8);
            }
            if (WUup == 1)
            {
                if (comboBox1.Text == "WASD")
                    SimulateKeyUp(0x57, 0x11);
                if (comboBox1.Text == "ZQSD")
                    SimulateKeyUp(0x5A, 0x2C);
                if (comboBox1.Text == "arrow keys")
                    SimulateKeyUpArrows(0x26, 0xC8);
            }
            if (mouseStruct.pt.y - HeightS > 100)
            {
                if (WDdown <= 1)
                    WDdown = WDdown + 1;
                WUdown = 0;
            }
            else
            {
                if (WUdown <= 1)
                    WUdown = WUdown + 1;
                WDdown = 0;
            }
            if (WDdown == 1)
            {
                if (comboBox1.Text == "WASD")
                    SimulateKeyDown(0x53, 0x1F);
                if (comboBox1.Text == "ZQSD")
                    SimulateKeyDown(0x53, 0x1F);
                if (comboBox1.Text == "arrow keys")
                    SimulateKeyDownArrows(0x28, 0xD0);
            }
            if (WUdown == 1)
            {
                if (comboBox1.Text == "WASD")
                    SimulateKeyUp(0x53, 0x1F);
                if (comboBox1.Text == "ZQSD")
                    SimulateKeyUp(0x53, 0x1F);
                if (comboBox1.Text == "arrow keys")
                    SimulateKeyUpArrows(0x28, 0xD0);
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            mouseHook.MouseMove -= new MouseHook.MouseHookCallback(mouseHook_MouseMove);
            mouseHook.Uninstall();
        }
        [DllImport("MouseMoveToKeysLibrary.dll", EntryPoint = "SimulateKeyDown")]
        private static extern void SimulateKeyDown(uint keyCode, uint bScan);
        [DllImport("MouseMoveToKeysLibrary.dll", EntryPoint = "SimulateKeyUp")]
        private static extern void SimulateKeyUp(uint keyCode, uint bScan);
        [DllImport("MouseMoveToKeysLibrary.dll", EntryPoint = "SimulateKeyDownArrows")]
        private static extern void SimulateKeyDownArrows(uint keyCode, uint bScan);
        [DllImport("MouseMoveToKeysLibrary.dll", EntryPoint = "SimulateKeyUpArrows")]
        private static extern void SimulateKeyUpArrows(uint keyCode, uint bScan);
    }
}
//Global-Low-Level-Key-Board-And-Mouse-Hook-master on github.com
namespace GlobalLowLevelHooks
{
    /// <summary>
    /// Class for intercepting low level Windows mouse hooks.
    /// </summary>
    class MouseHook
    {
        /// <summary>
        /// Internal callback processing function
        /// </summary>
        private delegate IntPtr MouseHookHandler(int nCode, IntPtr wParam, IntPtr lParam);
        private MouseHookHandler hookHandler;

        /// <summary>
        /// Function to be called when defined even occurs
        /// </summary>
        /// <param name="mouseStruct">MSLLHOOKSTRUCT mouse structure</param>
        public delegate void MouseHookCallback(MSLLHOOKSTRUCT mouseStruct);

        public event MouseHookCallback LeftButtonDown;
        public event MouseHookCallback LeftButtonUp;
        public event MouseHookCallback RightButtonDown;
        public event MouseHookCallback RightButtonUp;
        public event MouseHookCallback MouseMove;
        public event MouseHookCallback MouseWheel;
        public event MouseHookCallback DoubleClick;
        public event MouseHookCallback MiddleButtonDown;
        public event MouseHookCallback MiddleButtonUp;

        /// <summary>
        /// Low level mouse hook's ID
        /// </summary>
        private IntPtr hookID = IntPtr.Zero;

        /// <summary>
        /// Install low level mouse hook
        /// </summary>
        /// <param name="mouseHookCallbackFunc">Callback function</param>
        public void Install()
        {
            hookHandler = HookFunc;
            hookID = SetHook(hookHandler);
        }

        /// <summary>
        /// Remove low level mouse hook
        /// </summary>
        public void Uninstall()
        {
            if (hookID == IntPtr.Zero)
                return;

            UnhookWindowsHookEx(hookID);
            hookID = IntPtr.Zero;
        }

        /// <summary>
        /// Destructor. Unhook current hook
        /// </summary>
        ~MouseHook()
        {
            Uninstall();
        }

        /// <summary>
        /// Sets hook and assigns its ID for tracking
        /// </summary>
        /// <param name="proc">Internal callback function</param>
        /// <returns>Hook ID</returns>
        private IntPtr SetHook(MouseHookHandler proc)
        {
            using (ProcessModule module = Process.GetCurrentProcess().MainModule)
                return SetWindowsHookEx(WH_MOUSE_LL, proc, GetModuleHandle(module.ModuleName), 0);
        }

        /// <summary>
        /// Callback function
        /// </summary>
        private IntPtr HookFunc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            // parse system messages
            if (nCode >= 0)
            {
                if (MouseMessages.WM_LBUTTONDOWN == (MouseMessages)wParam)
                    if (LeftButtonDown != null)
                        LeftButtonDown((MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT)));
                if (MouseMessages.WM_LBUTTONUP == (MouseMessages)wParam)
                    if (LeftButtonUp != null)
                        LeftButtonUp((MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT)));
                if (MouseMessages.WM_RBUTTONDOWN == (MouseMessages)wParam)
                    if (RightButtonDown != null)
                        RightButtonDown((MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT)));
                if (MouseMessages.WM_RBUTTONUP == (MouseMessages)wParam)
                    if (RightButtonUp != null)
                        RightButtonUp((MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT)));
                if (MouseMessages.WM_MOUSEMOVE == (MouseMessages)wParam)
                    if (MouseMove != null)
                        MouseMove((MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT)));
                if (MouseMessages.WM_MOUSEWHEEL == (MouseMessages)wParam)
                    if (MouseWheel != null)
                        MouseWheel((MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT)));
                if (MouseMessages.WM_LBUTTONDBLCLK == (MouseMessages)wParam)
                    if (DoubleClick != null)
                        DoubleClick((MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT)));
                if (MouseMessages.WM_MBUTTONDOWN == (MouseMessages)wParam)
                    if (MiddleButtonDown != null)
                        MiddleButtonDown((MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT)));
                if (MouseMessages.WM_MBUTTONUP == (MouseMessages)wParam)
                    if (MiddleButtonUp != null)
                        MiddleButtonUp((MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT)));
            }
            return CallNextHookEx(hookID, nCode, wParam, lParam);
        }

        private const int WH_MOUSE_LL = 14;

        private enum MouseMessages
        {
            WM_LBUTTONDOWN = 0x0201,
            WM_LBUTTONUP = 0x0202,
            WM_MOUSEMOVE = 0x0200,
            WM_MOUSEWHEEL = 0x020A,
            WM_RBUTTONDOWN = 0x0204,
            WM_RBUTTONUP = 0x0205,
            WM_LBUTTONDBLCLK = 0x0203,
            WM_MBUTTONDOWN = 0x0207,
            WM_MBUTTONUP = 0x0208
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MSLLHOOKSTRUCT
        {
            public POINT pt;
            public uint mouseData;
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
            MouseHookHandler lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}
