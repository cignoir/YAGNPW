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
using YAGNPW;

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

            if(Win32API.IsIconic(hWnd))
            {
                //SendMessage(hWnd, WM_SYSCOMMAND, SC_MAXIMIZE, 0);
                //ShowWindowAsync(hWnd, SW_RESTORE);
                //SetFocus(hWnd);
                Win32API.SwitchToThisWindow(hWnd, true);
            }

            IntPtr forehWnd = Win32API.GetForegroundWindow();
            if(forehWnd == hWnd)
            {
                return;
            }
            uint foreThread = Win32API.GetWindowThreadProcessId(forehWnd, IntPtr.Zero);
            uint thisThread = Win32API.GetCurrentThreadId();
            uint timeout = 200000;
            if(foreThread != thisThread)
            {
                Win32API.SystemParametersInfoGet(Win32API.SPI_GETFOREGROUNDLOCKTIMEOUT, 0, ref timeout, 0);
                Win32API.SystemParametersInfoSet(Win32API.SPI_SETFOREGROUNDLOCKTIMEOUT, 0, 0, 0);

                Win32API.AttachThreadInput(thisThread, foreThread, true);
            }

            Win32API.SetForegroundWindow(hWnd);
            Win32API.SetWindowPos(hWnd, Win32API.HWND_TOP, 0, 0, 0, 0,
                Win32API.SWP_NOMOVE | Win32API.SWP_NOSIZE | Win32API.SWP_SHOWWINDOW | Win32API.SWP_ASYNCWINDOWPOS);
            Win32API.BringWindowToTop(hWnd);
            //ShowWindowAsync(hWnd, SW_SHOW);
            Win32API.SetFocus(hWnd);
            Win32API.SwitchToThisWindow(hWnd, true);

            if(foreThread != thisThread)
            {
                Win32API.SystemParametersInfoSet(Win32API.SPI_SETFOREGROUNDLOCKTIMEOUT, 0, timeout, 0);
                Win32API.AttachThreadInput(thisThread, foreThread, false);
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
                        var itemName = String.Format("{0} @{1}", process.ProcessName, process.Id);
                        if(!setList.Contains(itemName))
                        {
                            listBox.Items.Add(String.Format("{0} @{1}", process.ProcessName, process.Id));
                        }
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
                    var itemName = String.Format("{0} @{1}", process.ProcessName, process.Id);
                    if(!setList.Contains(itemName))
                    {
                        listBox.Items.Add(String.Format("{0} @{1}", process.ProcessName, process.Id));
                    }
                }
            }
            listBox.SetSelected(0, true);
        }

        private void RegisterAllHotkeys(int modKeys)
        {
            Win32API.RegisterHotKey(this.Handle, Win32API.WM_HOTKEY1, modKeys, (int)Keys.D1);
            Win32API.RegisterHotKey(this.Handle, Win32API.WM_HOTKEY2, modKeys, (int)Keys.D2);
            Win32API.RegisterHotKey(this.Handle, Win32API.WM_HOTKEY3, modKeys, (int)Keys.D3);
            Win32API.RegisterHotKey(this.Handle, Win32API.WM_HOTKEY4, modKeys, (int)Keys.D4);
            Win32API.RegisterHotKey(this.Handle, Win32API.WM_HOTKEY5, modKeys, (int)Keys.D5);
        }

        private void RegisterHotkeysByMOD()
        {
            if(altRadioButton.Checked)
            {
                RegisterAllHotkeys(Win32API.MOD_ALT);
                UpdateGroupBoxText("ALT");
            }
            else if(ctrlRadioButton.Checked)
            {
                RegisterAllHotkeys(Win32API.MOD_CONTROL);
                UpdateGroupBoxText("CTRL");
            }
            else if(winRadioButton.Checked)
            {
                RegisterAllHotkeys(Win32API.MOD_WIN);
                UpdateGroupBoxText("WIN");
            }
            else if(shiftRadioButton.Checked)
            {
                RegisterAllHotkeys(Win32API.MOD_SHIFT);
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
            Win32API.UnregisterHotKey(this.Handle, Win32API.WM_HOTKEY1);
            Win32API.UnregisterHotKey(this.Handle, Win32API.WM_HOTKEY2);
            Win32API.UnregisterHotKey(this.Handle, Win32API.WM_HOTKEY3);
            Win32API.UnregisterHotKey(this.Handle, Win32API.WM_HOTKEY4);
            Win32API.UnregisterHotKey(this.Handle, Win32API.WM_HOTKEY5);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            int procId = 0;
            string[] split = null;
            if(m.Msg == Win32API.WM_HOTKEY)
            {
                switch((int)m.WParam)
                {
                    case Win32API.WM_HOTKEY1:
                        split = label1.Text.Split('@');
                        break;
                    case Win32API.WM_HOTKEY2:
                        split = label2.Text.Split('@');
                        break;
                    case Win32API.WM_HOTKEY3:
                        split = label3.Text.Split('@');
                        break;
                    case Win32API.WM_HOTKEY4:
                        split = label4.Text.Split('@');
                        break;
                    case Win32API.WM_HOTKEY5:
                        split = label5.Text.Split('@');
                        break;
                    default:
                        break;
                }
                procId = split.Length > 1 ? int.Parse(split[split.Length - 1]) : 0;
            }

            if(procId != 0)
            {
                foreach(Process proc in Process.GetProcesses())
                {
                    if(!proc.MainWindowHandle.Equals(IntPtr.Zero))
                    {
                        if(proc.Id == procId)
                        {
                            try
                            {
                                ActivateWindow(proc.MainWindowHandle);
                            }
                            catch
                            {
                            }
                        }
                        else
                        {
                            if(!Win32API.IsIconic(proc.MainWindowHandle))
                            {
                                try
                                {
                                    HideWindow(proc.MainWindowHandle);
                                }
                                catch
                                {
                                }
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
            Win32API.SendMessage(hWnd, Win32API.WM_SYSCOMMAND, Win32API.SC_MINIMIZE, 0);
            //SendMessage(hWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
            //ShowWindowAsync(hWnd, SW_SHOWMINNOACTIVE);
        }

    }
}
