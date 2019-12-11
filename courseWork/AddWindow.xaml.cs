using courseWork.Classes;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Serialization;

namespace courseWork
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        Product[] products = new Product[10];
        public AddWindow(Product[] prod)
        {
            this.products = prod;
            InitializeComponent();


        }

        static public void Serialize(Product[] prod)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Product[]));
            using (FileStream fs = new FileStream("Products.xml", FileMode.Create))
            {
                formatter.Serialize(fs, prod);
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            int pricePerHour = 0, hour = 0, square = 0;

            if (int.TryParse(txtboxPricePerHour.Text, out pricePerHour) && int.TryParse(txtboxHour.Text, out hour) &&
                int.TryParse(txtboxSquare.Text, out square) &&
                    pricePerHour > 0
                    && hour > 0
                    && square > 0
                    && txtboxName.Text != null)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (products[i].Name == "Empty")
                    {
                        Product prod = new Product();
                        prod.Hours = Convert.ToDouble(txtboxHour.Text);
                        prod.Name = txtboxName.Text;
                        prod.PricePerHour = Convert.ToDouble(txtboxPricePerHour.Text);
                        prod.Square = Convert.ToDouble(txtboxSquare.Text);
                        prod.Date = DateTime.Now;

                        products[i] = prod;
                        int profit;
                        using (FileStream fs = new FileStream("profit.DAT", FileMode.OpenOrCreate))
                        {
                            using (StreamReader sr = new StreamReader(fs))
                            {
                                profit = sr.Read();
                            }

                        }
                        using (FileStream fs = new FileStream("profit.DAT", FileMode.Create))
                        {
                            using (StreamWriter sr = new StreamWriter(fs))
                            {
                                sr.Write(profit + prod.PricePerHour * prod.Hours);
                            }

                        }
                        AddWindow.Serialize(products);
                    this.DialogResult = true;
                    this.Close();
                        break;
                    }
                    
                }
            }
            
        }

    }
}
