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
    public partial class frmQLThongTinSV : Form
    {
        private readonly KTXDBContext context;
        public frmQLThongTinSV()
        {
            context = new KTXDBContext();
            InitializeComponent();
        }
        //Hàm binding list có tên hiện thị là tên phòng
        private void FillRoomCombobox(List<PHONGSV> listRoom)
        {

            this.cmbRoom.DataSource = listRoom;
            this.cmbRoom.DisplayMember = "TENPHONG";
            this.cmbRoom.ValueMember = "MAPHONG";  
        }
        private void FillSchoolCombobox(List<TRUONGHOC> listSchool)
        {
            this.cmbTruong.DataSource = listSchool;
            this.cmbTruong.DisplayMember = "TENTRUONG";
            this.cmbTruong.ValueMember = "MATRUONG";

        }

        private void cmbViewListSV_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = 1;
            List<SINHVIEN> listSV = context.SINHVIEN.ToList();
            if (cmbViewListSV.Text == "Đang Ở")
            {
                dgvStudent.Rows.Clear();
                foreach (var item in listSV)
                {
                    if (item.TRANGTHAI != "Đã Chuyển Đi")
                    {
                        int index = dgvStudent.Rows.Add();
                        dgvStudent.Rows[index].Cells[0].Value = i;
                        dgvStudent.Rows[index].Cells[1].Value = item.CCCD;
                        dgvStudent.Rows[index].Cells[2].Value = item.MSSV;
                        dgvStudent.Rows[index].Cells[3].Value = item.HOTEN;
                        dgvStudent.Rows[index].Cells[4].Value = item.NAMSINH;
                        dgvStudent.Rows[index].Cells[5].Value = item.GIOITINH;
                        dgvStudent.Rows[index].Cells[6].Value = item.SDT;
                        dgvStudent.Rows[index].Cells[7].Value = item.EMAIL;
                        dgvStudent.Rows[index].Cells[8].Value = item.DIACHI;
                        dgvStudent.Rows[index].Cells[9].Value = item.NGAYVAOKTX;
                        dgvStudent.Rows[index].Cells[10].Value = item.PHONGSV.TENPHONG;
                        dgvStudent.Rows[index].Cells[11].Value = item.TRUONGHOC.TENTRUONG;
                        dgvStudent.Rows[index].Cells[12].Value = item.TRANGTHAI;
                        dgvStudent.Rows[index].Cells[13].Value = item.NGAYRAKTX;
                        this.dgvStudent.Columns[13].Visible = false;
                        i++;
                    }
                }
            }
            else if (cmbViewListSV.Text == "Đã Chuyển Đi")
            {
                dgvStudent.Rows.Clear();
                foreach (var item in listSV)
                {
                    if (item.TRANGTHAI == "Đã Chuyển Đi")
                    {
                        int index = dgvStudent.Rows.Add();
                        dgvStudent.Rows[index].Cells[0].Value = i;
                        dgvStudent.Rows[index].Cells[1].Value = item.CCCD;
                        dgvStudent.Rows[index].Cells[2].Value = item.MSSV;
                        dgvStudent.Rows[index].Cells[3].Value = item.HOTEN;
                        dgvStudent.Rows[index].Cells[4].Value = item.NAMSINH;
                        dgvStudent.Rows[index].Cells[5].Value = item.GIOITINH;
                        dgvStudent.Rows[index].Cells[6].Value = item.SDT;
                        dgvStudent.Rows[index].Cells[7].Value = item.EMAIL;
                        dgvStudent.Rows[index].Cells[8].Value = item.DIACHI;
                        dgvStudent.Rows[index].Cells[9].Value = item.NGAYVAOKTX;
                        dgvStudent.Rows[index].Cells[10].Value = item.PHONGSV.TENPHONG;
                        dgvStudent.Rows[index].Cells[11].Value = item.TRUONGHOC.TENTRUONG;
                        dgvStudent.Rows[index].Cells[12].Value = item.TRANGTHAI;
                        dgvStudent.Rows[index].Cells[13].Value = item.NGAYRAKTX;
                        this.dgvStudent.Columns[13].Visible = true;
                        i++;
                    }
                }
            }
            else
            {
                dgvStudent.Rows.Clear();
                foreach (var item in listSV)
                {
                    int index = dgvStudent.Rows.Add();
                    dgvStudent.Rows[index].Cells[0].Value = i;
                    dgvStudent.Rows[index].Cells[1].Value = item.CCCD;
                    dgvStudent.Rows[index].Cells[2].Value = item.MSSV;
                    dgvStudent.Rows[index].Cells[3].Value = item.HOTEN;
                    dgvStudent.Rows[index].Cells[4].Value = item.NAMSINH;
                    dgvStudent.Rows[index].Cells[5].Value = item.GIOITINH;
                    dgvStudent.Rows[index].Cells[6].Value = item.SDT;
                    dgvStudent.Rows[index].Cells[7].Value = item.EMAIL;
                    dgvStudent.Rows[index].Cells[8].Value = item.DIACHI;
                    dgvStudent.Rows[index].Cells[9].Value = item.NGAYVAOKTX;
                    dgvStudent.Rows[index].Cells[10].Value = item.PHONGSV.TENPHONG;
                    dgvStudent.Rows[index].Cells[11].Value = item.TRUONGHOC.TENTRUONG;
                    dgvStudent.Rows[index].Cells[12].Value = item.TRANGTHAI;
                    dgvStudent.Rows[index].Cells[13].Value = item.NGAYRAKTX;
                    this.dgvStudent.Columns[13].Visible = true;
                    i++;
                }
            }
        }
        private void BindGrid(List<SINHVIEN> listStudent)
        {
            dgvStudent.Rows.Clear();
            int i = 1;
            foreach (var item in listStudent)
            {
                if(item.TRANGTHAI == "Đang Ở")
                {
                    int index = dgvStudent.Rows.Add();
                    dgvStudent.Rows[index].Cells[0].Value = i;
                    dgvStudent.Rows[index].Cells[1].Value = item.CCCD;
                    dgvStudent.Rows[index].Cells[2].Value = item.MSSV;
                    dgvStudent.Rows[index].Cells[3].Value = item.HOTEN;
                    dgvStudent.Rows[index].Cells[4].Value = item.NAMSINH;
                    dgvStudent.Rows[index].Cells[5].Value = item.GIOITINH;
                    dgvStudent.Rows[index].Cells[6].Value = item.SDT;
                    dgvStudent.Rows[index].Cells[7].Value = item.EMAIL;
                    dgvStudent.Rows[index].Cells[8].Value = item.DIACHI;
                    dgvStudent.Rows[index].Cells[9].Value = item.NGAYVAOKTX;
                    dgvStudent.Rows[index].Cells[10].Value = item.PHONGSV.TENPHONG;
                    dgvStudent.Rows[index].Cells[11].Value = item.TRUONGHOC.TENTRUONG;
                    dgvStudent.Rows[index].Cells[12].Value = item.TRANGTHAI;
                    dgvStudent.Rows[index].Cells[13].Value = item.NGAYRAKTX;
                    this.dgvStudent.Columns[13].Visible = false;
                    i++;
                }    
                
            }
        }
        private void setNull()
        {
            txtStudentID.Text = "";
            txtStudentName.Text = "";
            txtAddressSV.Text = "";
            txtPhoneSV.Text = "";
            cmbTruong.SelectedValue = 0;
            robMale.Checked = true;
            dtpBirthday.Value = DateTime.Now;
            dtpNgayVaoKTX.Value = DateTime.Now;
            cmbTrangThaiSV.SelectedIndex = 0;
            cmbRoom.SelectedIndex = 0;
        }
        private int GetSelectedRow(string studentID)
        {
            for (int i = 0; i < dgvStudent.Rows.Count; i++)
            {
                if (dgvStudent.Rows[i].Cells[1].Value.ToString() == studentID)
                {
                    return i;
                }
            }
            return -1;
        }
        private bool CheckValidate()
        {
            if (txtCCCD.Text == "" || txtStudentID.Text == "" || txtStudentName.Text == "" || txtAddressSV.Text == "" || txtPhoneSV.Text == "" || txtEmail.Text == "")
            {
                MessageBox.Show("Vui lòng không để trống thông tin", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }
        private void reloadDGV()
        {
            List<SINHVIEN> listStudent = context.SINHVIEN.ToList(); //lấy sinh viên  Câu lệnh LinQ
            BindGrid(listStudent);
        }
        private void frmQLThongTinSV_Load(object sender, EventArgs e)
        {
            try
            {
                List<TRUONGHOC> listSchool = context.TRUONGHOC.ToList();
                List<PHONGSV> listRoom = context.PHONGSV.ToList();
                List<SINHVIEN> listStudent = context.SINHVIEN.ToList();
                List<TOANHA> listToa = context.TOANHA.ToList();
                FillRoomCombobox(listRoom);
                FillSchoolCombobox(listSchool);
                BindGrid(listStudent); 
                cmbViewListSV.SelectedIndex = 0;
                robMale.Checked = true;
                cmbRoom.SelectedIndex = 0;
                cmbTruong.SelectedIndex = 0;
                pnAddStudent.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dgvStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvStudent.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgvStudent.CurrentRow.Selected = true;
                    txtCCCD.Text = dgvStudent.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                    txtStudentID.Text = dgvStudent.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                    txtStudentName.Text = dgvStudent.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                    dtpBirthday.Value = DateTime.Parse(dgvStudent.Rows[e.RowIndex].Cells[4].FormattedValue.ToString());
                    string gioitinh = dgvStudent.Rows[e.RowIndex].Cells[5].FormattedValue.ToString();
                    if (gioitinh == "Nam")
                    {
                        robMale.Checked = true;
                    }
                    else
                    {
                        robFemale.Checked = true;

                    }
                    txtPhoneSV.Text = dgvStudent.Rows[e.RowIndex].Cells[6].FormattedValue.ToString();
                    txtEmail.Text = dgvStudent.Rows[e.RowIndex].Cells[7].FormattedValue.ToString();
                    txtAddressSV.Text = dgvStudent.Rows[e.RowIndex].Cells[8].FormattedValue.ToString();
                    dtpNgayVaoKTX.Value = DateTime.Parse(dgvStudent.Rows[e.RowIndex].Cells[9].FormattedValue.ToString()); 
                    cmbRoom.SelectedIndex = cmbRoom.FindString(dgvStudent.Rows[e.RowIndex].Cells[10].FormattedValue.ToString());
                    cmbTruong.SelectedIndex = cmbTruong.FindString(dgvStudent.Rows[e.RowIndex].Cells[11].FormattedValue.ToString());
                    cmbTrangThaiSV.SelectedIndex = cmbTrangThaiSV.FindString(dgvStudent.Rows[e.RowIndex].Cells[12].FormattedValue.ToString());
                    dieuchinh(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddSV_Click(object sender, EventArgs e)
        {     
            if (CheckValidate())
            {
                string thongbao = "\nTạo Mới Tài Khoản Thành Công!\nTài khoản: " + txtCCCD.Text + "\nMật khẩu: " + txtPhoneSV.Text;
                string ngay = String.Format("{0:yyyy-MM-dd}", dtpBirthday.Value);
                string ngayvaoktx = String.Format("{0:yyyy-MM-dd}", dtpNgayVaoKTX.Value);
                string gioitinh;
                if (robMale.Checked == true)
                {
                    gioitinh = "Nam";
                }
                else
                {
                    gioitinh = "Nữ";
                }
                if (GetSelectedRow(txtCCCD.Text) == -1)
                {
                    ACCOUNT user = context.ACCOUNT.FirstOrDefault(p => p.USER == txtCCCD.Text);
                    SINHVIEN masv = context.SINHVIEN.FirstOrDefault(p => p.CCCD == txtCCCD.Text);
                    if (masv == null)
                    {
                        SINHVIEN sv = new SINHVIEN()
                        {
                            CCCD = txtCCCD.Text,
                            MSSV = txtStudentID.Text,
                            HOTEN = txtStudentName.Text,
                            DIACHI = txtAddressSV.Text,
                            EMAIL = txtEmail.Text,
                            SDT = txtPhoneSV.Text,
                            GIOITINH = gioitinh,
                            NGAYVAOKTX = dtpNgayVaoKTX.Value,
                            NAMSINH = dtpBirthday.Value,
                            MATRUONG = cmbTruong.SelectedValue.ToString(),
                            MAPHONG = cmbRoom.SelectedValue.ToString(),
                            TRANGTHAI = cmbTrangThaiSV.SelectedItem.ToString()
                        };
                        ACCOUNT a = new ACCOUNT()
                        {
                   
                            USER = txtCCCD.Text,
                            PASS = txtPhoneSV.Text,
                            QUYEN = "USER",
                            CCCD = txtCCCD.Text
                        };
                        PHONGSV phongsv = context.PHONGSV.FirstOrDefault(p => p.MAPHONG == cmbRoom.SelectedValue.ToString() );
                        {
                            if (phongsv.SOLUONG > 0)
                            {
                                phongsv.SOLUONG -= 1;
                                context.SINHVIEN.Add(sv);
                                context.ACCOUNT.Add(a);
                                context.SaveChanges();
                                reloadDGV();
                                setNull();
                                MessageBox.Show("Thêm mới dữ liệu thành công!" + thongbao, "Thông báo", MessageBoxButtons.OK);
                            }
                            else
                            {     
                                MessageBox.Show("Phòng Đã Đầy", "Thông báo", MessageBoxButtons.OK);
                            }    
                        }                  
                    }
                }
                else
                {
                    MessageBox.Show("Sinh viên đã tồn tại", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }
        private void btnUpdateSV_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStudentID.Text) || string.IsNullOrEmpty(txtStudentName.Text) || string.IsNullOrEmpty(txtPhoneSV.Text) || string.IsNullOrEmpty(txtAddressSV.Text) || string.IsNullOrEmpty(txtEmail.Text))
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
                ACCOUNT accUpdate = context.ACCOUNT.FirstOrDefault(p => p.CCCD == txtCCCD.Text);
                SINHVIEN dbUpdate = context.SINHVIEN.FirstOrDefault(p => p.CCCD == txtCCCD.Text);
                if (dbUpdate != null)
                {
                    {
                        dbUpdate.CCCD = txtCCCD.Text;
                        dbUpdate.MSSV = txtStudentID.Text;
                        dbUpdate.HOTEN = txtStudentName.Text;
                        dbUpdate.DIACHI = txtAddressSV.Text;
                        dbUpdate.EMAIL = txtEmail.Text;
                        dbUpdate.SDT = txtPhoneSV.Text;
                        dbUpdate.GIOITINH = gioitinh;
                        dbUpdate.NGAYVAOKTX = dtpNgayVaoKTX.Value;
                        dbUpdate.NAMSINH = dtpBirthday.Value;
                        dbUpdate.MATRUONG = cmbTruong.SelectedValue.ToString();
                        dbUpdate.MAPHONG = cmbRoom.SelectedValue.ToString();
                        dbUpdate.TRANGTHAI = cmbTrangThaiSV.SelectedItem.ToString();
                        context.SaveChanges();
                        reloadDGV();
                        setNull();
                        MessageBox.Show("Cập Nhập dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
                    };
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sinh viên cần sửa ", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private void btnDeleteSV_Click(object sender, EventArgs e)
        {
            //if(cmbViewListSV.SelectedIndex == 0)
            //{
                ACCOUNT tt = context.ACCOUNT.FirstOrDefault(p => p.USER == txtCCCD.Text);
                SINHVIEN dbDelete = context.SINHVIEN.FirstOrDefault(p => p.CCCD == txtCCCD.Text);
                PHONGSV phongsv = context.PHONGSV.FirstOrDefault(p => p.MAPHONG == cmbRoom.SelectedValue.ToString());
                if (dbDelete != null)
                {
                    DialogResult noti = MessageBox.Show("Bạn có muốn xóa?", "Thông Báo", MessageBoxButtons.YesNo);
                    if (noti == DialogResult.Yes)
                    {
                        phongsv.SOLUONG += 1;
                        context.ACCOUNT.Remove(tt);
                        dbDelete.TRANGTHAI = "Đã Chuyển Đi";
                        dbDelete.NGAYRAKTX = DateTime.Now;
                        context.SaveChanges();
                        reloadDGV();
                        setNull();
                        MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy tài khoản cần Xóa ", "Thông báo", MessageBoxButtons.OK);
                }
            //}
            //else
            //{
            //    ACCOUNT tt = context.ACCOUNT.FirstOrDefault(p => p.USER == txtCCCD.Text);
            //    SINHVIEN dbDelete = context.SINHVIEN.FirstOrDefault(p => p.CCCD == txtCCCD.Text);
            //    if (dbDelete != null)
            //    {
            //        DialogResult noti = MessageBox.Show("Bạn có muốn xóa?", "Thông Báo", MessageBoxButtons.YesNo);
            //        if (noti == DialogResult.Yes)
            //        {
                        
            //            context.ACCOUNT.Remove(tt);
            //            context.SINHVIEN.Remove(dbDelete);
            //            context.SaveChanges();
            //            reloadDGV();
            //            setNull();
            //            MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
            //            //Sum();

            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Không tìm thấy tài khoản cần Xóa ", "Thông báo", MessageBoxButtons.OK);
            //    }
            //}     
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            setNull();
        }
        private void txtSearchSV_TextChanged(object sender, EventArgs e)
        {
            List<SINHVIEN> listSVSearch = new List<SINHVIEN>();
            List<SINHVIEN> listSinhVien = context.SINHVIEN.ToList();
            string search = txtSearchSV.Text;
            if (search != "")
            {
                foreach (SINHVIEN item in listSinhVien)
                {
                    if (item.HOTEN.ToLower().Contains(search.ToLower()) || item.MSSV.ToLower().Contains(search.ToLower()) || item.CCCD.ToLower().Contains(search.ToLower()) || item.SDT.ToLower().Contains(search.ToLower()))
                    {
                        listSVSearch.Add(item);
                    }
                }
                BindGrid(listSVSearch);
            }
            else
            {
                BindGrid(listSinhVien);
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
        //private void Sum()
        //{
        //    int TongSV = 0;
        //    for (int i = 0; i < dgvStudent.Rows.Count; i++)
        //    {
        //        if (dgvStudent.Rows[i].Cells[1].Value != null)
        //        {
        //            TongSV++;
        //        }
        //    }
        //    lblTongSV.Text = TongSV.ToString();
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

            cl2.Value2 = "Mã Sinh Viên";

            cl2.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");

            cl3.Value2 = "Họ Tên";

            cl3.ColumnWidth = 25.0;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");

            cl4.Value2 = "Giới Tính";
            cl4.ColumnWidth = 12.0;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");

            cl5.Value2 = "Ngày Sinh";

            cl5.ColumnWidth = 24;

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");

            cl6.Value2 = "Số ĐT";

            cl6.ColumnWidth = 14;

            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G3", "G3");

            cl7.Value2 = "Địa Chỉ";

            cl7.ColumnWidth = 18.5;

            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H3", "H3");

            cl8.Value2 = "Trường";

            cl8.ColumnWidth = 18.5;

            Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("I3", "I3");

            cl9.Value2 = "Phòng";

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
            DataColumn col2 = new DataColumn("MSSV");
            DataColumn col3 = new DataColumn("HOTEN");
            DataColumn col4 = new DataColumn("GIOITINH");
            DataColumn col5 = new DataColumn("NAMSINH");
            DataColumn col6 = new DataColumn("SDT");
            DataColumn col7 = new DataColumn("DIACHI");
            DataColumn col8 = new DataColumn("TENTRUONG");
            DataColumn col9 = new DataColumn("PHONGSV.MAPHONGSV");
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

            foreach (DataGridViewRow dgvRow in dgvStudent.Rows)
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
                // dtRow[10] = dgvRow.Cells[10].Value;

                dataTable.Rows.Add(dtRow);
            }
            ExportFile(dataTable, "Danh Sach", "Danh Sách Sinh Viên");
        }

        
    }
}
