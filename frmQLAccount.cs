using QLKTX.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows.Forms;

namespace QLKTX
{
    public partial class frmQLAccount : Form
    {
        KTXDBContext context = new KTXDBContext();
        public frmQLAccount()
        {
            InitializeComponent();
        }

        private void BindGrid(List<ACCOUNT> listAccount)
        {
            //string id = frmLogin.userlogin;
            //ACCOUNT acc = context.ACCOUNT.FirstOrDefault();
            dgvQLAccount.Rows.Clear();
            int i = 1;
            foreach (var item in listAccount)
            {
                if (item.QUYEN == "ADMIN" || item.QUYEN == "MANAGE")
                {
                    int index = dgvQLAccount.Rows.Add();
                    dgvQLAccount.Rows[index].Cells[0].Value = i;
                    dgvQLAccount.Rows[index].Cells[1].Value = item.NHANVIEN.HOTENNV;
                    dgvQLAccount.Rows[index].Cells[2].Value = item.USER;
                    dgvQLAccount.Rows[index].Cells[3].Value = item.PASS;
                    dgvQLAccount.Rows[index].Cells[4].Value = item.QUYEN;
                    i++;
                    //Sum();
                }

            }
        }
        private void BindGridSV(List<ACCOUNT> listAccount)
        {
            dgvQLAccount.Rows.Clear();
            int i = 1;
            foreach (var item in listAccount)
            {
                if (item.QUYEN == "USER")
                {
                    int index = dgvQLAccount.Rows.Add();
                    dgvQLAccount.Rows[index].Cells[0].Value = i;
                    dgvQLAccount.Rows[index].Cells[1].Value = item.SINHVIEN.HOTEN;
                    dgvQLAccount.Rows[index].Cells[2].Value = item.USER;
                    dgvQLAccount.Rows[index].Cells[3].Value = item.PASS;
                    dgvQLAccount.Rows[index].Cells[4].Value = item.QUYEN;
                    i++;
                    //Sum();
                }

            }
        }
       
        private void cmbViewListAcc_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<ACCOUNT> listAccount = context.ACCOUNT.ToList();
            if (cmbViewListAcc.Text == "Nhân Viên")
            {
                BindGrid(listAccount);
            }
            else
            {
                BindGridSV(listAccount);
            }
        }
       
