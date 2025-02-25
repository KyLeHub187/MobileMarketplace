using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace MobileMarketplace
{
    /// <summary>
    /// Represents the home page control of the mobile marketplace application.
    /// </summary>
    public partial class HomePageControl : UserControl
    {
        private const int MaxProductCards = 12;
        private int currentUserId;
        private CarouselControl carousel;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomePageControl"/> class.
        /// </summary>
        public HomePageControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HomePageControl"/> class with a specified user ID.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        public HomePageControl(int userId) : this()
        {
            currentUserId = userId;

            // Set up carousel in panel1
            carousel = new CarouselControl
            {
                Location = new Point(0, 0),
                Size = new Size(panel1.Width, panel1.Height),
                Anchor = AnchorStyles.None
            };
            panel1.Controls.Add(carousel);

            // Set welcome message
            if (userId > 0)
            {
                string firstName = UserDatabase.GetFirstNameByUserId(userId);
                lblWelcome.Text = $"Welcome, {firstName}";
            }
        }

        /// <summary>
        /// Loads the product cards.
        /// </summary>
        private void LoadProductCards()
        {
            try
            {
                // Query that selects DeviceID along with other fields
                string query = $@"
                    SELECT TOP {MaxProductCards} [DeviceID], [Name], [Type], [Condition], [Price]
                    FROM Devices 
                    ORDER BY DateAdded DESC";

                DataTable dt = new Database().ExecuteQuery(query);

                // Clear any existing product cards
                pnlAll.Controls.Clear();

                // Loop through each row in the DataTable
                foreach (DataRow row in dt.Rows)
                {
                    int deviceId = Convert.ToInt32(row["DeviceID"]);
                    string name = row["Name"].ToString();
                    string type = row["Type"].ToString();
                    string condition = row["Condition"].ToString();
                    decimal price = Convert.ToDecimal(row["Price"]);

                    // Create a new ProductCardControl (passing false to avoid any unwanted internal loading)
                    var card = new ProductCardControl(false);

                    // Set its data; this method now accepts the DeviceID
                    card.SetProductData(deviceId, name, type, condition, price);

                    // Subscribe to the ProductClicked event
                    card.ProductClicked += (s, e) =>
                    {
                        var clickedCard = (ProductCardControl)s;
                      
                    };

                    // Add the card to pnlAll
                    pnlAll.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
                // Log the error (assuming a Logger class is available)
           
                MessageBox.Show("Error loading product cards: " + ex.Message);
            }
        }

        /// <summary>
        /// Handles the Load event of the HomePageControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void HomePageControl_Load(object sender, EventArgs e)
        {
            LoadProductCards();

            List<Image> banners = new List<Image>
            {
                Properties.Resources.Phones_and_Icons,
                Properties.Resources.mobile_phone_promo,
                Properties.Resources.X_Banner
            };
            carousel.SetImages(banners);
        }

        /// <summary>
        /// Handles the Click event of the tbSearch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void tbSearch_Click(object sender, EventArgs e)
        {
            tbSearch.Text = "";
        }

        /// <summary>
        /// Handles the Paint event of the pnlAll control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void pnlAll_Paint(object sender, PaintEventArgs e)
        {
            // Optional custom drawing logic can go here.
        }
    }
}