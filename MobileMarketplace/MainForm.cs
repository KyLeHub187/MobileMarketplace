using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;
 

namespace MobileMarketplace
{
    public partial class MainForm : MaterialForm
    {
        private int currentUserId;

        public int CurrentUserId
        {
            get { return currentUserId; }
            set { currentUserId = value; }
        }

        public MainForm()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue600, Primary.Blue700,
                Primary.Blue200, Accent.LightBlue200,
                TextShade.WHITE
            );
            this.StartPosition = FormStartPosition.CenterScreen;

            // Load HomePageControl by default
            LoadControl(new LoginControl(this));
        }

        // Method to switch user controls dynamically
        public void LoadControl(UserControl control)
        {
            mainPanel.Controls.Clear(); // Clear previous control
            control.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(control);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (CurrentUserId > 0)
            {
                // Pass CurrentUserId to HomePageControl
                HomePageControl homePageControl = new HomePageControl(CurrentUserId);
                homePageControl.Dock = DockStyle.Fill;
                mainPanel.Controls.Add(homePageControl);
            }
   
            
        }

        // MenuStrip Navigation Events
        private void HomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainPanel.Controls.Clear();
            string firstName = UserDatabase.GetFirstNameByUserId(CurrentUserId);
            HomePageControl homeControl = new HomePageControl(CurrentUserId);
            homeControl.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(homeControl);
        }

        private void ShopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

       

        

  

        private void allDevicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllDevicesControl allDevicesControl = new AllDevicesControl();
            allDevicesControl.Dock = DockStyle.Fill;

            mainPanel.Controls.Clear();  // Remove old control
            mainPanel.Controls.Add(allDevicesControl);
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listDeviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SellDeviceControl sellDeviceControl = new SellDeviceControl(CurrentUserId);
            sellDeviceControl.Dock = DockStyle.Fill;

            mainPanel.Controls.Clear();  // Remove old control
            mainPanel.Controls.Add(sellDeviceControl);
        }
    }
}
