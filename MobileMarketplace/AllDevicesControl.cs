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
            ApplyFilters();
        }

        private void LoadDevicesByPage()
        {
            // Your existing pagination logic here (if needed)
        }

        // Add your ApplyFilters method inside the same class
        private void ApplyFilters()
        {
            // 1) Gather user selections
            string selectedType = cmbType.SelectedItem?.ToString() ?? "All";
            string selectedCondition = cmbCondition.SelectedItem?.ToString() ?? "All";
            string selectedPriceRange = cmbPrice.SelectedItem?.ToString() ?? "All";

            // 2) Build a base query
            string query = "SELECT [DeviceID], [Name], [Type], [Condition], [Price] FROM Devices WHERE 1=1";
            List<SqlParameter> parameters = new List<SqlParameter>();

            // Filter by brand
            if (selectedType != "All")
            {
                query += " AND [Type] = @type";
                parameters.Add(new SqlParameter("@Type", selectedType));
            }

            // Filter by condition
            if (selectedCondition != "All")
            {
                query += " AND [Condition] = @condition";
                parameters.Add(new SqlParameter("@condition", selectedCondition));
            }

            // Filter by price range
            switch (selectedPriceRange)
            {
                case "Under 100":
                    query += " AND Price < @maxPrice";
                    parameters.Add(new SqlParameter("@maxPrice", 100));
                    break;
                case "100 - 250":
                    query += " AND Price >= @minPrice AND Price <= @maxPrice";
                    parameters.Add(new SqlParameter("@minPrice", 100));
                    parameters.Add(new SqlParameter("@maxPrice", 250));
                    break;
                case "250 - 500":
                    query += " AND Price >= @minPrice AND Price <= @maxPrice";
                    parameters.Add(new SqlParameter("@minPrice", 250));
                    parameters.Add(new SqlParameter("@maxPrice", 500));
                    break;
                case "Over 500":
                    query += " AND Price > @minPrice";
                    parameters.Add(new SqlParameter("@minPrice", 500));
                    break;
                    // If "All", no price filter
            }

            // 3) Execute the query
            DataTable dt = UserDatabase.ExecuteQuery(query, parameters.ToArray());

            // 4) Clear old results and display new ones
            flowLayoutPanel1.Controls.Clear();

            foreach (DataRow row in dt.Rows)
            {
                string name = row["Name"].ToString();
                string type = row["Type"].ToString();
                string condition = row["Condition"].ToString();
                decimal price = Convert.ToDecimal(row["Price"]);

             
            }
        }

        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                // Optionally call ApplyFilters() here if pagination is combined with filters
                ApplyFilters();
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            currentPage++;
            ApplyFilters();
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
            ApplyFilters();
        }
    }
}
