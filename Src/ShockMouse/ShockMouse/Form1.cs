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
namespace ShockMouse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static Point Position;
        MouseHook mouseHook = new MouseHook();
        private static System.Threading.Thread thrShock;
        public static int x, y, Xcenter, Ycenter, _signxchanged, _signychanged, _valuexchanged, _valueychanged, Xcenterinit, Ycenterinit, qtx, qty, mouseStructptx, mouseStructpty;
        private static bool _Signxchanged, _Signychanged, _Valuexchanged, _Valueychanged;
        public void Form1_Load(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(10000);
            GetCursorPos(out x, out y);
            thrShock = new System.Threading.Thread(new System.Threading.ThreadStart(Shock));
            thrShock.Start();
            mouseHook.MouseMove += new MouseHook.MouseHookCallback(mouseHook_MouseMove);
            mouseHook.Install();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            OnKeyDown(e.KeyData);
        }
        private void OnKeyDown(Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                const string message = "• Author: Michaël André Franiatte.\n\r\n\r• Contact: michael.franiatte@gmail.com.\n\r\n\r• Publisher: https://github.com/michaelandrefraniatte.\n\r\n\r• Copyrights: All rights reserved, no permissions granted.\n\r\n\r• License: Not open source, not free of charge to use.";
                const string caption = "About";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (keyData == Keys.Escape)
            {
                this.Close();
            }
        }
        private void mouseHook_MouseMove(MouseHook.MSLLHOOKSTRUCT mouseStruct)
        {
            mouseStructptx = mouseStruct.pt.x;
            mouseStructpty = mouseStruct.pt.y;
            textBox1.Text = "X = " + (Xcenter - Xcenterinit).ToString();
            textBox2.Text = "Y = " + (Ycenter - Ycenterinit).ToString();
        }
        private void Shock()
        {
            while (true)
            {
                if (!this.Visible)
                    break;
                GetCursorPos(out x, out y);
                if (mouseStructptx - x != 0 & Math.Abs(mouseStructptx - x) >= 10)
                    Signxchanged = Math.Sign(mouseStructptx - x);
                if (_Signxchanged)
                    Xcenterinit = Xcenter;
                if (mouseStructpty - y != 0 & Math.Abs(mouseStructpty - y) >= 10)
                    Signychanged = Math.Sign(mouseStructpty - y);
                if (_Signychanged)
                    Ycenterinit = Ycenter;
                if (Math.Abs(Xcenter - Xcenterinit) <= 300)
                    Valuexchanged = (mouseStructptx - x);
                else
                {
                    if (Math.Abs(Xcenter - Xcenterinit) <= 900)
                        Valuexchanged = (mouseStructptx - x) / 6;
                    else
                        Valuexchanged = (mouseStructptx - x) / 12;
                }
                if (_Valuexchanged)
                {
                    Xcenter += mouseStructptx - x;
                    if (Math.Abs(Xcenter - Xcenterinit) > 6000)
                        Xcenter -= mouseStructptx - x;
                }
                if (Math.Abs(Ycenter - Ycenterinit) <= 300)
                    Valueychanged = (mouseStructpty - y);
                else
                {
                    if (Math.Abs(Ycenter - Ycenterinit) <= 900)
                        Valueychanged = (mouseStructpty - y) / 6;
                    else
                        Valueychanged = (mouseStructpty - y) / 12;
                }
                if (_Valueychanged)
                {
                    Ycenter += mouseStructpty - y;
                    if (Math.Abs(Ycenter - Ycenterinit) > 6000)
                        Ycenter -= mouseStructpty - y;
                }
                MouseBrink((Xcenter - Xcenterinit) / 75, (Ycenter - Ycenterinit) / 75);
                SetCursorPos(x, y);
                System.Threading.Thread.Sleep(21);
            }
        }
        private int Signxchanged
        {
            get { return _signxchanged; }
            set
            {
                if (_signxchanged != value)
                    _Signxchanged = true;
                else
                    _Signxchanged = false;
                _signxchanged = value;
            }
        }
        private int Signychanged
        {
            get { return _signychanged; }
            set
            {
                if (_signychanged != value)
                    _Signychanged = true;
                else
                    _Signychanged = false;
                _signychanged = value;
            }
        }
        private int Valuexchanged
        {
            get { return _valuexchanged; }
            set
            {
                if (_valuexchanged != value)
                    _Valuexchanged = true;
                else
                    _Valuexchanged = false;
                _valuexchanged = value;
            }
        }
        private int Valueychanged
        {
            get { return _signychanged; }
            set
            {
                if (_valueychanged != value)
                    _Valueychanged = true;
                else
                    _Valueychanged = false;
                _valueychanged = value;
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            mouseHook.MouseMove -= new MouseHook.MouseHookCallback(mouseHook_MouseMove);
            mouseHook.Uninstall();
        }
        [DllImport("MouseMoveToKeysLibrary.dll", EntryPoint = "MouseBrink")]
        private static extern void MouseBrink(int X, int Y);
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool GetCursorPos(out int x, out int y);
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool SetCursorPos(int x, int y);
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