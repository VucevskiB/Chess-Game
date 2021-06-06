
namespace Chess
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
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.ResignButton = new System.Windows.Forms.Button();
            this.GameBox = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.clockBlack = new System.Windows.Forms.Label();
            this.clockWhite = new System.Windows.Forms.Label();
            this.WhitePointsTxt = new System.Windows.Forms.Label();
            this.BlackPointsTxt = new System.Windows.Forms.Label();
            this.TurnText = new System.Windows.Forms.Label();
            this.whiteGreenCheck = new System.Windows.Forms.PictureBox();
            this.blackGreenCheck = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.GameBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.whiteGreenCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blackGreenCheck)).BeginInit();
            this.SuspendLayout();
            // 
            // ResignButton
            // 
            this.ResignButton.Location = new System.Drawing.Point(636, 277);
            this.ResignButton.Name = "ResignButton";
            this.ResignButton.Size = new System.Drawing.Size(75, 23);
            this.ResignButton.TabIndex = 0;
            this.ResignButton.Text = "Resign";
            this.ResignButton.UseVisualStyleBackColor = true;
            this.ResignButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // GameBox
            // 
            this.GameBox.BackColor = System.Drawing.Color.Tan;
            this.GameBox.Location = new System.Drawing.Point(74, 55);
            this.GameBox.Name = "GameBox";
            this.GameBox.Size = new System.Drawing.Size(512, 512);
            this.GameBox.TabIndex = 1;
            this.GameBox.TabStop = false;
            this.GameBox.Paint += new System.Windows.Forms.PaintEventHandler(this.gamePanel_Paint);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // clockBlack
            // 
            this.clockBlack.AutoSize = true;
            this.clockBlack.Font = new System.Drawing.Font("Sitka Small", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.clockBlack.Location = new System.Drawing.Point(507, 21);
            this.clockBlack.Name = "clockBlack";
            this.clockBlack.Size = new System.Drawing.Size(79, 31);
            this.clockBlack.TabIndex = 2;
            this.clockBlack.Text = "10:00";
            // 
            // clockWhite
            // 
            this.clockWhite.AutoSize = true;
            this.clockWhite.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.clockWhite.Font = new System.Drawing.Font("Sitka Small", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.clockWhite.Location = new System.Drawing.Point(507, 570);
            this.clockWhite.Name = "clockWhite";
            this.clockWhite.Size = new System.Drawing.Size(79, 31);
            this.clockWhite.TabIndex = 3;
            this.clockWhite.Text = "10:00";
            // 
            // WhitePointsTxt
            // 
            this.WhitePointsTxt.AutoSize = true;
            this.WhitePointsTxt.Font = new System.Drawing.Font("Yu Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.WhitePointsTxt.Location = new System.Drawing.Point(74, 570);
            this.WhitePointsTxt.Name = "WhitePointsTxt";
            this.WhitePointsTxt.Size = new System.Drawing.Size(28, 20);
            this.WhitePointsTxt.TabIndex = 4;
            this.WhitePointsTxt.Text = "+3";
            // 
            // BlackPointsTxt
            // 
            this.BlackPointsTxt.AutoSize = true;
            this.BlackPointsTxt.Font = new System.Drawing.Font("Yu Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BlackPointsTxt.Location = new System.Drawing.Point(74, 32);
            this.BlackPointsTxt.Name = "BlackPointsTxt";
            this.BlackPointsTxt.Size = new System.Drawing.Size(28, 20);
            this.BlackPointsTxt.TabIndex = 5;
            this.BlackPointsTxt.Text = "+3";
            // 
            // TurnText
            // 
            this.TurnText.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TurnText.AutoSize = true;
            this.TurnText.Font = new System.Drawing.Font("Franklin Gothic Heavy", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TurnText.Location = new System.Drawing.Point(256, 9);
            this.TurnText.Name = "TurnText";
            this.TurnText.Size = new System.Drawing.Size(165, 30);
            this.TurnText.TabIndex = 6;
            this.TurnText.Text = "WHITES TURN";
            // 
            // whiteGreenCheck
            // 
            this.whiteGreenCheck.Location = new System.Drawing.Point(488, 583);
            this.whiteGreenCheck.Name = "whiteGreenCheck";
            this.whiteGreenCheck.Size = new System.Drawing.Size(23, 18);
            this.whiteGreenCheck.TabIndex = 7;
            this.whiteGreenCheck.TabStop = false;
            // 
            // blackGreenCheck
            // 
            this.blackGreenCheck.Location = new System.Drawing.Point(488, 31);
            this.blackGreenCheck.Name = "blackGreenCheck";
            this.blackGreenCheck.Size = new System.Drawing.Size(23, 18);
            this.blackGreenCheck.TabIndex = 8;
            this.blackGreenCheck.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(865, 621);
            this.Controls.Add(this.blackGreenCheck);
            this.Controls.Add(this.whiteGreenCheck);
            this.Controls.Add(this.TurnText);
            this.Controls.Add(this.BlackPointsTxt);
            this.Controls.Add(this.WhitePointsTxt);
            this.Controls.Add(this.clockWhite);
            this.Controls.Add(this.clockBlack);
            this.Controls.Add(this.GameBox);
            this.Controls.Add(this.ResignButton);
            this.Name = "Form1";
            this.Text = "Chess";
            ((System.ComponentModel.ISupportInitialize)(this.GameBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.whiteGreenCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blackGreenCheck)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ResignButton;
        public System.Windows.Forms.PictureBox GameBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label clockBlack;
        private System.Windows.Forms.Label clockWhite;
        private System.Windows.Forms.Label WhitePointsTxt;
        private System.Windows.Forms.Label BlackPointsTxt;
        private System.Windows.Forms.Label TurnText;
        private System.Windows.Forms.PictureBox whiteGreenCheck;
        private System.Windows.Forms.PictureBox blackGreenCheck;
    }
}

