using System;
using System.Windows.Forms;
using Taxi_Registry;
using System.Drawing;
using System.Drawing.Imaging;
namespace TaxiRegistry.UI
{
    public partial class TaxiForm : Form
    {
        public TaxiForm()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button3.Enabled = listBox1.SelectedItem is Order;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var of = new OrderForm() { order = new Order() };
            if (of.ShowDialog(this) == DialogResult.OK)
            {
                listBox1.Items.Add(of.order);
            }
        }

        private void pictureButton_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Filter = "Фотография|*.jpg" };
            var dr = ofd.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is Order)
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.listBox1.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                var item = (Order)listBox1.Items[index];
                var ff = new OrderForm() { order = item };
                if (ff.ShowDialog(this) == DialogResult.OK)
                {
                    listBox1.Items.Remove(item);
                    listBox1.Items.Insert(index, item);
                }
            }
        }
    }
}
