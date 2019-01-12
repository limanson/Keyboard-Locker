using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Drawing;
using System.Collections.Generic;

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

        private static readonly string LockString = "Lock";
        private static readonly string UnLockString = "UnLock";
        private static readonly Color RedColor = Color.FromKnownColor(KnownColor.OrangeRed);
        private static readonly Color GreenColor = Color.FromKnownColor(KnownColor.ForestGreen);
        private static readonly string StateMsgString = "Keyboard now is 「{0}」";
        private static readonly string BackgroundMsgString = "Background running.";

        private static readonly List<int> ExceptionKeyCodeList = new List<int>{ 20 };
        private static readonly int ExceptionKeyComboCount = 3;
        private static readonly int ExceptionKeyComboMilliseconds = 1000;
        private int m_CurrentExceptionKeyClickCount = 0;
        private DateTime m_ExceptionKeyFirstClickTime;

        private HookHandlerDelegate m_Proc = null;
        private bool m_IsLock = false;

        private int HookCallback(int nCode, IntPtr wparam, ref KBDLLHOOKSTRUCT lparam)
        {
            if (nCode >= 0 && ExceptionKeyCodeList.Contains(lparam.vkCode) )
            {
                m_CurrentExceptionKeyClickCount++;
                if (m_CurrentExceptionKeyClickCount == 2)
                {
                    m_ExceptionKeyFirstClickTime = DateTime.Now;
                }
                else if (m_CurrentExceptionKeyClickCount == ExceptionKeyComboCount * 2)
                {
                    if ((DateTime.Now - m_ExceptionKeyFirstClickTime).TotalMilliseconds <= ExceptionKeyComboMilliseconds)
                        MainButton_Click(null, null);

                    m_CurrentExceptionKeyClickCount = 0;
                }
                
            }

            return m_IsLock ? 1 : 0;
        }

        public Form1()
        {
            InitializeComponent();

            Icon icon = Properties.Resources.AppIcon;
            this.Icon = icon;
            NotifyIcon1.Icon = icon;

            MainButton.BackColor = m_IsLock ? GreenColor : RedColor;

            m_Proc = new HookHandlerDelegate(HookCallback);
            using (Process curPro = Process.GetCurrentProcess())
            using (ProcessModule curMod = curPro.MainModule)
            {
                SetWindowsHookExW(WH_KEYBOARD_LL, m_Proc, GetModuleHandle(curMod.ModuleName), 0);
            }
        }

        private void MainButton_Click(object sender, MouseEventArgs e)
        {
            m_IsLock = !m_IsLock;
            MainButton.Text = m_IsLock ? UnLockString : LockString;
            MainButton.BackColor = m_IsLock ? GreenColor : RedColor;

            NotifyIcon1.ShowBalloonTip(0, this.Text,
                    string.Format(StateMsgString, m_IsLock ? LockString : UnLockString),
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
                NotifyIcon1.Tag = string.Empty;
                NotifyIcon1.ShowBalloonTip(3000, this.Text,
                    BackgroundMsgString,
                    ToolTipIcon.Info);
            }
        }

        private void NotifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.ShowForm();
        }

        private void OpenWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowForm();
        }

        private void LockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainButton_Click(sender, null);
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ContextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            LockToolStripMenuItem.Text = m_IsLock ? UnLockString : LockString;
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

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_IsLock = false;
            this.Dispose();
        }
    }
}