        private void frmQLAccount_Load(object sender, EventArgs e)
        {
            
            List<ACCOUNT> listAccount = context.ACCOUNT.ToList();
            cmbViewListAcc.SelectedIndex = 0;
            BindGrid(listAccount);
            //txtSearchAcc.Hide();
        }
        private void setNull()
        {
            txtFullName.Text = "";
            txtAccount.Text = "";
            txtPassAcc.Text = "";
            cmbQuyen.SelectedIndex = 0;
            txtSearchAcc.Text = "";
        }
        private int GetSelectedRow(string USER)
        {
            for (int i = 0; i < dgvQLAccount.Rows.Count; i++)
            {
                if (dgvQLAccount.Rows[i].Cells[0].Value != null) // check null dgv
                {
                    if (dgvQLAccount.Rows[i].Cells[0].Value.ToString() == USER)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
        private bool CheckValidate()
        {
            if (txtAccount.Text == "" || txtPassAcc.Text == "" || txtFullName.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK);
                return false;
            }

            return true;
        }
        private void reloadDGV()
        {
            List<ACCOUNT> listAccount = context.ACCOUNT.ToList();
            BindGrid(listAccount);
            BindGridSV(listAccount);
        }
        //private void btnAddAcc_Click(object sender, EventArgs e)
        //{
        //    if (CheckValidate())
        //    {
        //        if (GetSelectedRow(txtAccount.Text) == -1)
        //        {
        //            ACCOUNT user = context.ACCOUNT.FirstOrDefault(p => p.USER == txtAccount.Text);
        //            if (user == null)
        //            {
        //                ACCOUNT a = new ACCOUNT()
        //                {
        //                    HOTEN = txtFullName.Text,
        //                    USER = txtAccount.Text,
        //                    PASS = txtPassAcc.Text,
        //                    QUYEN = cmbQuyen.SelectedItem.ToString()
        //                };
        //                context.ACCOUNT.Add(a);
        //                context.SaveChanges();
        //                reloadDGV();
        //                setNull();
        //                MessageBox.Show("Thêm mới dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
        //            }
        //            else
        //            {
        //                MessageBox.Show("Tài Khoản Đã Tồn Tại", "Thông Báo", MessageBoxButtons.OK);
        //            }
        //        }

        //    }
        //}

        private void txtSearchAcc_TextChanged(object sender, EventArgs e)
        {

            if(cmbViewListAcc.SelectedIndex == 0 )
            {
                string search = txtSearchAcc.Text;
                //ACCOUNT acc = context.ACCOUNT.Find(p => p.USER == txtSearchAcc.ToString());
                List<ACCOUNT> listAccountSearch = new List<ACCOUNT>();
                List<ACCOUNT> listAccount = context.ACCOUNT.ToList();
       
                
                if (search != "")
                {
                    foreach (ACCOUNT item in listAccount )
                    {
                        if ( item.USER.ToLower().Contains(search.ToLower()) )
                        {
                            listAccountSearch.Add(item);
                        }
                    }
                    BindGrid(listAccountSearch);
                }
                else
                {
                    BindGrid(listAccount);
                }
            }
            else
            {
                List<ACCOUNT> listAccountSearch = new List<ACCOUNT>();
                List<ACCOUNT> listAccount = context.ACCOUNT.ToList();
                string search = txtSearchAcc.Text;
                if (search != "")
                {
                    foreach (ACCOUNT item in listAccount)
                    {
                        if ( item.USER.ToLower().Contains(search.ToLower()))
                        {
                            listAccountSearch.Add(item);
                        }
                    }
                    BindGridSV(listAccountSearch);
                }
                else
                {
                    BindGridSV(listAccount);
                }
            }    
            
        }

        private void dgvQLAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvQLAccount.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgvQLAccount.CurrentRow.Selected = true;

                    txtFullName.Text = dgvQLAccount.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                    txtAccount.Text = dgvQLAccount.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                    cmbQuyen.SelectedIndex = cmbQuyen.FindString(dgvQLAccount.Rows[e.RowIndex].Cells[4].FormattedValue.ToString());
                    txtPassAcc.Text = dgvQLAccount.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //private void Sum()
        //{
        //    int Tong = 0;
        //    for (int i = 0; i < dgvQLAccount.Rows.Count; i++)
        //    {
        //        if (dgvQLAccount.Rows[i].Cells[1].Value != null)
        //        {
        //            Tong++;
        //        }
        //    }
        //    lblTong.Text = Tong.ToString();
        //}

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CheckValidate())
            {

                ACCOUNT dbUpdate = context.ACCOUNT.FirstOrDefault(p => p.USER == txtAccount.Text);
                if (dbUpdate != null)
                {
                    dbUpdate.NHANVIEN.HOTENNV = txtFullName.Text;
                    dbUpdate.USER = txtAccount.Text;
                    dbUpdate.PASS = txtPassAcc.Text;
                    dbUpdate.QUYEN = cmbQuyen.Text;
                    context.SaveChanges();
                    reloadDGV();
                    setNull();
                    MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
                    //Sum();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy tài khoản cần sửa ", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ACCOUNT dbDelete = context.ACCOUNT.FirstOrDefault(p => p.USER == txtAccount.Text);
            if (dbDelete != null)
            {
                DialogResult noti = MessageBox.Show("Bạn có muốn xóa?", "Thông Báo", MessageBoxButtons.YesNo);
                if (noti == DialogResult.Yes)
                {
                    context.ACCOUNT.Remove(dbDelete);
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

        
    }
}
