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
