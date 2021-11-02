
namespace O_Neillo_Assignment
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.playerTwoName = new System.Windows.Forms.TextBox();
            this.playerOneName = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.numOfWhite = new System.Windows.Forms.Label();
            this.numOfBlck = new System.Windows.Forms.Label();
            this.toPlayWhite = new System.Windows.Forms.PictureBox();
            this.toPlayBlck = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toPlayWhite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toPlayBlck)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.PaleVioletRed;
            this.groupBox1.Controls.Add(this.toPlayWhite);
            this.groupBox1.Controls.Add(this.numOfBlck);
            this.groupBox1.Controls.Add(this.numOfWhite);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.playerTwoName);
            this.groupBox1.Controls.Add(this.playerOneName);
            this.groupBox1.Location = new System.Drawing.Point(9, 377);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(372, 53);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // playerTwoName
            // 
            this.playerTwoName.Location = new System.Drawing.Point(260, 30);
            this.playerTwoName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.playerTwoName.Name = "playerTwoName";
            this.playerTwoName.Size = new System.Drawing.Size(76, 20);
            this.playerTwoName.TabIndex = 1;
            // 
            // playerOneName
            // 
            this.playerOneName.Location = new System.Drawing.Point(84, 30);
            this.playerOneName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.playerOneName.Name = "playerOneName";
            this.playerOneName.Size = new System.Drawing.Size(76, 20);
            this.playerOneName.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(390, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(232, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(56, 25);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(23, 23);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // numOfWhite
            // 
            this.numOfWhite.AutoSize = true;
            this.numOfWhite.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numOfWhite.ForeColor = System.Drawing.Color.Black;
            this.numOfWhite.Location = new System.Drawing.Point(10, 23);
            this.numOfWhite.Name = "numOfWhite";
            this.numOfWhite.Size = new System.Drawing.Size(40, 25);
            this.numOfWhite.TabIndex = 2;
            this.numOfWhite.Text = "2X";
            // 
            // numOfBlck
            // 
            this.numOfBlck.AutoSize = true;
            this.numOfBlck.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numOfBlck.ForeColor = System.Drawing.Color.Black;
            this.numOfBlck.Location = new System.Drawing.Point(186, 23);
            this.numOfBlck.Name = "numOfBlck";
            this.numOfBlck.Size = new System.Drawing.Size(40, 25);
            this.numOfBlck.TabIndex = 3;
            this.numOfBlck.Text = "2X";
            // 
            // toPlayWhite
            // 
            this.toPlayWhite.Image = ((System.Drawing.Image)(resources.GetObject("toPlayWhite.Image")));
            this.toPlayWhite.Location = new System.Drawing.Point(85, 0);
            this.toPlayWhite.Name = "toPlayWhite";
            this.toPlayWhite.Size = new System.Drawing.Size(75, 25);
            this.toPlayWhite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.toPlayWhite.TabIndex = 2;
            this.toPlayWhite.TabStop = false;
            this.toPlayWhite.Visible = false;
            // 
            // toPlayBlck
            // 
            this.toPlayBlck.Image = ((System.Drawing.Image)(resources.GetObject("toPlayBlck.Image")));
            this.toPlayBlck.Location = new System.Drawing.Point(270, 377);
            this.toPlayBlck.Name = "toPlayBlck";
            this.toPlayBlck.Size = new System.Drawing.Size(75, 25);
            this.toPlayBlck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.toPlayBlck.TabIndex = 3;
            this.toPlayBlck.TabStop = false;
            this.toPlayBlck.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightPink;
            this.ClientSize = new System.Drawing.Size(390, 437);
            this.Controls.Add(this.toPlayBlck);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.LightPink;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "O\'Neillo v1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toPlayWhite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toPlayBlck)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox playerTwoName;
        private System.Windows.Forms.TextBox playerOneName;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label numOfBlck;
        private System.Windows.Forms.Label numOfWhite;
        private System.Windows.Forms.PictureBox toPlayWhite;
        private System.Windows.Forms.PictureBox toPlayBlck;
    }
}

