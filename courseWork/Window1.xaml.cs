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

namespace courseWork
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        Product[] products;
        List<Product> list = new List<Product>();

        public Window1(Product[]prod)
        {
            products = prod;
            InitializeComponent();

            using (FileStream fs = new FileStream("profit.DAT", FileMode.OpenOrCreate))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    lblProfit.Content = sr.Read();
                }
            }
            
        }

        private void BtnPromiser_Click(object sender, RoutedEventArgs e)
        {
            list.Clear();
            for(int i=0;i<10;i++)
            {
               

                if (products[i].Name!="Empty" && products[i].Date <= DateTime.Now.AddHours(-products[i].Hours))
                {
                 
                    list.Add(products[i]);
                }
            }
            datagrid.ItemsSource = list;
        }

        private void BtnFreeSpace_Click(object sender, RoutedEventArgs e)
        {
            list.Clear();

            for(int i=0;i<10;i++)
            {
                if(products[i].Name=="Empty")
                {
                    list.Add(products[i]);
                }
            }

            datagrid.ItemsSource = list;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();

            this.Close();
        }
    }
}
