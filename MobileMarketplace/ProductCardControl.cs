using System;
using System.Drawing;
using System.Windows.Forms;

namespace MobileMarketplace
{
    public partial class ProductCardControl : UserControl
    {
        public int DeviceID { get; set; }
        public event EventHandler ProductClicked;
        private PictureBox pictureBox;
        private Label lblType;
        private Label lblCondition;
        private Label lblPrice;

        public ProductCardControl(bool loadDevices = true) // ✅ Added constructor with 'bool'
        {
            InitializeComponent();
            this.Click += CardControl_Click;
            pictureBox.Click += CardControl_Click;
            lblName.Click += CardControl_Click;
            lblType.Click += CardControl_Click;
            lblCondition.Click += CardControl_Click;
            lblPrice.Click += CardControl_Click;
            lblName.Width = pictureBox.Width;
            lblType.Width = pictureBox.Width;
            lblCondition.Width = pictureBox.Width;
            lblPrice.Width = pictureBox.Width;

            // Align them under the picture box
            lblName.Left = pictureBox.Left;
            lblType.Left = pictureBox.Left;
            lblCondition.Left = pictureBox.Left;
            lblPrice.Left = pictureBox.Left;

            lblName.TextAlign = ContentAlignment.MiddleCenter;
            lblType.TextAlign = ContentAlignment.MiddleCenter;
            lblCondition.TextAlign = ContentAlignment.MiddleCenter;
            lblPrice.TextAlign = ContentAlignment.MiddleCenter;


            if (loadDevices) // Prevents infinite recursion
            {
                LoadLatestDevicesIntoPanel();
            }
        }

        private void CardControl_Click(object sender, EventArgs e)
        {
            ProductClicked?.Invoke(this, e);
        }

        public void SetProductData(int deviceId, string deviceName, string deviceType, string condition, decimal price, string imageUrl = null)
        {
            DeviceID = deviceId;
            lblName.Text = deviceName;
            lblType.Text = $"{deviceType}";
            lblCondition.Text = $"{condition}";
            lblPrice.Text = $"${price:F2}";

            if (!string.IsNullOrEmpty(imageUrl))
            {
                try
                {
                    pictureBox.Image = Image.FromFile(imageUrl);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image: {ex.Message}", "Image Load Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.lblType = new System.Windows.Forms.Label();
            this.lblCondition = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblName.Location = new System.Drawing.Point(25, 105);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(100, 20);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(25, 5);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(100, 100);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(25, 125);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(100, 20);
            this.lblType.TabIndex = 1;
            this.lblType.Text = "Type";
            this.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCondition
            // 
            this.lblCondition.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCondition.Location = new System.Drawing.Point(22, 145);
            this.lblCondition.MaximumSize = new System.Drawing.Size(100, 0);
            this.lblCondition.Name = "lblCondition";
            this.lblCondition.Size = new System.Drawing.Size(96, 16);
            this.lblCondition.TabIndex = 2;
            this.lblCondition.Text = "Condition: ";
            this.lblCondition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPrice
            // 
            this.lblPrice.Location = new System.Drawing.Point(26, 161);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(100, 20);
            this.lblPrice.TabIndex = 3;
            this.lblPrice.Text = "Price";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProductCardControl
            // 
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblCondition);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.pictureBox);
            this.Name = "ProductCardControl";
            this.Size = new System.Drawing.Size(150, 180);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        internal void SetProductData(int deviceId, string name, string type, string condition, decimal price)
        {
            throw new NotImplementedException();
        }

        internal void SetProductData(string name, string type, string condition, decimal price)
        {
            throw new NotImplementedException();
        }
    }
}

