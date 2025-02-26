using System;
using System.Windows.Forms;
using System.Drawing;
using System.Data.SqlClient;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace MobileMarketplace
{


    public partial class SellDeviceControl : UserControl
    {
        private int _userId;  // Class-level field to store userId
        private string _placeholderText = "Enter name...";
        private bool _isPlaceholderActive = true;

        // Constructor that takes userId as a parameter
        public SellDeviceControl(int userId)
        {
            InitializeComponent();
            _userId = userId;  // Assign the passed userId to the class-level field
            LoadDevicesForUser();  // Call method to load devices
            this.Dock = DockStyle.Fill;
            this.AutoScroll = true;
            tbName.Text = _placeholderText;
            tbName.ForeColor = Color.Gray;
        }

        private void TbName_Enter(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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

            panelPage1.Visible = true;
            panelPage2.Visible = false;
            btnPhone.Visible = true;
            btnTablet.Visible = true;
            lblChooseDevice.Visible = true;
            lblChooseOs.Visible = false;
            SetPlaceholder(cmbBrand, "Brand...");
            SetPlaceholder(cmbCondition, "Condition...");
            SetPlaceholder(cmbProcessor, "Processer...");
            SetPlaceholder(cmbAdditionalFeatures, "Features...");
            SetPlaceholder(cmbStorage, "Storage...");
            SetPlaceholder(cmbRam, "Ram...");
            SetPlaceholder(cmbColor, "Color...");
            SetPlaceholder(tbSellerNotes, "Sellers Notes...");


            cmbBrand.Text = "Brand";


            cmbCondition.Items.Add("Condition");
            cmbCondition.Items.Add("New (open box)");
            cmbCondition.Items.Add("Used (like new)");
            cmbCondition.Items.Add("Fair");
            cmbCondition.Items.Add("Parts (mot working)");

            cmbCondition.Text = "Condition";

        }

        private void SetPlaceholder(Control control, string placeholder)
        {
            control.Text = placeholder;
            control.ForeColor = Color.Gray;
            control.Enter += (s, e) =>
            {
                if (control.Text == placeholder)
                {
                    control.Text = "";
                    control.ForeColor = Color.Black;
                }
            };
            control.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(control.Text))
                {
                    control.Text = placeholder;
                    control.ForeColor = Color.Gray;
                }
            };
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

        private void panelPage1_Paint(object sender, PaintEventArgs e)
        {
            SetPlaceholder(tbName, "Device Name...");
            SetPlaceholder(tbModel, "Device Model...");
            SetPlaceholder(tbPrice, "Price...");
            SetPlaceholder(tbDescription, "Device Description...");
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            panelPage1.Visible = false;
            panelPage2.Visible = true;
            btnListDevice.Visible = true;
            btnNext.Visible = false;
        }

        private void btnPhone_Click(object sender, EventArgs e)
        {
            btnPhone.Visible = false;
            btnTablet.Visible = false;
            lblChooseDevice.Visible = false;
            lblChooseOs.Visible = true;
            btnIos.Visible = true;
            btnAndroid.Visible = true;
            lblBack.Visible = true;
        }

        private void btnTablet_Click(object sender, EventArgs e)
        {
            btnPhone.Visible = false;
            btnTablet.Visible = false;
            lblChooseDevice.Visible = false;
            lblChooseOs.Visible = true;
            btnIos.Visible = true;
            btnAndroid.Visible = true;
            lblBack.Visible = true;
        }
    }
}



     