using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Project.DTO
{
    public class Bill
    {
        public Bill(int id, DateTime? dateCheckIn, DateTime? dateCheckOut, int status, int discount = 0)
        {
            this.ID = id;
            this.DateCheckIn = dateCheckIn;
            this.DateCheckOut = dateCheckOut;
            this.Status = status;
            this.Discount = discount;
        }

        public Bill(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.DateCheckIn = (DateTime?)row["Date_In"];

            var dateCheckOutTemp = row["Date_Out"];
            if (dateCheckOutTemp.ToString() != "")
            {
                this.DateCheckOut = (DateTime?)dateCheckOutTemp;
            }

            this.Status = (int)row["status"];
            if (row["DISCOUNT"].ToString() != "")
            {
                this.Discount = (int)row["discount"];
            }
        }

        private int discount;
        private int status;
        private DateTime? dateCheckOut;
        private DateTime? dateCheckIn;
        private int iD;

        public int ID
        {
            get => iD;
            set => iD = value;
        }
        public DateTime? DateCheckIn
        {
            get => dateCheckIn;
            set => dateCheckIn = value;
        }
        public DateTime? DateCheckOut
        {
            get => dateCheckOut;
            set => dateCheckOut = value;
        }
        public int Status
        {
            get => status;
            set => status = value;
        }
        public int Discount
        {
            get => discount;
            set => discount = value;
        }
    }
}