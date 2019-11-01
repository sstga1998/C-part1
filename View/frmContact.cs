using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Controller;
using WindowsFormsApp1.Modal;

namespace WindowsFormsApp1.View
{
    public partial class frmContact : Form
    {
        private string id;
        string pathListDataFile;
        public frmContact()
        {
            InitializeComponent();
            
            pathListDataFile = Application.StartupPath + @"\Data\list.txt";
            bindingSource1.DataSource = null;
            DBlistName.AutoGenerateColumns = false;
            reloadDataList();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void reloadDataList()
        {
            
            bindingSource1.DataSource = null;
            DBlistName.AutoGenerateColumns = false;
            List<ListName> lstContacts = Class1.GetList(pathListDataFile);
            if (lstContacts == null)
                throw new Exception("Chua co thong tin");
            else
            {
                bindingSource1.DataSource = lstContacts;
            }
            DBlistName.DataSource = bindingSource1;
        }

        private void ToolStripLabel1_Click(object sender, EventArgs e)
        {
            var listID = DBlistName.CurrentRow.Cells[0].Value.ToString();
            Class1.deleteContact(pathListDataFile, listID);
            DBlistName.Rows.RemoveAt(DBlistName.CurrentRow.Index);
            MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            //var NameList = bindingSource1.Current as ListName;
            //if (NameList != null)
            //{
            //    reloadDataList();
            //}
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            //var NameList = bindingSource1.Current as ListName;
            //if (NameList != null)
            //{
             //   reloadDataList();
            //}
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            string value = textBox1.Text;
            bindingSource1.DataSource = null;
            DBlistName.AutoGenerateColumns = false;
            List<Class1> lstSearchContacts = Class1.SearchContacts(pathListDataFile, value);
            if (lstSearchContacts == null)
                throw new Exception("Khong tim thay");
            else
            {
                bindingSource1.DataSource = lstSearchContacts;
            }
            DBlistName.DataSource = bindingSource1;
        }
    }
}
