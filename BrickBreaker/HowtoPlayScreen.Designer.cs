
namespace BrickBreaker
{
    partial class HowtoPlayScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.howtolabel = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // howtolabel
            // 
            this.howtolabel.BackColor = System.Drawing.Color.White;
            this.howtolabel.Font = new System.Drawing.Font("Super Mario 256", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.howtolabel.ForeColor = System.Drawing.Color.Black;
            this.howtolabel.Location = new System.Drawing.Point(61, 50);
            this.howtolabel.Name = "howtolabel";
            this.howtolabel.Size = new System.Drawing.Size(287, 153);
            this.howtolabel.TabIndex = 0;
            this.howtolabel.Text = "Arrow Keys (←→) To Move!\r\n\r\nDont Let the Ball Touch the Ground!\r\n\r\nYou Have 3 Liv" +
    "es!\r\n";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::BrickBreaker.Properties.Resources.realbubble;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(28, 30);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(333, 213);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // HowtoPlayScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BrickBreaker.Properties.Resources.howtoplay;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.howtolabel);
            this.Controls.Add(this.pictureBox2);
            this.Name = "HowtoPlayScreen";
            this.Size = new System.Drawing.Size(854, 542);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label howtolabel;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
