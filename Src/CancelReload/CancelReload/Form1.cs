using System;
using System.Windows.Forms;
namespace CancelReload
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static System.Threading.Thread thrCancelReload, thrReloading;
        private static int WD, WU, Delay;
        private static bool Reload, thrAlive;
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            thrAlive = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            thrAlive = true;
            Delay = int.Parse(textBox1.Text);
            thrReloading = new System.Threading.Thread(new System.Threading.ThreadStart(Reloading));
            thrReloading.Start();
            thrCancelReload = new System.Threading.Thread(new System.Threading.ThreadStart(CancelReload));
            thrCancelReload.Start();
        }
        private void CancelReload()
        {
            while (thrAlive)
            {
                if ((Microsoft.Xna.Framework.Input.Mouse.GetState().RightButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed) & Reload)
                {
                    if (WD <= 1)
                        WD = WD + 1;
                    WU = 0;
                }
                else
                {
                    if (WU <= 1)
                        WU = WU + 1;
                    WD = 0;
                }
                if (WD == 1)
                {
                    SendE.WheelUpF();
                }
                if (WU == 1)
                {
                    Reload = false;
                }
                System.Threading.Thread.Sleep(1);
            }
        }
        private void Reloading()
        {
            while (thrAlive)
            {
                Reload = SendE.GetAsyncKeyState(System.Windows.Forms.Keys.R);
                if (Reload)
                    System.Threading.Thread.Sleep(Delay);
                Reload = false;
                System.Threading.Thread.Sleep(1);
            }
        }
        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit)]
        struct MOUSEKEYBDHARDWAREINPUT
        {
            [System.Runtime.InteropServices.FieldOffset(0)]
            public MOUSEINPUT Mouse;
            [System.Runtime.InteropServices.FieldOffset(0)]
            public KEYBDINPUT Keyboard;
        }
        private struct INPUT
        {
            public UInt32 Type;
            public MOUSEKEYBDHARDWAREINPUT Data;
        }
        public enum InputType : uint
        {
            MOUSE = 0, KEYBOARD = 1, HARDWARE = 2,
        }
        struct KEYBDINPUT
        {
            public UInt16 Vk;
            public UInt16 Scan;
            public uint Flags;
            public uint Time;
            public IntPtr ExtraInfo;
        }
        struct MOUSEINPUT
        {
            public int X;
            public int Y;
            public int MouseData;
            public uint Flags;
            public uint Time;
            public IntPtr ExtraInfo;
        }
        private static INPUT[] Micek = new INPUT[1], MiceW3 = new INPUT[1], Micewu = new INPUT[1], down = new INPUT[1], up = new INPUT[1], Micel = new INPUT[1], Micelf = new INPUT[1], Micerc = new INPUT[1], Micercf = new INPUT[1], Micemc = new INPUT[1], Micewd = new INPUT[1], Micemcf = new INPUT[1];
        private static class SendE
        {
            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
            public static extern bool GetAsyncKeyState(System.Windows.Forms.Keys vKey);
            [System.Runtime.InteropServices.DllImport("user32.dll")]
            private static extern uint SendInput(uint numberOfInputs, INPUT[] inputs, int sizeOfInputStructure);
            public static void SimulateKeyDown(UInt16 keyCode, UInt16 bScan)
            {
                down[0].Type = (UInt32)InputType.KEYBOARD;
                down[0].Data.Keyboard = new KEYBDINPUT();
                down[0].Data.Keyboard.Vk = keyCode;
                down[0].Data.Keyboard.Scan = bScan;
                down[0].Data.Keyboard.Flags = (UInt16)(0x0001) | (UInt16)(0x0008);
                down[0].Data.Keyboard.Time = 0;
                down[0].Data.Keyboard.ExtraInfo = IntPtr.Zero;
                if (keyCode == 0x25 | keyCode == 0x26 | keyCode == 0x27 | keyCode == 0x28)
                    SendInput(1, down, System.Runtime.InteropServices.Marshal.SizeOf(typeof(INPUT)));
                down[0].Data.Keyboard.Flags = 0;
                SendInput(1, down, System.Runtime.InteropServices.Marshal.SizeOf(typeof(INPUT)));
            }
            public static void SimulateKeyUp(UInt16 keyCode, UInt16 bScan)
            {
                up[0].Type = (UInt32)InputType.KEYBOARD;
                up[0].Data.Keyboard = new KEYBDINPUT();
                up[0].Data.Keyboard.Vk = keyCode;
                up[0].Data.Keyboard.Scan = bScan;
                up[0].Data.Keyboard.Flags = (UInt16)(0x0002) | (UInt16)(0x0001) | (UInt16)(0x0008);
                up[0].Data.Keyboard.Time = 0;
                up[0].Data.Keyboard.ExtraInfo = IntPtr.Zero;
                if (keyCode == 0x25 | keyCode == 0x26 | keyCode == 0x27 | keyCode == 0x28)
                    SendInput(1, up, System.Runtime.InteropServices.Marshal.SizeOf(typeof(INPUT)));
                up[0].Data.Keyboard.Flags = (UInt16)(0x0002);
                SendInput(1, up, System.Runtime.InteropServices.Marshal.SizeOf(typeof(INPUT)));
            }
            public static void MouseMW3(int x, int y)
            {
                MiceW3[0].Type = (UInt32)InputType.MOUSE;
                MiceW3[0].Data.Mouse = new MOUSEINPUT();
                MiceW3[0].Data.Mouse.MouseData = 1;
                MiceW3[0].Data.Mouse.Flags = (UInt16)(0x8001);
                MiceW3[0].Data.Mouse.Time = 0;
                MiceW3[0].Data.Mouse.X = x;
                MiceW3[0].Data.Mouse.Y = y;
                MiceW3[0].Data.Mouse.ExtraInfo = IntPtr.Zero;
                SendInput(1, MiceW3, System.Runtime.InteropServices.Marshal.SizeOf(typeof(INPUT)));
            }
            public static void MouseBrink(int x, int y)
            {
                Micek[0].Type = (UInt32)InputType.MOUSE;
                Micek[0].Data.Mouse = new MOUSEINPUT();
                Micek[0].Data.Mouse.MouseData = 1;
                Micek[0].Data.Mouse.Flags = (UInt16)(0x0001);
                Micek[0].Data.Mouse.Time = 0;
                Micek[0].Data.Mouse.X = x;
                Micek[0].Data.Mouse.Y = y;
                Micek[0].Data.Mouse.ExtraInfo = IntPtr.Zero;
                SendInput(1, Micek, System.Runtime.InteropServices.Marshal.SizeOf(typeof(INPUT)));
            }
            public static void LeftClick()
            {
                Micel[0].Type = (UInt32)InputType.MOUSE;
                Micel[0].Data.Mouse = new MOUSEINPUT();
                Micel[0].Data.Mouse.MouseData = 0;
                Micel[0].Data.Mouse.Flags = (UInt16)(0x0002);
                Micel[0].Data.Mouse.Time = 0;
                Micel[0].Data.Mouse.ExtraInfo = IntPtr.Zero;
                SendInput(1, Micel, System.Runtime.InteropServices.Marshal.SizeOf(typeof(INPUT)));
            }
            public static void LeftClickF()
            {
                Micelf[0].Type = (UInt32)InputType.MOUSE;
                Micelf[0].Data.Mouse = new MOUSEINPUT();
                Micelf[0].Data.Mouse.MouseData = 0;
                Micelf[0].Data.Mouse.Flags = (UInt16)(0x0004);
                Micelf[0].Data.Mouse.Time = 0;
                Micelf[0].Data.Mouse.ExtraInfo = IntPtr.Zero;
                SendInput(1, Micelf, System.Runtime.InteropServices.Marshal.SizeOf(typeof(INPUT)));
            }
            public static void RightClick()
            {
                Micerc[0].Type = (UInt32)InputType.MOUSE;
                Micerc[0].Data.Mouse = new MOUSEINPUT();
                Micerc[0].Data.Mouse.MouseData = 0;
                Micerc[0].Data.Mouse.Flags = (UInt16)(0x0008);
                Micerc[0].Data.Mouse.Time = 0;
                Micerc[0].Data.Mouse.ExtraInfo = IntPtr.Zero;
                SendInput(1, Micerc, System.Runtime.InteropServices.Marshal.SizeOf(typeof(INPUT)));
            }
            public static void RightClickF()
            {
                Micercf[0].Type = (UInt32)InputType.MOUSE;
                Micercf[0].Data.Mouse = new MOUSEINPUT();
                Micercf[0].Data.Mouse.MouseData = 0;
                Micercf[0].Data.Mouse.Flags = (UInt16)(0x0010);
                Micercf[0].Data.Mouse.Time = 0;
                Micercf[0].Data.Mouse.ExtraInfo = IntPtr.Zero;
                SendInput(1, Micercf, System.Runtime.InteropServices.Marshal.SizeOf(typeof(INPUT)));
            }
            public static void MiddleClick()
            {
                Micemc[0].Type = (UInt32)InputType.MOUSE;
                Micemc[0].Data.Mouse = new MOUSEINPUT();
                Micemc[0].Data.Mouse.MouseData = 0;
                Micemc[0].Data.Mouse.Flags = (UInt16)(0x0020);
                Micemc[0].Data.Mouse.Time = 0;
                Micemc[0].Data.Mouse.ExtraInfo = IntPtr.Zero;
                SendInput(1, Micemc, System.Runtime.InteropServices.Marshal.SizeOf(typeof(INPUT)));
            }
            public static void MiddleClickF()
            {
                Micemcf[0].Type = (UInt32)InputType.MOUSE;
                Micemcf[0].Data.Mouse = new MOUSEINPUT();
                Micemcf[0].Data.Mouse.MouseData = 0;
                Micemcf[0].Data.Mouse.Flags = (UInt16)(0x0040);
                Micemcf[0].Data.Mouse.Time = 0;
                Micemcf[0].Data.Mouse.ExtraInfo = IntPtr.Zero;
                SendInput(1, Micemcf, System.Runtime.InteropServices.Marshal.SizeOf(typeof(INPUT)));
            }
            public static void WheelDownF()
            {
                Micewd[0].Type = (UInt32)InputType.MOUSE;
                Micewd[0].Data.Mouse = new MOUSEINPUT();
                Micewd[0].Data.Mouse.MouseData = -120;
                Micewd[0].Data.Mouse.Flags = (UInt16)(0x0800);
                Micewd[0].Data.Mouse.Time = 0;
                Micewd[0].Data.Mouse.ExtraInfo = IntPtr.Zero;
                SendInput(1, Micewd, System.Runtime.InteropServices.Marshal.SizeOf(typeof(INPUT)));
            }
            public static void WheelUpF()
            {
                Micewu[0].Type = (UInt32)InputType.MOUSE;
                Micewu[0].Data.Mouse = new MOUSEINPUT();
                Micewu[0].Data.Mouse.MouseData = 120;
                Micewu[0].Data.Mouse.Flags = (UInt16)(0x0800);
                Micewu[0].Data.Mouse.Time = 0;
                Micewu[0].Data.Mouse.ExtraInfo = IntPtr.Zero;
                SendInput(1, Micewu, System.Runtime.InteropServices.Marshal.SizeOf(typeof(INPUT)));
            }
        }
    }
}