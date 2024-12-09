using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form2 : Form
    {
        public Form2(Student edit = null)
        {
            InitializeComponent();
            if (edit != null)
            {
                Load(edit);
            }
        }
        public delegate void AddStudentHandler(Student student);
        public event AddStudentHandler OnAdd;
        public event AddStudentHandler OnUpdate;
        public Student EditStudent { get; set; }

        private void Load(Student edit)
        {
            EditStudent = edit;
            txtMSSV.Text = EditStudent.Id.ToString();
            txtTenNhanVien.Text = EditStudent.HoTen;
            txtLuongCanBan.Text = EditStudent.Luong.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Student student = new Student
            {
                Id = int.Parse(txtMSSV.Text),
                HoTen = txtTenNhanVien.Text,
                Luong = float.Parse(txtLuongCanBan.Text)
            };
            if (EditStudent != null)
            {
                student.Id = EditStudent.Id;
                OnUpdate?.Invoke(student);
            }
            else
            {
                OnAdd?.Invoke(student);
            }

            this.Close();
        }
    }
}
