namespace GameNoGame
{
    partial class ExitControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExitControl));
            this.YESButton = new System.Windows.Forms.Button();
            this.NOButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // YESButton
            // 
            this.YESButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(224)))), ((int)(((byte)(250)))));
            this.YESButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 30F, System.Drawing.FontStyle.Bold);
            this.YESButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(0)))), ((int)(((byte)(63)))));
            this.YESButton.Location = new System.Drawing.Point(473, 578);
            this.YESButton.Name = "YESButton";
            this.YESButton.Size = new System.Drawing.Size(230, 100);
            this.YESButton.TabIndex = 0;
            this.YESButton.Text = "Да";
            this.YESButton.UseVisualStyleBackColor = false;
            this.YESButton.Click += new System.EventHandler(this.YESButton_Click);
            // 
            // NOButton
            // 
            this.NOButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(224)))), ((int)(((byte)(250)))));
            this.NOButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 30F, System.Drawing.FontStyle.Bold);
            this.NOButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(0)))), ((int)(((byte)(63)))));
            this.NOButton.Location = new System.Drawing.Point(745, 578);
            this.NOButton.Name = "NOButton";
            this.NOButton.Size = new System.Drawing.Size(230, 100);
            this.NOButton.TabIndex = 1;
            this.NOButton.Text = "Нет";
            this.NOButton.UseVisualStyleBackColor = false;
            this.NOButton.Click += new System.EventHandler(this.NOButton_Click);
            // 
            // ExitControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.NOButton);
            this.Controls.Add(this.YESButton);
            this.Name = "ExitControl";
            this.Size = new System.Drawing.Size(1440, 1024);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button YESButton;
        private System.Windows.Forms.Button NOButton;
    }
}
