using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Data.SqlClient;

namespace MobileMarketplace
{

    public partial class AllDevicesControl : UserControl
    {
        private int currentPage = 1;
        private int pageSize = 12;

        public AllDevicesControl()
        {
            InitializeComponent();
            
        }

        private void AllDevicesControl_Load(object sender, EventArgs e)
        {
            // Populate ComboBoxes
            cmbType.Items.Add("All");
            cmbType.Items.Add("Phone");
            cmbType.Items.Add("Tablet");
            cmbType.Items.Add("Laptop");
            cmbType.SelectedIndex = 0;

            cmbCondition.Items.Add("All");
            cmbCondition.Items.Add("New (open box)");
            cmbCondition.Items.Add("Used");
            cmbCondition.Items.Add("Fair");
            cmbCondition.Items.Add("Parts (not working)");
            cmbCondition.SelectedIndex = 0;

            cmbPrice.Items.Add("Price");
            cmbPrice.Items.Add("Under 100");
            cmbPrice.Items.Add("100 - 250");
            cmbPrice.Items.Add("250 - 500");
            cmbPrice.Items.Add("Over 500");
            cmbPrice.SelectedIndex = 0;

            // Instead of calling LoadDevicesByPage() directly,
            // call ApplyFilters to load devices using the filter settings.

        }

        private void LoadDevicesByPage()
        {
            // Your existing pagination logic here (if needed)
        }

        // Add your ApplyFilters method inside the same class
       
        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;

            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            currentPage++;

        }

        private void BtnPrevious_MouseHover(object sender, EventArgs e)
        {
            BtnPrevious.ForeColor = Color.Red;
            BtnPrevious.BackColor = Color.Green;
        }

        private void BtnPrevious_MouseLeave(object sender, EventArgs e)
        {
            BtnPrevious.BackColor = Color.White;

        }

        private void btnApplyFilters_Click(object sender, EventArgs e)
        {
           
        }
    }
}
