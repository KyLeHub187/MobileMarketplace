using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MobileMarketplace
{
    public partial class CarouselControl : UserControl
    {
        private List<Image> _images;
        private int _currentIndex;
        private int _nextIndex;
        private int _animationOffset;   // How far into the slide we are
        private Timer _displayTimer;    // Timer for display duration
        private Timer _animationTimer;  // Timer for the sliding animation
        private int _animationStep = 20;

        public CarouselControl()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            this.Size = new Size(682, 100);
            this.MinimumSize = new Size(682, 100);
            this.MaximumSize = new Size(682, 100);

            _images = new List<Image>();
            _currentIndex = 0;
            _animationOffset = 0;

            // Timer for how long the image is displayed.
            _displayTimer = new Timer();
            _displayTimer.Interval = 5000; // 5 seconds display time
            _displayTimer.Tick += DisplayTimer_Tick;
            _displayTimer.Start();

            // Timer for the sliding animation.
            _animationTimer = new Timer();
            _animationTimer.Interval = 30; // 30ms per tick for the animation
            _animationTimer.Tick += AnimationTimer_Tick;
        }

        // Public method to load images
        public void SetImages(List<Image> images)
        {
            _images = images;
            if (_images.Count > 0)
            {
                _currentIndex = 0;
                Invalidate();
            }
        }

        private void DisplayTimer_Tick(object sender, EventArgs e)
        {
            if (_images.Count == 0) return;

            _nextIndex = (_currentIndex + 1) % _images.Count;
            _animationOffset = 0;
            _animationTimer.Start();
            _displayTimer.Stop();
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            _animationOffset += _animationStep;
            if (_animationOffset >= this.Width)
            {
                // Animation complete: update the current index.
                _animationTimer.Stop();
                _currentIndex = _nextIndex;
                _animationOffset = 0;
                _displayTimer.Start();
            }
            Invalidate(); // Redraw the control
        }

        private void CarouselControl_Load(object sender, EventArgs e)
        {

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (_images.Count == 0) return;

            int bannerWidth = 682;
            int bannerHeight = 100;

            if (_animationTimer.Enabled)
            {
                // Draw current image sliding out
                Rectangle currentRect = new Rectangle(-_animationOffset, 0, bannerWidth, bannerHeight);
                e.Graphics.DrawImage(_images[_currentIndex], currentRect);

                // Draw next image sliding in
                Rectangle nextRect = new Rectangle(bannerWidth - _animationOffset, 0, bannerWidth, bannerHeight);
                e.Graphics.DrawImage(_images[_nextIndex], nextRect);
            }
            else
            {
                // Draw current image at fixed size
                e.Graphics.DrawImage(_images[_currentIndex], new Rectangle(0, 0, bannerWidth, bannerHeight));
            }
        }

    }
}
