namespace MobileMarketplace
{
    partial class AllDevicesControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cmbCondition = new System.Windows.Forms.ComboBox();
            this.cmbPrice = new System.Windows.Forms.ComboBox();
            this.BtnPrevious = new System.Windows.Forms.Button();
            this.BtnNext = new System.Windows.Forms.Button();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.btnApplyFilters = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(189, 35);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(765, 605);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // cmbCondition
            // 
            this.cmbCondition.FormattingEnabled = true;
            this.cmbCondition.Location = new System.Drawing.Point(15, 183);
            this.cmbCondition.Margin = new System.Windows.Forms.Padding(3, 100, 3, 3);
            this.cmbCondition.Name = "cmbCondition";
            this.cmbCondition.Size = new System.Drawing.Size(156, 24);
            this.cmbCondition.TabIndex = 2;
            this.cmbCondition.Text = "Condition";
            // 
            // cmbPrice
            // 
            this.cmbPrice.FormattingEnabled = true;
            this.cmbPrice.Location = new System.Drawing.Point(15, 310);
            this.cmbPrice.Margin = new System.Windows.Forms.Padding(3, 100, 3, 100);
            this.cmbPrice.Name = "cmbPrice";
            this.cmbPrice.Size = new System.Drawing.Size(156, 24);
            this.cmbPrice.TabIndex = 3;
            this.cmbPrice.Text = "Price";
            // 
            // BtnPrevious
            // 
            this.BtnPrevious.Location = new System.Drawing.Point(0, 692);
            this.BtnPrevious.Name = "BtnPrevious";
            this.BtnPrevious.Size = new System.Drawing.Size(1094, 23);
            this.BtnPrevious.TabIndex = 4;
            this.BtnPrevious.Text = "Prev";
            this.BtnPrevious.UseVisualStyleBackColor = true;
            this.BtnPrevious.Click += new System.EventHandler(this.BtnPrevious_Click);
            this.BtnPrevious.MouseLeave += new System.EventHandler(this.BtnPrevious_MouseLeave);
            this.BtnPrevious.MouseHover += new System.EventHandler(this.BtnPrevious_MouseHover);
            // 
            // BtnNext
            // 
            this.BtnNext.Location = new System.Drawing.Point(0, 721);
            this.BtnNext.Name = "BtnNext";
            this.BtnNext.Size = new System.Drawing.Size(1094, 23);
            this.BtnNext.TabIndex = 5;
            this.BtnNext.Text = "Next";
            this.BtnNext.UseVisualStyleBackColor = true;
            this.BtnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(15, 56);
            this.cmbType.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(156, 24);
            this.cmbType.TabIndex = 1;
            this.cmbType.Text = "Type";
            // 
            // btnApplyFilters
            // 
            this.btnApplyFilters.Location = new System.Drawing.Point(15, 437);
            this.btnApplyFilters.Name = "btnApplyFilters";
            this.btnApplyFilters.Size = new System.Drawing.Size(156, 23);
            this.btnApplyFilters.TabIndex = 6;
            this.btnApplyFilters.Text = "Apply Filters";
            this.btnApplyFilters.UseVisualStyleBackColor = true;
            // 
            // AllDevicesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.btnApplyFilters);
            this.Controls.Add(this.BtnNext);
            this.Controls.Add(this.BtnPrevious);
            this.Controls.Add(this.cmbPrice);
            this.Controls.Add(this.cmbCondition);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "AllDevicesControl";
            this.Size = new System.Drawing.Size(1094, 758);
            this.Load += new System.EventHandler(this.AllDevicesControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ComboBox cmbCondition;
        private System.Windows.Forms.ComboBox cmbPrice;
        private System.Windows.Forms.Button BtnPrevious;
        private System.Windows.Forms.Button BtnNext;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Button btnApplyFilters;
    }
}
