using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Project.DTO
{
    public class BillInfo
    {
        public BillInfo(int id, int billID, int itemID, int quantity)
        {
            this.ID = id;
            this.BillID = billID;
            this.ItemID = itemID;
            this.Quantity = quantity;
        }

        public BillInfo(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.BillID = (int)row["Bill_ID"];
            this.ItemID = (int)row["Items_ID"];
            this.Quantity = (int)row["quantity"];
        }

        private int quantity;
        private int itemID;
        private int billID;
        private int iD;

        public int ID
        {
            get => iD;
            set => iD = value;
        }
        public int BillID
        {
            get => billID;
            set => billID = value;
        }
        public int ItemID
        {
            get => itemID;
            set => itemID = value;
        }
        public int Quantity
        {
            get => quantity;
            set => quantity = value;
        }
    }
}