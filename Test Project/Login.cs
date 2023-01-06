using Krypton.Toolkit;
using Test_Project.DAO;
using Test_Project.DTO;

namespace Test_Project
{
    public partial class Login : KryptonForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string passWord = txbPassWord.Text;

            if (SuccessLogin(userName, passWord))
            {
                Account loginAccount = AccountDAO.Instance.GetAccountByUserName(userName);
                TableManager tableManager = new(loginAccount);
                Hide();
                tableManager.ShowDialog();
                Show();
            }
            else
            {
                MessageBox.Show("Wrong Username or Password");
            }
        }

        bool SuccessLogin(string userName, string passWord)
        {
            return AccountDAO.Instance.SuccessLogin(userName, passWord);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure to exit?", "Warning", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}