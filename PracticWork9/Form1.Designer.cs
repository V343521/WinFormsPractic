namespace PracticWork9
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelXmin;
        private System.Windows.Forms.Label labelXmax;
        private System.Windows.Forms.Label labelStep;
        private System.Windows.Forms.TextBox txtXmin;
        private System.Windows.Forms.TextBox txtXmax;
        private System.Windows.Forms.TextBox txtStep;
        private System.Windows.Forms.Button btnCalculate;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            labelXmin = new Label();
            labelXmax = new Label();
            labelStep = new Label();
            txtXmin = new TextBox();
            txtXmax = new TextBox();
            txtStep = new TextBox();
            btnCalculate = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.BackColor = Color.White;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(660, 380);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // labelXmin
            // 
            labelXmin.AutoSize = true;
            labelXmin.Location = new Point(15, 405);
            labelXmin.Name = "labelXmin";
            labelXmin.Size = new Size(35, 15);
            labelXmin.TabIndex = 7;
            labelXmin.Text = "Xmin";
            // 
            // labelXmax
            // 
            labelXmax.AutoSize = true;
            labelXmax.Location = new Point(120, 405);
            labelXmax.Name = "labelXmax";
            labelXmax.Size = new Size(36, 15);
            labelXmax.TabIndex = 6;
            labelXmax.Text = "Xmax";
            // 
            // labelStep
            // 
            labelStep.AutoSize = true;
            labelStep.Location = new Point(225, 405);
            labelStep.Name = "labelStep";
            labelStep.Size = new Size(29, 15);
            labelStep.TabIndex = 5;
            labelStep.Text = "Шаг";
            // 
            // txtXmin
            // 
            txtXmin.Location = new Point(15, 423);
            txtXmin.Name = "txtXmin";
            txtXmin.Size = new Size(90, 23);
            txtXmin.TabIndex = 1;
            txtXmin.Text = "-5";
            // 
            // txtXmax
            // 
            txtXmax.Location = new Point(120, 423);
            txtXmax.Name = "txtXmax";
            txtXmax.Size = new Size(90, 23);
            txtXmax.TabIndex = 2;
            txtXmax.Text = "5";
            // 
            // txtStep
            // 
            txtStep.Location = new Point(225, 423);
            txtStep.Name = "txtStep";
            txtStep.Size = new Size(90, 23);
            txtStep.TabIndex = 3;
            txtStep.Text = "0,1";
            // 
            // btnCalculate
            // 
            btnCalculate.Location = new Point(335, 422);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(90, 25);
            btnCalculate.TabIndex = 4;
            btnCalculate.Text = "Calculation";
            btnCalculate.UseVisualStyleBackColor = true;
            btnCalculate.Click += btnCalculate_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 461);
            Controls.Add(btnCalculate);
            Controls.Add(txtStep);
            Controls.Add(txtXmax);
            Controls.Add(txtXmin);
            Controls.Add(labelStep);
            Controls.Add(labelXmax);
            Controls.Add(labelXmin);
            Controls.Add(pictureBox1);
            MinimumSize = new Size(700, 500);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Plotting functions";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}