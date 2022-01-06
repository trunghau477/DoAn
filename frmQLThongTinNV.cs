using FontAwesome.Sharp;
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
    public partial class frmQLThongTinNV : Form
    {
        KTXDBContext context = new KTXDBContext();
        public frmQLThongTinNV()
        {
            InitializeComponent();
        }
        private void BindGrid(List<NHANVIEN> listNhanVien)
        {
          
            dgvNhanVien.Rows.Clear();
            int i = 1;
            foreach (var item in listNhanVien)
            {
                if (item.TRANGTHAI == "Đang Làm Việc")
                {
                    int index = dgvNhanVien.Rows.Add();
                    dgvNhanVien.Rows[index].Cells[0].Value = i;
                    dgvNhanVien.Rows[index].Cells[1].Value = item.MANV;
                    dgvNhanVien.Rows[index].Cells[2].Value = item.HOTENNV;
                    dgvNhanVien.Rows[index].Cells[3].Value = item.NGAYSINH;
                    dgvNhanVien.Rows[index].Cells[4].Value = item.GIOITINH;
                    dgvNhanVien.Rows[index].Cells[5].Value = item.SDT;
                    dgvNhanVien.Rows[index].Cells[6].Value = item.DIACHI;
                    dgvNhanVien.Rows[index].Cells[7].Value = item.CHUCVU;
                    dgvNhanVien.Rows[index].Cells[8].Value = item.LUONG;
                    dgvNhanVien.Rows[index].Cells[9].Value = item.TRANGTHAI;
                    i++;
                    //Sum();
                }
            }
        }
        private void reloadDGV()
        {
            List<NHANVIEN> listNV = context.NHANVIEN.ToList();
            BindGrid(listNV);
        }

        private void setNull()
        {
            txtMaNV.Text = "";
            txtHoTenNV.Text = "";
            txtPhoneNV.Text = "";
            txtAddressNV.Text = "";
            txtChucVu.Text = "";
            robMale.Checked = true;
            dtpBirthday.Value = DateTime.Now;
            txtLuong.Text = "";
            cmbStatus.SelectedIndex = 0;
            cmbViewListNV.SelectedIndex = 0;
        }
        private int GetSelectedRow(string MaNV)
        {
            for (int i = 0; i < dgvNhanVien.Rows.Count; i++)
            {
                if (dgvNhanVien.Rows[i].Cells[0].Value != null) // check null dgv
                {
                    if (dgvNhanVien.Rows[i].Cells[0].Value.ToString() == MaNV)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
        private void frmQLThongTinNV_Load(object sender, EventArgs e)
        {
            try
            {
                
                List<NHANVIEN> listNV = context.NHANVIEN.ToList();
                BindGrid(listNV);   
                robMale.Checked = true;
                cmbStatus.SelectedIndex = 0;
                cmbViewListNV.SelectedIndex = 0;
                pnAddStudent.Visible = false;
                //reloadDGV(listNV);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddNV_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtHoTenNV.Text) || string.IsNullOrEmpty(txtMaNV.Text) || string.IsNullOrEmpty(txtPhoneNV.Text) || string.IsNullOrEmpty(txtAddressNV.Text) || string.IsNullOrEmpty(txtChucVu.Text))
                {
                    MessageBox.Show("Vui lòng điền đủ thông tin", "Thông Báo");
                }
                else
                {
                    string ngay = String.Format("{0:yyyy-MM-dd}", dtpBirthday.Value);
                    string gioitinh;
                    if (robMale.Checked == true)
                    {
                        gioitinh = "Nam";
                    }
                    else
                    {
                        gioitinh = "Nữ";
                    }

                    if (GetSelectedRow(txtMaNV.Text) == -1)
                    {
                        string thongbao = "\nTạo Mới Tài Khoản Thành Công!\nTài khoản: " + txtMaNV.Text + "\nMật khẩu: " + txtPhoneNV.Text;
                        NHANVIEN manv = context.NHANVIEN.FirstOrDefault(p => p.MANV == txtMaNV.Text);
                        ACCOUNT user = context.ACCOUNT.FirstOrDefault(p => p.USER == txtMaNV.Text);
                        if (manv == null)
                        {
                            NHANVIEN nv = new NHANVIEN()
                            {
                                HOTENNV = txtHoTenNV.Text,
                                MANV = txtMaNV.Text,
                                NGAYSINH = dtpBirthday.Value,
                                GIOITINH = gioitinh,
                                SDT = txtPhoneNV.Text,
                                DIACHI = txtAddressNV.Text,
                                CHUCVU = txtChucVu.Text,
                                LUONG = float.Parse(txtLuong.Text),
                                TRANGTHAI = cmbStatus.SelectedItem.ToString()
                            };
                            ACCOUNT a = new ACCOUNT()
                            {
                                USER = txtMaNV.Text,
                                PASS = txtPhoneNV.Text,
                                QUYEN = "MANAGE",
                                MANV = txtMaNV.Text
                            };
                            context.NHANVIEN.Add(nv);
                            context.ACCOUNT.Add(a);
                            context.SaveChanges();
                            reloadDGV();
                            setNull();
                            MessageBox.Show("Thêm mới dữ liệu thành công!" + thongbao, "Thông báo", MessageBoxButtons.OK);
                            //Sum();
                        }
                        else
                        {
                            MessageBox.Show("Mã Nhân Viên Đã Tồn Tại", "Thông Báo", MessageBoxButtons.OK);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateNV_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtHoTenNV.Text) || string.IsNullOrEmpty(txtMaNV.Text) || string.IsNullOrEmpty(txtPhoneNV.Text) || string.IsNullOrEmpty(txtAddressNV.Text) || string.IsNullOrEmpty(txtChucVu.Text) || string.IsNullOrEmpty(txtLuong.Text))
            {
                MessageBox.Show("Vui lòng điền đủ thông tin", "Thông Báo");
            }
            else
            {
                string ngay = String.Format("{0:yyyy-MM-dd}", dtpBirthday.Value);
                string gioitinh;
                if (robMale.Checked == true)
                {
                    gioitinh = "Nam";
                }
                else
                {
                    gioitinh = "Nữ";
                }
                NHANVIEN dbUpdate = context.NHANVIEN.FirstOrDefault(p => p.MANV == txtMaNV.Text);
                ACCOUNT accUpdate = context.ACCOUNT.FirstOrDefault(p => p.MANV == txtMaNV.Text);
                if (dbUpdate != null)
                {
                        dbUpdate.HOTENNV = txtHoTenNV.Text;
                        dbUpdate.MANV = txtMaNV.Text;
                        dbUpdate.NGAYSINH = dtpBirthday.Value;
                        dbUpdate.GIOITINH = gioitinh;
                        dbUpdate.SDT = txtPhoneNV.Text;
                        dbUpdate.DIACHI = txtAddressNV.Text;
                        dbUpdate.CHUCVU = txtChucVu.Text;
                        dbUpdate.LUONG = float.Parse(txtLuong.Text);
                        dbUpdate.TRANGTHAI = cmbStatus.Text;
                        //accUpdate.USER = txtMaNV.Text;
                        //accUpdate.PASS = txtPhoneNV.Text;
                        context.SaveChanges();
                        reloadDGV();
                        setNull();
                        MessageBox.Show("Cập Nhập dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
                    //Sum();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy tài khoản cần sửa ", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private void btnDeleteNV_Click(object sender, EventArgs e)
        {
            ACCOUNT tt = context.ACCOUNT.FirstOrDefault(p => p.USER == txtMaNV.Text);
            NHANVIEN dbDelete = context.NHANVIEN.FirstOrDefault(p => p.MANV == txtMaNV.Text);
            if (dbDelete != null)
            {
                DialogResult noti = MessageBox.Show("Bạn có muốn xóa?", "Thông Báo", MessageBoxButtons.YesNo);
                if (noti == DialogResult.Yes)
                {
                    context.ACCOUNT.Remove(tt);
                    dbDelete.TRANGTHAI = "Đã nghỉ việc";
                    context.SaveChanges();
                    reloadDGV();
                    setNull();
                    MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
                    //Sum();
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy tài khoản cần Xóa ", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnCancelNV_Click(object sender, EventArgs e)
        {
            setNull();
        }
        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvNhanVien.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgvNhanVien.CurrentRow.Selected = true;

                    txtMaNV.Text = dgvNhanVien.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                    txtHoTenNV.Text = dgvNhanVien.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                    dtpBirthday.Value = DateTime.Parse(dgvNhanVien.Rows[e.RowIndex].Cells[3].FormattedValue.ToString());
                    string gioitinh = dgvNhanVien.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
                    if (gioitinh == "Nam")
                    {
                        robMale.Checked = true;
                    }
                    else
                    {
                        robFemale.Checked = true;
                    }
                    txtPhoneNV.Text = dgvNhanVien.Rows[e.RowIndex].Cells[5].FormattedValue.ToString();
                    txtAddressNV.Text = dgvNhanVien.Rows[e.RowIndex].Cells[6].FormattedValue.ToString();
                    txtChucVu.Text = dgvNhanVien.Rows[e.RowIndex].Cells[7].FormattedValue.ToString();
                    txtLuong.Text = dgvNhanVien.Rows[e.RowIndex].Cells[8].FormattedValue.ToString();
                    cmbStatus.SelectedIndex = cmbStatus.FindString(dgvNhanVien.Rows[e.RowIndex].Cells[9].FormattedValue.ToString());
                    dieuchinh(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbViewListNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = 1;
            List<NHANVIEN> listNhanVien = context.NHANVIEN.ToList();
            if (cmbViewListNV.Text == "Đang Làm Việc")
            {
                dgvNhanVien.Rows.Clear();
                foreach (var item in listNhanVien)
                {
                    if (item.TRANGTHAI != "Đã Nghỉ Việc")
                    {
                        int index = dgvNhanVien.Rows.Add();
                        dgvNhanVien.Rows[index].Cells[0].Value = i;
                        dgvNhanVien.Rows[index].Cells[1].Value = item.MANV;
                        dgvNhanVien.Rows[index].Cells[2].Value = item.HOTENNV;
                        dgvNhanVien.Rows[index].Cells[3].Value = item.NGAYSINH;
                        dgvNhanVien.Rows[index].Cells[4].Value = item.GIOITINH;
                        dgvNhanVien.Rows[index].Cells[5].Value = item.SDT;
                        dgvNhanVien.Rows[index].Cells[6].Value = item.DIACHI;
                        dgvNhanVien.Rows[index].Cells[7].Value = item.CHUCVU;
                        dgvNhanVien.Rows[index].Cells[8].Value = item.LUONG;
                        dgvNhanVien.Rows[index].Cells[9].Value = item.TRANGTHAI;
                        i++;
                        //Sum();
                    }
                }
            }
            else if (cmbViewListNV.Text == "Đã Nghỉ Việc")
            {
                dgvNhanVien.Rows.Clear();
                foreach (var item in listNhanVien)
                {
                    if (item.TRANGTHAI == "Đã Nghỉ Việc")
                    {
                        int index = dgvNhanVien.Rows.Add();
                        dgvNhanVien.Rows[index].Cells[0].Value = i;
                        dgvNhanVien.Rows[index].Cells[1].Value = item.MANV;
                        dgvNhanVien.Rows[index].Cells[2].Value = item.HOTENNV;
                        dgvNhanVien.Rows[index].Cells[3].Value = item.NGAYSINH;
                        dgvNhanVien.Rows[index].Cells[4].Value = item.GIOITINH;
                        dgvNhanVien.Rows[index].Cells[5].Value = item.SDT;
                        dgvNhanVien.Rows[index].Cells[6].Value = item.DIACHI;
                        dgvNhanVien.Rows[index].Cells[7].Value = item.CHUCVU;
                        dgvNhanVien.Rows[index].Cells[8].Value = item.LUONG;
                        dgvNhanVien.Rows[index].Cells[9].Value = item.TRANGTHAI;
                        i++;
                        //Sum();
                    }
                }
            }
            else
            {
                dgvNhanVien.Rows.Clear();
                foreach (var item in listNhanVien)
                {
                    int index = dgvNhanVien.Rows.Add();
                    dgvNhanVien.Rows[index].Cells[0].Value = i;
                    dgvNhanVien.Rows[index].Cells[1].Value = item.MANV;
                    dgvNhanVien.Rows[index].Cells[2].Value = item.HOTENNV;
                    dgvNhanVien.Rows[index].Cells[3].Value = item.NGAYSINH;
                    dgvNhanVien.Rows[index].Cells[4].Value = item.GIOITINH;
                    dgvNhanVien.Rows[index].Cells[5].Value = item.SDT;
                    dgvNhanVien.Rows[index].Cells[6].Value = item.DIACHI;
                    dgvNhanVien.Rows[index].Cells[7].Value = item.CHUCVU;
                    dgvNhanVien.Rows[index].Cells[8].Value = item.LUONG;
                    dgvNhanVien.Rows[index].Cells[9].Value = item.TRANGTHAI;
                    i++;
                    //Sum();
                }
            }
        }
        private void dieuchinh(bool e)
        {
            if (e == true)
            {
                pnAddStudent.Visible = true;
                iconUpDown.IconChar = IconChar.CaretDown;
            }
            else
            {
                pnAddStudent.Visible = false;
                iconUpDown.IconChar = IconChar.CaretUp;
            }
        }
        private void iconUpDown_Click(object sender, EventArgs e)
        {
            if (iconUpDown.IconChar == IconChar.CaretUp)
            {
                dieuchinh(true);
            }
            else
            {
                dieuchinh(false);
            }
        }
        private void txtSearchNV_TextChanged(object sender, EventArgs e)
        {
            List<NHANVIEN> listNhanVienSearch = new List<NHANVIEN>();
            List<NHANVIEN> listNhanVien = context.NHANVIEN.ToList();
            string search = txtSearchNV.Text;
            if (search != "")
            {
                foreach (NHANVIEN item in listNhanVien)
                {
                    if (item.HOTENNV.ToLower().Contains(search.ToLower()) || item.MANV.ToLower().Contains(search.ToLower()))
                    {
                        listNhanVienSearch.Add(item);
                    }
                }
                BindGrid(listNhanVienSearch);
            }
            else
            {
                BindGrid(listNhanVien);
            }
        }
        //private void Sum()
        //{
        //    int TongNV = 0;
        //    for (int i = 0; i < dgvNhanVien.Rows.Count; i++)
        //    {
        //        if (dgvNhanVien.Rows[i].Cells[1].Value != null)
        //        {
        //            if (dgvNhanVien.Rows[i].Cells[9].Value.ToString() == "Đang làm việc")
        //            {
        //                TongNV++;
        //            }
        //            else
        //            {
        //                TongNV--;
        //            }
        //        }
        //    }
        //    lblTongNV.Text = TongNV.ToString();
        //}
        public void ExportFile(DataTable dataTable, string sheetName, string title)
        {
            //Tạo các đối tượng Excel

            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();

            Microsoft.Office.Interop.Excel.Workbooks oBooks;

            Microsoft.Office.Interop.Excel.Sheets oSheets;

            Microsoft.Office.Interop.Excel.Workbook oBook;

            Microsoft.Office.Interop.Excel.Worksheet oSheet;

            //Tạo mới một Excel WorkBook 

            oExcel.Visible = true;

            oExcel.DisplayAlerts = false;

            oExcel.Application.SheetsInNewWorkbook = 1;

            oBooks = oExcel.Workbooks;

            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));

            oSheets = oBook.Worksheets;

            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);

            oSheet.Name = sheetName;

            // Tạo phần Tiêu đề
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "G1");

            head.MergeCells = true;

            head.Value2 = title;

            head.Font.Bold = true;

            head.Font.Name = "Times New Roman";

            head.Font.Size = "20";

            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo tiêu đề cột 
            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");

            cl1.Value2 = "STT";

            cl1.ColumnWidth = 8;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");

            cl2.Value2 = "Mã Nhân Viên";

            cl2.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");

            cl3.Value2 = "Họ Tên";

            cl3.ColumnWidth = 25.0;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");

            cl4.Value2 = "Ngày sinh";
            cl4.ColumnWidth = 12.0;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");

            cl5.Value2 = "Giới tính";

            cl5.ColumnWidth = 10.5;

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");

            cl6.Value2 = "Số ĐT";

            cl6.ColumnWidth = 20.5;

            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G3", "G3");

            cl7.Value2 = "Địa Chỉ";

            cl7.ColumnWidth = 18.5;

            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H3", "H3");

            cl8.Value2 = "Chức Vụ";

            cl8.ColumnWidth = 18.5;

            Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("I3", "I3");

            cl9.Value2 = "Lương";

            cl9.ColumnWidth = 18.5;

            Microsoft.Office.Interop.Excel.Range c20 = oSheet.get_Range("J3", "J3");

            c20.Value2 = "Trạng Thái";

            c20.ColumnWidth = 18;

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "J3");

            rowHead.Font.Bold = true;

            // Kẻ viền

            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Thiết lập màu nền

            rowHead.Interior.ColorIndex = 6;

            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo mảng theo datatable

            object[,] arr = new object[dataTable.Rows.Count, dataTable.Columns.Count];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng

            for (int row = 0; row < dataTable.Rows.Count; row++)
            {
                DataRow dataRow = dataTable.Rows[row];

                for (int col = 0; col < dataTable.Columns.Count; col++)
                {
                    arr[row, col] = dataRow[col];
                }
            }

            //Thiết lập vùng điền dữ liệu

            int rowStart = 4;

            int columnStart = 1;

            int rowEnd = rowStart + dataTable.Rows.Count - 1;

            int columnEnd = dataTable.Columns.Count;

            // Ô bắt đầu điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];

            // Ô kết thúc điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];

            // Lấy về vùng điền dữ liệu

            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            //Điền dữ liệu vào vùng đã thiết lập

            range.Value2 = arr;

            // Kẻ viền

            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Căn giữa cột mã nhân viên

            //Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnStart];

            //Microsoft.Office.Interop.Excel.Range c4 = oSheet.get_Range(c1, c3);

            //Căn giữa cả bảng 
            oSheet.get_Range(c1, c2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        }
        private void btnOutputExcel_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();

            DataColumn col1 = new DataColumn("STT");
            DataColumn col2 = new DataColumn("MANV");
            DataColumn col3 = new DataColumn("HOTENNV");
            DataColumn col4 = new DataColumn("NGAYSINH");
            DataColumn col5 = new DataColumn("GIOITINH");
            DataColumn col6 = new DataColumn("SDT");
            DataColumn col7 = new DataColumn("DIACHI");
            DataColumn col8 = new DataColumn("CHUCVU");
            DataColumn col9 = new DataColumn("LUONG");
            DataColumn col10 = new DataColumn("TRANGTHAI");

            dataTable.Columns.Add(col1);
            dataTable.Columns.Add(col2);
            dataTable.Columns.Add(col3);
            dataTable.Columns.Add(col4);
            dataTable.Columns.Add(col5);
            dataTable.Columns.Add(col6);
            dataTable.Columns.Add(col7);
            dataTable.Columns.Add(col8);
            dataTable.Columns.Add(col9);
            dataTable.Columns.Add(col10);

            foreach (DataGridViewRow dgvRow in dgvNhanVien.Rows)
            {
                DataRow dtRow = dataTable.NewRow();

                dtRow[0] = dgvRow.Cells[0].Value;
                dtRow[1] = dgvRow.Cells[1].Value;
                dtRow[2] = dgvRow.Cells[2].Value;
                dtRow[3] = dgvRow.Cells[3].Value;
                dtRow[4] = dgvRow.Cells[4].Value;
                dtRow[5] = dgvRow.Cells[5].Value;
                dtRow[6] = dgvRow.Cells[6].Value;
                dtRow[7] = dgvRow.Cells[7].Value;
                dtRow[8] = dgvRow.Cells[8].Value;
                dtRow[9] = dgvRow.Cells[9].Value;

                dataTable.Rows.Add(dtRow);
            }
            ExportFile(dataTable, "Danh sách", "Danh Sách Nhân Viên");
        }
    }
}

