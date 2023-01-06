using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Project.DTO;

namespace Test_Project.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;

        public static CategoryDAO Instance
        {
            get
            {
                if (instance == null) instance = new CategoryDAO();
                return instance;
            }
            private set => instance = value;
        }

        private CategoryDAO()
        {
        }

        public List<Category> GetCategoryList()
        {
            List<Category> list = new();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM Items_Category");

            foreach (DataRow row in data.Rows)
            {
                Category category = new(row);
                list.Add(category);
            }

            return list;
        }

        public Category GetCategoryByID(int id)
        {
            Category category = null;

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM Items_Category WHERE ID = " + id);

            foreach (DataRow row in data.Rows)
            {
                category = new(row);
                return category;
            }

            return category;
        }
    }
}