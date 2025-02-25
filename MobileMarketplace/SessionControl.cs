using System;
using System.Windows.Forms;

namespace MobileMarketplace
{
    public partial class SessionControl : UserControl
    {
        // Define the event
        public event EventHandler LoginSuccessful;

        public SessionControl()
        {
            InitializeComponent();
        }

        // Call this method when the login is successful
        protected virtual void OnLoginSuccessful()
        {
            LoginSuccessful?.Invoke(this, EventArgs.Empty); // Trigger the event
        }

        // Your login logic here (example)
        private void LoginButton_Click(object sender, EventArgs e)
        {
            // If the login is successful, trigger the event
            OnLoginSuccessful();
        }
    }
}
