using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Project.DTO;

namespace Test_Project.DAO
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;

        public static BillInfoDAO Instance
        {
            get
            {
                if (instance == null) instance = new BillInfoDAO();
                return instance;
            }
            private set => instance = value;
        }

        private BillInfoDAO()
        {
        }

        public List<BillInfo> GetBillInfoList(int id)
        {
            List<BillInfo> listBillInfo = new();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM Bill_Info WHERE Bill_ID = " + id);

            foreach (DataRow item in data.Rows)
            {
                BillInfo info = new(item);
                listBillInfo.Add(info);
            }

            return listBillInfo;
        }

        public void DeleteBillInfoByItemID(int id)
        {
            DataProvider.Instance.ExecuteQuery("DELETE Bill_Info WHERE Items_ID = " + id);
        }

        public void InsertBillInfo(int bill_ID, int items_ID, int quantity)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC USP_InsertBillInfo @Bill_ID , @Items_ID , @quantity", new object[] { bill_ID, items_ID, quantity });
        }
    }
}