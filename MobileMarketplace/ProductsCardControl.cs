using System;
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
                    MessageBox.Show($"Error loading image: {ex.Message}",
                                    "Image Load Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }
        }
    }
}
