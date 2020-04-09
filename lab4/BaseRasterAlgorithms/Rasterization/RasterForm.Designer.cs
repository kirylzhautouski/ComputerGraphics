namespace BaseRasterAlgorithms
{
    partial class RasterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RasterForm));
            this.pointsPictureBox = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.stepByStepButton = new System.Windows.Forms.ToolStripMenuItem();
            this.ddaButton = new System.Windows.Forms.ToolStripMenuItem();
            this.brezenhemButton = new System.Windows.Forms.ToolStripMenuItem();
            this.brezenhemCircleButton = new System.Windows.Forms.ToolStripMenuItem();
            this.clearButton = new System.Windows.Forms.ToolStripMenuItem();
            this.tbx = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tbY = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tbX2 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.tbY2 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.tbRadius = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.label7 = new System.Windows.Forms.ToolStripLabel();
            this.timeLabel = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pointsPictureBox)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pointsPictureBox
            // 
            this.pointsPictureBox.Location = new System.Drawing.Point(27, 75);
            this.pointsPictureBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pointsPictureBox.Name = "pointsPictureBox";
            this.pointsPictureBox.Size = new System.Drawing.Size(1744, 1201);
            this.pointsPictureBox.TabIndex = 10;
            this.pointsPictureBox.TabStop = false;
            this.pointsPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pointsPictureBox_Paint);
            this.pointsPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pointsPictureBox_MouseClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.tbx,
            this.toolStripLabel1,
            this.tbY,
            this.toolStripLabel2,
            this.tbX2,
            this.toolStripLabel3,
            this.tbY2,
            this.toolStripLabel4,
            this.tbRadius,
            this.toolStripLabel5,
            this.label7,
            this.timeLabel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(2021, 31);
            this.toolStrip1.TabIndex = 18;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stepByStepButton,
            this.ddaButton,
            this.brezenhemButton,
            this.brezenhemCircleButton,
            this.clearButton});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(38, 28);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // stepByStepButton
            // 
            this.stepByStepButton.Name = "stepByStepButton";
            this.stepByStepButton.Size = new System.Drawing.Size(252, 30);
            this.stepByStepButton.Text = "StepByStep";
            this.stepByStepButton.Click += new System.EventHandler(this.stepByStepButton_Click);
            // 
            // ddaButton
            // 
            this.ddaButton.Name = "ddaButton";
            this.ddaButton.Size = new System.Drawing.Size(252, 30);
            this.ddaButton.Text = "DDA";
            this.ddaButton.Click += new System.EventHandler(this.ddaButton_Click);
            // 
            // brezenhemButton
            // 
            this.brezenhemButton.Name = "brezenhemButton";
            this.brezenhemButton.Size = new System.Drawing.Size(252, 30);
            this.brezenhemButton.Text = "Brezenhem";
            this.brezenhemButton.Click += new System.EventHandler(this.brezenhemButton_Click);
            // 
            // brezenhemCircleButton
            // 
            this.brezenhemCircleButton.Name = "brezenhemCircleButton";
            this.brezenhemCircleButton.Size = new System.Drawing.Size(252, 30);
            this.brezenhemCircleButton.Text = "Brezenhem (circle)";
            this.brezenhemCircleButton.Click += new System.EventHandler(this.brezenhemCircleButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(252, 30);
            this.clearButton.Text = "Clear all points";
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // tbx
            // 
            this.tbx.Name = "tbx";
            this.tbx.Size = new System.Drawing.Size(112, 31);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(83, 28);
            this.toolStripLabel1.Text = "X1          ";
            // 
            // tbY
            // 
            this.tbY.Name = "tbY";
            this.tbY.Size = new System.Drawing.Size(112, 31);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(72, 28);
            this.toolStripLabel2.Text = "Y1        ";
            // 
            // tbX2
            // 
            this.tbX2.Name = "tbX2";
            this.tbX2.Size = new System.Drawing.Size(112, 31);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(63, 28);
            this.toolStripLabel3.Text = "X2      ";
            // 
            // tbY2
            // 
            this.tbY2.Name = "tbY2";
            this.tbY2.Size = new System.Drawing.Size(112, 31);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(67, 28);
            this.toolStripLabel4.Text = "Y2       ";
            // 
            // tbRadius
            // 
            this.tbRadius.Name = "tbRadius";
            this.tbRadius.Size = new System.Drawing.Size(112, 31);
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(65, 28);
            this.toolStripLabel5.Text = "Radius";
            // 
            // label7
            // 
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 28);
            this.label7.Text = "   Время:  ";
            // 
            // timeLabel
            // 
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(0, 28);
            // 
            // RasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2133, 1215);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pointsPictureBox);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(2155, 1271);
            this.MinimumSize = new System.Drawing.Size(1918, 1018);
            this.Name = "RasterForm";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 112, 0);
            this.Text = "RasterForm";
            ((System.ComponentModel.ISupportInitialize)(this.pointsPictureBox)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pointsPictureBox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem ddaButton;
        private System.Windows.Forms.ToolStripMenuItem brezenhemButton;
        private System.Windows.Forms.ToolStripMenuItem brezenhemCircleButton;
        private System.Windows.Forms.ToolStripMenuItem stepByStepButton;
        private System.Windows.Forms.ToolStripTextBox tbx;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tbY;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox tbX2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripTextBox tbY2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripTextBox tbRadius;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripMenuItem clearButton;
        private System.Windows.Forms.ToolStripLabel label7;
        private System.Windows.Forms.ToolStripLabel timeLabel;
    }
}

