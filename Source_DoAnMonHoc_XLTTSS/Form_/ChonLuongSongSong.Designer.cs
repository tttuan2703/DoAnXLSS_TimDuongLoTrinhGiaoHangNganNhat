namespace Form_
{
    partial class ChonLuongSongSong
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
            this.btnXemDL = new System.Windows.Forms.Button();
            this.btnTimDuong = new System.Windows.Forms.Button();
            this.lstV_SS = new System.Windows.Forms.ListView();
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.lbThoiGian = new System.Windows.Forms.Label();
            this.lbTongKC = new System.Windows.Forms.Label();
            this.lbTongSL = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnXemDL
            // 
            this.btnXemDL.Location = new System.Drawing.Point(2208, 166);
            this.btnXemDL.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnXemDL.Name = "btnXemDL";
            this.btnXemDL.Size = new System.Drawing.Size(250, 56);
            this.btnXemDL.TabIndex = 33;
            this.btnXemDL.Text = "XEM DỮ LIỆU";
            this.btnXemDL.UseVisualStyleBackColor = true;
            // 
            // btnTimDuong
            // 
            this.btnTimDuong.Location = new System.Drawing.Point(547, 68);
            this.btnTimDuong.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnTimDuong.Name = "btnTimDuong";
            this.btnTimDuong.Size = new System.Drawing.Size(184, 60);
            this.btnTimDuong.TabIndex = 34;
            this.btnTimDuong.Text = "TÌM ĐƯỜNG";
            this.btnTimDuong.UseVisualStyleBackColor = true;
            this.btnTimDuong.Click += new System.EventHandler(this.btnTimDuong_Click);
            // 
            // lstV_SS
            // 
            this.lstV_SS.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12});
            this.lstV_SS.FullRowSelect = true;
            this.lstV_SS.GridLines = true;
            this.lstV_SS.HideSelection = false;
            this.lstV_SS.Location = new System.Drawing.Point(33, 205);
            this.lstV_SS.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lstV_SS.Name = "lstV_SS";
            this.lstV_SS.Size = new System.Drawing.Size(758, 394);
            this.lstV_SS.TabIndex = 35;
            this.lstV_SS.UseCompatibleStateImageBehavior = false;
            this.lstV_SS.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "DiemDi";
            this.columnHeader10.Width = 200;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "DiemDen";
            this.columnHeader11.Width = 200;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "KhoangCachGiuaHaiDiem(Met)";
            this.columnHeader12.Width = 318;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 89);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 29);
            this.label1.TabIndex = 36;
            this.label1.Text = "Nhập số luồng";
            // 
            // lbThoiGian
            // 
            this.lbThoiGian.AutoSize = true;
            this.lbThoiGian.Location = new System.Drawing.Point(462, 177);
            this.lbThoiGian.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbThoiGian.Name = "lbThoiGian";
            this.lbThoiGian.Size = new System.Drawing.Size(66, 29);
            this.lbThoiGian.TabIndex = 37;
            this.lbThoiGian.Text = "label";
            this.lbThoiGian.Visible = false;
            // 
            // lbTongKC
            // 
            this.lbTongKC.AutoSize = true;
            this.lbTongKC.Location = new System.Drawing.Point(462, 616);
            this.lbTongKC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTongKC.Name = "lbTongKC";
            this.lbTongKC.Size = new System.Drawing.Size(66, 29);
            this.lbTongKC.TabIndex = 39;
            this.lbTongKC.Text = "label";
            this.lbTongKC.Visible = false;
            // 
            // lbTongSL
            // 
            this.lbTongSL.AutoSize = true;
            this.lbTongSL.Location = new System.Drawing.Point(43, 21);
            this.lbTongSL.Name = "lbTongSL";
            this.lbTongSL.Size = new System.Drawing.Size(467, 29);
            this.lbTongSL.TabIndex = 40;
            this.lbTongSL.Text = "Tổng số lượng đối tác với Đại lý Giao Hàng";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(228, 86);
            this.txtSoLuong.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(300, 35);
            this.txtSoLuong.TabIndex = 32;
            // 
            // FormCoDong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 652);
            this.Controls.Add(this.lbTongSL);
            this.Controls.Add(this.lbTongKC);
            this.Controls.Add(this.lbThoiGian);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstV_SS);
            this.Controls.Add(this.btnXemDL);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.btnTimDuong);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormCoDong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormCoDong";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnXemDL;
        private System.Windows.Forms.Button btnTimDuong;
        private System.Windows.Forms.ListView lstV_SS;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbThoiGian;
        private System.Windows.Forms.Label lbTongKC;
        private System.Windows.Forms.Label lbTongSL;
        private System.Windows.Forms.TextBox txtSoLuong;
    }
}