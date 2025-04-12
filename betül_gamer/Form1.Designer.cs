namespace betül_gamer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pictureBox1 = new PictureBox();
            DATAGRİDVİEW = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1079, 624);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.WaitOnLoad = true;
         
            // 
            // DATAGRİDVİEW
            // 
            DATAGRİDVİEW.Location = new Point(597, 283);
            DATAGRİDVİEW.Name = "DATAGRİDVİEW";
            DATAGRİDVİEW.Size = new Size(186, 87);
            DATAGRİDVİEW.TabIndex = 1;
            DATAGRİDVİEW.Text = "DataGridView";
            DATAGRİDVİEW.UseVisualStyleBackColor = true;
            DATAGRİDVİEW.Click += DATAGRİDVİEW_Click;
            // 
            // button2
            // 
            button2.Location = new Point(305, 283);
            button2.Name = "button2";
            button2.Size = new Size(202, 87);
            button2.TabIndex = 2;
            button2.Text = "ListView";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1079, 624);
            Controls.Add(button2);
            Controls.Add(DATAGRİDVİEW);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
          
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button DATAGRİDVİEW;
        private Button button2;
    }
}
