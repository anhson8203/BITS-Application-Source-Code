using Krypton.Toolkit;
using Test_Project.DAO;
using Test_Project.DTO;

namespace Test_Project
{
    public partial class AddingItems : KryptonForm
    {
        public AddingItems()
        {
            InitializeComponent();
            LoadData();
        }

        #region Methods
        void LoadData()
        {
            LoadItemCategoryList(cbCategory);
        }

        void LoadItemCategoryList(ComboBox comboBox)
        {
            comboBox.DataSource = CategoryDAO.Instance.GetCategoryList();
            comboBox.DisplayMember = "name";
        }

        #endregion

        #region Events
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txbItemName.Text;
            int categoryID = (cbCategory.SelectedItem as Category).ID;
            float price = (float)nmItemPrice.Value;

            if (name != "" && price > 0.00)
            {
                if (ItemDAO.Instance.InsertItem(name, categoryID, price))
                {
                    MessageBox.Show("Added item Successfully");
                }
                else
                {
                    MessageBox.Show("Something went wrong. Please try again");
                }
            }
            else if (name == "")
            {
                MessageBox.Show("Item Name cannot be blank");
            }
            else if (price <= 0)
            {
                MessageBox.Show("Item Price must be greater than 0");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}