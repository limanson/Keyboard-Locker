using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Drawing;

namespace Keyboard_Locker
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SetWindowsHookExW(int idHook, HookHandlerDelegate lpfn, IntPtr hmod, uint dwThreadID);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr GetModuleHandle(String modulename);

        public const int WM_KEYDOWN = 0x0100;
        public const int WH_KEYBOARD_LL = 13;
        public const int WM_SYSKEYDOWN = 0x0104;

        public struct KBDLLHOOKSTRUCT
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }

        public delegate int HookHandlerDelegate(int nCode, IntPtr wparam, ref KBDLLHOOKSTRUCT lparam);

        private HookHandlerDelegate proc = null;
        private readonly string LockString = "Lock";
        private readonly string UnLockString = "UnLock";
        private readonly Color RedColor = Color.FromKnownColor(KnownColor.OrangeRed);
        private readonly Color GreenColor = Color.FromKnownColor(KnownColor.ForestGreen);
        private bool m_IsLock = false;

        private int HookCallback(int nCode, IntPtr wparam, ref KBDLLHOOKSTRUCT lparam)
        {
            return m_IsLock ? 1 : 0;
        }

        public Form1()
        {
            InitializeComponent();

            MainButton.BackColor = m_IsLock ? GreenColor : RedColor;

            proc = new HookHandlerDelegate(HookCallback);
            using (Process curPro = Process.GetCurrentProcess())
            using (ProcessModule curMod = curPro.MainModule)
            {
                SetWindowsHookExW(WH_KEYBOARD_LL, proc, GetModuleHandle(curMod.ModuleName), 0);
            }
        }

        private void MainButton_Click(object sender, EventArgs e)
        {
            m_IsLock = !m_IsLock;
            MainButton.Text = m_IsLock ? UnLockString : LockString;
            MainButton.BackColor = m_IsLock ? GreenColor : RedColor;

            notifyIcon1.ShowBalloonTip(0, this.Text,
                    string.Format("Keyboard now is 「{0}」", m_IsLock ? LockString : UnLockString),
                    ToolTipIcon.Info);

            System.GC.Collect();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.ShowInTaskbar = false;
                this.WindowState = FormWindowState.Minimized;
                notifyIcon1.Tag = string.Empty;
                notifyIcon1.ShowBalloonTip(3000, this.Text,
                    "Background running.",
                    ToolTipIcon.Info);
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.ShowForm();
        }

        private void openWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowForm();
        }

        private void lockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainButton_Click(sender, e);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            lockToolStripMenuItem.Text = m_IsLock ? UnLockString : LockString;
        }

        private void ShowForm()
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.ShowInTaskbar = true;
                this.WindowState = FormWindowState.Normal;
            }
        }

    }
}
