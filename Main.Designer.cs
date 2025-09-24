namespace BlueBox
{
    partial class Main
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.windowListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.refreshButton = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.settingsGroupBox = new System.Windows.Forms.GroupBox();
            this.fullCountdownLabel = new System.Windows.Forms.Label();
            this.positionalCountdownLabel = new System.Windows.Forms.Label();
            this.fullTimerLabel = new System.Windows.Forms.Label();
            this.positionalTimerLabel = new System.Windows.Forms.Label();
            this.gapLabel = new System.Windows.Forms.Label();
            this.fullTimerNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.positionalTimerNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.gapNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.thicknessNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.thicknessLabel = new System.Windows.Forms.Label();
            this.colorPreviewPanel = new System.Windows.Forms.Panel();
            this.colorLabel = new System.Windows.Forms.Label();
            this.settingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fullTimerNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionalTimerNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gapNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thicknessNumericUpDown)).BeginInit();
            this.SuspendLayout();

            this.windowListView.CheckBoxes = true;
            this.windowListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.columnHeader1 });
            this.windowListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.windowListView.Location = new System.Drawing.Point(0, 0);
            this.windowListView.Name = "windowListView";
            this.windowListView.Size = new System.Drawing.Size(484, 335);
            this.windowListView.TabIndex = 0;
            this.windowListView.UseCompatibleStateImageBehavior = false;
            this.windowListView.View = System.Windows.Forms.View.Details;
            this.windowListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.windowListView_ItemChecked);
 
            this.columnHeader1.Text = "Title";
            this.columnHeader1.Width = 450;

            this.refreshButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.refreshButton.Location = new System.Drawing.Point(0, 428);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(484, 33);
            this.refreshButton.TabIndex = 1;
            this.refreshButton.Text = "Refresh List";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
 
            this.notifyIcon.Text = "BlueBox Window Outliner";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);

            this.settingsGroupBox.Controls.Add(this.fullCountdownLabel);
            this.settingsGroupBox.Controls.Add(this.positionalCountdownLabel);
            this.settingsGroupBox.Controls.Add(this.fullTimerLabel);
            this.settingsGroupBox.Controls.Add(this.positionalTimerLabel);
            this.settingsGroupBox.Controls.Add(this.gapLabel);
            this.settingsGroupBox.Controls.Add(this.fullTimerNumericUpDown);
            this.settingsGroupBox.Controls.Add(this.positionalTimerNumericUpDown);
            this.settingsGroupBox.Controls.Add(this.gapNumericUpDown);
            this.settingsGroupBox.Controls.Add(this.thicknessNumericUpDown);
            this.settingsGroupBox.Controls.Add(this.thicknessLabel);
            this.settingsGroupBox.Controls.Add(this.colorPreviewPanel);
            this.settingsGroupBox.Controls.Add(this.colorLabel);
            this.settingsGroupBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.settingsGroupBox.Location = new System.Drawing.Point(0, 335);
            this.settingsGroupBox.Name = "settingsGroupBox";
            this.settingsGroupBox.Size = new System.Drawing.Size(484, 93);
            this.settingsGroupBox.TabIndex = 2;
            this.settingsGroupBox.TabStop = false;
            this.settingsGroupBox.Text = "Settings";
 
            this.fullCountdownLabel.AutoSize = true;
            this.fullCountdownLabel.Location = new System.Drawing.Point(407, 59);
            this.fullCountdownLabel.Name = "fullCountdownLabel";
            this.fullCountdownLabel.Size = new System.Drawing.Size(43, 15);
            this.fullCountdownLabel.TabIndex = 11;
            this.fullCountdownLabel.Text = "(05:00)";

            this.positionalCountdownLabel.AutoSize = true;
            this.positionalCountdownLabel.Location = new System.Drawing.Point(174, 59);
            this.positionalCountdownLabel.Name = "positionalCountdownLabel";
            this.positionalCountdownLabel.Size = new System.Drawing.Size(29, 15);
            this.positionalCountdownLabel.TabIndex = 10;
            this.positionalCountdownLabel.Text = "(15s)";

            this.fullTimerLabel.AutoSize = true;
            this.fullTimerLabel.Location = new System.Drawing.Point(230, 59);
            this.fullTimerLabel.Name = "fullTimerLabel";
            this.fullTimerLabel.Size = new System.Drawing.Size(112, 15);
            this.fullTimerLabel.TabIndex = 9;
            this.fullTimerLabel.Text = "Full Refresh (mins):";

            this.positionalTimerLabel.AutoSize = true;
            this.positionalTimerLabel.Location = new System.Drawing.Point(12, 59);
            this.positionalTimerLabel.Name = "positionalTimerLabel";
            this.positionalTimerLabel.Size = new System.Drawing.Size(100, 15);
            this.positionalTimerLabel.TabIndex = 8;
            this.positionalTimerLabel.Text = "Pos. Refresh (sec):";

            this.gapLabel.AutoSize = true;
            this.gapLabel.Location = new System.Drawing.Point(348, 30);
            this.gapLabel.Name = "gapLabel";
            this.gapLabel.Size = new System.Drawing.Size(53, 15);
            this.gapLabel.TabIndex = 7;
            this.gapLabel.Text = "Gap (px):";

            this.fullTimerNumericUpDown.Location = new System.Drawing.Point(348, 57);
            this.fullTimerNumericUpDown.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            this.fullTimerNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.fullTimerNumericUpDown.Name = "fullTimerNumericUpDown";
            this.fullTimerNumericUpDown.Size = new System.Drawing.Size(50, 23);
            this.fullTimerNumericUpDown.TabIndex = 6;
            this.fullTimerNumericUpDown.Value = new decimal(new int[] { 5, 0, 0, 0 });
            this.fullTimerNumericUpDown.ValueChanged += new System.EventHandler(this.fullTimerNumericUpDown_ValueChanged);
            this.positionalTimerNumericUpDown.Location = new System.Drawing.Point(118, 57);
            this.positionalTimerNumericUpDown.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            this.positionalTimerNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.positionalTimerNumericUpDown.Name = "positionalTimerNumericUpDown";
            this.positionalTimerNumericUpDown.Size = new System.Drawing.Size(50, 23);
            this.positionalTimerNumericUpDown.TabIndex = 5;
            this.positionalTimerNumericUpDown.Value = new decimal(new int[] { 15, 0, 0, 0 });
            this.positionalTimerNumericUpDown.ValueChanged += new System.EventHandler(this.positionalTimerNumericUpDown_ValueChanged);

            this.gapNumericUpDown.Location = new System.Drawing.Point(407, 28);
            this.gapNumericUpDown.Name = "gapNumericUpDown";
            this.gapNumericUpDown.Size = new System.Drawing.Size(50, 23);
            this.gapNumericUpDown.TabIndex = 4;
            this.gapNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.gapNumericUpDown.ValueChanged += new System.EventHandler(this.gapNumericUpDown_ValueChanged);

            this.thicknessNumericUpDown.Location = new System.Drawing.Point(267, 28);
            this.thicknessNumericUpDown.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            this.thicknessNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.thicknessNumericUpDown.Name = "thicknessNumericUpDown";
            this.thicknessNumericUpDown.Size = new System.Drawing.Size(50, 23);
            this.thicknessNumericUpDown.TabIndex = 3;
            this.thicknessNumericUpDown.Value = new decimal(new int[] { 2, 0, 0, 0 });
            this.thicknessNumericUpDown.ValueChanged += new System.EventHandler(this.thicknessNumericUpDown_ValueChanged);

            this.thicknessLabel.AutoSize = true;
            this.thicknessLabel.Location = new System.Drawing.Point(173, 30);
            this.thicknessLabel.Name = "thicknessLabel";
            this.thicknessLabel.Size = new System.Drawing.Size(88, 15);
            this.thicknessLabel.TabIndex = 2;
            this.thicknessLabel.Text = "Thickness (px):";

            this.colorPreviewPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorPreviewPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.colorPreviewPanel.Location = new System.Drawing.Point(92, 26);
            this.colorPreviewPanel.Name = "colorPreviewPanel";
            this.colorPreviewPanel.Size = new System.Drawing.Size(65, 25);
            this.colorPreviewPanel.TabIndex = 1;
            this.colorPreviewPanel.Click += new System.EventHandler(this.colorPreviewPanel_Click);

            this.colorLabel.AutoSize = true;
            this.colorLabel.Location = new System.Drawing.Point(12, 30);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(74, 15);
            this.colorLabel.TabIndex = 0;
            this.colorLabel.Text = "Border Color:";

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.windowListView);
            this.Controls.Add(this.settingsGroupBox);
            this.Controls.Add(this.refreshButton);
            this.Name = "Main";
            this.Text = "BlueBox Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.settingsGroupBox.ResumeLayout(false);
            this.settingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fullTimerNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionalTimerNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gapNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thicknessNumericUpDown)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        private ListView windowListView;
        private Button refreshButton;
        private NotifyIcon notifyIcon;
        private ColumnHeader columnHeader1;
        private GroupBox settingsGroupBox;
        private Label colorLabel;
        private Panel colorPreviewPanel;
        private Label thicknessLabel;
        private NumericUpDown thicknessNumericUpDown;
        private Label gapLabel;
        private NumericUpDown fullTimerNumericUpDown;
        private NumericUpDown positionalTimerNumericUpDown;
        private NumericUpDown gapNumericUpDown;
        private Label fullTimerLabel;
        private Label positionalTimerLabel;
        private Label fullCountdownLabel;
        private Label positionalCountdownLabel;
    }
}