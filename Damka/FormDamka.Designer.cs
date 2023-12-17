namespace Damka
{
    partial class FormDamka
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
            this.labelPlayerOneName = new System.Windows.Forms.Label();
            this.labelPlayerOneScore = new System.Windows.Forms.Label();
            this.labelPlayerTwoName = new System.Windows.Forms.Label();
            this.labelPlayerTwoScore = new System.Windows.Forms.Label();
            this.labelPlayerTurn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelPlayerOneName
            // 
            this.labelPlayerOneName.AutoSize = true;
            this.labelPlayerOneName.Location = new System.Drawing.Point(72, 30);
            this.labelPlayerOneName.Name = "labelPlayerOneName";
            this.labelPlayerOneName.Size = new System.Drawing.Size(48, 13);
            this.labelPlayerOneName.TabIndex = 1;
            this.labelPlayerOneName.Text = "Player 1:";
            // 
            // labelPlayerOneScore
            // 
            this.labelPlayerOneScore.AutoSize = true;
            this.labelPlayerOneScore.Location = new System.Drawing.Point(126, 30);
            this.labelPlayerOneScore.Name = "labelPlayerOneScore";
            this.labelPlayerOneScore.Size = new System.Drawing.Size(13, 13);
            this.labelPlayerOneScore.TabIndex = 3;
            this.labelPlayerOneScore.Text = "0";
            // 
            // labelPlayerTwoName
            // 
            this.labelPlayerTwoName.AutoSize = true;
            this.labelPlayerTwoName.Location = new System.Drawing.Point(240, 30);
            this.labelPlayerTwoName.Name = "labelPlayerTwoName";
            this.labelPlayerTwoName.Size = new System.Drawing.Size(48, 13);
            this.labelPlayerTwoName.TabIndex = 4;
            this.labelPlayerTwoName.Text = "Player 2:";
            // 
            // labelPlayerTwoScore
            // 
            this.labelPlayerTwoScore.AutoSize = true;
            this.labelPlayerTwoScore.Location = new System.Drawing.Point(294, 30);
            this.labelPlayerTwoScore.Name = "labelPlayerTwoScore";
            this.labelPlayerTwoScore.Size = new System.Drawing.Size(13, 13);
            this.labelPlayerTwoScore.TabIndex = 5;
            this.labelPlayerTwoScore.Text = "0";
            // 
            // labelPlayerTurn
            // 
            this.labelPlayerTurn.AutoSize = true;
            this.labelPlayerTurn.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelPlayerTurn.Location = new System.Drawing.Point(148, 9);
            this.labelPlayerTurn.Name = "labelPlayerTurn";
            this.labelPlayerTurn.Size = new System.Drawing.Size(84, 16);
            this.labelPlayerTurn.TabIndex = 6;
            this.labelPlayerTurn.Text = "Player1 turn";
            // 
            // FormDamka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 379);
            this.Controls.Add(this.labelPlayerTurn);
            this.Controls.Add(this.labelPlayerTwoScore);
            this.Controls.Add(this.labelPlayerTwoName);
            this.Controls.Add(this.labelPlayerOneScore);
            this.Controls.Add(this.labelPlayerOneName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormDamka";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Damka";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPlayerOneName;
        private System.Windows.Forms.Label labelPlayerOneScore;
        private System.Windows.Forms.Label labelPlayerTwoName;
        private System.Windows.Forms.Label labelPlayerTwoScore;
        private System.Windows.Forms.Label labelPlayerTurn;
    }
}