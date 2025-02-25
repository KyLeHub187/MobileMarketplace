using System;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace MobileMarketplace
{
    public partial class ProductsCardControl : UserControl
    {
        public int DeviceID { get; set; }
        public event EventHandler ProductClicked;

        public ProductsCardControl()
        {
            InitializeComponent(); 
            AttachClickEvents();
        }

        private void AttachClickEvents()
        {
            this.Click += ProductsCardControl_Click;
            pictureBox.Click += ProductsCardControl_Click;
            lblName.Click += ProductsCardControl_Click;
            lblType.Click += ProductsCardControl_Click;
            lblCondition.Click += ProductsCardControl_Click;
            lblPrice.Click += ProductsCardControl_Click;
        }

        private void ProductsCardControl_Click(object sender, EventArgs e)
        {
            ProductClicked?.Invoke(this, e);
        }

        public void SetProductData(int deviceId, string deviceName, string deviceType, string condition, decimal price, string imageUrl = null)
        {
            DeviceID = deviceId;
            lblName.Text = deviceName;
            lblType.Text = deviceType;
            lblCondition.Text = condition;
            lblPrice.Text = $"${price:F2}";

            if (!string.IsNullOrEmpty(imageUrl))
            {
                try
                {
                    pictureBox.Image = Image.FromFile(imageUrl);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image from file: {ex.Message}", "Image Load Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                // Query the database to load the image
                LoadProductImage(deviceId);
            }
        }

        private void LoadProductImage(int deviceId)
        {
            // Query to fetch the first image for the given device
            string query = "SELECT TOP 1 ImageData FROM DeviceImages WHERE DeviceID = @DeviceID";
            SqlParameter[] parameters = new SqlParameter[] {
        new SqlParameter("@DeviceID", deviceId)
    };

            DataTable dt = new Database().ExecuteQuery(query, parameters);
            if (dt != null && dt.Rows.Count > 0)
            {
                byte[] imageData = dt.Rows[0]["ImageData"] as byte[];
                if (imageData != null && imageData.Length > 0)
                {
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream(imageData))
                    {
                        pictureBox.Image = Image.FromStream(ms);
                    }
                }
            }
        }

    }
}
