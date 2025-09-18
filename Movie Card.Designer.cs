namespace Holly_View
{
    partial class movie_card
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(movie_card));
            this.guna2ContainerControl1 = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.movie_pos_pg = new Guna.UI2.WinForms.Guna2Button();
            this.movie_pos_genres = new System.Windows.Forms.Label();
            this.movie_pos_language = new System.Windows.Forms.Label();
            this.movie_pos_name = new System.Windows.Forms.Label();
            this.movie_pos_pic = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2ContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.movie_pos_pic)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2ContainerControl1
            // 
            this.guna2ContainerControl1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ContainerControl1.BorderRadius = 20;
            this.guna2ContainerControl1.Controls.Add(this.movie_pos_pg);
            this.guna2ContainerControl1.Controls.Add(this.movie_pos_genres);
            this.guna2ContainerControl1.Controls.Add(this.movie_pos_language);
            this.guna2ContainerControl1.Controls.Add(this.movie_pos_name);
            this.guna2ContainerControl1.Controls.Add(this.movie_pos_pic);
            this.guna2ContainerControl1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.guna2ContainerControl1.Location = new System.Drawing.Point(3, 3);
            this.guna2ContainerControl1.Name = "guna2ContainerControl1";
            this.guna2ContainerControl1.ShadowDecoration.BorderRadius = 20;
            this.guna2ContainerControl1.ShadowDecoration.Depth = 3;
            this.guna2ContainerControl1.ShadowDecoration.Enabled = true;
            this.guna2ContainerControl1.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.guna2ContainerControl1.Size = new System.Drawing.Size(306, 604);
            this.guna2ContainerControl1.TabIndex = 0;
            this.guna2ContainerControl1.Text = "guna2ContainerControl1";
            // 
            // movie_pos_pg
            // 
            this.movie_pos_pg.BorderRadius = 14;
            this.movie_pos_pg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.movie_pos_pg.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.movie_pos_pg.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.movie_pos_pg.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(32)))), ((int)(((byte)(38)))));
            this.movie_pos_pg.DisabledState.ForeColor = System.Drawing.Color.White;
            this.movie_pos_pg.Enabled = false;
            this.movie_pos_pg.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(32)))), ((int)(((byte)(38)))));
            this.movie_pos_pg.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.movie_pos_pg.ForeColor = System.Drawing.Color.White;
            this.movie_pos_pg.Location = new System.Drawing.Point(15, 17);
            this.movie_pos_pg.Name = "movie_pos_pg";
            this.movie_pos_pg.Size = new System.Drawing.Size(68, 29);
            this.movie_pos_pg.TabIndex = 3;
            this.movie_pos_pg.Text = "R";
            this.movie_pos_pg.UseTransparentBackground = true;
            // 
            // movie_pos_genres
            // 
            this.movie_pos_genres.AutoSize = true;
            this.movie_pos_genres.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.movie_pos_genres.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(96)))), ((int)(((byte)(110)))));
            this.movie_pos_genres.Location = new System.Drawing.Point(4, 561);
            this.movie_pos_genres.Name = "movie_pos_genres";
            this.movie_pos_genres.Padding = new System.Windows.Forms.Padding(10, 5, 0, 0);
            this.movie_pos_genres.Size = new System.Drawing.Size(201, 25);
            this.movie_pos_genres.TabIndex = 2;
            this.movie_pos_genres.Text = "Biography, Drama, History";
            // 
            // movie_pos_language
            // 
            this.movie_pos_language.AutoSize = true;
            this.movie_pos_language.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.movie_pos_language.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(96)))), ((int)(((byte)(110)))));
            this.movie_pos_language.Location = new System.Drawing.Point(4, 536);
            this.movie_pos_language.Name = "movie_pos_language";
            this.movie_pos_language.Padding = new System.Windows.Forms.Padding(10, 5, 0, 0);
            this.movie_pos_language.Size = new System.Drawing.Size(68, 25);
            this.movie_pos_language.TabIndex = 2;
            this.movie_pos_language.Text = "English";
            // 
            // movie_pos_name
            // 
            this.movie_pos_name.AutoSize = true;
            this.movie_pos_name.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.movie_pos_name.Location = new System.Drawing.Point(3, 492);
            this.movie_pos_name.Name = "movie_pos_name";
            this.movie_pos_name.Padding = new System.Windows.Forms.Padding(10, 5, 0, 0);
            this.movie_pos_name.Size = new System.Drawing.Size(157, 35);
            this.movie_pos_name.TabIndex = 1;
            this.movie_pos_name.Text = "Oppenheimer";
            // 
            // movie_pos_pic
            // 
            this.movie_pos_pic.BorderRadius = 20;
            this.movie_pos_pic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.movie_pos_pic.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.movie_pos_pic.Image = ((System.Drawing.Image)(resources.GetObject("movie_pos_pic.Image")));
            this.movie_pos_pic.ImageRotate = 0F;
            this.movie_pos_pic.Location = new System.Drawing.Point(0, -3);
            this.movie_pos_pic.Name = "movie_pos_pic";
            this.movie_pos_pic.ShadowDecoration.BorderRadius = 20;
            this.movie_pos_pic.ShadowDecoration.Depth = 3;
            this.movie_pos_pic.Size = new System.Drawing.Size(306, 492);
            this.movie_pos_pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.movie_pos_pic.TabIndex = 0;
            this.movie_pos_pic.TabStop = false;
            this.movie_pos_pic.Click += new System.EventHandler(this.movie_pos_pic_Click);
            // 
            // movie_card
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.guna2ContainerControl1);
            this.Margin = new System.Windows.Forms.Padding(70, 50, 3, 3);
            this.Name = "movie_card";
            this.Size = new System.Drawing.Size(321, 620);
            this.guna2ContainerControl1.ResumeLayout(false);
            this.guna2ContainerControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.movie_pos_pic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ContainerControl guna2ContainerControl1;
        private Guna.UI2.WinForms.Guna2PictureBox movie_pos_pic;
        private System.Windows.Forms.Label movie_pos_name;
        private System.Windows.Forms.Label movie_pos_language;
        private System.Windows.Forms.Label movie_pos_genres;
        private Guna.UI2.WinForms.Guna2Button movie_pos_pg;
    }
}
