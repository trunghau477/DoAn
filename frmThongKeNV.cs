using Microsoft.Reporting.WinForms;
using QLKTX.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKTX
{
    public partial class frmThongKeNV : Form
    {
        private readonly KTXDBContext context;
        public frmThongKeNV()
        {
            context = new KTXDBContext();
            InitializeComponent();
        }

        private void frmThongKeNV_Load(object sender, EventArgs e)
        {
            robListLamViec.Checked = true;
            rptNhanVien.Visible = false;
        }

        private void btnOutputReport_Click(object sender, EventArgs e)
        {
            if (robListLamViec.Checked == true) //TH báo giá
            {
                List<NHANVIEN> listNhanVien = context.NHANVIEN.ToList();
                this.rptNhanVien.LocalReport.ReportPath = @"../../rptNhanVienDangLam.rdlc";
                var reportDataSource = new ReportDataSource("NhanVienDataSet", listNhanVien);
                this.rptNhanVien.LocalReport.DataSources.Clear();
                this.rptNhanVien.LocalReport.DataSources.Add(reportDataSource);
                rptNhanVien.Visible = true;
            }
            else 
            {
                List<NHANVIEN> listNhanVien = context.NHANVIEN.ToList();
                this.rptNhanVien.LocalReport.ReportPath = @"../../rptNhanVienNghiViec.rdlc";
                var reportDataSource = new ReportDataSource("NVNghiViecDataSet", listNhanVien);
                this.rptNhanVien.LocalReport.DataSources.Clear();
                this.rptNhanVien.LocalReport.DataSources.Add(reportDataSource);
                rptNhanVien.Visible = true;
            }
            this.rptNhanVien.RefreshReport();
        }

        private void robListLamViec_CheckedChanged(object sender, EventArgs e)
        {
            rptNhanVien.Visible = false;
        }

        private void robListNghiViec_CheckedChanged(object sender, EventArgs e)
        {
            rptNhanVien.Visible = false;
        }
    }
}
