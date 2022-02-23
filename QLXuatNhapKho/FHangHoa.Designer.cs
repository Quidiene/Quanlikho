namespace QLXuatNhapKho
{
    partial class FHangHoa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FHangHoa));
            this.dhh = new System.Windows.Forms.DataGridView();
            this.dhsd = new System.Windows.Forms.DateTimePicker();
            this.dngaysx = new System.Windows.Forms.DateTimePicker();
            this.txttimkiem = new System.Windows.Forms.TextBox();
            this.btntimkiem = new System.Windows.Forms.Button();
            this.cbloai = new System.Windows.Forms.ComboBox();
            this.btnhuy = new System.Windows.Forms.Button();
            this.btntrove = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btnluu = new System.Windows.Forms.Button();
            this.btnsua = new System.Windows.Forms.Button();
            this.han = new System.Windows.Forms.Label();
            this.nsxxx = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtdvt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txttsl = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtgianhap = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMH = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txttenhh = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbncc = new System.Windows.Forms.ComboBox();
            this.txttnv = new System.Windows.Forms.Label();
            this.txtthanhtien = new System.Windows.Forms.TextBox();
            this.la = new System.Windows.Forms.Label();
            this.tnvv = new System.Windows.Forms.TextBox();
            this.btall = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtgiamgia = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dhh)).BeginInit();
            this.SuspendLayout();
            // 
            // dhh
            // 
            this.dhh.AllowUserToAddRows = false;
            this.dhh.AllowUserToDeleteRows = false;
            this.dhh.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dhh.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dhh.BackgroundColor = System.Drawing.Color.DimGray;
            this.dhh.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dhh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dhh.Location = new System.Drawing.Point(12, 434);
            this.dhh.Name = "dhh";
            this.dhh.ReadOnly = true;
            this.dhh.RowHeadersWidth = 51;
            this.dhh.RowTemplate.Height = 24;
            this.dhh.Size = new System.Drawing.Size(635, 219);
            this.dhh.TabIndex = 0;
            this.dhh.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dhh_CellClick);
            this.dhh.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dhh_CellContentClick);
            // 
            // dhsd
            // 
            this.dhsd.Location = new System.Drawing.Point(480, 225);
            this.dhsd.Name = "dhsd";
            this.dhsd.Size = new System.Drawing.Size(167, 22);
            this.dhsd.TabIndex = 98;
            // 
            // dngaysx
            // 
            this.dngaysx.Location = new System.Drawing.Point(480, 183);
            this.dngaysx.Name = "dngaysx";
            this.dngaysx.Size = new System.Drawing.Size(167, 22);
            this.dngaysx.TabIndex = 97;
            this.dngaysx.Value = new System.DateTime(2020, 10, 20, 0, 0, 0, 0);
            // 
            // txttimkiem
            // 
            this.txttimkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttimkiem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txttimkiem.Location = new System.Drawing.Point(111, 400);
            this.txttimkiem.Name = "txttimkiem";
            this.txttimkiem.Size = new System.Drawing.Size(303, 24);
            this.txttimkiem.TabIndex = 96;
            this.txttimkiem.Text = "Tên hàng hóa";
            this.txttimkiem.Enter += new System.EventHandler(this.txttimkiem_Enter);
            this.txttimkiem.Leave += new System.EventHandler(this.txttimkiem_Leave);
            // 
            // btntimkiem
            // 
            this.btntimkiem.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btntimkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntimkiem.Image = ((System.Drawing.Image)(resources.GetObject("btntimkiem.Image")));
            this.btntimkiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btntimkiem.Location = new System.Drawing.Point(12, 395);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.Size = new System.Drawing.Size(93, 33);
            this.btntimkiem.TabIndex = 95;
            this.btntimkiem.Text = "Tìm  ";
            this.btntimkiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btntimkiem.UseVisualStyleBackColor = false;
            this.btntimkiem.Click += new System.EventHandler(this.btntimkiem_Click);
            // 
            // cbloai
            // 
            this.cbloai.AllowDrop = true;
            this.cbloai.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbloai.FormattingEnabled = true;
            this.cbloai.Location = new System.Drawing.Point(143, 93);
            this.cbloai.Name = "cbloai";
            this.cbloai.Size = new System.Drawing.Size(167, 24);
            this.cbloai.TabIndex = 94;
            this.cbloai.SelectedIndexChanged += new System.EventHandler(this.cbloai_SelectedIndexChanged);
            // 
            // btnhuy
            // 
            this.btnhuy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnhuy.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnhuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnhuy.Image = ((System.Drawing.Image)(resources.GetObject("btnhuy.Image")));
            this.btnhuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnhuy.Location = new System.Drawing.Point(321, 360);
            this.btnhuy.Name = "btnhuy";
            this.btnhuy.Size = new System.Drawing.Size(93, 33);
            this.btnhuy.TabIndex = 93;
            this.btnhuy.Text = "  Hủy  ";
            this.btnhuy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnhuy.UseVisualStyleBackColor = false;
            this.btnhuy.Click += new System.EventHandler(this.btnhuy_Click);
            // 
            // btntrove
            // 
            this.btntrove.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btntrove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntrove.Image = ((System.Drawing.Image)(resources.GetObject("btntrove.Image")));
            this.btntrove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btntrove.Location = new System.Drawing.Point(416, 360);
            this.btntrove.Name = "btntrove";
            this.btntrove.Size = new System.Drawing.Size(103, 34);
            this.btntrove.TabIndex = 92;
            this.btntrove.Text = "Trở về";
            this.btntrove.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btntrove.UseVisualStyleBackColor = false;
            this.btntrove.Click += new System.EventHandler(this.btntrove_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnxoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnxoa.Image = ((System.Drawing.Image)(resources.GetObject("btnxoa.Image")));
            this.btnxoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnxoa.Location = new System.Drawing.Point(111, 360);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(93, 33);
            this.btnxoa.TabIndex = 91;
            this.btnxoa.Text = "Xóa ";
            this.btnxoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnxoa.UseVisualStyleBackColor = false;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btnluu
            // 
            this.btnluu.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnluu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnluu.ForeColor = System.Drawing.Color.Black;
            this.btnluu.Image = ((System.Drawing.Image)(resources.GetObject("btnluu.Image")));
            this.btnluu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnluu.Location = new System.Drawing.Point(216, 360);
            this.btnluu.Name = "btnluu";
            this.btnluu.Size = new System.Drawing.Size(93, 33);
            this.btnluu.TabIndex = 90;
            this.btnluu.Text = "Lưu   ";
            this.btnluu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnluu.UseVisualStyleBackColor = false;
            this.btnluu.Click += new System.EventHandler(this.btnluu_Click);
            // 
            // btnsua
            // 
            this.btnsua.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnsua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsua.Image = ((System.Drawing.Image)(resources.GetObject("btnsua.Image")));
            this.btnsua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsua.Location = new System.Drawing.Point(12, 360);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(93, 33);
            this.btnsua.TabIndex = 89;
            this.btnsua.Text = "Sửa ";
            this.btnsua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnsua.UseVisualStyleBackColor = false;
            this.btnsua.Click += new System.EventHandler(this.button2_Click);
            // 
            // han
            // 
            this.han.AutoSize = true;
            this.han.BackColor = System.Drawing.Color.White;
            this.han.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.han.Location = new System.Drawing.Point(348, 223);
            this.han.Name = "han";
            this.han.Size = new System.Drawing.Size(102, 18);
            this.han.TabIndex = 86;
            this.han.Text = "Hạn sử dụng";
            // 
            // nsxxx
            // 
            this.nsxxx.AutoSize = true;
            this.nsxxx.BackColor = System.Drawing.Color.White;
            this.nsxxx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nsxxx.Location = new System.Drawing.Point(348, 184);
            this.nsxxx.Name = "nsxxx";
            this.nsxxx.Size = new System.Drawing.Size(114, 18);
            this.nsxxx.TabIndex = 85;
            this.nsxxx.Text = "Ngày sản xuất";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(348, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 18);
            this.label8.TabIndex = 82;
            this.label8.Text = "Nhà cung cấp";
            // 
            // txtdvt
            // 
            this.txtdvt.Location = new System.Drawing.Point(480, 93);
            this.txtdvt.Name = "txtdvt";
            this.txtdvt.Size = new System.Drawing.Size(167, 22);
            this.txtdvt.TabIndex = 81;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(348, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 18);
            this.label7.TabIndex = 80;
            this.label7.Text = "Đơn vị tính";
            // 
            // txttsl
            // 
            this.txttsl.Location = new System.Drawing.Point(143, 306);
            this.txttsl.Name = "txttsl";
            this.txttsl.Size = new System.Drawing.Size(167, 22);
            this.txttsl.TabIndex = 79;
            this.txttsl.TextChanged += new System.EventHandler(this.txttsl_TextChanged);
            this.txttsl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttsl_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 309);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 18);
            this.label6.TabIndex = 78;
            this.label6.Text = "Tổng số lượng";
            // 
            // txtgianhap
            // 
            this.txtgianhap.Location = new System.Drawing.Point(480, 266);
            this.txtgianhap.Name = "txtgianhap";
            this.txtgianhap.Size = new System.Drawing.Size(167, 22);
            this.txtgianhap.TabIndex = 75;
            this.txtgianhap.TextChanged += new System.EventHandler(this.txtgianhap_TextChanged);
            this.txtgianhap.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtgianhap_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(348, 268);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 18);
            this.label4.TabIndex = 74;
            this.label4.Text = "Giá nhập hàng";
            // 
            // txtMH
            // 
            this.txtMH.Location = new System.Drawing.Point(143, 138);
            this.txtMH.Name = "txtMH";
            this.txtMH.Size = new System.Drawing.Size(167, 22);
            this.txtMH.TabIndex = 73;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 18);
            this.label3.TabIndex = 72;
            this.label3.Text = "Mã Hàng Hóa";
            // 
            // txttenhh
            // 
            this.txttenhh.Location = new System.Drawing.Point(143, 179);
            this.txttenhh.Name = "txttenhh";
            this.txttenhh.Size = new System.Drawing.Size(167, 22);
            this.txttenhh.TabIndex = 71;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 18);
            this.label2.TabIndex = 70;
            this.label2.Text = "Tên hàng hóa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 18);
            this.label1.TabIndex = 68;
            this.label1.Text = "Loại hàng";
            // 
            // cbncc
            // 
            this.cbncc.AllowDrop = true;
            this.cbncc.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbncc.FormattingEnabled = true;
            this.cbncc.Location = new System.Drawing.Point(480, 134);
            this.cbncc.Name = "cbncc";
            this.cbncc.Size = new System.Drawing.Size(167, 24);
            this.cbncc.TabIndex = 100;
            this.cbncc.SelectedIndexChanged += new System.EventHandler(this.cbncc_SelectedIndexChanged);
            // 
            // txttnv
            // 
            this.txttnv.AutoSize = true;
            this.txttnv.BackColor = System.Drawing.Color.White;
            this.txttnv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttnv.Location = new System.Drawing.Point(348, 307);
            this.txttnv.Name = "txttnv";
            this.txttnv.Size = new System.Drawing.Size(91, 18);
            this.txttnv.TabIndex = 87;
            this.txttnv.Text = "Thành Tiền";
            // 
            // txtthanhtien
            // 
            this.txtthanhtien.Location = new System.Drawing.Point(480, 308);
            this.txtthanhtien.Name = "txtthanhtien";
            this.txtthanhtien.Size = new System.Drawing.Size(167, 22);
            this.txtthanhtien.TabIndex = 101;
            // 
            // la
            // 
            this.la.AutoSize = true;
            this.la.BackColor = System.Drawing.Color.White;
            this.la.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.la.Location = new System.Drawing.Point(9, 222);
            this.la.Name = "la";
            this.la.Size = new System.Drawing.Size(89, 18);
            this.la.TabIndex = 102;
            this.la.Text = "Nhân Viên ";
            // 
            // tnvv
            // 
            this.tnvv.Location = new System.Drawing.Point(143, 218);
            this.tnvv.Name = "tnvv";
            this.tnvv.Size = new System.Drawing.Size(167, 22);
            this.tnvv.TabIndex = 106;
            // 
            // btall
            // 
            this.btall.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btall.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btall.Image = ((System.Drawing.Image)(resources.GetObject("btall.Image")));
            this.btall.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btall.Location = new System.Drawing.Point(416, 392);
            this.btall.Name = "btall";
            this.btall.Size = new System.Drawing.Size(103, 33);
            this.btall.TabIndex = 107;
            this.btall.Text = "Báo Cáo";
            this.btall.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btall.UseVisualStyleBackColor = false;
            this.btall.Click += new System.EventHandler(this.btall_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(180, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(295, 32);
            this.label5.TabIndex = 108;
            this.label5.Text = "Thông Tin Hàng Hóa";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(7, 267);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 18);
            this.label9.TabIndex = 110;
            this.label9.Text = "Giám giá";
            // 
            // txtgiamgia
            // 
            this.txtgiamgia.Location = new System.Drawing.Point(143, 266);
            this.txtgiamgia.Name = "txtgiamgia";
            this.txtgiamgia.Size = new System.Drawing.Size(167, 22);
            this.txtgiamgia.TabIndex = 111;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.White;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(650, 268);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(42, 18);
            this.label17.TabIndex = 150;
            this.label17.Text = "VNĐ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(650, 311);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 18);
            this.label10.TabIndex = 151;
            this.label10.Text = "VNĐ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.White;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(312, 268);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(25, 20);
            this.label15.TabIndex = 152;
            this.label15.Text = "%";
            // 
            // FHangHoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(704, 665);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtgiamgia);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btall);
            this.Controls.Add(this.tnvv);
            this.Controls.Add(this.la);
            this.Controls.Add(this.txtthanhtien);
            this.Controls.Add(this.cbncc);
            this.Controls.Add(this.dhsd);
            this.Controls.Add(this.dngaysx);
            this.Controls.Add(this.txttimkiem);
            this.Controls.Add(this.btntimkiem);
            this.Controls.Add(this.cbloai);
            this.Controls.Add(this.btnhuy);
            this.Controls.Add(this.btntrove);
            this.Controls.Add(this.btnxoa);
            this.Controls.Add(this.btnluu);
            this.Controls.Add(this.btnsua);
            this.Controls.Add(this.txttnv);
            this.Controls.Add(this.han);
            this.Controls.Add(this.nsxxx);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtdvt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txttsl);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtgianhap);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMH);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txttenhh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dhh);
            this.Name = "FHangHoa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FHangHoa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dhh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dhh;
        private System.Windows.Forms.DateTimePicker dhsd;
        private System.Windows.Forms.DateTimePicker dngaysx;
        private System.Windows.Forms.TextBox txttimkiem;
        private System.Windows.Forms.Button btntimkiem;
        private System.Windows.Forms.ComboBox cbloai;
        private System.Windows.Forms.Button btnhuy;
        private System.Windows.Forms.Button btntrove;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btnluu;
        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Label han;
        private System.Windows.Forms.Label nsxxx;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtdvt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txttsl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtgianhap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txttenhh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbncc;
        private System.Windows.Forms.Label txttnv;
        private System.Windows.Forms.TextBox txtthanhtien;
        private System.Windows.Forms.Label la;
        private System.Windows.Forms.TextBox tnvv;
        private System.Windows.Forms.Button btall;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtgiamgia;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label15;
    }
}