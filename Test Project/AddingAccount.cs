using Krypton.Toolkit;
using Test_Project.DAO;

namespace Test_Project
{
    public partial class AddingAccount : KryptonForm
    {
        public AddingAccount()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string displayName = txbDisplayName.Text;
            int type = (int)nmAccountType.Value;

            if (userName != "" && displayName != "")
            {
                if (AccountDAO.Instance.InsertAccount(userName, displayName, type))
                {
                    MessageBox.Show("Add Successfully\nThe default password is 1");
                }
                else
                {
                    MessageBox.Show("Something went wrong. Please try again");
                }
            }
            else
            {
                MessageBox.Show("Username and Name cannot be blank");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}