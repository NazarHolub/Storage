using courseWork.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace courseWork
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        Product[] products;
        int index;
        public EditWindow(int index,Product[]prod)
        {
            InitializeComponent();
            products = prod;
            this.index = index;

            txtboxHour.Text = prod[index].Hours.ToString();
            txtboxName.Text = prod[index].Name.ToString();
            txtboxPricePerHour.Text = prod[index].PricePerHour.ToString();
            txtboxSquare.Text = prod[index].Square.ToString();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            int pricePerHour = 0, hour = 0, square = 0;

            if (int.TryParse(txtboxPricePerHour.Text, out pricePerHour) && int.TryParse(txtboxHour.Text, out hour) &&
                int.TryParse(txtboxSquare.Text, out square) &&
                    pricePerHour > 0
                    && hour > 0
                    && square > 0
                    && txtboxName.Text != null
                    )
            {

                if (products[index].Name != "Empty")
                {
                    Product prod = new Product();
                    prod.Hours = Convert.ToDouble(txtboxHour.Text);
                    prod.Name = txtboxName.Text;
                    prod.PricePerHour = Convert.ToDouble(txtboxPricePerHour.Text);
                    prod.Square = Convert.ToDouble(txtboxSquare.Text);
                    prod.Date = DateTime.Now;

                    products[index] = prod;
                    
                }
                
                AddWindow.Serialize(products);
            }
            else
            {
                MessageBox.Show("error");
                
                this.Close();

                return;
            }
            this.DialogResult = true;
            this.Close();
        }
    }
}
