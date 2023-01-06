using Krypton.Toolkit;
using Test_Project.DAO;
using Test_Project.DTO;

namespace Test_Project
{
    public partial class Admin : KryptonForm
    {
        BindingSource itemList = new();
        BindingSource accountList = new();
        BindingSource categoryList = new();
        BindingSource tableList = new();

        public Account currentAccount;

        public Admin()
        {
            InitializeComponent();
            LoadData();
        }

        #region Methods
        void LoadData()
        {
            dtgvItems.DataSource = itemList;
            dtgvAccount.DataSource = accountList;
            dtgvCategory.DataSource = categoryList;
            dtgvTable.DataSource = tableList;

            LoadDatePickerBill();
            LoadBillByDate(dtpFromDate.Value, dtpToDate.Value);
            LoadItemsList();
            LoadItemCategory(cbCategory);
            LoadAccountList();
            LoadCategoryList();
            LoadTableList();

            ItemBinding();
            AccountBinding();
            CategoryBinding();
            TableBinding();
        }

        void LoadBillByDate(DateTime checkIn, DateTime checkOut)
        {
            dtgvBill.DataSource = BillDAO.Instance.GetBillByDateAndPage(checkIn, checkOut, 1);
            dtgvBill.Columns["ID"].Visible = false;
        }

        void LoadDatePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpFromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpToDate.Value = dtpFromDate.Value.AddMonths(1).AddDays(-1);
        }

        void LoadItemsList()
        {
            itemList.DataSource = ItemDAO.Instance.GetItemsList();

            dtgvItems.Columns[0].Visible = false;
            dtgvItems.Columns[1].Width = 190;
            dtgvItems.Columns[2].Visible = false;
        }

        void ItemBinding()
        {
            txbItemName.DataBindings.Add(new Binding("Text", dtgvItems.DataSource, "name", true, DataSourceUpdateMode.Never));
            txbItemId.DataBindings.Add(new Binding("Text", dtgvItems.DataSource, "ID", true, DataSourceUpdateMode.Never));
            nmItemPrice.DataBindings.Add(new Binding("Value", dtgvItems.DataSource, "price", true, DataSourceUpdateMode.Never));
        }

        void LoadItemCategory(ComboBox comboBox)
        {
            comboBox.DataSource = CategoryDAO.Instance.GetCategoryList();
            comboBox.DisplayMember = "name";
        }

        List<Item> SearchItemByName(string name)
        {
            List<Item> itemList = ItemDAO.Instance.SearchItemByName(name);

            return itemList;
        }

        void LoadAccountList()
        {
            accountList.DataSource = AccountDAO.Instance.GetAccountList();
        }

