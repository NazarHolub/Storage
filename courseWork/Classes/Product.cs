using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courseWork.Classes
{
    [Serializable]
    public class Product
    {
        public string Name { get; set; }
        public double Square { get; set; }
        public DateTime Date { get; set; }
        public double Hours { get; set; }
        public double PricePerHour { get; set; }

        public Product(string name,double square,double hours,double price)
        {
            Name = name;
            Square = square;
            Hours = hours;
            PricePerHour = price;
            Date = DateTime.Now;
        }

        public Product()
        {

        }
    }
}
