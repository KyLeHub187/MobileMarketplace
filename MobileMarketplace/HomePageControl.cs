using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace MobileMarketplace
{

    public partial class HomePageControl : UserControl
    {
        private const int MaxProductCards = 12;
        private int currentUserId;
        private CarouselControl carousel;

   
        public HomePageControl()
        {
            InitializeComponent();
        }
                public HomePageControl(int userId) : this()
        {
            currentUserId = userId;

            carousel = new CarouselControl
            {
                Location = new Point(0, 0),
                Size = new Size(panel1.Width, panel1.Height),
                Anchor = AnchorStyles.None
            };
            panel1.Controls.Add(carousel);

            if (userId > 0)
            {
                string firstName = UserDatabase.GetFirstNameByUserId(userId);
                lblWelcome.Text = $"Welcome, {firstName}";
            }
        }      
        private void LoadProductCards()
        {
            try
            {
                string query = $@"
                    SELECT TOP {MaxProductCards} [DeviceID], [Name], [Type], [Condition], [Price]
                    FROM Devices 
                    ORDER BY DateAdded DESC";

                DataTable dt = new Database().ExecuteQuery(query);

                pnlAll.Controls.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    int deviceId = Convert.ToInt32(row["DeviceID"]);
                    string name = row["Name"].ToString();
                    string type = row["Type"].ToString();
                    string condition = row["Condition"].ToString();
                    decimal price = Convert.ToDecimal(row["Price"]);

                    var card = new ProductsCardControl();

                    card.SetProductData(deviceId, name, type, condition, price);

                    card.ProductClicked += (s, e) =>
                    {
                        var clickedCard = (ProductsCardControl)s;
                        int clickedDeviceId = clickedCard.DeviceID;

                        MainForm mainForm = (MainForm)this.FindForm();

                        var detailsControl = new ProductDetailsControl(clickedDeviceId);

                        mainForm.LoadControl(detailsControl);
                    };

                    pnlAll.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
           
                MessageBox.Show("Error loading product cards: " + ex.Message);
            }
        }

      
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

        private void tbSearch_Click(object sender, EventArgs e)
        {
            tbSearch.Text = "";
        }

        private void pnlAll_Paint(object sender, PaintEventArgs e)
        {
            // Optional custom drawing logic can go here.
        }
    }
}