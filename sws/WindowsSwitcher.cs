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
        List<string> setList = new List<string>();

        private void filterButton_Click(object sender, EventArgs e)
        {
            FilterListBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(listBox.SelectedItems.Count != 0){
                if(label1.Text.Length != 0) setList.Remove(label1.Text);

                label1.Text = listBox.SelectedItem.ToString();
                setList.Add(label1.Text);
                FilterListBox();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(listBox.SelectedItems.Count != 0)
            {
                if(label2.Text.Length != 0) setList.Remove(label2.Text);
                label2.Text = listBox.SelectedItem.ToString();
                setList.Add(label2.Text);
                FilterListBox();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(listBox.SelectedItems.Count != 0)
            {
                if(label3.Text.Length != 0) setList.Remove(label3.Text);
                label3.Text = listBox.SelectedItem.ToString();
                setList.Add(label3.Text);
                FilterListBox();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(listBox.SelectedItems.Count != 0)
            {
                if(label4.Text.Length != 0) setList.Remove(label4.Text);
                label4.Text = listBox.SelectedItem.ToString();
                setList.Add(label4.Text);
                FilterListBox();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(listBox.SelectedItems.Count != 0)
            {
                if(label5.Text.Length != 0) setList.Remove(label5.Text);
                label5.Text = listBox.SelectedItem.ToString();
                setList.Add(label5.Text);
                FilterListBox();
            }
        }

        private void deleteButton1_Click(object sender, EventArgs e)
        {
            setList.Remove(label1.Text);
            FilterListBox();
            label1.Text = String.Empty;
        }

        private void deleteButton2_Click(object sender, EventArgs e)
        {
            setList.Remove(label2.Text);
            FilterListBox();
            label2.Text = String.Empty;
        }

        private void deleteButton3_Click(object sender, EventArgs e)
        {
            setList.Remove(label3.Text);
            FilterListBox();
            label3.Text = String.Empty;
        }

        private void deleteButton4_Click(object sender, EventArgs e)
        {
            setList.Remove(label4.Text);
            FilterListBox();
            label4.Text = String.Empty;
        }

        private void deleteButton5_Click(object sender, EventArgs e)
        {
            setList.Remove(label5.Text);
            FilterListBox();
            label5.Text = String.Empty;
        }

        private void WindowsSwitcher_Load(object sender, EventArgs e)
        {
            RegisterAllHotkeys(Win32API.MOD_ALT);
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
