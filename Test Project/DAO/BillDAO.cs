using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Project.DTO;

namespace Test_Project.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get
            {
                if (instance == null) instance = new BillDAO();
                return instance;
            }
            private set => instance = value;
        }

        private BillDAO()
        {
        }

        public void CheckOut(int id, int discount, float totalCost)
        {
            DataProvider.Instance.ExecuteNonQuery("UPDATE Bill SET Date_Out = GETDATE(), status = 1, " + "discount = " + discount + ", Total_Cost = " + totalCost + " WHERE ID = " + id);
        }

        public int GetUncheckBillIdByTableId(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM Bill WHERE Table_ID = " + id + " AND status = 0");

            if (data.Rows.Count > 0)
            {
                Bill bill = new(data.Rows[0]);
                return bill.ID;
            }

            return -1;
        }

        public void InsertBill(int id)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC USP_InsertBill @Table_ID", new object[] { id });
        }

        public int GetBiggestBillId()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(ID) FROM Bill");
            }
            catch
            {
                return 1;
            }
        }

        public DataTable GetBillByDateAndPage(DateTime checkIn, DateTime checkOut, int pageNum)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC USP_GetBillByDateAndPage @checkIn , @checkOut , @page", new object[] { checkIn, checkOut, pageNum });
        }

        public int GetNumBillByDate(DateTime checkIn, DateTime checkOut)
        {
            return (int)DataProvider.Instance.ExecuteScalar("EXEC USP_GetNumByDate @checkIn , @checkOut", new object[] { checkIn, checkOut });
        }
    }
}