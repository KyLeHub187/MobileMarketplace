using System;
using System.Windows.Forms;

namespace MobileMarketplace
{
    public partial class LoginControl : UserControl
    {
        private MainForm mainForm;

        public LoginControl(MainForm parentForm) // ✅ Receive MainForm reference
        {
            InitializeComponent();
            mainForm = parentForm;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();

                int userId;
                if (UserDatabase.VerifyCredentials(username, password, out userId))
                {
                    mainForm.CurrentUserId = userId;
                    HomePageControl homePageControl = new HomePageControl(userId);
                    mainForm.LoadControl(homePageControl);
                }
                else
                {
                    MessageBox.Show("Invalid username or password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}