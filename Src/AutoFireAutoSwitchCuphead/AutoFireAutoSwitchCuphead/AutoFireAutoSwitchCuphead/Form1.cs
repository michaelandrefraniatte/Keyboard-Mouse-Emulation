using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoFireAutoSwitchCuphead
{
    public partial class AutoFireAutoSwitchCuphead : Form
    {
        private static System.Threading.Thread thrAutoFire;
        private static int WD, WU, Interval, Pressdelay;
        private static bool starton;
        private static string fire, switcher;
        private static Point fireassign, switcherassign;
        public AutoFireAutoSwitchCuphead()
        {
            InitializeComponent();
        }
        private struct Point
        {
            public int X, Y;
            public Point(int X, int Y)
            {
                this.X = X;
                this.Y = Y;
            }
            public override string ToString()
            {
                return (String.Format("({0},{1})", X, Y));
            }
        }
        private Point assign(string keys)
        {
            int vkcode = 0;
            int bscancode = 0;
            switch (keys)
            {
                case "Fire":
                    vkcode = 0x58;
                    bscancode = 0x2D;
                    break;
                case "Switch":
                    vkcode = 0x09;
                    bscancode = 0x0F;
                    break;
                case "right click":
                    vkcode = 0x888;
                    bscancode = 0x888;
                    break;
                case "left click":
                    vkcode = 0x999;
                    bscancode = 0x999;
                    break;
                case "middle click":
                    vkcode = 0x666;
                    bscancode = 0x666;
                    break;
                case "wheel up":
                    vkcode = 0x444;
                    bscancode = 0x444;
                    break;
                case "wheel down":
                    vkcode = 0x333;
                    bscancode = 0x333;
                    break;
                case "W":
                    vkcode = 0x57;
                    bscancode = 0x11;
                    break;
                case "A":
                    vkcode = 0x41;
                    bscancode = 0x1E;
                    break;
                case "Z":
                    vkcode = 0x5A;
                    bscancode = 0x2C;
                    break;
                case "Q":
                    vkcode = 0x51;
                    bscancode = 0x10;
                    break;
                case "S":
                    vkcode = 0x53;
                    bscancode = 0x1F;
                    break;
                case "D":
                    vkcode = 0x44;
                    bscancode = 0x20;
                    break;
                case "E":
                    vkcode = 0x45;
                    bscancode = 0x12;
                    break;
                case "R":
                    vkcode = 0x52;
                    bscancode = 0x13;
                    break;
                case "F":
                    vkcode = 0x46;
                    bscancode = 0x21;
                    break;
                case "J":
                    vkcode = 0x4A;
                    bscancode = 0x24;
                    break;
                case "K":
                    vkcode = 0x4B;
                    bscancode = 0x25;
                    break;
                case "B":
                    vkcode = 0x42;
                    bscancode = 0x30;
                    break;
                case "N":
                    vkcode = 0x4E;
                    bscancode = 0x31;
                    break;
                case "X":
                    vkcode = 0x58;
                    bscancode = 0x2D;
                    break;
                case "Y":
                    vkcode = 0x59;
                    bscancode = 0x15;
                    break;
                case "U":
                    vkcode = 0x55;
                    bscancode = 0x16;
                    break;
                case "C":
                    vkcode = 0x43;
                    bscancode = 0x2E;
                    break;
                case "T":
                    vkcode = 0x54;
                    bscancode = 0x14;
                    break;
                case "G":
                    vkcode = 0x47;
                    bscancode = 0x22;
                    break;
                case "H":
                    vkcode = 0x48;
                    bscancode = 0x23;
                    break;
                case "V":
                    vkcode = 0x56;
                    bscancode = 0x2F;
                    break;
                case "Tab":
                    vkcode = 0x09;
                    bscancode = 0x0F;
                    break;
                case "Space":
                    vkcode = 0x20;
                    bscancode = 0x39;
                    break;
                case "Enter":
                    vkcode = 0x0D;
                    bscancode = 0x1C;
                    break;
                case "Shift":
                    vkcode = 0x10;
                    bscancode = 0x2A;
                    break;
                case "Control":
                    vkcode = 0x11;
                    bscancode = 0x1D;
                    break;
                case "Escape":
                    vkcode = 0x1B;
                    bscancode = 0x01;
                    break;
                case "left":
                    vkcode = 0x25;
                    bscancode = 0xCB;
                    break;
                case "right":
                    vkcode = 0x27;
                    bscancode = 0xCD;
                    break;
                case "up":
                    vkcode = 0x26;
                    bscancode = 0xC8;
                    break;
                case "down":
                    vkcode = 0x28;
                    bscancode = 0xD0;
                    break;
                case "L":
                    vkcode = 0x4C;
                    bscancode = 0x26;
                    break;
                case "M":
                    vkcode = 0x4D;
                    bscancode = 0x32;
                    break;
                case "P":
                    vkcode = 0x50;
                    bscancode = 0x19;
                    break;
                case "O":
                    vkcode = 0x4F;
                    bscancode = 0x18;
                    break;
                case "I":
                    vkcode = 0x49;
                    bscancode = 0x17;
                    break;
                case "Apostrophe":
                    vkcode = 0xDE;
                    bscancode = 0xDE;
                    break;
                case "Back":
                    vkcode = 0x08;
                    bscancode = 0x0E;
                    break;
                case "0":
                    vkcode = 0x30;
                    bscancode = 0x0B;
                    break;
                case "1":
                    vkcode = 0x31;
                    bscancode = 0x02;
                    break;
                case "2":
                    vkcode = 0x32;
                    bscancode = 0x03;
                    break;
                case "3":
                    vkcode = 0x33;
                    bscancode = 0x04;
                    break;
                case "4":
                    vkcode = 0x34;
                    bscancode = 0x05;
                    break;
                case "5":
                    vkcode = 0x35;
                    bscancode = 0x06;
                    break;
                case "6":
                    vkcode = 0x36;
                    bscancode = 0x07;
                    break;
                case "7":
                    vkcode = 0x37;
                    bscancode = 0x08;
                    break;
                case "8":
                    vkcode = 0x38;
                    bscancode = 0x09;
                    break;
                case "9":
                    vkcode = 0x39;
                    bscancode = 0x0A;
                    break;
                case "Alt":
                    vkcode = 0x12;
                    bscancode = 0x38;
                    break;
                case "F1":
                    vkcode = 0x70;
                    bscancode = 0x3B;
                    break;
                case "F2":
                    vkcode = 0x71;
                    bscancode = 0x3C;
                    break;
                case "F3":
                    vkcode = 0x72;
                    bscancode = 0x3D;
                    break;
                case "F4":
                    vkcode = 0x73;
                    bscancode = 0x3E;
                    break;
                case "F5":
                    vkcode = 0x74;
                    bscancode = 0x3F;
                    break;
                case "F6":
                    vkcode = 0x75;
                    bscancode = 0x40;
                    break;
                case "F7":
                    vkcode = 0x76;
                    bscancode = 0x41;
                    break;
                case "F8":
                    vkcode = 0x77;
                    bscancode = 0x42;
                    break;
                case "F9":
                    vkcode = 0x78;
                    bscancode = 0x43;
                    break;
                case "F10":
                    vkcode = 0x79;
                    bscancode = 0x44;
                    break;
                case "F11":
                    vkcode = 0x7A;
                    bscancode = 0x57;
                    break;
                case "F12":
                    vkcode = 0x7B;
                    bscancode = 0x58;
                    break;
                case "LControl":
                    vkcode = 0xA2;
                    bscancode = 0x1D;
                    break;
                case "RControl":
                    vkcode = 0xA3;
                    bscancode = 0x9D;
                    break;
                case "LShift":
                    vkcode = 0xA0;
                    bscancode = 0x2A;
                    break;
                case "RShift":
                    vkcode = 0xA1;
                    bscancode = 0x36;
                    break;
                case "":
                    break;
            }
            return new Point(vkcode, bscancode);
        }
        private void AutoFire()
        {
            while (true)
            {
                if (!this.Visible)
                {
                    if (fireassign.X != 0x888 & fireassign.X != 0x999 & fireassign.X != 0x666 & fireassign.X != 0x444 & fireassign.X != 0x333 & fireassign.X != 0)
                        SendE.SimulateKeyUp((ushort)fireassign.X, (ushort)fireassign.Y);
                    else
                        mouseeventf(fireassign.X);
                    if (switcherassign.X != 0x888 & switcherassign.X != 0x999 & switcherassign.X != 0x666 & switcherassign.X != 0x444 & switcherassign.X != 0x333 & switcherassign.X != 0)
                        SendE.SimulateKeyUp((ushort)switcherassign.X, (ushort)switcherassign.Y);
                    else
                        mouseeventf(switcherassign.X);
                    break;
                }
                //if (Mouse.GetState().LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                //SendE.GetAsyncKeyState(System.Windows.Forms.Keys.ShiftKey)
                if (SendE.GetAsyncKeyState(System.Windows.Forms.Keys.CapsLock))
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
                    if (!starton)
                    {
                        assignating();
                        starton = true;
                    }
                    else
                        starton = false;
                } 
                if (starton)
                {
                    if (fireassign.X != 0x888 & fireassign.X != 0x999 & fireassign.X != 0x666 & fireassign.X != 0x444 & fireassign.X != 0x333 & fireassign.X != 0)
                        SendE.SimulateKeyDown((ushort)fireassign.X, (ushort)fireassign.Y);
                    else
                        mouseevent(fireassign.X);
                    if (switcherassign.X != 0x888 & switcherassign.X != 0x999 & switcherassign.X != 0x666 & switcherassign.X != 0x444 & switcherassign.X != 0x333 & switcherassign.X != 0)
                        SendE.SimulateKeyDown((ushort)switcherassign.X, (ushort)switcherassign.Y);
                    else
                        mouseevent(switcherassign.X);
                    System.Threading.Thread.Sleep(Pressdelay);
                    if (switcherassign.X != 0x888 & switcherassign.X != 0x999 & switcherassign.X != 0x666 & switcherassign.X != 0x444 & switcherassign.X != 0x333 & switcherassign.X != 0)
                        SendE.SimulateKeyUp((ushort)switcherassign.X, (ushort)switcherassign.Y);
                    else
                        mouseeventf(switcherassign.X);
                }
                if (!starton & WD == 1)
                {
                    if (fireassign.X != 0x888 & fireassign.X != 0x999 & fireassign.X != 0x666 & fireassign.X != 0x444 & fireassign.X != 0x333 & fireassign.X != 0)
                        SendE.SimulateKeyUp((ushort)fireassign.X, (ushort)fireassign.Y);
                    else
                        mouseeventf(fireassign.X);
                    if (switcherassign.X != 0x888 & switcherassign.X != 0x999 & switcherassign.X != 0x666 & switcherassign.X != 0x444 & switcherassign.X != 0x333 & switcherassign.X != 0)
                        SendE.SimulateKeyUp((ushort)switcherassign.X, (ushort)switcherassign.Y);
                    else
                        mouseeventf(switcherassign.X);
                }
                System.Threading.Thread.Sleep(Interval);
            }
        }
        private void mouseevent(int micetypeevent)
        {
            if (micetypeevent == 0x888)
                SendE.RightClick();
            if (micetypeevent == 0x999)
                SendE.LeftClick();
            if (micetypeevent == 0x666)
                SendE.MiddleClick();
            if (micetypeevent == 0x444)
                SendE.WheelUpF();
            if (micetypeevent == 0x333)
                SendE.WheelDownF();
        }
        private void mouseeventf(int micetypeevent)
        {
            if (micetypeevent == 0x888)
                SendE.RightClickF();
            if (micetypeevent == 0x999)
                SendE.LeftClickF();
            if (micetypeevent == 0x666)
                SendE.MiddleClickF();
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
        public enum InputType : uint // UInt32
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
        private void AutoFireAutoSwitchCuphead_Load(object sender, EventArgs e)
        {
            thrAutoFire = new System.Threading.Thread(new System.Threading.ThreadStart(AutoFire));
            thrAutoFire.Start();
        }
        public void assignating()
        {
            fire = toolStripComboBox1.Text;
            switcher = toolStripComboBox2.Text;
            fireassign.X = assign(fire).X;
            fireassign.Y = assign(fire).Y;
            switcherassign.X = assign(switcher).X;
            switcherassign.Y = assign(switcher).Y;
            if (toolStripTextBox1.Text == "Interval")
                Interval = 40;
            else
                Interval = int.Parse(toolStripTextBox1.Text);
            if (toolStripTextBox2.Text == "Press delay")
                Pressdelay = 10;
            else
                Pressdelay = int.Parse(toolStripTextBox2.Text);
        }
        private void enregistrerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String charstore;
            System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                charstore = saveFileDialog1.FileName;
                System.IO.StreamWriter file = new System.IO.StreamWriter(charstore);
                file.WriteLine("//Fire");
                file.WriteLine(toolStripComboBox1.Text);
                file.WriteLine("//Switch");
                file.WriteLine(toolStripComboBox2.Text);
                file.WriteLine("//Interval");
                file.WriteLine(toolStripTextBox1.Text);
                file.WriteLine("//Press delay");
                file.WriteLine(toolStripTextBox2.Text);
                file.Close();
            }
        }
        private void ouvrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String myRead;
            System.Windows.Forms.OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                myRead = openFileDialog1.FileName;
                System.IO.StreamReader file = new System.IO.StreamReader(myRead);
                file.ReadLine();
                toolStripComboBox1.SelectedItem = file.ReadLine();
                file.ReadLine();
                toolStripComboBox2.SelectedItem = file.ReadLine();
                file.ReadLine();
                toolStripTextBox1.Text = file.ReadLine();
                file.ReadLine();
                toolStripTextBox2.Text = file.ReadLine();
                file.Close();
            }
            assignating();
        }
    }
}
