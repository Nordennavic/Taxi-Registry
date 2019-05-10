using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Taxi_Registry;

namespace TaxiRegistry.UI
{
    public partial class OrderForm : Form
    { 
        public Order order { get; set; }

        public OrderForm()
        {
            InitializeComponent();
            this.dateTimePicker1.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy HH:mm";
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = order.From;
            textBox2.Text = order.To;
            order.RideTime = DateTime.Today;
            dateTimePicker1.Value = order.RideTime;
            checkBox1.Checked = order.AdditionalTerms;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            order.From = textBox1.Text;
            order.To = textBox2.Text;
            order.RideTime = dateTimePicker1.Value;
            order.AdditionalTerms = checkBox1.Checked;
            switch (comboBox1.SelectedItem?.ToString())
            {
                case "Отменён":
                    order.Status = Order.OrderStatus.Cancelled;
                    break;
                case "Выполнен":
                    order.Status = Order.OrderStatus.Completed;
                    break;
            }

            switch (comboBox2.SelectedItem?.ToString())
            { 

                case "1":
                    order.Rating = Order.RideRating.One;
                break;
                case "2":
                    order.Rating = Order.RideRating.Two;
                    break;
                case "3":
                    order.Rating = Order.RideRating.Three;
                    break;
                case "4":
                    order.Rating = Order.RideRating.Four;
                    break;
                case "5":
                    order.Rating = Order.RideRating.Five;
                    break;
                case "нету":
                    order.Rating = Order.RideRating.none;
                    break;
            }
        }
    }
}
