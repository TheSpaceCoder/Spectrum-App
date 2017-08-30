﻿using Microsoft.Win32;
using Spectrum.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spectrum {
    public partial class SettingsForm : Form {

        int originalComboBoxVal = Settings.Default.updateComboBoxInt;

        bool checkChanged = false;
        public SettingsForm() {
            InitializeComponent();


            Size = new Size(391, 320);

            if (Settings.Default.isConnected) startupConnectCheckBox.Enabled = true;
            // Sets Check Box
            if (Settings.Default.closeToTrayBool) closeToTrayCheckbox.Checked = true;
            if (Settings.Default.connectOnStartupBool) startupConnectCheckBox.Checked = true;
            if (Settings.Default.startMinimizedBool) startMinCheckbox.Checked = true;
            if (Settings.Default.windowsStartupBool) windowsCheckbox.Checked = true;

            updateComboBox.SelectedIndex = Settings.Default.updateComboBoxInt;


            treeView1.TabIndex = 0;
        }


        private void settingsCheckboxes_CheckedChanged(object sender, EventArgs e) {
            if (Settings.Default.connectOnStartupBool != startupConnectCheckBox.Checked) {
                checkChanged = true;
            }
            else if (Settings.Default.closeToTrayBool != closeToTrayCheckbox.Checked) {
                checkChanged = true;
            }
            else if (Settings.Default.startMinimizedBool != startMinCheckbox.Checked) {
                checkChanged = true;
            }
            else if (Settings.Default.windowsStartupBool != windowsCheckbox.Checked) {
                checkChanged = true;
            }
            else checkChanged = false;

            if (checkChanged || Settings.Default.updateComboBoxInt != originalComboBoxVal) applySettingsButton.Enabled = true;
            else applySettingsButton.Enabled = false;
        }


        // Apply Settings Button
        private void applySettingsButton_Click(object sender, EventArgs e) {

            setSettings();

            applySettingsButton.Enabled = false;
        }


        private void updateComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            Settings.Default.updateComboBoxInt = updateComboBox.SelectedIndex;

            if (updateComboBox.SelectedIndex == 0) Settings.Default.startupUpdateDate = false;



            if(Settings.Default.updateComboBoxInt != originalComboBoxVal) applySettingsButton.Enabled = true;
            else if (!checkChanged) applySettingsButton.Enabled = false;
            
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e) {
            if (treeView1.SelectedNode.Name == "generalNode") {
                updatesGroupBox.Visible = false;
                generalSettingsGroupBox.Visible = true;
            }
            else if (treeView1.SelectedNode.Name == "updatesNode") {
                generalSettingsGroupBox.Visible = false;
                updatesGroupBox.Left = 111;
                updatesGroupBox.Top = 34;
                updatesGroupBox.Visible = true;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e) {

            if (applySettingsButton.Enabled) {
                DialogResult dialogResult = MessageBox.Show("You have unsaved settings are you sure you want to exit settings without saving?", "Exit Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes) Close();
            }
            else Close();
            
        }

        private void okButton_Click(object sender, EventArgs e) {
            setSettings();
            Close();
        }

        void setSettings() {
            // Connect at Startup Settings
            if (startupConnectCheckBox.Checked) Settings.Default.connectOnStartupBool = true;
            else Settings.Default.connectOnStartupBool = false;

            // Close to Tray Settings
            if (closeToTrayCheckbox.Checked) Settings.Default.closeToTrayBool = true;
            else Settings.Default.closeToTrayBool = false;

            // Start Minimized
            if (startMinCheckbox.Checked) Settings.Default.startMinimizedBool = true;
            else Settings.Default.startMinimizedBool = false;

            // Start With Windows
            if (windowsCheckbox.Checked) {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true)) {
                    key.SetValue("Spectrum", "\"" + Application.ExecutablePath + "\"");
                    Settings.Default.windowsStartupBool = true;
                }
            }
            else {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true)) {
                    key.DeleteValue("Spectrum", false);
                    Settings.Default.windowsStartupBool = false;
                }
            }
            Settings.Default.Save();
        }

    }
}
