using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace BindingListWithDataSource
{
    public partial class Form1 : Form
    {
        private BindingList<Person> people = new BindingList<Person>();
        private BindingSource bindingSource = new BindingSource();

        public Form1()
        {
            InitializeComponent();

            // Gắn BindingList vào BindingSource
            bindingSource.DataSource = people;

            // Gắn BindingSource vào DataGridView
            dataGridView1.DataSource = bindingSource;

            // Thêm vài mẫu
            people.Add(new Person { Id = 1, Name = "Nguyen Van A", Age = 25 });
            people.Add(new Person { Id = 2, Name = "Tran Thi B", Age = 30 });
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Thêm mới thông qua people
            people.Add(new Person
            {
                Id = people.Count + 1,
                Name = "User " + (people.Count + 1),
                Age = 20 + people.Count
            });
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (bindingSource.Current is Person person)
            {
                // Xóa bằng BindingSource hoặc trực tiếp từ people
                bindingSource.Remove(person);
                // people.Remove(person); // cũng được
            }
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int Age { get; set; }
    }
}
