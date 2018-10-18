namespace ISE.Framework.Client.Win.Selector
{
    partial class UCItemListSelect<T>
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
            this.components = new System.ComponentModel.Container();
            Janus.Windows.Common.JanusColorScheme janusColorScheme1 = new Janus.Windows.Common.JanusColorScheme();
            this.iGroupBox1 = new ISE.UILibrary.IGroupBox();
            this.btnCancel = new Janus.Windows.EditControls.UIButton();
            this.visualStyleManager1 = new Janus.Windows.Common.VisualStyleManager(this.components);
            this.btnSelect = new Janus.Windows.EditControls.UIButton();
            this.iGridEX1 = new ISE.UILibrary.IGridEX();
            this.iGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iGridEX1)).BeginInit();
            this.SuspendLayout();
            // 
            // iGroupBox1
            // 
            this.iGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iGroupBox1.Controls.Add(this.btnCancel);
            this.iGroupBox1.Controls.Add(this.btnSelect);
            this.iGroupBox1.Controls.Add(this.iGridEX1);
            this.iGroupBox1.Location = new System.Drawing.Point(6, 2);
            this.iGroupBox1.Name = "iGroupBox1";
            this.iGroupBox1.Size = new System.Drawing.Size(723, 403);
            this.iGroupBox1.TabIndex = 1;
            this.iGroupBox1.TabStop = false;
            this.iGroupBox1.Text = "انتخاب آيتم";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.ImageIndex = 49;
            this.btnCancel.Location = new System.Drawing.Point(517, 363);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 34);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "بستن";
            this.btnCancel.VisualStyleManager = this.visualStyleManager1;
            this.btnCancel.Click += new System.EventHandler(this.iButtonCancel_Click);
            // 
            // visualStyleManager1
            // 
            janusColorScheme1.HighlightTextColor = System.Drawing.SystemColors.HighlightText;
            janusColorScheme1.Name = "Scheme0";
            janusColorScheme1.Office2007CustomColor = System.Drawing.Color.Empty;
            janusColorScheme1.VisualStyle = Janus.Windows.Common.VisualStyle.Office2007;
            this.visualStyleManager1.ColorSchemes.Add(janusColorScheme1);
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.ImageIndex = 42;
            this.btnSelect.Location = new System.Drawing.Point(632, 363);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(85, 34);
            this.btnSelect.TabIndex = 15;
            this.btnSelect.Text = "انتخاب";
            this.btnSelect.VisualStyleManager = this.visualStyleManager1;
            this.btnSelect.Click += new System.EventHandler(this.iButtonSelect_Click);
            // 
            // iGridEX1
            // 
            this.iGridEX1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iGridEX1.DefaultFilterRowComparison = Janus.Windows.GridEX.FilterConditionOperator.Contains;
            this.iGridEX1.Location = new System.Drawing.Point(0, 17);
            this.iGridEX1.Name = "iGridEX1";
            this.iGridEX1.Size = new System.Drawing.Size(717, 340);
            this.iGridEX1.TabIndex = 12;
            this.iGridEX1.RowDoubleClick += new Janus.Windows.GridEX.RowActionEventHandler(this.iGridEX1_RowDoubleClick);
            // 
            // UCItemListSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.iGroupBox1);
            this.Name = "UCItemListSelect";
            this.Size = new System.Drawing.Size(734, 406);
            this.iGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iGridEX1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UILibrary.IGroupBox iGroupBox1;
        private UILibrary.IGridEX iGridEX1;
        private Janus.Windows.EditControls.UIButton btnSelect;
        private Janus.Windows.Common.VisualStyleManager visualStyleManager1;
        private Janus.Windows.EditControls.UIButton btnCancel;

    }
}
