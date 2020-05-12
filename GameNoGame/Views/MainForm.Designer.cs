namespace GameNoGame
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.exitControl = new GameNoGame.ExitControl();
            this.startControl = new GameNoGame.StartControl();
            this.levelControl = new GameNoGame.LevelControl();
            this.mapChoosingControl = new GameNoGame.MapChoosingControl();
            this.SuspendLayout();
            // 
            // exitControl
            // 
            this.exitControl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("exitControl.BackgroundImage")));
            this.exitControl.Location = new System.Drawing.Point(-5, -5);
            this.exitControl.Name = "exitControl";
            this.exitControl.Size = new System.Drawing.Size(1431, 1030);
            this.exitControl.TabIndex = 1;
            // 
            // startControl
            // 
            this.startControl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("startControl.BackgroundImage")));
            this.startControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.startControl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.startControl.Location = new System.Drawing.Point(2, 2);
            this.startControl.Margin = new System.Windows.Forms.Padding(2);
            this.startControl.Name = "startControl";
            this.startControl.Size = new System.Drawing.Size(1440, 1024);
            this.startControl.TabIndex = 0;
            // 
            // levelControl
            // 
            this.levelControl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("levelControl.BackgroundImage")));
            this.levelControl.Location = new System.Drawing.Point(2, 1);
            this.levelControl.Name = "levelControl";
            this.levelControl.Size = new System.Drawing.Size(1440, 1024);
            this.levelControl.TabIndex = 3;
            // 
            // mapChoosingControl
            // 
            this.mapChoosingControl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mapChoosingControl.BackgroundImage")));
            this.mapChoosingControl.Location = new System.Drawing.Point(2, 1);
            this.mapChoosingControl.Name = "mapChoosingControl";
            this.mapChoosingControl.Size = new System.Drawing.Size(1440, 1024);
            this.mapChoosingControl.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1424, 985);
            this.Controls.Add(this.startControl);
            this.Controls.Add(this.levelControl);
            this.Controls.Add(this.mapChoosingControl);
            this.Controls.Add(this.exitControl);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private StartControl startControl;
        private ExitControl exitControl;
        private MapChoosingControl mapChoosingControl;
        private LevelControl levelControl;
    }
}

