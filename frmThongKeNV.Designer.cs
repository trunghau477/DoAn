
namespace QLKTX
{
    partial class frmThongKeNV
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
            this.pnTopReport = new System.Windows.Forms.Panel();
            this.pnReportNV = new System.Windows.Forms.Panel();
            this.rptNhanVien = new Microsoft.Reporting.WinForms.ReportViewer();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnOutputReport = new Guna.UI2.WinForms.Guna2Button();
            this.robListNghiViec = new System.Windows.Forms.RadioButton();
            this.robListLamViec = new System.Windows.Forms.RadioButton();
            this.pnReportNV.SuspendLayout();
            this.guna2GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnTopReport
            // 
            this.pnTopReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnTopReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(73)))), ((int)(((byte)(92)))));
            this.pnTopReport.Location = new System.Drawing.Point(0, 0);
            this.pnTopReport.Name = "pnTopReport";
            this.pnTopReport.Size = new System.Drawing.Size(1164, 65);
            this.pnTopReport.TabIndex = 0;
            // 
            // pnReportNV
            // 
            this.pnReportNV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.pnReportNV.Controls.Add(this.rptNhanVien);
            this.pnReportNV.Controls.Add(this.pnTopReport);
            this.pnReportNV.Controls.Add(this.guna2GroupBox1);
            this.pnReportNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnReportNV.Location = new System.Drawing.Point(0, 0);
            this.pnReportNV.Name = "pnReportNV";
            this.pnReportNV.Size = new System.Drawing.Size(1164, 737);
            this.pnReportNV.TabIndex = 1;
            // 
            // rptNhanVien
            // 
            this.rptNhanVien.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rptNhanVien.Location = new System.Drawing.Point(0, 279);
            this.rptNhanVien.Name = "rptNhanVien";
            this.rptNhanVien.ServerReport.BearerToken = null;
            this.rptNhanVien.Size = new System.Drawing.Size(1164, 393);
            this.rptNhanVien.TabIndex = 1;
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2GroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.guna2GroupBox1.Controls.Add(this.btnOutputReport);
            this.guna2GroupBox1.Controls.Add(this.robListNghiViec);
            this.guna2GroupBox1.Controls.Add(this.robListLamViec);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.Gray;
            this.guna2GroupBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.guna2GroupBox1.Location = new System.Drawing.Point(0, 63);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.ShadowDecoration.Parent = this.guna2GroupBox1;
            this.guna2GroupBox1.Size = new System.Drawing.Size(1164, 210);
            this.guna2GroupBox1.TabIndex = 0;
            this.guna2GroupBox1.Text = "Chọn danh sách cần xuất report";
            // 
            // btnOutputReport
            // 
            this.btnOutputReport.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOutputReport.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(132)))), ((int)(((byte)(127)))));
            this.btnOutputReport.BorderRadius = 5;
            this.btnOutputReport.BorderThickness = 1;
            this.btnOutputReport.CheckedState.Parent = this.btnOutputReport;
            this.btnOutputReport.CustomImages.Parent = this.btnOutputReport;
            this.btnOutputReport.DisabledState.Parent = this.btnOutputReport;
            this.btnOutputReport.FillColor = System.Drawing.Color.Transparent;
            this.btnOutputReport.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnOutputReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(132)))), ((int)(((byte)(127)))));
            this.btnOutputReport.HoverState.FillColor = System.Drawing.SystemColors.ControlLight;
            this.btnOutputReport.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnOutputReport.HoverState.Parent = this.btnOutputReport;
            this.btnOutputReport.Location = new System.Drawing.Point(646, 90);
            this.btnOutputReport.Margin = new System.Windows.Forms.Padding(4);
            this.btnOutputReport.Name = "btnOutputReport";
            this.btnOutputReport.ShadowDecoration.Parent = this.btnOutputReport;
            this.btnOutputReport.Size = new System.Drawing.Size(255, 45);
            this.btnOutputReport.TabIndex = 30;
            this.btnOutputReport.Text = "Xuất Report";
            this.btnOutputReport.Click += new System.EventHandler(this.btnOutputReport_Click);
            // 
            // robListNghiViec
            // 
            this.robListNghiViec.AutoSize = true;
            this.robListNghiViec.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.robListNghiViec.ForeColor = System.Drawing.Color.Black;
            this.robListNghiViec.Location = new System.Drawing.Point(202, 128);
            this.robListNghiViec.Name = "robListNghiViec";
            this.robListNghiViec.Size = new System.Drawing.Size(293, 26);
            this.robListNghiViec.TabIndex = 1;
            this.robListNghiViec.Text = "Danh sách nhân viên đã nghỉ việc";
            this.robListNghiViec.UseVisualStyleBackColor = true;
            this.robListNghiViec.CheckedChanged += new System.EventHandler(this.robListNghiViec_CheckedChanged);
            // 
            // robListLamViec
            // 
            this.robListLamViec.AutoSize = true;
            this.robListLamViec.Checked = true;
            this.robListLamViec.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.robListLamViec.ForeColor = System.Drawing.Color.Black;
            this.robListLamViec.Location = new System.Drawing.Point(202, 74);
            this.robListLamViec.Name = "robListLamViec";
            this.robListLamViec.Size = new System.Drawing.Size(307, 26);
            this.robListLamViec.TabIndex = 2;
            this.robListLamViec.TabStop = true;
            this.robListLamViec.Text = "Danh sách nhân viên đang làm việc";
            this.robListLamViec.UseVisualStyleBackColor = true;
            this.robListLamViec.CheckedChanged += new System.EventHandler(this.robListLamViec_CheckedChanged);
            // 
            // frmThongKeNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 737);
            this.Controls.Add(this.pnReportNV);
            this.Name = "frmThongKeNV";
            this.Text = "Thống Kê Nhân Viên";
            this.Load += new System.EventHandler(this.frmThongKeNV_Load);
            this.pnReportNV.ResumeLayout(false);
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnTopReport;
        private System.Windows.Forms.Panel pnReportNV;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Microsoft.Reporting.WinForms.ReportViewer rptNhanVien;
        private System.Windows.Forms.RadioButton robListNghiViec;
        private System.Windows.Forms.RadioButton robListLamViec;
        private Guna.UI2.WinForms.Guna2Button btnOutputReport;
    }
}