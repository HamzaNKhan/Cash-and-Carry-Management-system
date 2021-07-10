using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Supermarket_Mangment_System
{
    public class InvoiceItems 
    {
        private string serial;
        private string name ;
        private int qty ;
        private string discount ;
        private int price;

        public InvoiceItems()
        {
            serial = "";
            name = "";
            Qty = 1;
            discount = "";
            price = 0;
    }

        public string Serial { get => serial; set => serial = value; }
        public string Name { get => name; set => name = value; }
        
        public string Discount { get => discount; set => discount = value; }
        public int Price { get => price; set => price = value; }
        public int Qty { get => qty; set => qty = value; }

        
    }

}

