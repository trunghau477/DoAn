using QLKTX.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKTX
{
    public partial class frmAddRoom : Form
    {
        private readonly KTXDBContext context;
        public frmAddRoom()
        {
            context = new KTXDBContext();
            InitializeComponent();
        }
        private void BindGrid(List<PHONGSV> listRoomSV)
        {
            update();
            dgvRoom.Rows.Clear();
            foreach (var item in listRoomSV)
            {
                int index = dgvRoom.Rows.Add();
                dgvRoom.Rows[index].Cells[0].Value = item.TOANHA.TENTOA;
                dgvRoom.Rows[index].Cells[1].Value = item.MAPHONG;
                dgvRoom.Rows[index].Cells[2].Value = item.TENPHONG;
                dgvRoom.Rows[index].Cells[3].Value = item.LOAIPHONG;
                dgvRoom.Rows[index].Cells[4].Value = item.SOLUONG;
                dgvRoom.Rows[index].Cells[5].Value = item.GIAPHONG;
                dgvRoom.Rows[index].Cells[6].Value = item.TRANGTHAI; 
            }
        }
        private void setNull()
        {
            txtRoomID.Text = "";
            txtRoomName.Text = "";
            cmbLoaiPhong.SelectedIndex = 0;
            cmbTrangThaiPhong.SelectedIndex = 0;
            txtGiaPhong.Text = "";
            cmbToa.SelectedIndex = 0;
            //cmbTrangThaiPhong.SelectedIndex = 0;
        }
        private int GetSelectedRow(string roomSVID)
        {
            for (int i = 0; i < dgvRoom.Rows.Count; i++)
            {
                if (dgvRoom.Rows[i].Cells[0].Value.ToString() == roomSVID)
                {
                    return i;
                }
            }
            return -1;
        }
        private bool CheckValidate()
        {
            if (txtRoomID.Text == "" || txtRoomName.Text == "")//|| txtTrangThaiPhong.Text == "" || txtGiaPhong.Text == "")
            {
                MessageBox.Show("Vui lòng không để trống dữ liệu", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            else return true;
        }
        private void reloadDGV()
        {
            List<PHONGSV> listRoomSV = context.PHONGSV.ToList();
            BindGrid(listRoomSV);
        }
        private void FillToaCombobox(List<TOANHA> listToa)
        {
            cmbToa.DataSource = listToa;
            cmbToa.DisplayMember = "TENTOA";
            cmbToa.ValueMember = "MATOA";
        }
        private void frmAddRoom_Load(object sender, EventArgs e)
        {
            try
            {
                List<TOANHA> listToa = context.TOANHA.ToList();
                List<PHONGSV> listRoomSV = context.PHONGSV.ToList();
                BindGrid(listRoomSV);
                FillToaCombobox(listToa);
                cmbLoaiPhong.SelectedIndex = 0;
                cmbToa.SelectedIndex = 0;
                cmbTrangThaiPhong.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void update()
        {
            List<PHONGSV> psv = context.PHONGSV.ToList();
            foreach (var item in psv)
                if (item.SOLUONG == 0)
                {
                    item.TRANGTHAI = "Đã Đủ";
                }
                else
                {
                    item.TRANGTHAI = "Còn Trống";
                }
        }


        //private void Sum()
        //{
        //    int Tong = 0;
        //    for (int i = 0; i < dgvRoom.Rows.Count; i++)
        //    {
        //        if (dgvRoom.Rows[i].Cells[1].Value != null)
        //        {
        //            Tong++;
        //        }
        //    }
        //    lblTong.Text = Tong.ToString();
        //}

        private void dgvRoom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvRoom.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgvRoom.CurrentRow.Selected = true;
                    
                    txtRoomID.Text = dgvRoom.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtRoomName.Text = dgvRoom.Rows[e.RowIndex].Cells[2].Value.ToString();
                    cmbLoaiPhong.SelectedIndex = cmbLoaiPhong.FindString(dgvRoom.Rows[e.RowIndex].Cells[3].FormattedValue.ToString());
                    txtGiaPhong.Text = dgvRoom.Rows[e.RowIndex].Cells[5].FormattedValue.ToString();
                    cmbTrangThaiPhong.SelectedIndex = cmbTrangThaiPhong.FindString(dgvRoom.Rows[e.RowIndex].Cells[6].FormattedValue.ToString());
                    cmbToa.SelectedIndex = cmbToa.FindString(dgvRoom.Rows[e.RowIndex].Cells[0].FormattedValue.ToString());

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        
        /*
        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            PHONGSV dbDelete = context.PHONGSV.FirstOrDefault(p => p.MAPHONG.ToString() == txtRoomID.Text);
            if (dbDelete != null)
            {
                DialogResult dr = MessageBox.Show("Bạn có muốn xoá?", "Yes/No", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    context.PHONGSV.Remove(dbDelete);
                    context.SaveChanges(); //Lưu thay dổi
                    reloadDGV();
                    setNull();
                    MessageBox.Show("Xóa phòng thành công!", "Thông báo", MessageBoxButtons.OK);
                    //Sum();
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy phòng cần xóa!", "Thông báo", MessageBoxButtons.OK);
            }
        }*/

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckValidate())
            {

                if (GetSelectedRow(txtRoomID.Text) == -1)
                {
                    PHONGSV phong = new PHONGSV()
                    {
                        MAPHONG = txtRoomID.Text,
                        TENPHONG = txtRoomName.Text,
                        LOAIPHONG = cmbLoaiPhong.SelectedItem.ToString(),
                        //SOLUONG = 2,
                        GIAPHONG = float.Parse(txtGiaPhong.Text),
                        TRANGTHAI = cmbTrangThaiPhong.SelectedItem.ToString(),
                        MATOA = cmbToa.SelectedValue.ToString()
                    };
                    if (cmbLoaiPhong.SelectedItem.ToString() == "Phòng 2")
                    {
                        phong.SOLUONG = 2;         
                        //phong.TRANGTHAI = cmbTrangThaiPhong.SelectedItem.ToString();
                    }
                    else if (cmbLoaiPhong.SelectedItem.ToString() == "Phòng 4")
                    {
                        phong.SOLUONG = 4;
                        //phong.TRANGTHAI = cmbTrangThaiPhong.SelectedItem.ToString();
                    }
                    else
                    {
                        phong.SOLUONG = 6;
                        //phong.TRANGTHAI = cmbTrangThaiPhong.SelectedItem.ToString();
                    }
                    context.PHONGSV.Add(phong);
                    context.SaveChanges();
                    reloadDGV();
                    setNull();
                    MessageBox.Show("Thêm mới dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
                    //Sum();
                }
               
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
                var idphong = txtRoomID.Text;
                PHONGSV dbUpdate = context.PHONGSV.FirstOrDefault(p => p.MAPHONG == idphong);
                if (dbUpdate != null)
                {
                    dbUpdate.MAPHONG = txtRoomID.Text;
                    dbUpdate.TENPHONG = txtRoomName.Text;
                    dbUpdate.LOAIPHONG = cmbLoaiPhong.Text;
                    dbUpdate.GIAPHONG = float.Parse(txtGiaPhong.Text);
                    dbUpdate.TRANGTHAI = cmbTrangThaiPhong.Text;
                    dbUpdate.MATOA = cmbToa.SelectedValue.ToString();
                    
                    context.SaveChanges(); //Lưu thay đổi
                    reloadDGV();
                    setNull();
                    MessageBox.Show("Cập nhật dữ liệu thành công!”.", "Thông báo", MessageBoxButtons.OK);
                    //Sum();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy phòng cần sửa!", "Thông báo", MessageBoxButtons.OK);
                }
            }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            List<PHONGSV> listPhongSVSearch = new List<PHONGSV>();
            List<PHONGSV> listPhongSV = context.PHONGSV.ToList();
            string search = txtFind.Text;
            if (search != "")
            {
                foreach (PHONGSV item in listPhongSV)
                {
                    if (item.TENPHONG.ToLower().Contains(search.ToLower()) || item.LOAIPHONG.ToLower().Contains(search.ToLower()) || item.TOANHA.TENTOA.ToLower().Contains(search.ToLower()) || item.TRANGTHAI.ToLower().Contains(search.ToLower()))
                    {
                        listPhongSVSearch.Add(item);
                    }
                }
                BindGrid(listPhongSVSearch);
            }
            else
            {
                BindGrid(listPhongSV);
            }
        }
    }
}
