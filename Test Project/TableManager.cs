using Krypton.Toolkit;
using System.Globalization;
using Test_Project.DAO;
using Test_Project.DTO;

namespace Test_Project
{
    public partial class TableManager : KryptonForm
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get => loginAccount;
            set
            {
                loginAccount = value;
                ChangeAccount(loginAccount.Type);
            }
        }

        public TableManager(Account account)
        {
            InitializeComponent();

            LoginAccount = account;
            LoadTable();
            LoadCategory();
            LoadTableList(cbSwitchTable);
        }

        #region Methods
        void ChangeAccount(int type)
        {
            adminToolStripMenuItem.Enabled = type == 1;
            accountToolStripMenuItem.Text += " (" + LoginAccount.DisplayName + ")";
        }

        void LoadCategory()
        {
            List<Category> listCategory = CategoryDAO.Instance.GetCategoryList();
            cbCategory.DataSource = listCategory;
            cbCategory.DisplayMember = "Name";
        }

        void LoadItemListByCategoryID(int id)
        {
            List<Item> listItem = ItemDAO.Instance.GetItemByCategoryID(id);
            cbItems.DataSource = listItem;
            cbItems.DisplayMember = "Name";
        }

        void LoadTable()
        {
            flpTable.Controls.Clear();
            List<Table> tableList = TableDAO.Instance.LoadTableList();

            foreach (Table item in tableList)
            {
                Button btn = new()
                {
                    Width = TableDAO.TableWidth,
                    Height = TableDAO.TableHeight,
                    Text = item.Name + "\n" + item.Status
                };
                btn.Click += btn_Click;
                btn.Tag = item;

                btn.BackColor = item.Status switch
                {
                    "Empty" => Color.SandyBrown,
                    _ => ColorTranslator.FromHtml("#BFCDDB"),
                };
                flpTable.Controls.Add(btn);
            }
        }

        void ShowBill(int id)
        {
            lsvBill.Items.Clear();
            float totalCost = 0;
            List<Menu> listBillInfo = MenuDAO.Instance.GetListMenuByTable(id);
            CultureInfo culture = new("en-US");
            Thread.CurrentThread.CurrentCulture = culture;

            foreach (Menu item in listBillInfo)
            {
                ListViewItem lsvItem = new(item.ItemName.ToString());
                lsvItem.SubItems.Add(item.Quantity.ToString());
                lsvItem.SubItems.Add(item.Price.ToString("c"));
                lsvItem.SubItems.Add(item.TotalCost.ToString("c"));
                totalCost += item.TotalCost;

                lsvBill.Items.Add(lsvItem);
            }
            txbTotalCost.Text = totalCost.ToString("c");
        }

        void LoadTableList(ComboBox comboBox)
        {
            comboBox.DataSource = TableDAO.Instance.LoadTableList();
            comboBox.DisplayMember = "Name";
        }

        #endregion

        #region Events
        void btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).ID;
            lsvBill.Tag = (sender as Button).Tag;

            ShowBill(tableID);
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void accountInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountProfile accountProfile = new(LoginAccount);
            accountProfile.UpdateAccount += accountProfile_UpdateAccount;
            accountProfile.ShowDialog();
        }

        void accountProfile_UpdateAccount(object sender, AccountEvent e)
        {
            accountToolStripMenuItem.Text = "Account (" + e.Account.DisplayName + ")";
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin admin = new();
            admin.currentAccount = LoginAccount;
            admin.DeleteItem += Admin_DeleteItem;
            admin.EditItem += Admin_EditItem;
            admin.ShowDialog();
        }

        private void Admin_EditItem(object? sender, EventArgs e)
        {
            LoadItemListByCategoryID((cbCategory.SelectedItem as Category).ID);
            if (lsvBill.Tag != null)
            {
                ShowBill((lsvBill.Tag as Table).ID);
            }
        }

        private void Admin_DeleteItem(object? sender, EventArgs e)
        {
            LoadItemListByCategoryID((cbCategory.SelectedItem as Category).ID);
            if (lsvBill.Tag != null)
            {
                ShowBill((lsvBill.Tag as Table).ID);
            }
            LoadTable();
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id;
            ComboBox comboBox = sender as ComboBox;

            if (comboBox.SelectedItem == null)
            {
                return;
            }

            Category selected = comboBox.SelectedItem as Category;
            id = selected.ID;

            LoadItemListByCategoryID(id);
        }

        private void btnAddItems_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;

            if (table == null)
            {
                MessageBox.Show("No Table selected");
                return;
            }

            int bill_ID = BillDAO.Instance.GetUncheckBillIdByTableId(table.ID);
            int item_ID = (cbItems.SelectedItem as Item).ID;
            int quantity = (int)nmItemsCount.Value;

            if (bill_ID == -1)
            {
                BillDAO.Instance.InsertBill(table.ID);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetBiggestBillId(), item_ID, quantity);
            }
            else
            {
                BillInfoDAO.Instance.InsertBillInfo(bill_ID, item_ID, quantity);
            }

            ShowBill(table.ID);
            LoadTable();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;
            int billID = BillDAO.Instance.GetUncheckBillIdByTableId(table.ID);
            int discount = (int)nmDiscount.Value;
            double totalTemp = Convert.ToDouble(txbTotalCost.Text.TrimStart('$'));
            double totalCost = totalTemp - (totalTemp / 100) * discount;

            if (billID != -1)
            {
                if (MessageBox.Show(string.Format("Checking out for {0}\nTotal cost (after discount {1}%): {2:C2}", table.Name, discount, totalCost), "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    BillDAO.Instance.CheckOut(billID, discount, (float)totalCost);

                    ShowBill(table.ID);
                    LoadTable();
                }
            }
        }

        private void btnSwitchTable_Click(object sender, EventArgs e)
        {
            int firstID = (lsvBill.Tag as Table).ID;
            int secondID = (cbSwitchTable.SelectedItem as Table).ID;

            if (MessageBox.Show(string.Format("Are you sure to switch from {0} to {1} ?", (lsvBill.Tag as Table).Name, (cbSwitchTable.SelectedItem as Table).Name), "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                TableDAO.Instance.SwitchTable(firstID, secondID);
                LoadTable();
            }
        }

        #endregion
    }
}