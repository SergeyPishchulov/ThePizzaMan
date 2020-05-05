namespace GameNoGame
{
    partial class MapChoosingControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapChoosingControl));
            this.Map1 = new System.Windows.Forms.Button();
            this.Map2 = new System.Windows.Forms.Button();
            this.Map3 = new System.Windows.Forms.Button();
            this.Map4 = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Map1
            // 
            this.Map1.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Map1.Location = new System.Drawing.Point(250, 108);
            this.Map1.Name = "Map1";
            this.Map1.Size = new System.Drawing.Size(400, 300);
            this.Map1.TabIndex = 0;
            this.Map1.Text = "1";
            this.Map1.UseVisualStyleBackColor = true;
            this.Map1.Click += new System.EventHandler(this.Map1_Click);
            // 
            // Map2
            // 
            this.Map2.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Map2.Location = new System.Drawing.Point(790, 108);
            this.Map2.Name = "Map2";
            this.Map2.Size = new System.Drawing.Size(400, 300);
            this.Map2.TabIndex = 1;
            this.Map2.Text = "2";
            this.Map2.UseVisualStyleBackColor = true;
            this.Map2.Click += new System.EventHandler(this.Map2_Click);
            // 
            // Map3
            // 
            this.Map3.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Map3.Location = new System.Drawing.Point(250, 480);
            this.Map3.Name = "Map3";
            this.Map3.Size = new System.Drawing.Size(400, 300);
            this.Map3.TabIndex = 2;
            this.Map3.Text = "3";
            this.Map3.UseVisualStyleBackColor = true;
            this.Map3.Click += new System.EventHandler(this.Map3_Click);
            // 
            // Map4
            // 
            this.Map4.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Map4.Location = new System.Drawing.Point(790, 480);
            this.Map4.Name = "Map4";
            this.Map4.Size = new System.Drawing.Size(400, 300);
            this.Map4.TabIndex = 3;
            this.Map4.Text = "4";
            this.Map4.UseVisualStyleBackColor = true;
            this.Map4.Click += new System.EventHandler(this.Map4_Click);
            // 
            // Back
            // 
            this.Back.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Back.BackColor = System.Drawing.Color.Black;
            this.Back.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Back.BackgroundImage")));
            this.Back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Back.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Back.Image = ((System.Drawing.Image)(resources.GetObject("Back.Image")));
            this.Back.Location = new System.Drawing.Point(15, 15);
            this.Back.Margin = new System.Windows.Forms.Padding(0);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(100, 100);
            this.Back.TabIndex = 4;
            this.Back.UseVisualStyleBackColor = false;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // MapChoosingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.Back);
            this.Controls.Add(this.Map4);
            this.Controls.Add(this.Map3);
            this.Controls.Add(this.Map2);
            this.Controls.Add(this.Map1);
            this.Name = "MapChoosingControl";
            this.Size = new System.Drawing.Size(1440, 1024);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Map1;
        private System.Windows.Forms.Button Map2;
        private System.Windows.Forms.Button Map3;
        private System.Windows.Forms.Button Map4;
        private System.Windows.Forms.Button Back;
    }
}
