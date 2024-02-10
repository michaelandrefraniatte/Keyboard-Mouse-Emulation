using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PressToPush
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            thr = new System.Threading.Thread(new System.Threading.ThreadStart(this.PressToPushThr));
            thr.Start();
        }
        private System.Threading.Thread thr;
        private static bool breakstart = new bool();
        private static bool RC1 = new bool();
        private static bool RC2 = new bool();
        private static bool RC3 = new bool();
        private static bool RC4 = new bool();
        private static bool RC5 = new bool();
        private static bool RC6 = new bool();
        private static bool RC7 = new bool();
        private static bool RC8 = new bool();
        private static bool RC9 = new bool();
        private static bool RC10 = new bool();
        private static bool RC11 = new bool();
        private static bool RC12 = new bool();
        private static bool RC13 = new bool();
        private static bool RC14 = new bool();
        private static bool RC15 = new bool();
        private static bool RC16 = new bool();
        private static bool RC17 = new bool();
        private static bool RC18 = new bool();
        private static int rand1 = new int();
        private static int rand2 = new int();
        private static int rand3 = new int();
        private static int rand4 = new int();
        private static int rand5 = new int();
        private static int rand6 = new int();
        private static int rand7 = new int();
        private static int rand8 = new int();
        private static int rand9 = new int();
        private static int rand10 = new int();
        private static int rand11 = new int();
        private static int rand12 = new int();
        private static int rand13 = new int();
        private static int rand14 = new int();
        private static int rand15 = new int();
        private static int rand16 = new int();
        private static int rand17 = new int();
        private static int rand18 = new int();
        private void button1_Click_1(object sender, EventArgs e)
        {
            breakstart = false;
            if (comboBox1.Text.EndsWith(" Y"))
            {
                RC1 = true;
            }
            if (comboBox1.Text.EndsWith(" U"))
            {
                RC2 = true;
            }
            if (comboBox1.Text.EndsWith(" X"))
            {
                RC3 = true;
            }
            if (comboBox1.Text.EndsWith(" C"))
            {
                RC4 = true;
            }
            if (comboBox1.Text.EndsWith(" F"))
            {
                RC5 = true;
            }
            if (comboBox1.Text.EndsWith(" T"))
            {
                RC6 = true;
            }
            if (comboBox1.Text.EndsWith(" G"))
            {
                RC7 = true;
            }
            if (comboBox1.Text.EndsWith(" B"))
            {
                RC8 = true;
            }
            if (comboBox1.Text.EndsWith(" N"))
            {
                RC9 = true;
            }
            if (comboBox1.Text.EndsWith(" Ctrl"))
            {
                RC10 = true;
            }
            if (comboBox1.Text.EndsWith(" Tab"))
            {
                RC11 = true;
            }
            if (comboBox1.Text.EndsWith(" Shift"))
            {
                RC12 = true;
            }
            if (comboBox1.Text.EndsWith(" Space"))
            {
                RC13 = true;
            }
            if (comboBox1.Text.EndsWith(" Enter"))
            {
                RC14 = true;
            }
            if (comboBox1.Text.EndsWith(" Left arrow"))
            {
                RC15 = true;
            }
            if (comboBox1.Text.EndsWith(" Right arrow"))
            {
                RC16 = true;
            }
            if (comboBox1.Text.EndsWith(" Up arrow"))
            {
                RC17 = true;
            }
            if (comboBox1.Text.EndsWith(" Down arrow"))
            {
                RC18 = true;
            }
        }
        private void PressToPushThr()
        {
            while (!breakstart)
            {
                cevent(1, InputSimulator.GetAsyncKeyState(System.Windows.Forms.Keys.Y) & RC1);
                if (WU[1] == 1)
                {
                    if (rand1 == 0)
                    {
                        InputSimulator.SimulateKeyDown((VirtualKeyCode)0x59, (bScan)0x15);
                        rand1 = 1;
                        System.Media.SystemSounds.Asterisk.Play();
                    }
                    else
                        if (rand1 == 1)
                        {
                            InputSimulator.SimulateKeyUp((VirtualKeyCode)0x59, (bScan)0x15);
                            rand1 = 0;
                            System.Media.SystemSounds.Hand.Play();
                        }
                }
                cevent(2, InputSimulator.GetAsyncKeyState(System.Windows.Forms.Keys.U) & RC2);
                if (WU[2] == 1)
                {
                    if (rand2 == 0)
                    {
                        InputSimulator.SimulateKeyDown((VirtualKeyCode)0x55, (bScan)0x16);
                        rand2 = 1;
                        System.Media.SystemSounds.Asterisk.Play();
                    }
                    else
                        if (rand2 == 1)
                        {
                            InputSimulator.SimulateKeyUp((VirtualKeyCode)0x55, (bScan)0x16);
                            rand2 = 0;
                            System.Media.SystemSounds.Hand.Play();
                        }
                }
                cevent(3, InputSimulator.GetAsyncKeyState(System.Windows.Forms.Keys.X) & RC3);
                if (WU[3] == 1)
                {
                    if (rand3 == 0)
                    {
                        InputSimulator.SimulateKeyDown((VirtualKeyCode)0x58, (bScan)0x2D);
                        rand3 = 1;
                        System.Media.SystemSounds.Asterisk.Play();
                    }
                    else
                        if (rand3 == 1)
                        {
                            InputSimulator.SimulateKeyUp((VirtualKeyCode)0x58, (bScan)0x2D);
                            rand3 = 0;
                            System.Media.SystemSounds.Hand.Play();
                        }
                }
                cevent(4, InputSimulator.GetAsyncKeyState(System.Windows.Forms.Keys.C) & RC4);
                if (WU[4] == 1)
                {
                    if (rand4 == 0)
                    {
                        InputSimulator.SimulateKeyDown((VirtualKeyCode)0x43, (bScan)0x2E);
                        rand4 = 1;
                        System.Media.SystemSounds.Asterisk.Play();
                    }
                    else
                        if (rand4 == 1)
                        {
                            InputSimulator.SimulateKeyUp((VirtualKeyCode)0x43, (bScan)0x2E);
                            rand4 = 0;
                            System.Media.SystemSounds.Hand.Play();
                        }
                }
                cevent(5, InputSimulator.GetAsyncKeyState(System.Windows.Forms.Keys.F) & RC5);
                if (WU[5] == 1)
                {
                    if (rand5 == 0)
                    {
                        InputSimulator.SimulateKeyDown((VirtualKeyCode)0x46, (bScan)0x21);
                        rand5 = 1;
                        System.Media.SystemSounds.Asterisk.Play();
                    }
                    else
                        if (rand5 == 1)
                        {
                            InputSimulator.SimulateKeyUp((VirtualKeyCode)0x46, (bScan)0x21);
                            rand5 = 0;
                            System.Media.SystemSounds.Hand.Play();
                        }
                }
                cevent(6, InputSimulator.GetAsyncKeyState(System.Windows.Forms.Keys.T) & RC6);
                if (WU[6] == 1)
                {
                    if (rand6 == 0)
                    {
                        InputSimulator.SimulateKeyDown((VirtualKeyCode)0x54, (bScan)0x14);
                        rand6 = 1;
                        System.Media.SystemSounds.Asterisk.Play();
                    }
                    else
                        if (rand6 == 1)
                        {
                            InputSimulator.SimulateKeyUp((VirtualKeyCode)0x54, (bScan)0x14);
                            rand6 = 0;
                            System.Media.SystemSounds.Hand.Play();
                        }
                }
                cevent(7, InputSimulator.GetAsyncKeyState(System.Windows.Forms.Keys.G) & RC7);
                if (WU[7] == 1)
                {
                    if (rand7 == 0)
                    {
                        InputSimulator.SimulateKeyDown((VirtualKeyCode)0x47, (bScan)0x22);
                        rand7 = 1;
                        System.Media.SystemSounds.Asterisk.Play();
                    }
                    else
                        if (rand7 == 1)
                        {
                            InputSimulator.SimulateKeyUp((VirtualKeyCode)0x47, (bScan)0x22);
                            rand7 = 0;
                            System.Media.SystemSounds.Hand.Play();
                        }
                }
                cevent(8, InputSimulator.GetAsyncKeyState(System.Windows.Forms.Keys.B) & RC8);
                if (WU[8] == 1)
                {
                    if (rand8 == 0)
                    {
                        InputSimulator.SimulateKeyDown((VirtualKeyCode)0x42, (bScan)0x30);
                        rand8 = 1;
                        System.Media.SystemSounds.Asterisk.Play();
                    }
                    else
                        if (rand8 == 1)
                        {
                            InputSimulator.SimulateKeyUp((VirtualKeyCode)0x42, (bScan)0x30);
                            rand8 = 0;
                            System.Media.SystemSounds.Hand.Play();
                        }
                }
                cevent(9, InputSimulator.GetAsyncKeyState(System.Windows.Forms.Keys.N) & RC9);
                if (WU[9] == 1)
                {
                    if (rand9 == 0)
                    {
                        InputSimulator.SimulateKeyDown((VirtualKeyCode)0x4E, (bScan)0x31);
                        rand9 = 1;
                        System.Media.SystemSounds.Asterisk.Play();
                    }
                    else
                        if (rand9 == 1)
                        {
                            InputSimulator.SimulateKeyUp((VirtualKeyCode)0x4E, (bScan)0x31);
                            rand9 = 0;
                            System.Media.SystemSounds.Hand.Play();
                        }
                }
                cevent(10, InputSimulator.GetAsyncKeyState(System.Windows.Forms.Keys.ControlKey) & RC10);
                if (WU[10] == 1)
                {
                    if (rand10 == 0)
                    {
                        InputSimulator.SimulateKeyDown((VirtualKeyCode)0x11, (bScan)0x1D);
                        rand10 = 1;
                        System.Media.SystemSounds.Asterisk.Play();
                    }
                    else
                        if (rand10 == 1)
                        {
                            InputSimulator.SimulateKeyUp((VirtualKeyCode)0x11, (bScan)0x1D);
                            rand10 = 0;
                            System.Media.SystemSounds.Hand.Play();
                        }
                }
                cevent(11, InputSimulator.GetAsyncKeyState(System.Windows.Forms.Keys.Tab) & RC11);
                if (WU[11] == 1)
                {
                    if (rand11 == 0)
                    {
                        InputSimulator.SimulateKeyDown((VirtualKeyCode)0x09, (bScan)0x0F);
                        rand11 = 1;
                        System.Media.SystemSounds.Asterisk.Play();
                    }
                    else
                        if (rand11 == 1)
                        {
                            InputSimulator.SimulateKeyUp((VirtualKeyCode)0x09, (bScan)0x0F);
                            rand11 = 0;
                            System.Media.SystemSounds.Hand.Play();
                        }
                }
                cevent(12, InputSimulator.GetAsyncKeyState(System.Windows.Forms.Keys.ShiftKey) & RC12);
                if (WU[12] == 1)
                {
                    if (rand12 == 0)
                    {
                        InputSimulator.SimulateKeyDown((VirtualKeyCode)0x10, (bScan)0x2A);
                        rand12 = 1;
                        System.Media.SystemSounds.Asterisk.Play();
                    }
                    else
                        if (rand12 == 1)
                        {
                            InputSimulator.SimulateKeyUp((VirtualKeyCode)0x10, (bScan)0x2A);
                            rand12 = 0;
                            System.Media.SystemSounds.Hand.Play();
                        }
                }
                cevent(13, InputSimulator.GetAsyncKeyState(System.Windows.Forms.Keys.Space) & RC13);
                if (WU[13] == 1)
                {
                    if (rand13 == 0)
                    {
                        InputSimulator.SimulateKeyDown((VirtualKeyCode)0x20, (bScan)0x39);
                        rand13 = 1;
                        System.Media.SystemSounds.Asterisk.Play();
                    }
                    else
                        if (rand13 == 1)
                        {
                            InputSimulator.SimulateKeyUp((VirtualKeyCode)0x20, (bScan)0x39);
                            rand13 = 0;
                            System.Media.SystemSounds.Hand.Play();
                        }
                }
                cevent(14, InputSimulator.GetAsyncKeyState(System.Windows.Forms.Keys.Enter) & RC14);
                if (WU[14] == 1)
                {
                    if (rand14 == 0)
                    {
                        InputSimulator.SimulateKeyDown((VirtualKeyCode)0x0D, (bScan)0x1C);
                        rand14 = 1;
                        System.Media.SystemSounds.Asterisk.Play();
                    }
                    else
                        if (rand14 == 1)
                        {
                            InputSimulator.SimulateKeyUp((VirtualKeyCode)0x0D, (bScan)0x1C);
                            rand14 = 0;
                            System.Media.SystemSounds.Hand.Play();
                        }
                }
                cevent(15, InputSimulator.GetAsyncKeyState(System.Windows.Forms.Keys.Left) & RC15);
                if (WU[15] == 1)
                {
                    if (rand15 == 0)
                    {
                        InputSimulator.SimulateKeyDown((VirtualKeyCode)0x25, (bScan)0xCB);
                        rand15 = 1;
                        System.Media.SystemSounds.Asterisk.Play();
                    }
                    else
                        if (rand15 == 1)
                        {
                            InputSimulator.SimulateKeyUp((VirtualKeyCode)0x25, (bScan)0xCB);
                            rand15 = 0;
                            System.Media.SystemSounds.Hand.Play();
                        }
                }
                cevent(16, InputSimulator.GetAsyncKeyState(System.Windows.Forms.Keys.Right) & RC16);
                if (WU[16] == 1)
                {
                    if (rand16 == 0)
                    {
                        InputSimulator.SimulateKeyDown((VirtualKeyCode)0x27, (bScan)0xCD);
                        rand16 = 1;
                        System.Media.SystemSounds.Asterisk.Play();
                    }
                    else
                        if (rand16 == 1)
                        {
                            InputSimulator.SimulateKeyUp((VirtualKeyCode)0x27, (bScan)0xCD);
                            rand16 = 0;
                            System.Media.SystemSounds.Hand.Play();
                        }
                }
                cevent(17, InputSimulator.GetAsyncKeyState(System.Windows.Forms.Keys.Up) & RC17);
                if (WU[17] == 1)
                {
                    if (rand17 == 0)
                    {
                        InputSimulator.SimulateKeyDown((VirtualKeyCode)0x26, (bScan)0xC8);
                        rand17 = 1;
                        System.Media.SystemSounds.Asterisk.Play();
                    }
                    else
                        if (rand17 == 1)
                        {
                            InputSimulator.SimulateKeyUp((VirtualKeyCode)0x26, (bScan)0xC8);
                            rand17 = 0;
                            System.Media.SystemSounds.Hand.Play();
                        }
                }
                cevent(18, InputSimulator.GetAsyncKeyState(System.Windows.Forms.Keys.Down) & RC18);
                if (WU[18] == 1)
                {
                    if (rand18 == 0)
                    {
                        InputSimulator.SimulateKeyDown((VirtualKeyCode)0x28, (bScan)0xD0);
                        rand18 = 1;
                        System.Media.SystemSounds.Asterisk.Play();
                    }
                    else
                        if (rand18 == 1)
                        {
                            InputSimulator.SimulateKeyUp((VirtualKeyCode)0x28, (bScan)0xD0);
                            rand18 = 0;
                            System.Media.SystemSounds.Hand.Play();
                        }
                }
                System.Threading.Thread.Sleep(1);
                if (breakstart | !this.Visible)
                    break;
            }
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
        struct INPUT
        {
            public UInt32 Type;
            public MOUSEKEYBDHARDWAREINPUT Data;
        }
        public static class InputSimulator
        {
            public static void SimulateKeyDown(VirtualKeyCode keyCode, bScan bScan)
            {
                var down = new INPUT();
                down.Type = (UInt32)InputType.KEYBOARD;
                down.Data.Keyboard = new KEYBDINPUT();
                down.Data.Mouse.MouseData = 0;
                down.Data.Keyboard.Vk = (UInt16)keyCode;
                down.Data.Keyboard.Scan = (UInt16)bScan;
                down.Data.Keyboard.Flags = 0;
                down.Data.Keyboard.Time = 0;
                down.Data.Keyboard.ExtraInfo = IntPtr.Zero;
                INPUT[] inputList = new INPUT[1];
                inputList[0] = down;
                var numberOfSuccessfulSimulatedInputs = SendInput(1, inputList, System.Runtime.InteropServices.Marshal.SizeOf(typeof(INPUT)));
            }
            public static void SimulateKeyUp(VirtualKeyCode keyCode, bScan bScan)
            {
                var up = new INPUT();
                up.Type = (UInt32)InputType.KEYBOARD;
                up.Data.Keyboard = new KEYBDINPUT();
                up.Data.Mouse.MouseData = 0;
                up.Data.Keyboard.Vk = (UInt16)keyCode;
                up.Data.Keyboard.Scan = (UInt16)bScan;
                up.Data.Keyboard.Flags = (UInt32)KeyboardFlag.KEYUP;
                up.Data.Keyboard.Time = 0;
                up.Data.Keyboard.ExtraInfo = IntPtr.Zero;
                INPUT[] inputList = new INPUT[1];
                inputList[0] = up;
                var numberOfSuccessfulSimulatedInputs = SendInput(1, inputList, System.Runtime.InteropServices.Marshal.SizeOf(typeof(INPUT)));
            }
            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
            static extern UInt32 SendInput(UInt32 numberOfInputs, INPUT[] inputs, Int32 sizeOfInputStructure);
            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
            public static extern bool GetAsyncKeyState(System.Windows.Forms.Keys vKey);
        }
        public enum InputType : uint // UInt32
        {
            MOUSE = 0, KEYBOARD = 1, HARDWARE = 2,
        }
        struct KEYBDINPUT
        {
            public UInt16 Vk;
            public UInt16 Scan;
            public UInt32 Flags;
            public UInt32 Time;
            public IntPtr ExtraInfo;
        }
        public enum KeyboardFlag : uint // UInt32
        {
            EXTENDEDKEY = 0x0001, KEYUP = 0x0002, UNICODE = 0x0004, SCANCODE = 0x0008,
        }
        public enum MouseFlag : uint
        {
            MOVE = 0x0001, LEFTDOWN = 0x0002, LEFTUP = 0x0004, RIGHTDOWN = 0x0008, RIGHTUP = 0x0010, MIDDLEDOWN = 0x0020, MIDDLEUP = 0x0040, XDOWN = 0x0080, XUP = 0x0100, WHEEL = 0x0800, VIRTUALDESK = 0x4000, ABSOLUTE = 0x8000,
        }
        struct MOUSEINPUT
        {
            public Int32 X;
            public Int32 Y;
            public Int32 MouseData;
            public UInt32 Flags;
            public UInt32 Time;
            public IntPtr ExtraInfo;
        }
        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit)]
        struct MOUSEKEYBDHARDWAREINPUT
        {
            [System.Runtime.InteropServices.FieldOffset(0)]
            public MOUSEINPUT Mouse;
            [System.Runtime.InteropServices.FieldOffset(0)]
            public KEYBDINPUT Keyboard;
        }
        public enum VirtualKeyCode : ushort { }
        public enum bScan : ushort { }
        private void button2_Click_1(object sender, EventArgs e)
        {
            breakstart = true;
        }
        private static int[] WD = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36 };
        private static int[] WU = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36 };
        public static void cevent(int cint, bool cbool)
        {
            if (cbool)
            {
                if (WD[cint] <= 1)
                    WD[cint] = WD[cint] + 1;
                WU[cint] = 0;
            }
            else
            {
                if (WU[cint] <= 1)
                    WU[cint] = WU[cint] + 1;
                WD[cint] = 0;
            }
        }
    }
}
