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

        spectrumFormMain spectrumForm;

        public SettingsForm() {
            InitializeComponent();
            if (Settings.Default.isConnected) startupConnectCheckBox.Enabled = true;
            // Sets Check Box
            if (Settings.Default.closeToTrayBool) closeToTrayCheckbox.Checked = true;
            if (Settings.Default.connectOnStartupBool) startupConnectCheckBox.Checked = true;
            if (Settings.Default.startMinimizedBool) startMinCheckbox.Checked = true;
            if (Settings.Default.windowsStartupBool) windowsCheckbox.Checked = true;
        }


        private void settingsCheckboxes_CheckedChanged(object sender, EventArgs e) {
            if (Settings.Default.connectOnStartupBool != startupConnectCheckBox.Checked) {
                applySettingsButton.Enabled = true;
            }
            else if (Settings.Default.closeToTrayBool != closeToTrayCheckbox.Checked) {
                applySettingsButton.Enabled = true;
            }
            else if(Settings.Default.startMinimizedBool != startMinCheckbox.Checked) {
                applySettingsButton.Enabled = true;
            }
            else if (Settings.Default.windowsStartupBool != windowsCheckbox.Checked) {
                applySettingsButton.Enabled = true;
            }
            else applySettingsButton.Enabled = false;
        }


        // Apply Settings Button
        private void applySettingsButton_Click(object sender, EventArgs e) {

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
            applySettingsButton.Enabled = false;
        }
    }
}
