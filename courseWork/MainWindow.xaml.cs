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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace courseWork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Worker> workers = new List<Worker>();
        const int maxProducts = 10;
        static double profit = 0;

        Product []products = new Product[maxProducts];

        public MainWindow()
        {
            InitializeComponent();

            XmlSerializer xmll = new XmlSerializer(typeof(Product[]));

           

            using (FileStream fs = new FileStream("Products.xml", FileMode.Open))
            {
                products = (Product[])xmll.Deserialize(fs);
            }

            using (FileStream fs = new FileStream("profit.DAT",FileMode.OpenOrCreate))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    profit = sr.Read();
                }
            }

                XmlSerializer xml = new XmlSerializer(typeof(List<Worker>));


            using (FileStream fs = new FileStream("Workers.xml", FileMode.Open))
            {
                workers = (List<Worker>)xml.Deserialize(fs);
            }
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            for(int i=0;i<workers.Count;i++)
            {
                if (txtboxLogin.Text == workers[i].Login && txtboxPassword.Password == workers[i].Password)
                {
                    if(workers[i].Profession==Worker.Vocation.Manager)
                    {
                        Window1 window = new Window1(products);
                        window.Show();
                        this.Close();
                    }
                    else
                    {
                        WindowWorker window = new WindowWorker(products);
                        window.Show();

                        this.Close();
                    }
                }
                
            }
        }
    }
}
