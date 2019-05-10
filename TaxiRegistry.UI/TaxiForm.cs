using System;
using System.Windows.Forms;
using Taxi_Registry;
using System.Drawing;
using System.Linq;
using System.Drawing.Imaging;
using System.Xml.Serialization;
using System.IO;

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
            var ofd = new OpenFileDialog() { Filter = "Jpeg|*.jpeg|Jpg|*.jpg|Png|*.png" };
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

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog() { Filter = "Такси|*.taxi" };
            if (sfd.ShowDialog(this) != DialogResult.OK)
                return;

            var driver = new Driver()
            {
                Name = textBox7.Text,
                Surname = textBox8.Text,
                MiddleName = textBox9.Text,
                DateOfBirth = dateTimePicker1.Value,
                LicenseNumber = int.Parse(textBox10.Text),
                DriverRating = CalculateRating(),
                CompletedOrdersCount = CalculateCompleted(),
            };

            var taxi = new Taxi()
            {
                Model = textBox1.Text,
                Color = textBox2.Text,
                RegistrationPlate = textBox3.Text,
                VehicleLicense = int.Parse(textBox5.Text + textBox6.Text),
                Driver = driver,
                BabyChair = checkBox1.Checked,
                Orders = listBox1.Items.OfType<Order>().ToList(),
            };

            var stream = new MemoryStream();
            pictureBox1.Image.Save(stream, ImageFormat.Jpeg);
            taxi.Photo = stream.ToArray();

            switch (comboBox1.SelectedValue?.ToString())
            {
                case "Эконом":
                    taxi.Type = TaxiType.Econom;
                    break;
                case "Комфорт":
                    taxi.Type = TaxiType.Comfort;
                    break;
                case "Бизнес":
                    taxi.Type = TaxiType.Business;
                    break;
                default:
                    taxi.Type = TaxiType.Cargo;
                    break;
            }

            var xs = new XmlSerializer(typeof(Taxi));
            var file = File.Create(sfd.FileName);
            xs.Serialize(file, taxi);
            file.Close();
        }
        public double CalculateRating()
        {
            double a = 0;
            foreach (var e in listBox1.Items.OfType<Order>().Where(x =>
              x.Status == Order.OrderStatus.Completed))
                a += (int)e.Rating;
            return (a / listBox1.Items.OfType<Order>().Where(x =>
              x.Status == Order.OrderStatus.Completed && (int)x.Rating > 0).Count());
        }

        public int CalculateCompleted()
        {
            return listBox1.Items.OfType<Order>().Where(x =>
              x.Status == Order.OrderStatus.Completed).Count();
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Filter = "Такси|*.taxi" };

            if (ofd.ShowDialog(this) != DialogResult.OK)
                return;
            var xs = new XmlSerializer(typeof(Taxi));
            var file = File.OpenRead(ofd.FileName);
            var taxi = (Taxi)xs.Deserialize(file);
            file.Close();
            var driver = taxi.Driver;
            textBox1.Text = taxi.Model;
            textBox2.Text = taxi.Color;
            checkBox1.Checked = taxi.BabyChair;
            textBox3.Text = taxi.RegistrationPlate;
            if (taxi.VehicleLicense.ToString().Length > 3)
                textBox5.Text = taxi.VehicleLicense.ToString().Substring(0, 4);
            else textBox5.Text = "";
            if (taxi.VehicleLicense.ToString().Length > 4)
                textBox6.Text = taxi.VehicleLicense.ToString().Substring(5);
            else textBox5.Text = "";
            textBox4.Text = driver.Name + " " + driver.Surname + " " + driver.MiddleName;
            textBox7.Text = driver.Name;
            textBox8.Text = driver.Surname;
            textBox9.Text = driver.MiddleName;
            dateTimePicker1.Value = driver.DateOfBirth;
            textBox10.Text = driver.LicenseNumber.ToString();
            textBox11.Text = driver.DriverRating.ToString();
            textBox12.Text = driver.CompletedOrdersCount.ToString();

            var ms = new MemoryStream(taxi.Photo);
            pictureBox1.Image = Image.FromStream(ms);

            listBox1.Items.Clear();
            foreach (var order in taxi.Orders)
            {
                listBox1.Items.Add(order);
            }

            switch (taxi.Type)
            {
                case TaxiType.Business:
                    comboBox1.Text = "Бизнес";
                    break;
                case TaxiType.Cargo:
                    comboBox1.Text = "Грузовое";
                    break;
                case TaxiType.Comfort:
                    comboBox1.Text = "Комфорт";
                    break;
                case TaxiType.Econom:
                    comboBox1.Text = "Эконом";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
