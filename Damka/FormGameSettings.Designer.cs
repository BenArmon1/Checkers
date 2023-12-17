namespace GameSettings
{
    partial class FormGameSettings
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
            this.ButtonDone = new System.Windows.Forms.Button();
            this.RadioButtonSizeSix = new System.Windows.Forms.RadioButton();
            this.RadioButtonSizeTen = new System.Windows.Forms.RadioButton();
            this.RadioButtonSizeEight = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPlayerOneName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPlayerTwoName = new System.Windows.Forms.TextBox();
            this.checkBoxPlayerTwo = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ButtonDone
            // 
            this.ButtonDone.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ButtonDone.Location = new System.Drawing.Point(145, 162);
            this.ButtonDone.Name = "ButtonDone";
            this.ButtonDone.Size = new System.Drawing.Size(93, 28);
            this.ButtonDone.TabIndex = 9;
            this.ButtonDone.Tag = "";
            this.ButtonDone.Text = "Done";
            this.ButtonDone.UseVisualStyleBackColor = true;
            this.ButtonDone.Click += new System.EventHandler(this.ButtonDone_Click);
            // 
            // RadioButtonSizeSix
            // 
            this.RadioButtonSizeSix.AutoSize = true;
            this.RadioButtonSizeSix.Location = new System.Drawing.Point(30, 29);
            this.RadioButtonSizeSix.Name = "RadioButtonSizeSix";
            this.RadioButtonSizeSix.Size = new System.Drawing.Size(46, 18);
            this.RadioButtonSizeSix.TabIndex = 1;
            this.RadioButtonSizeSix.TabStop = true;
            this.RadioButtonSizeSix.Text = "6 x 6";
            this.RadioButtonSizeSix.UseCompatibleTextRendering = true;
            this.RadioButtonSizeSix.UseVisualStyleBackColor = true;
            this.RadioButtonSizeSix.CheckedChanged += new System.EventHandler(this.RadioButtonSize_CheckedChanged);
            // 
            // RadioButtonSizeTen
            // 
            this.RadioButtonSizeTen.AutoSize = true;
            this.RadioButtonSizeTen.Location = new System.Drawing.Point(168, 29);
            this.RadioButtonSizeTen.Name = "RadioButtonSizeTen";
            this.RadioButtonSizeTen.Size = new System.Drawing.Size(60, 17);
            this.RadioButtonSizeTen.TabIndex = 3;
            this.RadioButtonSizeTen.TabStop = true;
            this.RadioButtonSizeTen.Text = "10 x 10";
            this.RadioButtonSizeTen.UseVisualStyleBackColor = true;
            // 
            // RadioButtonSizeEight
            // 
            this.RadioButtonSizeEight.AutoSize = true;
            this.RadioButtonSizeEight.Location = new System.Drawing.Point(101, 29);
            this.RadioButtonSizeEight.Name = "RadioButtonSizeEight";
            this.RadioButtonSizeEight.Size = new System.Drawing.Size(48, 17);
            this.RadioButtonSizeEight.TabIndex = 2;
            this.RadioButtonSizeEight.TabStop = true;
            this.RadioButtonSizeEight.Text = "8 x 8";
            this.RadioButtonSizeEight.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Board Size:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Players:";
            // 
            // textBoxPlayerOneName
            // 
            this.textBoxPlayerOneName.Location = new System.Drawing.Point(115, 87);
            this.textBoxPlayerOneName.Name = "textBoxPlayerOneName";
            this.textBoxPlayerOneName.Size = new System.Drawing.Size(123, 20);
            this.textBoxPlayerOneName.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(27, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Player 1:";
            // 
            // textBoxPlayerTwoName
            // 
            this.textBoxPlayerTwoName.Enabled = false;
            this.textBoxPlayerTwoName.Location = new System.Drawing.Point(115, 124);
            this.textBoxPlayerTwoName.Name = "textBoxPlayerTwoName";
            this.textBoxPlayerTwoName.Size = new System.Drawing.Size(123, 20);
            this.textBoxPlayerTwoName.TabIndex = 8;
            this.textBoxPlayerTwoName.Text = "[Computer]";
            // 
            // checkBoxPlayerTwo
            // 
            this.checkBoxPlayerTwo.AutoSize = true;
            this.checkBoxPlayerTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.checkBoxPlayerTwo.Location = new System.Drawing.Point(26, 123);
            this.checkBoxPlayerTwo.Name = "checkBoxPlayerTwo";
            this.checkBoxPlayerTwo.Size = new System.Drawing.Size(83, 21);
            this.checkBoxPlayerTwo.TabIndex = 7;
            this.checkBoxPlayerTwo.Text = "Player 2:";
            this.checkBoxPlayerTwo.UseVisualStyleBackColor = true;
            this.checkBoxPlayerTwo.CheckedChanged += new System.EventHandler(this.checkBoxPlayerTwo_CheckedChanged);
            // 
            // FormGameSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(250, 202);
            this.Controls.Add(this.checkBoxPlayerTwo);
            this.Controls.Add(this.textBoxPlayerTwoName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxPlayerOneName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RadioButtonSizeEight);
            this.Controls.Add(this.RadioButtonSizeTen);
            this.Controls.Add(this.RadioButtonSizeSix);
            this.Controls.Add(this.ButtonDone);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGameSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Settings";
            this.FormClosing += FormGameSettings_FormClosing;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonDone;
        private System.Windows.Forms.RadioButton RadioButtonSizeSix;
        private System.Windows.Forms.RadioButton RadioButtonSizeTen;
        private System.Windows.Forms.RadioButton RadioButtonSizeEight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPlayerOneName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPlayerTwoName;
        private System.Windows.Forms.CheckBox checkBoxPlayerTwo;
    }
}

