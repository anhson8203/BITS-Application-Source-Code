using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Project.DTO;

namespace Test_Project.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instance;

        public static MenuDAO Instance
        {
            get
            {
                if (instance == null) instance = new MenuDAO();
                return instance;
            }
            private set => instance = value;
        }

        private MenuDAO()
        {
        }

        public List<Menu> GetListMenuByTable(int id)
        {
            List<Menu> listMenu = new();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT i.name, bi.quantity, i.price, i.price * bi.quantity AS totalCost FROM Bill_Info AS bi, Bill AS b, Items AS i WHERE bi.Bill_ID  = b.ID AND bi.Items_ID = i.ID AND b.status = 0 AND b.Table_ID = " + id);

            foreach(DataRow row in data.Rows)
            {
                Menu menu = new(row);
                listMenu.Add(menu);
            }

            return listMenu;
        }
    }
}