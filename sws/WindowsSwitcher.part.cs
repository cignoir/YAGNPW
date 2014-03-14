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
        public WindowsSwitcher()
        {
            InitializeComponent();
            ShowAllProcesses();
        }

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

            if(listBox.Items.Count > 0)
            {
                listBox.SetSelected(0, true);
            }
        }

        private void ShowAllProcesses()
        {
            var processes = Process.GetProcesses();
            foreach(var process in processes)
            {
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
            if(m.Msg == WM_HOTKEY)
            {
                switch((int)m.WParam)
                {
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
                foreach(Process proc in Process.GetProcesses())
                {
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

    }
}
