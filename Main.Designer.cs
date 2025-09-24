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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            windowListView = new ListView();
            columnHeader1 = new ColumnHeader();
            refreshButton = new Button();
            notifyIcon = new NotifyIcon(components);
            settingsGroupBox = new GroupBox();
            thicknessLabel = new Label();
            fullCountdownLabel = new Label();
            colorLabel = new Label();
            positionalCountdownLabel = new Label();
            colorPreviewPanel = new Panel();
            fullTimerLabel = new Label();
            thicknessNumericUpDown = new NumericUpDown();
            gapLabel = new Label();
            positionalTimerLabel = new Label();
            gapNumericUpDown = new NumericUpDown();
            fullTimerNumericUpDown = new NumericUpDown();
            positionalTimerNumericUpDown = new NumericUpDown();
            settingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)thicknessNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gapNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fullTimerNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)positionalTimerNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // windowListView
            // 
            windowListView.CheckBoxes = true;
            windowListView.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            windowListView.Dock = DockStyle.Fill;
            windowListView.Location = new Point(0, 0);
            windowListView.Name = "windowListView";
            windowListView.Size = new Size(455, 410);
            windowListView.TabIndex = 0;
            windowListView.UseCompatibleStateImageBehavior = false;
            windowListView.View = View.Details;
            windowListView.ItemChecked += windowListView_ItemChecked;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Title";
            columnHeader1.Width = 450;
            // 
            // refreshButton
            // 
            refreshButton.Dock = DockStyle.Bottom;
            refreshButton.Location = new Point(0, 566);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(455, 33);
            refreshButton.TabIndex = 1;
            refreshButton.Text = "Refresh";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += refreshButton_Click;
            // 
            // notifyIcon
            // 
            notifyIcon.Text = "BlueBox Window Outliner";
            notifyIcon.Visible = true;
            notifyIcon.MouseDoubleClick += notifyIcon_MouseDoubleClick;
            // 
            // settingsGroupBox
            // 
            settingsGroupBox.Controls.Add(thicknessLabel);
            settingsGroupBox.Controls.Add(fullCountdownLabel);
            settingsGroupBox.Controls.Add(colorLabel);
            settingsGroupBox.Controls.Add(positionalCountdownLabel);
            settingsGroupBox.Controls.Add(colorPreviewPanel);
            settingsGroupBox.Controls.Add(fullTimerLabel);
            settingsGroupBox.Controls.Add(thicknessNumericUpDown);
            settingsGroupBox.Controls.Add(gapLabel);
            settingsGroupBox.Controls.Add(positionalTimerLabel);
            settingsGroupBox.Controls.Add(gapNumericUpDown);
            settingsGroupBox.Controls.Add(fullTimerNumericUpDown);
            settingsGroupBox.Controls.Add(positionalTimerNumericUpDown);
            settingsGroupBox.Dock = DockStyle.Bottom;
            settingsGroupBox.Location = new Point(0, 410);
            settingsGroupBox.Name = "settingsGroupBox";
            settingsGroupBox.Size = new Size(455, 156);
            settingsGroupBox.TabIndex = 2;
            settingsGroupBox.TabStop = false;
            settingsGroupBox.Text = "Settings";
            settingsGroupBox.Enter += settingsGroupBox_Enter;
            // 
            // thicknessLabel
            // 
            thicknessLabel.AutoSize = true;
            thicknessLabel.Location = new Point(25, 59);
            thicknessLabel.Name = "thicknessLabel";
            thicknessLabel.Size = new Size(85, 15);
            thicknessLabel.TabIndex = 2;
            thicknessLabel.Text = "Thickness (px):";
            thicknessLabel.Click += thicknessLabel_Click;
            // 
            // fullCountdownLabel
            // 
            fullCountdownLabel.AutoSize = true;
            fullCountdownLabel.Location = new Point(355, 120);
            fullCountdownLabel.Name = "fullCountdownLabel";
            fullCountdownLabel.Size = new Size(42, 15);
            fullCountdownLabel.TabIndex = 11;
            fullCountdownLabel.Text = "(05:00)";
            // 
            // colorLabel
            // 
            colorLabel.AutoSize = true;
            colorLabel.Location = new Point(25, 27);
            colorLabel.Name = "colorLabel";
            colorLabel.Size = new Size(77, 15);
            colorLabel.TabIndex = 0;
            colorLabel.Text = "Border Color:";
            // 
            // positionalCountdownLabel
            // 
            positionalCountdownLabel.AutoSize = true;
            positionalCountdownLabel.Location = new Point(355, 52);
            positionalCountdownLabel.Name = "positionalCountdownLabel";
            positionalCountdownLabel.Size = new Size(32, 15);
            positionalCountdownLabel.TabIndex = 10;
            positionalCountdownLabel.Text = "(15s)";
            // 
            // colorPreviewPanel
            // 
            colorPreviewPanel.BorderStyle = BorderStyle.FixedSingle;
            colorPreviewPanel.Cursor = Cursors.Hand;
            colorPreviewPanel.Location = new Point(117, 26);
            colorPreviewPanel.Name = "colorPreviewPanel";
            colorPreviewPanel.Size = new Size(50, 19);
            colorPreviewPanel.TabIndex = 1;
            colorPreviewPanel.Click += colorPreviewPanel_Click;
            // 
            // fullTimerLabel
            // 
            fullTimerLabel.AutoSize = true;
            fullTimerLabel.Location = new Point(237, 96);
            fullTimerLabel.Name = "fullTimerLabel";
            fullTimerLabel.Size = new Size(108, 15);
            fullTimerLabel.TabIndex = 9;
            fullTimerLabel.Text = "Full Refresh (mins):";
            // 
            // thicknessNumericUpDown
            // 
            thicknessNumericUpDown.Location = new Point(117, 57);
            thicknessNumericUpDown.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            thicknessNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            thicknessNumericUpDown.Name = "thicknessNumericUpDown";
            thicknessNumericUpDown.Size = new Size(50, 23);
            thicknessNumericUpDown.TabIndex = 3;
            thicknessNumericUpDown.Value = new decimal(new int[] { 2, 0, 0, 0 });
            thicknessNumericUpDown.ValueChanged += thicknessNumericUpDown_ValueChanged;
            // 
            // gapLabel
            // 
            gapLabel.AutoSize = true;
            gapLabel.Location = new Point(26, 90);
            gapLabel.Name = "gapLabel";
            gapLabel.Size = new Size(55, 15);
            gapLabel.TabIndex = 7;
            gapLabel.Text = "Gap (px):";
            // 
            // positionalTimerLabel
            // 
            positionalTimerLabel.AutoSize = true;
            positionalTimerLabel.Location = new Point(237, 30);
            positionalTimerLabel.Name = "positionalTimerLabel";
            positionalTimerLabel.Size = new Size(102, 15);
            positionalTimerLabel.TabIndex = 8;
            positionalTimerLabel.Text = "Pos. Refresh (sec):";
            // 
            // gapNumericUpDown
            // 
            gapNumericUpDown.Location = new Point(117, 88);
            gapNumericUpDown.Name = "gapNumericUpDown";
            gapNumericUpDown.Size = new Size(50, 23);
            gapNumericUpDown.TabIndex = 4;
            gapNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            gapNumericUpDown.ValueChanged += gapNumericUpDown_ValueChanged;
            // 
            // fullTimerNumericUpDown
            // 
            fullTimerNumericUpDown.Location = new Point(355, 94);
            fullTimerNumericUpDown.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            fullTimerNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            fullTimerNumericUpDown.Name = "fullTimerNumericUpDown";
            fullTimerNumericUpDown.Size = new Size(50, 23);
            fullTimerNumericUpDown.TabIndex = 6;
            fullTimerNumericUpDown.Value = new decimal(new int[] { 5, 0, 0, 0 });
            fullTimerNumericUpDown.ValueChanged += fullTimerNumericUpDown_ValueChanged;
            // 
            // positionalTimerNumericUpDown
            // 
            positionalTimerNumericUpDown.Location = new Point(355, 26);
            positionalTimerNumericUpDown.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            positionalTimerNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            positionalTimerNumericUpDown.Name = "positionalTimerNumericUpDown";
            positionalTimerNumericUpDown.Size = new Size(50, 23);
            positionalTimerNumericUpDown.TabIndex = 5;
            positionalTimerNumericUpDown.Value = new decimal(new int[] { 15, 0, 0, 0 });
            positionalTimerNumericUpDown.ValueChanged += positionalTimerNumericUpDown_ValueChanged;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(455, 599);
            Controls.Add(windowListView);
            Controls.Add(settingsGroupBox);
            Controls.Add(refreshButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BlueBox";
            FormClosing += Main_FormClosing;
            Load += Main_Load;
            Resize += Main_Resize;
            settingsGroupBox.ResumeLayout(false);
            settingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)thicknessNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)gapNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)fullTimerNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)positionalTimerNumericUpDown).EndInit();
            ResumeLayout(false);
        }
        #endregion

        private ListView windowListView;
        private Button refreshButton;
        private NotifyIcon notifyIcon;
        private ColumnHeader columnHeader1;
        private GroupBox settingsGroupBox;
        private NumericUpDown fullTimerNumericUpDown;
        private NumericUpDown positionalTimerNumericUpDown;
        private Label fullTimerLabel;
        private Label positionalTimerLabel;
        private Label fullCountdownLabel;
        private Label positionalCountdownLabel;
        private Label thicknessLabel;
        private Label colorLabel;
        private Panel colorPreviewPanel;
        private NumericUpDown thicknessNumericUpDown;
        private Label gapLabel;
        private NumericUpDown gapNumericUpDown;
    }
}