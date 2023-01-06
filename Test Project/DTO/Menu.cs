using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Project.DTO
{
    public class Menu
    {
        public Menu(string itemName, int quantity, float price, float totalCost = 0)
        {
            this.ItemName = itemName;
            this.Quantity = quantity;
            this.Price = price;
            this.TotalCost = totalCost;
        }

        public Menu(DataRow row)
        {
            this.ItemName = row["Name"].ToString();
            this.Quantity = (int)row["quantity"];
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
            this.TotalCost = (float)Convert.ToDouble(row["totalCost"].ToString());
        }

        private float totalCost;
        private float price;
        private int quantity;
        private string itemName;

        public string ItemName
        {
            get => itemName;
            set => itemName = value;
        }
        public int Quantity
        {
            get => quantity;
            set => quantity = value;
        }
        public float TotalCost
        {
            get => totalCost;
            set => totalCost = value;
        }
        public float Price
        {
            get => price;
            set => price = value;
        }
    }
}