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
    /// Interaction logic for WindowWorker.xaml
    /// </summary>
    public partial class WindowWorker : Window
    {
        Product[] products;
        public WindowWorker(Product[] products)
        {
            InitializeComponent();
            this.products = products;
            datagrid.ItemsSource = products;
        }

        private void BtnAddItem_Click(object sender, RoutedEventArgs e)
        {
            bool flag = false;
            for (int i = 0; i < 10; i++)
            {
                if (products[i].Name == "Empty")
                    flag = true;

            }

            if (flag == false)
                MessageBox.Show("All cell's are locked");
            else
            {
                AddWindow window = new AddWindow(products);
                if (window.ShowDialog().Value == true)
                {
                    XmlSerializer xml = new XmlSerializer(typeof(Product[]));
                    using (FileStream fs = new FileStream("Products.xml", FileMode.Open))
                    {
                        products = (Product[])xml.Deserialize(fs);
                    }
                }
            }
            datagrid.ItemsSource = null;
            datagrid.ItemsSource = products;
        }

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (datagrid.SelectedIndex < 11 && datagrid.SelectedIndex >= 0)
                products[datagrid.SelectedIndex] = new Product("Empty", 0, -1, 0);

            datagrid.ItemsSource = null;
            datagrid.ItemsSource = products;

            AddWindow.Serialize(products);
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            int profit;
            using (FileStream fs = new FileStream("profit.DAT", FileMode.OpenOrCreate))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    profit = sr.Read();
                }
            }



            if (datagrid.SelectedIndex < 11 && datagrid.SelectedIndex >= 0)
            {
                profit -= (int)products[datagrid.SelectedIndex].Hours * (int)products[datagrid.SelectedIndex].PricePerHour;

                EditWindow window = new EditWindow(datagrid.SelectedIndex, products);
                if (window.ShowDialog().Value == true)
                {
                    XmlSerializer xml = new XmlSerializer(typeof(Product[]));
                    using (FileStream fs = new FileStream("Products.xml", FileMode.Open))
                    {
                        products = (Product[])xml.Deserialize(fs);
                    }
                }


                profit += (int)products[datagrid.SelectedIndex].Hours * (int)products[datagrid.SelectedIndex].PricePerHour;

                using (FileStream fs = new FileStream("profit.DAT", FileMode.Create))
                {
                    using (StreamWriter sr = new StreamWriter(fs))
                    {
                        sr.Write(profit);
                    }
                }
            }
            datagrid.ItemsSource = null;
            datagrid.ItemsSource = products;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();

            this.Close();
        }
    }
}
