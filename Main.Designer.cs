namespace BlueBox
{
    partial class Main
    {
   

        private System.ComponentModel.IContainer components = null;


        /// <param name="disposing">true if managed resources should be disposed -  otherwise, false.</param>
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
            this.SuspendLayout();
       
            this.windowListView.CheckBoxes = true;
            this.windowListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.windowListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.windowListView.Location = new System.Drawing.Point(0, 0);
            this.windowListView.Name = "windowListView";
            this.windowListView.Size = new System.Drawing.Size(484, 428);
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

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.windowListView);
            this.Controls.Add(this.refreshButton);
            this.Name = "Main";
            this.Text = "BlueBox Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.ResumeLayout(false);
        }

        #endregion

        private ListView windowListView;
        private Button refreshButton;
        private NotifyIcon notifyIcon;
        private ColumnHeader columnHeader1;
    }
}