        void AccountBinding()
        {
            txbUserName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "Username", true, DataSourceUpdateMode.Never));
            txbDisplayedName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "Name", true, DataSourceUpdateMode.Never));
            nmAccountType.DataBindings.Add(new Binding("Value", dtgvAccount.DataSource, "Account Type", true, DataSourceUpdateMode.Never));
        }

        void LoadCategoryList()
        {
            categoryList.DataSource = CategoryDAO.Instance.GetCategoryList();
            dtgvCategory.Columns[0].Visible = false;
        }

        void CategoryBinding()
        {
            txbCategoryID.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txbCategoryName.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "name", true, DataSourceUpdateMode.Never));
        }

        void LoadTableList()
        {
            tableList.DataSource = TableDAO.Instance.ObtainTablesList();
        }

        void TableBinding()
        {
            txbTableID.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txbTableName.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "name", true, DataSourceUpdateMode.Never));
        }

        #endregion

        #region Events
        private void btnViewBill_Click(object sender, EventArgs e)
        {
            LoadBillByDate(dtpFromDate.Value, dtpToDate.Value);
        }

        private void btnShowItems_Click(object sender, EventArgs e)
        {
            LoadItemsList();
        }

        private void txbItemId_TextChanged(object sender, EventArgs e)
        {
            if (dtgvItems.SelectedCells.Count > 0)
            {
                int id = (int)dtgvItems.SelectedCells[0].OwningRow.Cells["CategoryID"].Value;

                Category category = CategoryDAO.Instance.GetCategoryByID(id);

                cbCategory.SelectedItem = category;

                int index = -1;
                int i = 0;

                foreach (Category item in cbCategory.Items)
                {
                    if (item.ID == category.ID)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }

                cbCategory.SelectedIndex = index;
            }
        }

        private void btnAddItems_Click(object sender, EventArgs e)
        {
            AddingItems addItems = new();
            addItems.ShowDialog();
        }

        private void btnEditItems_Click(object sender, EventArgs e)
        {
            string name = txbItemName.Text;
            int categoryID = (cbCategory.SelectedItem as Category).ID;
            float price = (float)nmItemPrice.Value;
            int id = Convert.ToInt16(txbItemId.Text);

            if (ItemDAO.Instance.EditItem(id, categoryID, name, price))
            {
                MessageBox.Show("Edit Successfully");
                LoadItemsList();

                editItem?.Invoke(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Something went wrong. Please try again");
            }
        }

        private void btnDeleteItems_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(txbItemId.Text);

            if (ItemDAO.Instance.DeleteItem(id))
            {
                MessageBox.Show("Delete Successfully");
                LoadItemsList();

                deleteItem?.Invoke(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Something went wrong. Please try again");
            }
        }

        private event EventHandler insertItem;
        public event EventHandler InsertItem
        {
            add => insertItem += value;
            remove => insertItem -= value;
        }

        private event EventHandler deleteItem;
        public event EventHandler DeleteItem
        {
            add => deleteItem += value;
            remove => deleteItem -= value;
        }

        private event EventHandler editItem;
        public event EventHandler EditItem
        {
            add => editItem += value;
            remove => editItem -= value;
        }

        private void btnSearchItems_Click(object sender, EventArgs e)
        {
            itemList.DataSource = SearchItemByName(txbSearchItem.Text);
        }

        private void btnShowAccount_Click(object sender, EventArgs e)
        {
            LoadAccountList();
        }

        private void btnShowCategory_Click(object sender, EventArgs e)
        {
            LoadCategoryList();
        }

        private void btnShowTable_Click(object sender, EventArgs e)
        {
            LoadTableList();
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            AddingAccount addAccount = new();
            addAccount.ShowDialog();
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;

            if (!currentAccount.UserName.Equals(userName))
            {
                if (AccountDAO.Instance.DeleteAccount(userName))
                {
                    MessageBox.Show("Delete Successfully");
                }
                else
                {
                    MessageBox.Show("Something went wrong. Please try again");
                }

                LoadAccountList();
            }
            else
            {
                MessageBox.Show("Cannot delete the currently logging in account");
                return;
            }
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string displayName = txbDisplayedName.Text;
            int type = (int)nmAccountType.Value;

            if (AccountDAO.Instance.EditAccount(userName, displayName, type))
            {
                MessageBox.Show("Edit Successfully");
            }
            else
            {
                MessageBox.Show("Something went wrong. Please try again");
            }

            LoadAccountList();
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;

            if (AccountDAO.Instance.ResetPassword(userName))
            {
                MessageBox.Show(string.Format("Reset Password for account {0} Successfully\nThe default password is 1", userName));
            }
            else
            {
                MessageBox.Show("Something went wrong. Please try again");
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            nmPage.Value = 1;
            dtgvBill.Columns["ID"].Visible = false;
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            int totalRecords = BillDAO.Instance.GetNumBillByDate(dtpFromDate.Value, dtpToDate.Value);
            int lastPage = totalRecords / 10;

            if (totalRecords % 10 != 0)
            {
                lastPage++;
            }
            nmPage.Value = lastPage;

            dtgvBill.Columns["ID"].Visible = false;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            int currentPage = Convert.ToInt32(nmPage.Value);

            if (currentPage > 1)
            {
                currentPage--;
            }
            nmPage.Value = currentPage;

            dtgvBill.Columns["ID"].Visible = false;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int currentPage = Convert.ToInt32(nmPage.Value);
            int totalRecords = BillDAO.Instance.GetNumBillByDate(dtpFromDate.Value, dtpToDate.Value);

            if (currentPage <= totalRecords / 10)
            {
                currentPage++;
            }
            nmPage.Value = currentPage;

            dtgvBill.Columns["ID"].Visible = false;
        }

        private void nmPage_ValueChanged(object sender, EventArgs e)
        {
            int totalRecords = BillDAO.Instance.GetNumBillByDate(dtpFromDate.Value, dtpToDate.Value);
            int lastPage = totalRecords / 10;
            dtgvBill.DataSource = BillDAO.Instance.GetBillByDateAndPage(dtpFromDate.Value, dtpToDate.Value, Convert.ToInt16(nmPage.Value));

            if (totalRecords % 10 != 0)
            {
                lastPage++;
            }
            nmPage.Maximum = lastPage;
        }

        #endregion
    }
}