namespace DeliciousPartnerApp
{
    partial class Form3
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraMap.GeoMapCoordinateSystem geoMapCoordinateSystem1 = new DevExpress.XtraMap.GeoMapCoordinateSystem();
            this.mapControl1 = new DevExpress.XtraMap.MapControl();
            this.imageLayer1 = new DevExpress.XtraMap.ImageLayer();
            this.bingMapDataProvider1 = new DevExpress.XtraMap.BingMapDataProvider();
            ((System.ComponentModel.ISupportInitialize)(this.mapControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // mapControl1
            // 
            this.mapControl1.CenterPoint = new DevExpress.XtraMap.GeoPoint(14.6069018670887D, 121.00317726903D);
            geoMapCoordinateSystem1.CircularScrollingMode = DevExpress.XtraMap.CircularScrollingMode.TilesAndVectorItems;
            this.mapControl1.CoordinateSystem = geoMapCoordinateSystem1;
            this.mapControl1.Layers.Add(this.imageLayer1);
            this.mapControl1.Location = new System.Drawing.Point(12, 12);
            this.mapControl1.Name = "mapControl1";
            this.mapControl1.NavigationPanelOptions.BackgroundStyle.Fill = System.Drawing.Color.Yellow;
            this.mapControl1.Size = new System.Drawing.Size(594, 450);
            this.mapControl1.TabIndex = 0;
            this.mapControl1.ZoomLevel = 20D;
            this.imageLayer1.DataProvider = this.bingMapDataProvider1;
            this.bingMapDataProvider1.BingKey = "iryJn9tdBhBoxVVWx79g~2Pgx9CP1acHKahkCWghuUQ~AitZDbJTTUk9EQOZWZLIetY1sijkfyGO4Zfmn" +
    "0Merk4nad8hmFEIhXD-QrdeT7bV";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 474);
            this.Controls.Add(this.mapControl1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mapControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraMap.MapControl mapControl1;
        private DevExpress.XtraMap.ImageLayer imageLayer1;
        private DevExpress.XtraMap.BingMapDataProvider bingMapDataProvider1;
    }
}