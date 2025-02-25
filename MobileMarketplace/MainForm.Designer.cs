namespace MobileMarketplace
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listDeviceToolStripMenuItem;
        private System.Windows.Forms.Panel mainPanel;

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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allDevicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listDeviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.shopToolStripMenuItem,
            this.listDeviceToolStripMenuItem,
            this.profileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(2, 52);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(896, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.homeToolStripMenuItem.Text = "Home";
            this.homeToolStripMenuItem.Click += new System.EventHandler(this.HomeToolStripMenuItem_Click);
            // 
            // shopToolStripMenuItem
            // 
            this.shopToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allDevicesToolStripMenuItem});
            this.shopToolStripMenuItem.Name = "shopToolStripMenuItem";
            this.shopToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.shopToolStripMenuItem.Text = "Shop";
            this.shopToolStripMenuItem.Click += new System.EventHandler(this.ShopToolStripMenuItem_Click);
            // 
            // allDevicesToolStripMenuItem
            // 
            this.allDevicesToolStripMenuItem.Name = "allDevicesToolStripMenuItem";
            this.allDevicesToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.allDevicesToolStripMenuItem.Text = "All Devices";
            this.allDevicesToolStripMenuItem.Click += new System.EventHandler(this.allDevicesToolStripMenuItem_Click);
            // 
            // listDeviceToolStripMenuItem
            // 
            this.listDeviceToolStripMenuItem.Name = "listDeviceToolStripMenuItem";
            this.listDeviceToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.listDeviceToolStripMenuItem.Text = "List Device";
            this.listDeviceToolStripMenuItem.Click += new System.EventHandler(this.listDeviceToolStripMenuItem_Click);
            // 
            // profileToolStripMenuItem
            // 
            this.profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            this.profileToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.profileToolStripMenuItem.Text = "Profile";
            // 
            // mainPanel
            // 
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(2, 76);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(896, 640);
            this.mainPanel.TabIndex = 1;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 718);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.menuStrip);
            this.DrawerBackgroundWithAccent = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(2, 52, 2, 2);
            this.Text = "Mobile Marketplace";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.ToolStripMenuItem allDevicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem;
    }
}
