using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace MobileMarketplace
{
    public partial class ProductCardControl : UserControl
    {
        private FlowLayoutPanel flowLayoutPanel;

        public ProductCardControl()
        {
            InitializeComponent();
            SetupFlowLayoutPanel();

            // Optionally, load devices immediately
            LoadLatestDevicesIntoPanel();
        }

        private void ProductsControl_Load(object sender, EventArgs e)
        {
            // Or load devices here, if you prefer to do it on load event
            LoadLatestDevicesIntoPanel();            
        }

        private void SetupFlowLayoutPanel()
        {
            flowLayoutPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                WrapContents = true,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(10)
            };
            this.Controls.Add(flowLayoutPanel);
        }


        private void LoadLatestDevicesIntoPanel()
        {
            try
            {
                // Query to fetch the newest 12 devices from your Devices table
                string query = @"
            SELECT TOP 12
                   [Name],
                   [Type],
                   [Condition],
                   Price
            FROM Devices
            ORDER BY DateAdded DESC;
        ";

                var db = new Database();
                DataTable dt = db.ExecuteQuery(query);

                // Clear any existing controls to avoid duplicates
                flowLayoutPanel.Controls.Clear();

                // Loop through each row in the returned DataTable
                foreach (DataRow row in dt.Rows)
                {
                    string deviceName = row["Name"]?.ToString() ?? "";
                    string deviceType = row["Type"]?.ToString() ?? "";
                    string condition = row["Condition"]?.ToString() ?? "";
                    decimal price = row["Price"] != DBNull.Value
                                    ? Convert.ToDecimal(row["Price"])
                                    : 0;

                    // Create a new product card
                    var card = new ProductCardControl();


                    // Populate the card with the device's data
                    card.SetProductData(deviceName, deviceType, condition, price, null);

                    // Add the card to the FlowLayoutPanel
                    flowLayoutPanel.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading devices: " + ex.Message);
            }
        }

        private void SetProductData(string deviceName, string deviceType, string condition, decimal price, object value)
        {
            throw new NotImplementedException();
        }

        private Label lblName;
    }
}