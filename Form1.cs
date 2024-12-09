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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Student> students;
        private void Form1_Load(object sender, EventArgs e)
        {
            students = new List<Student>();
            students.Add(new Student() { Id = 1, HoTen = "A", Luong = 20000 });
            students.Add(new Student() { Id = 2, HoTen = "B", Luong = 30000 });
            students.Add(new Student() { Id = 3, HoTen = "C", Luong = 40000 });
            dtgvNhanvien.DataSource = students;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.OnAdd += Add;
            form2.ShowDialog();
            
        }
        private void Add(Student s)
        {
            students.Add(s);
            dtgvNhanvien.DataSource = null;
            dtgvNhanvien.DataSource = students; 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dtgvNhanvien.SelectedRows.Count > 0)
            {
                var selected = (Student)dtgvNhanvien.SelectedRows[0].DataBoundItem;
                Form2 form2 = new Form2(selected);
                form2.OnUpdate += Update;
                form2.ShowDialog();
            }
        }
        private void Update(Student s)
        {
            var studentUpdate = students.FirstOrDefault(st => s.Id == s.Id);
            if (studentUpdate != null)
            {
                studentUpdate.HoTen = s.HoTen;
                studentUpdate.Luong = s.Luong;
                dtgvNhanvien.DataSource = null;
                dtgvNhanvien.DataSource = students;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if (dtgvNhanvien.SelectedRows.Count > 0)
            {
                students.RemoveAt(dtgvNhanvien.SelectedRows[0].Index);
                dtgvNhanvien.DataSource = null;
                dtgvNhanvien.DataSource = students;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
