namespace ImageCompressor
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.loadBtn = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.processBtn = new System.Windows.Forms.Button();
            this.textBoxYdim = new System.Windows.Forms.TextBox();
            this.textBoxXdim = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // loadBtn
            // 
            this.loadBtn.Location = new System.Drawing.Point(12, 414);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(230, 36);
            this.loadBtn.TabIndex = 0;
            this.loadBtn.Text = "Load";
            this.loadBtn.UseVisualStyleBackColor = true;
            this.loadBtn.Click += new System.EventHandler(this.loadBtn_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Black;
            this.imageList1.Images.SetKeyName(0, "USBLogo.jpg");
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(459, 369);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // processBtn
            // 
            this.processBtn.Location = new System.Drawing.Point(248, 414);
            this.processBtn.Name = "processBtn";
            this.processBtn.Size = new System.Drawing.Size(223, 36);
            this.processBtn.TabIndex = 2;
            this.processBtn.Text = "Process";
            this.processBtn.UseVisualStyleBackColor = true;
            this.processBtn.Click += new System.EventHandler(this.processBtn_Click);
            // 
            // textBoxYdim
            // 
            this.textBoxYdim.Location = new System.Drawing.Point(370, 388);
            this.textBoxYdim.Name = "textBoxYdim";
            this.textBoxYdim.Size = new System.Drawing.Size(100, 20);
            this.textBoxYdim.TabIndex = 3;
            this.textBoxYdim.TextChanged += new System.EventHandler(this.textBoxYdim_TextChanged);
            // 
            // textBoxXdim
            // 
            this.textBoxXdim.Location = new System.Drawing.Point(248, 388);
            this.textBoxXdim.Name = "textBoxXdim";
            this.textBoxXdim.Size = new System.Drawing.Size(100, 20);
            this.textBoxXdim.TabIndex = 4;
            this.textBoxXdim.TextChanged += new System.EventHandler(this.textBoxXdim_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 462);
            this.Controls.Add(this.textBoxXdim);
            this.Controls.Add(this.textBoxYdim);
            this.Controls.Add(this.processBtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.loadBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button loadBtn;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button processBtn;
        private System.Windows.Forms.TextBox textBoxYdim;
        private System.Windows.Forms.TextBox textBoxXdim;

    }
}

