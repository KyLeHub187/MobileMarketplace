using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MobileMarketplace
{
    public class BottomAlignedTextBox : TextBox
    {
        // We need the SendMessage WinAPI function
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, ref RECT lParam);

        private const int EM_SETRECT = 0xB3;

        public BottomAlignedTextBox()
        {
            // Ensure we only do this once at creation time
            this.Multiline = true;
            this.AcceptsReturn = false; // helps mimic single-line if needed
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            // Must be multiline to allow custom text rectangle
            if (!this.Multiline) this.Multiline = true;
            SetTextRect();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            SetTextRect();
        }

        private void SetTextRect()
        {
            // Adjust these values to position text near the bottom
            RECT rect = new RECT
            {
                Left = 0,
                Right = this.ClientSize.Width,
                // We'll place the top so that text is near the bottom
                Top = this.ClientSize.Height - this.Font.Height - 2,
                Bottom = this.ClientSize.Height
            };

            // Send the EM_SETRECT message to the native control
            SendMessage(this.Handle, EM_SETRECT, IntPtr.Zero, ref rect);
        }

        // The RECT struct used by EM_SETRECT
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
    }
}
