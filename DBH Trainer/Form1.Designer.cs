namespace DBH_Trainer
{
    partial class Form1
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.chkSpeedhack = new System.Windows.Forms.CheckBox();
            this.chkHighJump = new System.Windows.Forms.CheckBox();
            this.chkFreezeAll = new System.Windows.Forms.CheckBox();
            this.chkAirControl = new System.Windows.Forms.CheckBox();
            this.chkIceSlide = new System.Windows.Forms.CheckBox();
            this.chkFly = new System.Windows.Forms.CheckBox();
            this.chkGodMode = new System.Windows.Forms.CheckBox();
            this.btnVoidAll = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // chkSpeedhack
            // 
            this.chkSpeedhack.AutoSize = true;
            this.chkSpeedhack.Location = new System.Drawing.Point(197, 25);
            this.chkSpeedhack.Name = "chkSpeedhack";
            this.chkSpeedhack.Size = new System.Drawing.Size(121, 17);
            this.chkSpeedhack.TabIndex = 0;
            this.chkSpeedhack.Text = "Speedhack [Num 1]";
            this.chkSpeedhack.UseVisualStyleBackColor = true;
            // 
            // chkHighJump
            // 
            this.chkHighJump.AutoSize = true;
            this.chkHighJump.Location = new System.Drawing.Point(197, 59);
            this.chkHighJump.Name = "chkHighJump";
            this.chkHighJump.Size = new System.Drawing.Size(116, 17);
            this.chkHighJump.TabIndex = 1;
            this.chkHighJump.Text = "High Jump [Num 2]";
            this.chkHighJump.UseVisualStyleBackColor = true;
            // 
            // chkFreezeAll
            // 
            this.chkFreezeAll.AutoSize = true;
            this.chkFreezeAll.Location = new System.Drawing.Point(197, 93);
            this.chkFreezeAll.Name = "chkFreezeAll";
            this.chkFreezeAll.Size = new System.Drawing.Size(112, 17);
            this.chkFreezeAll.TabIndex = 2;
            this.chkFreezeAll.Text = "Freeze All [Num 3]";
            this.chkFreezeAll.UseVisualStyleBackColor = true;
            // 
            // chkAirControl
            // 
            this.chkAirControl.AutoSize = true;
            this.chkAirControl.Location = new System.Drawing.Point(197, 129);
            this.chkAirControl.Name = "chkAirControl";
            this.chkAirControl.Size = new System.Drawing.Size(114, 17);
            this.chkAirControl.TabIndex = 3;
            this.chkAirControl.Text = "Air Control [Num 4]";
            this.chkAirControl.UseVisualStyleBackColor = true;
            // 
            // chkIceSlide
            // 
            this.chkIceSlide.AutoSize = true;
            this.chkIceSlide.Location = new System.Drawing.Point(197, 163);
            this.chkIceSlide.Name = "chkIceSlide";
            this.chkIceSlide.Size = new System.Drawing.Size(107, 17);
            this.chkIceSlide.TabIndex = 4;
            this.chkIceSlide.Text = "Ice Slide [Num 5]";
            this.chkIceSlide.UseVisualStyleBackColor = true;
            // 
            // chkFly
            // 
            this.chkFly.AutoSize = true;
            this.chkFly.Location = new System.Drawing.Point(197, 204);
            this.chkFly.Name = "chkFly";
            this.chkFly.Size = new System.Drawing.Size(116, 17);
            this.chkFly.TabIndex = 5;
            this.chkFly.Text = "No Gravity [Num 6]";
            this.chkFly.UseVisualStyleBackColor = true;
            // 
            // chkGodMode
            // 
            this.chkGodMode.AutoSize = true;
            this.chkGodMode.Location = new System.Drawing.Point(197, 243);
            this.chkGodMode.Name = "chkGodMode";
            this.chkGodMode.Size = new System.Drawing.Size(116, 17);
            this.chkGodMode.TabIndex = 6;
            this.chkGodMode.Text = "God Mode [Num 7]";
            this.chkGodMode.UseVisualStyleBackColor = true;
            // 
            // btnVoidAll
            // 
            this.btnVoidAll.Location = new System.Drawing.Point(197, 283);
            this.btnVoidAll.Name = "btnVoidAll";
            this.btnVoidAll.Size = new System.Drawing.Size(156, 23);
            this.btnVoidAll.TabIndex = 8;
            this.btnVoidAll.Text = "VOID ALL ZOMBIES [Num 0]";
            this.btnVoidAll.UseVisualStyleBackColor = true;
            this.btnVoidAll.Click += new System.EventHandler(this.btnVoidAll_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(12, 142);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(169, 16);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "Статус: Ожидание игры...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 320);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnVoidAll);
            this.Controls.Add(this.chkGodMode);
            this.Controls.Add(this.chkFly);
            this.Controls.Add(this.chkIceSlide);
            this.Controls.Add(this.chkAirControl);
            this.Controls.Add(this.chkFreezeAll);
            this.Controls.Add(this.chkHighJump);
            this.Controls.Add(this.chkSpeedhack);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "DriveBeyondHorizons Trainer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkSpeedhack;
        private System.Windows.Forms.CheckBox chkHighJump;
        private System.Windows.Forms.CheckBox chkFreezeAll;
        private System.Windows.Forms.CheckBox chkAirControl;
        private System.Windows.Forms.CheckBox chkIceSlide;
        private System.Windows.Forms.CheckBox chkFly;
        private System.Windows.Forms.CheckBox chkGodMode;
        private System.Windows.Forms.Button btnVoidAll;
        private System.Windows.Forms.Label lblStatus;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

