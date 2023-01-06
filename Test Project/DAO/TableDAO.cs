using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Project.DTO;

namespace Test_Project.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;

        public static TableDAO Instance
        {
            get
            {
                if (instance == null) instance = new TableDAO();
                return instance;
            }
            private set => instance = value;
        }

        public static int TableWidth = 88;
        public static int TableHeight = 88;

        private TableDAO()
        {
        }

        public List<Table> LoadTableList()
        {
            List<Table> tableList = new();

            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetTableList");

            foreach (DataRow item in data.Rows)
            {
                Table table = new(item);
                tableList.Add(table);
            }

            return tableList;
        }

        public void SwitchTable(int firtsID, int sencondID)
        {
            DataProvider.Instance.ExecuteQuery("USP_SwitchTable @firstTableId , @secondTableId", new object[] { firtsID, sencondID });
        }

        public List<Table> ObtainTablesList()
        {
            List<Table> list = new();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM Customer_Table");

            foreach (DataRow row in data.Rows)
            {
                Table table = new(row);
                list.Add(table);
            }

            return list;
        }
    }
}