using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Test_Project.DTO;

namespace Test_Project.DAO
{
    public class ItemDAO
    {
        private static ItemDAO instance;

        public static ItemDAO Instance
        {
            get
            {
                instance ??= new ItemDAO();
                return instance;
            }
            private set => instance = value;
        }

        private ItemDAO()
        {
        }

        public List<Item> GetItemByCategoryID(int id)
        {
            List<Item> list = new();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM Items WHERE Category_ID = " + id);

            foreach (DataRow row in data.Rows) 
            {
                Item item = new(row);
                list.Add(item);
            }

            return list;
        }

        public List<Item> GetItemsList()
        {
            List<Item> list = new();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM Items");

            foreach (DataRow row in data.Rows)
            {
                Item item = new(row);
                list.Add(item);
            }

            return list;
        }

        public List<Item> SearchItemByName(string name)
        {
            List<Item> list = new();
            string query = string.Format("SELECT * FROM Items WHERE dbo.fuConvertToUnsign1(name) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", name);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                Item item = new(row);
                list.Add(item);
            }

            return list;
        }

        public bool InsertItem(string name, int id, float price)
        {
            string query = string.Format("INSERT Items (name, Category_ID, price) VALUES (N'{0}', {1} , {2})", name, id, price);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool EditItem(int itemID, int id, string name, float price)
        {
            string query = string.Format("UPDATE Items SET name = N'{0}', Category_ID = {1}, price = {2} WHERE ID = {3}", name, id, price, itemID);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool DeleteItem(int itemID)
        {
            BillInfoDAO.Instance.DeleteBillInfoByItemID(itemID);
            int result = DataProvider.Instance.ExecuteNonQuery("DELETE Items WHERE ID = " + itemID);

            return result > 0;
        }
    }
}