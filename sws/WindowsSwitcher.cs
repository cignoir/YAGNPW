using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sws
{
    public partial class WindowsSwitcher: Form
    {
        const int MOD_ALT = 0x0001;
        const int MOD_CONTROL = 0x0002;
        const int MOD_SHIFT = 0x0004;
        const int MOD_WIN = 0x0008;
        const int WM_HOTKEY = 0x0312;
        const int WM_HOTKEY1 = 0x0001;
        const int WM_HOTKEY2 = 0x0002;
        const int WM_HOTKEY3 = 0x0003;
        const int WM_HOTKEY4 = 0x0004;
        const int WM_HOTKEY5 = 0x0005;

        public WindowsSwitcher()
        {
            InitializeComponent();
            ShowAllProcesses();
        }

        [DllImport("user32.dll")]
        extern static int RegisterHotKey(IntPtr HWnd, int ID, int MOD_KEY, int KEY);

        [DllImport("user32.dll")]
        extern static int UnregisterHotKey(IntPtr HWnd, int ID);

        private void ActivateWindow(IntPtr hWnd)
        {
            if(hWnd == IntPtr.Zero)
            {
                return;
            }

            if(IsIconic(hWnd))
            {
                ShowWindowAsync(hWnd, SW_RESTORE);
            }

            IntPtr forehWnd=GetForegroundWindow();
            if(forehWnd == hWnd)
            {
                return;
            }
            uint foreThread = GetWindowThreadProcessId(forehWnd, IntPtr.Zero);
            uint thisThread = GetCurrentThreadId();
            uint timeout = 200000;
            if(foreThread != thisThread)
            {
                SystemParametersInfoGet(SPI_GETFOREGROUNDLOCKTIMEOUT, 0, ref timeout, 0);
                SystemParametersInfoSet(SPI_SETFOREGROUNDLOCKTIMEOUT, 0, 0, 0);

                AttachThreadInput(thisThread, foreThread, true);
            }

            SetForegroundWindow(hWnd);
            SetWindowPos(hWnd, HWND_TOP, 0, 0, 0, 0,
                SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW | SWP_ASYNCWINDOWPOS);
            BringWindowToTop(hWnd);
            ShowWindowAsync(hWnd, SW_SHOW);
            SetFocus(hWnd);

            if(foreThread != thisThread)
            {
                SystemParametersInfoSet(SPI_SETFOREGROUNDLOCKTIMEOUT, 0, timeout, 0);
                AttachThreadInput(thisThread, foreThread, false);
            }
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool BringWindowToTop(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern IntPtr SetFocus(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetWindowPos(IntPtr hWnd,
            int hWndInsertAfter, int x, int y, int cx, int cy, int uFlags);

        private const int SWP_NOSIZE = 0x0001;
        private const int SWP_NOMOVE = 0x0002;
        private const int SWP_NOZORDER = 0x0004;
        private const int SWP_SHOWWINDOW = 0x0040;
        private const int SWP_ASYNCWINDOWPOS = 0x4000;
        private const int HWND_TOP = 0;
        private const int HWND_BOTTOM = 1;
        private const int HWND_TOPMOST = -1;
        private const int HWND_NOTOPMOST = -2;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        private const int SW_SHOWNORMAL = 1;
        private const int SW_SHOWMINIMIZED = 2;
        private const int SW_SHOW = 5;
        private const int SW_RESTORE = 9;
        private const int SW_FORCEMINIMIZE = 11;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsIconic(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(
            IntPtr hWnd, IntPtr ProcessId);

        [DllImport("kernel32.dll")]
        private static extern uint GetCurrentThreadId();

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AttachThreadInput(
            uint idAttach, uint idAttachTo, bool fAttach);

        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo",
            SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SystemParametersInfoGet(
            uint action, uint param, ref uint vparam, uint init);

        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo",
            SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SystemParametersInfoSet(
            uint action, uint param, uint vparam, uint init);

        private const uint SPI_GETFOREGROUNDLOCKTIMEOUT = 0x2000;
        private const uint SPI_SETFOREGROUNDLOCKTIMEOUT = 0x2001;
        private const uint SPIF_UPDATEINIFILE = 0x01;
        private const uint SPIF_SENDCHANGE = 0x02;

        private void FilterListBox()
        {
            if(filterTextBox.Text.Length != 0)
            {
                listBox.Items.Clear();

                foreach(var process in Process.GetProcesses())
                {
                    if(process.ProcessName.Contains(filterTextBox.Text))
                    {
                        listBox.Items.Add(String.Format("{0} @{1}", process.ProcessName, process.Id));
                    }
                }
            }
            else
            {
                listBox.Items.Clear();
                ShowAllProcesses();
            }

            if(listBox.Items.Count > 0){
                listBox.SetSelected(0, true);
            }
        }

        private void ShowAllProcesses(){
            var processes = Process.GetProcesses();
            foreach(var process in processes){
                if(!process.MainWindowHandle.Equals(IntPtr.Zero))
                {
                    listBox.Items.Add(String.Format("{0} @{1}", process.ProcessName, process.Id));
                }
            }
            listBox.SetSelected(0, true);
        }

        private void RegisterAllHotkeys(int modKeys)
        {
            RegisterHotKey(this.Handle, WM_HOTKEY1, modKeys, (int)Keys.D1);
            RegisterHotKey(this.Handle, WM_HOTKEY2, modKeys, (int)Keys.D2);
            RegisterHotKey(this.Handle, WM_HOTKEY3, modKeys, (int)Keys.D3);
            RegisterHotKey(this.Handle, WM_HOTKEY4, modKeys, (int)Keys.D4);
            RegisterHotKey(this.Handle, WM_HOTKEY5, modKeys, (int)Keys.D5);
        }

        private void RegisterHotkeysByMOD()
        {
            if(altRadioButton.Checked)
            {
                RegisterAllHotkeys(MOD_ALT);
                UpdateGroupBoxText("ALT");
            }
            else if(ctrlRadioButton.Checked)
            {
                RegisterAllHotkeys(MOD_CONTROL);
                UpdateGroupBoxText("CTRL");
            }
            else if(winRadioButton.Checked)
            {
                RegisterAllHotkeys(MOD_WIN);
                UpdateGroupBoxText("WIN");
            }
            else if(shiftRadioButton.Checked)
            {
                RegisterAllHotkeys(MOD_SHIFT);
                UpdateGroupBoxText("SHIFT");
            }
        }

        private void UpdateGroupBoxText(string modKeyName)
        {
            groupBox1.Text = String.Format("{0} + 1", modKeyName);
            groupBox2.Text = String.Format("{0} + 2", modKeyName);
            groupBox3.Text = String.Format("{0} + 3", modKeyName);
            groupBox4.Text = String.Format("{0} + 4", modKeyName);
            groupBox5.Text = String.Format("{0} + 5", modKeyName);
        }

        private void UnregisterAllHotkeys()
        {
            UnregisterHotKey(this.Handle, WM_HOTKEY1);
            UnregisterHotKey(this.Handle, WM_HOTKEY2);
            UnregisterHotKey(this.Handle, WM_HOTKEY3);
            UnregisterHotKey(this.Handle, WM_HOTKEY4);
            UnregisterHotKey(this.Handle, WM_HOTKEY5);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            int procId = 0;
            string[] split = null;
            if(m.Msg == WM_HOTKEY){
                switch((int)m.WParam){
                    case WM_HOTKEY1:
                        split = label1.Text.Split('@');
                        break;
                    case WM_HOTKEY2:
                        split = label2.Text.Split('@');
                        break;
                    case WM_HOTKEY3:
                        split = label3.Text.Split('@');
                        break;
                    case WM_HOTKEY4:
                        split = label4.Text.Split('@');
                        break;
                    case WM_HOTKEY5:
                        split = label5.Text.Split('@');
                        break;
                    default:
                        break;
                }
                procId = split.Length > 0 ? int.Parse(split[split.Length - 1]) : 0;
            }

            if(procId != 0)
            {
                foreach(Process proc in Process.GetProcesses()){
                    if(!proc.MainWindowHandle.Equals(IntPtr.Zero))
                    {
                        if(proc.Id == procId)
                        {
                            ActivateWindow(proc.MainWindowHandle);
                        }
                        else
                        {
                            if(!IsIconic(proc.MainWindowHandle))
                            {
                                HideWindow(proc.MainWindowHandle);
                            }
                        }
                    }
                }
            }
        }

        private void HideWindow(IntPtr hWnd)
        {
            if(hWnd == IntPtr.Zero)
            {
                return;
            }

            ShowWindowAsync(hWnd, SW_SHOWMINIMIZED);
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            FilterListBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(listBox.SelectedItems.Count != 0){
                label1.Text = listBox.SelectedItem.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(listBox.SelectedItems.Count != 0)
            {
                label2.Text = listBox.SelectedItem.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(listBox.SelectedItems.Count != 0)
            {
                label3.Text = listBox.SelectedItem.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(listBox.SelectedItems.Count != 0)
            {
                label4.Text = listBox.SelectedItem.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(listBox.SelectedItems.Count != 0)
            {
                label5.Text = listBox.SelectedItem.ToString();
            }
        }

        private void deleteButton1_Click(object sender, EventArgs e)
        {
            label1.Text = String.Empty;
        }

        private void deleteButton2_Click(object sender, EventArgs e)
        {
            label2.Text = String.Empty;
        }

        private void deleteButton3_Click(object sender, EventArgs e)
        {
            label3.Text = String.Empty;
        }

        private void deleteButton4_Click(object sender, EventArgs e)
        {
            label4.Text = String.Empty;
        }

        private void deleteButton5_Click(object sender, EventArgs e)
        {
            label5.Text = String.Empty;
        }

        private void WindowsSwitcher_Load(object sender, EventArgs e)
        {
            RegisterAllHotkeys(MOD_ALT);
            UpdateGroupBoxText("ALT");
        }

        private void WindowsSwitcher_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnregisterAllHotkeys();
        }

        private void WindowsSwitcher_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                FilterListBox();
            }
        }

        private void filterTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                FilterListBox();
            }
        }

        private void altRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UnregisterAllHotkeys();
            RegisterHotkeysByMOD();
        }

        private void ctrlRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UnregisterAllHotkeys();
            RegisterHotkeysByMOD();
        }

        private void winRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UnregisterAllHotkeys();
            RegisterHotkeysByMOD();
        }

        private void shiftRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UnregisterAllHotkeys();
            RegisterHotkeysByMOD();
        }
    }
}
