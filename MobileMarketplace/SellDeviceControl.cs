﻿using System;
using System.Windows.Forms;
using System.Drawing;
using System.Data.SqlClient;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace MobileMarketplace
{


    public partial class SellDeviceControl : UserControl
    {
        private int _userId;  // Class-level field to store userId

        // Constructor that takes userId as a parameter
        public SellDeviceControl(int userId)
        {
            InitializeComponent();
            _userId = userId;  // Assign the passed userId to the class-level field
            LoadDevicesForUser();  // Call method to load devices
            this.Dock = DockStyle.Fill;
            this.AutoScroll = true;
        }

        private void LoadDevicesForUser()
        {
            // You can now use _userId to load devices specific to the user
            // Example (assuming a method exists in the database class):
            // var devices = Database.GetDevicesForUser(_userId);
            // Display them in the control (e.g., in a ListView or DataGridView)

            // Sample logic:
            // MessageBox.Show($"Loading devices for user with ID: {_userId}");
        }
        private PictureBox[] pictureBoxes; // Declare the PictureBox array

        private void ListDevicesControl_Load(object sender, EventArgs e)
        {
            pictureBoxes = new PictureBox[] { pictureBox1, pictureBox4, pictureBox5, pictureBox2, pictureBox6, pictureBox3 };
            
            cmbBrand.Items.Add("Brand");
            cmbBrand.Items.Add("Samsung");
            cmbBrand.Items.Add("Apple");
            cmbBrand.Items.Add("Xiaomi");
            cmbBrand.Items.Add("Vivo");
            cmbBrand.Items.Add("Transsion");
            cmbBrand.Items.Add("Honor");
            cmbBrand.Items.Add("Motorola");
            cmbBrand.Items.Add("Realme");
            cmbBrand.Items.Add("Huawei");

            cmbBrand.Text = "Brand";

            cmbCondition.Items.Add("Condition");
            cmbCondition.Items.Add("New (open box)");
            cmbCondition.Items.Add("Used (like new)");
            cmbCondition.Items.Add("Fair");
            cmbCondition.Items.Add("Parts (mot working)");

            cmbCondition.Text = "Condition";

            cmbType.Items.Add("Type");
            cmbType.Items.Add("Phone");
            cmbType.Items.Add("Tablet");
            cmbType.Items.Add("Laptop");

            cmbType.Text = "Type";
        }

        private void UploadImageToPictureBox(PictureBox pictureBox)
        {
            // Create an OpenFileDialog to allow the user to select an image
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Load the selected image into the PictureBox
                pictureBox.Image = Image.FromFile(openFileDialog.FileName);
            }
        }


        private void btnUpload1_Click(object sender, EventArgs e)
        {
            UploadImageToPictureBox(pictureBox1);
        }   

        private void btnUpload3_Click(object sender, EventArgs e)
        {
            UploadImageToPictureBox(pictureBox3);
        }

        private void btnUpload4_Click(object sender, EventArgs e)
        {
            UploadImageToPictureBox(pictureBox4);
        }

        private void btnUpload5_Click(object sender, EventArgs e)
        {
            UploadImageToPictureBox(pictureBox5);
        }

        private void btnUpload6_Click(object sender, EventArgs e)
        {
            UploadImageToPictureBox(pictureBox6);
        }

        private void btnUpload2_Click_1(object sender, EventArgs e)
        {
            UploadImageToPictureBox(pictureBox2);
        }

        private void btnListDevice_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbModel.Text) ||
                string.IsNullOrWhiteSpace(cmbBrand.Text) ||
                string.IsNullOrWhiteSpace(cmbCondition.Text) ||
                string.IsNullOrWhiteSpace(tbPrice.Text) ||
                string.IsNullOrWhiteSpace(tbDescription.Text))
            {
                MessageBox.Show("Please fill in all fields before listing the device.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Parse price
            if (!decimal.TryParse(tbPrice.Text, out decimal price))
            {
                MessageBox.Show("Invalid price format.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int newDeviceId;

                Database db = new Database();
                SqlConnection conn = new SqlConnection(db.ConnectionString);
                
                {
                    conn.Open();

                    // Insert the device and return the new ID
                    string query = @"
        INSERT INTO Devices (UserID, Name, Brand, Type, Model, Condition, Price, Description, DateAdded)
        VALUES (@UserID, @Name, @Brand, @Type, @Model, @Condition, @Price, @Description, GETDATE());
        SELECT SCOPE_IDENTITY();";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", _userId);
                        cmd.Parameters.AddWithValue("@Name", tbName.Text);
                        cmd.Parameters.AddWithValue("@Brand", cmbBrand.Text);
                        cmd.Parameters.AddWithValue("@Type", cmbType.Text);
                        cmd.Parameters.AddWithValue("@Model", tbModel.Text);
                        cmd.Parameters.AddWithValue("@Condition", cmbCondition.Text);
                        cmd.Parameters.AddWithValue("@Price", price);
                        cmd.Parameters.AddWithValue("@Description", tbDescription.Text);

                        // ExecuteScalar returns the first column of the first row → our new DeviceID
                        object result = cmd.ExecuteScalar();
                        newDeviceId = Convert.ToInt32(result);
                    }

                    // Now insert images into DeviceImages for the newly inserted device
                    InsertImagesForDevice(conn, newDeviceId);

                    MessageBox.Show("Device listed successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    tbName.Clear();
                    tbModel.Clear();
                    cmbBrand.SelectedIndex = 0;
                    cmbType.SelectedIndex = 0;
                    cmbCondition.SelectedIndex = 0;
                    tbPrice.Clear();
                    tbDescription.Clear();
                    foreach (PictureBox pb in pictureBoxes)
                    {
                        pb.Image = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error listing device: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void InsertImagesForDevice(SqlConnection conn, int deviceId)
        {
            string insertImageSql = @"
                INSERT INTO DeviceImages (DeviceID, ImageData, UploadDate)
                VALUES (@DeviceID, @ImageData, GETDATE())";

            foreach (PictureBox pb in pictureBoxes)
            {
                if (pb.Image != null)
                {
                    byte[] imageBytes = ConvertImageToBytes(pb.Image);

                    using (SqlCommand cmd = new SqlCommand(insertImageSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@DeviceID", deviceId);
                        cmd.Parameters.AddWithValue("@ImageData", imageBytes);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

      
        private byte[] ConvertImageToBytes(Image image)
        {
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
    }
}
