﻿namespace CinemaManagement.PL
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mniCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.mniCinema = new System.Windows.Forms.ToolStripMenuItem();
            this.mniRoom = new System.Windows.Forms.ToolStripMenuItem();
            this.mniHour = new System.Windows.Forms.ToolStripMenuItem();
            this.mniType = new System.Windows.Forms.ToolStripMenuItem();
            this.mniCountry = new System.Windows.Forms.ToolStripMenuItem();
            this.mniCompany = new System.Windows.Forms.ToolStripMenuItem();
            this.mniFilm = new System.Windows.Forms.ToolStripMenuItem();
            this.mniShowingFilm = new System.Windows.Forms.ToolStripMenuItem();
            this.mniAllFilm = new System.Windows.Forms.ToolStripMenuItem();
            this.mniShowTime = new System.Windows.Forms.ToolStripMenuItem();
            this.mniAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.mniSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinTàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đổiMậtKhẩuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mniLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.mniExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mniAboutSoft = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Fuchsia;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniCategory,
            this.mniFilm,
            this.mniShowTime,
            this.mniAdmin,
            this.mniSystem,
            this.mniLogout,
            this.mniExit,
            this.mniAboutSoft});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(785, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mniCategory
            // 
            this.mniCategory.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniCinema,
            this.mniRoom,
            this.mniHour,
            this.mniType,
            this.mniCountry,
            this.mniCompany});
            this.mniCategory.Name = "mniCategory";
            this.mniCategory.Size = new System.Drawing.Size(74, 20);
            this.mniCategory.Text = "&Danh mục";
            // 
            // mniCinema
            // 
            this.mniCinema.Name = "mniCinema";
            this.mniCinema.Size = new System.Drawing.Size(152, 22);
            this.mniCinema.Text = "&Rạp";
            this.mniCinema.Click += new System.EventHandler(this.mniCinema_Click);
            // 
            // mniRoom
            // 
            this.mniRoom.Name = "mniRoom";
            this.mniRoom.Size = new System.Drawing.Size(152, 22);
            this.mniRoom.Text = "&Phòng chiếu";
            this.mniRoom.Click += new System.EventHandler(this.mniRoom_Click);
            // 
            // mniHour
            // 
            this.mniHour.Name = "mniHour";
            this.mniHour.Size = new System.Drawing.Size(152, 22);
            this.mniHour.Text = "&Giờ chiếu";
            this.mniHour.Click += new System.EventHandler(this.mniHour_Click);
            // 
            // mniType
            // 
            this.mniType.Name = "mniType";
            this.mniType.Size = new System.Drawing.Size(152, 22);
            this.mniType.Text = "&Thể loại";
            this.mniType.Click += new System.EventHandler(this.mniType_Click);
            // 
            // mniCountry
            // 
            this.mniCountry.Name = "mniCountry";
            this.mniCountry.Size = new System.Drawing.Size(152, 22);
            this.mniCountry.Text = "&Nước sản xuất";
            this.mniCountry.Click += new System.EventHandler(this.mniCountry_Click);
            // 
            // mniCompany
            // 
            this.mniCompany.Name = "mniCompany";
            this.mniCompany.Size = new System.Drawing.Size(152, 22);
            this.mniCompany.Text = "&Hãng sản xuất";
            this.mniCompany.Click += new System.EventHandler(this.mniCompany_Click);
            // 
            // mniFilm
            // 
            this.mniFilm.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniShowingFilm,
            this.mniAllFilm});
            this.mniFilm.Name = "mniFilm";
            this.mniFilm.Size = new System.Drawing.Size(47, 20);
            this.mniFilm.Text = "&Phim";
            // 
            // mniShowingFilm
            // 
            this.mniShowingFilm.Name = "mniShowingFilm";
            this.mniShowingFilm.Size = new System.Drawing.Size(164, 22);
            this.mniShowingFilm.Text = "Phim &đang chiếu";
            this.mniShowingFilm.Click += new System.EventHandler(this.mniShowingFilm_Click);
            // 
            // mniAllFilm
            // 
            this.mniAllFilm.Name = "mniAllFilm";
            this.mniAllFilm.Size = new System.Drawing.Size(164, 22);
            this.mniAllFilm.Text = "&Tất cả phim";
            this.mniAllFilm.Click += new System.EventHandler(this.mniAllFilm_Click);
            // 
            // mniShowTime
            // 
            this.mniShowTime.Name = "mniShowTime";
            this.mniShowTime.Size = new System.Drawing.Size(73, 20);
            this.mniShowTime.Text = "&Lịch chiếu";
            this.mniShowTime.Click += new System.EventHandler(this.mniShowTime_Click);
            // 
            // mniAdmin
            // 
            this.mniAdmin.Enabled = false;
            this.mniAdmin.Name = "mniAdmin";
            this.mniAdmin.Size = new System.Drawing.Size(55, 20);
            this.mniAdmin.Text = "&Admin";
            // 
            // mniSystem
            // 
            this.mniSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinTàiKhoảnToolStripMenuItem,
            this.đổiMậtKhẩuToolStripMenuItem});
            this.mniSystem.Name = "mniSystem";
            this.mniSystem.Size = new System.Drawing.Size(69, 20);
            this.mniSystem.Text = "&Hệ thống";
            // 
            // thôngTinTàiKhoảnToolStripMenuItem
            // 
            this.thôngTinTàiKhoảnToolStripMenuItem.Name = "thôngTinTàiKhoảnToolStripMenuItem";
            this.thôngTinTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.thôngTinTàiKhoảnToolStripMenuItem.Text = "&Thông tin tài khoản";
            this.thôngTinTàiKhoảnToolStripMenuItem.Click += new System.EventHandler(this.thôngTinTàiKhoảnToolStripMenuItem_Click);
            // 
            // đổiMậtKhẩuToolStripMenuItem
            // 
            this.đổiMậtKhẩuToolStripMenuItem.Name = "đổiMậtKhẩuToolStripMenuItem";
            this.đổiMậtKhẩuToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.đổiMậtKhẩuToolStripMenuItem.Text = "&Đổi thông tin";
            this.đổiMậtKhẩuToolStripMenuItem.Click += new System.EventHandler(this.đổiMậtKhẩuToolStripMenuItem_Click);
            // 
            // mniLogout
            // 
            this.mniLogout.Name = "mniLogout";
            this.mniLogout.Size = new System.Drawing.Size(72, 20);
            this.mniLogout.Text = "&Đăng xuất";
            this.mniLogout.Click += new System.EventHandler(this.mniLogout_Click);
            // 
            // mniExit
            // 
            this.mniExit.Name = "mniExit";
            this.mniExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.mniExit.Size = new System.Drawing.Size(50, 20);
            this.mniExit.Text = "&Thoát";
            this.mniExit.Click += new System.EventHandler(this.mniExit_Click);
            // 
            // mniAboutSoft
            // 
            this.mniAboutSoft.Name = "mniAboutSoft";
            this.mniAboutSoft.Size = new System.Drawing.Size(132, 20);
            this.mniAboutSoft.Text = "Thông t&in phần mềm";
            this.mniAboutSoft.Click += new System.EventHandler(this.mniAboutSoft_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(785, 359);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý rạp chiếu phim";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mniCategory;
        private System.Windows.Forms.ToolStripMenuItem mniFilm;
        private System.Windows.Forms.ToolStripMenuItem mniAdmin;
        private System.Windows.Forms.ToolStripMenuItem mniLogout;
        private System.Windows.Forms.ToolStripMenuItem mniExit;
        private System.Windows.Forms.ToolStripMenuItem mniAboutSoft;
        private System.Windows.Forms.ToolStripMenuItem mniCinema;
        private System.Windows.Forms.ToolStripMenuItem mniRoom;
        private System.Windows.Forms.ToolStripMenuItem mniHour;
        private System.Windows.Forms.ToolStripMenuItem mniType;
        private System.Windows.Forms.ToolStripMenuItem mniCountry;
        private System.Windows.Forms.ToolStripMenuItem mniCompany;
        private System.Windows.Forms.ToolStripMenuItem mniShowTime;
        private System.Windows.Forms.ToolStripMenuItem mniSystem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinTàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đổiMậtKhẩuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mniShowingFilm;
        private System.Windows.Forms.ToolStripMenuItem mniAllFilm;
    }
}