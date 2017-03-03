namespace PathFinding
{
    partial class UIForm
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
            this.btnBegin = new System.Windows.Forms.Button();
            this.btnPlaceStart = new System.Windows.Forms.Button();
            this.btnPlaceGoal = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.cBoxDebugMode = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dbPanel = new PathFinding.DoubleBufferPanel();
            this.SuspendLayout();
            // 
            // btnBegin
            // 
            this.btnBegin.Enabled = false;
            this.btnBegin.Location = new System.Drawing.Point(266, 576);
            this.btnBegin.Name = "btnBegin";
            this.btnBegin.Size = new System.Drawing.Size(75, 23);
            this.btnBegin.TabIndex = 1;
            this.btnBegin.Text = "Begin";
            this.btnBegin.UseVisualStyleBackColor = true;
            this.btnBegin.Click += new System.EventHandler(this.btnBegin_Click);
            // 
            // btnPlaceStart
            // 
            this.btnPlaceStart.Location = new System.Drawing.Point(266, 518);
            this.btnPlaceStart.Name = "btnPlaceStart";
            this.btnPlaceStart.Size = new System.Drawing.Size(75, 23);
            this.btnPlaceStart.TabIndex = 3;
            this.btnPlaceStart.Text = "Place Start";
            this.btnPlaceStart.UseVisualStyleBackColor = true;
            this.btnPlaceStart.Click += new System.EventHandler(this.btnPlaceStart_Click);
            // 
            // btnPlaceGoal
            // 
            this.btnPlaceGoal.Location = new System.Drawing.Point(347, 518);
            this.btnPlaceGoal.Name = "btnPlaceGoal";
            this.btnPlaceGoal.Size = new System.Drawing.Size(75, 23);
            this.btnPlaceGoal.TabIndex = 4;
            this.btnPlaceGoal.Text = "Place Goal";
            this.btnPlaceGoal.UseVisualStyleBackColor = true;
            this.btnPlaceGoal.Click += new System.EventHandler(this.btnPlaceGoal_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(438, 518);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cBoxDebugMode
            // 
            this.cBoxDebugMode.AutoSize = true;
            this.cBoxDebugMode.Location = new System.Drawing.Point(382, 564);
            this.cBoxDebugMode.Name = "cBoxDebugMode";
            this.cBoxDebugMode.Size = new System.Drawing.Size(88, 17);
            this.cBoxDebugMode.TabIndex = 6;
            this.cBoxDebugMode.Text = "Debug Mode";
            this.cBoxDebugMode.UseVisualStyleBackColor = true;
            this.cBoxDebugMode.CheckedChanged += new System.EventHandler(this.cBoxDebugMode_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(13, 518);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 121);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Map Settings";
            // 
            // dbPanel
            // 
            this.dbPanel.Location = new System.Drawing.Point(13, 12);
            this.dbPanel.Name = "dbPanel";
            this.dbPanel.Size = new System.Drawing.Size(500, 500);
            this.dbPanel.TabIndex = 2;
            this.dbPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.doubleBufferPanel1_Paint);
            this.dbPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.doubleBufferPanel1_MouseClick);
            // 
            // UIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 651);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.cBoxDebugMode);
            this.Controls.Add(this.btnPlaceGoal);
            this.Controls.Add(this.btnPlaceStart);
            this.Controls.Add(this.dbPanel);
            this.Controls.Add(this.btnBegin);
            this.Name = "UIForm";
            this.Text = "PathFinding";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnBegin;
        private DoubleBufferPanel dbPanel;
        private System.Windows.Forms.Button btnPlaceStart;
        private System.Windows.Forms.Button btnPlaceGoal;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckBox cBoxDebugMode;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

