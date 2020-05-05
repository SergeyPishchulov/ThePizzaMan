namespace GameNoGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.mapChoosingControl1 = new GameNoGame.MapChoosingControl();
            this.exitControl1 = new GameNoGame.ExitControl();
            this.startControl1 = new GameNoGame.StartControl();
            this.SuspendLayout();
            // 
            // mapChoosingControl1
            // 
            this.mapChoosingControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mapChoosingControl1.BackgroundImage")));
            this.mapChoosingControl1.Location = new System.Drawing.Point(0, 0);
            this.mapChoosingControl1.Name = "mapChoosingControl1";
            this.mapChoosingControl1.Size = new System.Drawing.Size(1440, 1024);
            this.mapChoosingControl1.TabIndex = 2;
            // 
            // exitControl1
            // 
            this.exitControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("exitControl1.BackgroundImage")));
            this.exitControl1.Location = new System.Drawing.Point(0, 0);
            this.exitControl1.Name = "exitControl1";
            this.exitControl1.Size = new System.Drawing.Size(1440, 1024);
            this.exitControl1.TabIndex = 1;
            // 
            // startControl1
            // 
            this.startControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("startControl1.BackgroundImage")));
            this.startControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.startControl1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.startControl1.Location = new System.Drawing.Point(0, 0);
            this.startControl1.Margin = new System.Windows.Forms.Padding(2);
            this.startControl1.Name = "startControl1";
            this.startControl1.Size = new System.Drawing.Size(1440, 1024);
            this.startControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1424, 985);
            this.Controls.Add(this.exitControl1);
            this.Controls.Add(this.startControl1);
            this.Controls.Add(this.mapChoosingControl1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private StartControl startControl1;
        private ExitControl exitControl1;
        private MapChoosingControl mapChoosingControl1;
    }
}

