using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace MobileMarketplace
{
    public partial class ProductDetailsControl: UserControl
    {
        private int deviceId;
        public ProductDetailsControl(int deviceId)
        {
            InitializeComponent();
            this.deviceId = deviceId;
            LoadProductDetails();
            LoadProductImages(deviceId);
        }

        private void LoadProductDetails()
        {
            try
            {
                // 1) Query for main device info (e.g., name, brand, etc.)
                string detailsQuery = @"
            SELECT 
                [Name], 
                [Brand], 
                [Type],
                [Model], 
                [Condition], 
                [Price],                  
                [Description]
            FROM Devices
            WHERE DeviceID = @DeviceID";

                SqlParameter[] detailsParams =
                {
            new SqlParameter("@DeviceID", deviceId)
        };

                DataTable dtDetails = new Database().ExecuteQuery(detailsQuery, detailsParams);
                if (dtDetails != null && dtDetails.Rows.Count > 0)
                {
                    DataRow row = dtDetails.Rows[0];

                    // Fill text-based controls
                    lblName.Text = row["Name"].ToString();
                    lblBrand.Text = row["Brand"].ToString();
                    lblType.Text = row["Type"].ToString();
                    lblModel.Text = row["Model"].ToString();
                    lblCondition.Text = row["Condition"].ToString();
                    lblPrice.Text = $"${Convert.ToDecimal(row["Price"]):F2}";
                    rtbDescription.Text = row["Description"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading product details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadProductImages(int deviceId)
        {
            try
            {
                string query = "SELECT ImageData FROM DeviceImages WHERE DeviceID = @DeviceID ORDER BY ImageID";  // Order by ImageID so the first image is always first.
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@DeviceID", deviceId)
                };

                DataTable dt = new Database().ExecuteQuery(query, parameters);
                if (dt != null && dt.Rows.Count > 0)
                {
                    // Load the first image into the main picture box.
                    byte[] mainImageData = dt.Rows[0]["ImageData"] as byte[];
                    if (mainImageData != null && mainImageData.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(mainImageData))
                        {
                            mainPictureBox.Image = Image.FromStream(ms);
                        }
                    }

                    // Prepare a list of thumbnail PictureBoxes.
                    // Adjust this list according to how many thumbnail PictureBoxes you have.
                    var thumbnailBoxes = new PictureBox[]
                    {
                        pictureBoxThumb1,
                        pictureBoxThumb2,
                        pictureBoxThumb3, // Add more if available.
                    };

                    // Loop starting from the second row (index 1)
                    for (int i = 1; i < dt.Rows.Count && i - 1 < thumbnailBoxes.Length; i++)
                    {
                        byte[] thumbImageData = dt.Rows[i]["ImageData"] as byte[];
                        if (thumbImageData != null && thumbImageData.Length > 0)
                        {
                            using (MemoryStream ms = new MemoryStream(thumbImageData))
                            {
                                thumbnailBoxes[i - 1].Image = Image.FromStream(ms);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading product images: {ex.Message}",
                    "Image Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

