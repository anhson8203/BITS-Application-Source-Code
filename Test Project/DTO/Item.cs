﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Project.DTO
{
    public class Item
    {
        public Item(int id, string name, int categoryID, float price)
        {
            this.ID = id;
            this.Name = name;
            this.CategoryID = categoryID;
            this.Price = price;
        }

        public Item(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.Name = row["name"].ToString();
            this.CategoryID = (int)row["Category_ID"];
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
        }

        private float price;
        private int categoryID;
        private string name;
        private int iD;

        public int ID
        {
            get => iD;
            set => iD = value;
        }
        public string Name
        {
            get => name;
            set => name = value;
        }
        public int CategoryID
        {
            get => categoryID;
            set => categoryID = value;
        }
        public float Price
        {
            get => price;
            set => price = value;
        }
    }
}