﻿namespace Spectrum.Forms {
    partial class SettingsForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("General");
            this.generalGroupBox = new System.Windows.Forms.GroupBox();
            this.startWithWindows = new System.Windows.Forms.CheckBox();
            this.profileComboBox = new System.Windows.Forms.ComboBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.generalGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // generalGroupBox
            // 
            this.generalGroupBox.Controls.Add(this.startWithWindows);
            this.generalGroupBox.Controls.Add(this.profileComboBox);
            this.generalGroupBox.Location = new System.Drawing.Point(131, 12);
            this.generalGroupBox.Name = "generalGroupBox";
            this.generalGroupBox.Size = new System.Drawing.Size(252, 191);
            this.generalGroupBox.TabIndex = 0;
            this.generalGroupBox.TabStop = false;
            this.generalGroupBox.Text = "General";
            // 
            // startWithWindows
            // 
            this.startWithWindows.AutoSize = true;
            this.startWithWindows.Location = new System.Drawing.Point(63, 60);
            this.startWithWindows.Name = "startWithWindows";
            this.startWithWindows.Size = new System.Drawing.Size(120, 17);
            this.startWithWindows.TabIndex = 1;
            this.startWithWindows.Text = "Start With Windows";
            this.startWithWindows.UseVisualStyleBackColor = true;
            // 
            // profileComboBox
            // 
            this.profileComboBox.FormattingEnabled = true;
            this.profileComboBox.Location = new System.Drawing.Point(63, 19);
            this.profileComboBox.Name = "profileComboBox";
            this.profileComboBox.Size = new System.Drawing.Size(121, 21);
            this.profileComboBox.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(4, 12);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "generalNode";
            treeNode1.Text = "General";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView1.Size = new System.Drawing.Size(121, 426);
            this.treeView1.TabIndex = 1;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.generalGroupBox);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.Shown += new System.EventHandler(this.SettingsForm_Shown);
            this.generalGroupBox.ResumeLayout(false);
            this.generalGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox generalGroupBox;
        private System.Windows.Forms.ComboBox profileComboBox;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.CheckBox startWithWindows;
    }
}