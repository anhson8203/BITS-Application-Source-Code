using System.Text;
using Test_Project.DAO;
using Test_Project.DTO;
using Krypton.Toolkit;
using System.Security.Cryptography;

namespace Test_Project
{
    public partial class AccountProfile : KryptonForm
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get => loginAccount;
            set
            {
                loginAccount = value;
                ChangeAccount(LoginAccount);
            }
        }

        public AccountProfile(Account account)
        {
            InitializeComponent();

            LoginAccount = account;
        }

        void ChangeAccount(Account account)
        {
            txbUserName.Text = LoginAccount.UserName;
            txbDisplayedName.Text = LoginAccount.DisplayName;
        }

        void UpdateAccountInfo()
        {
            string displayName = txbDisplayedName.Text;
            string passWord = txbPassWord.Text;
            string newPassWord = txbNewPass.Text;
            string reEnterPass = txbReEnterPass.Text;
            string userName = txbUserName.Text;

            if (!newPassWord.Equals(reEnterPass))
            {
                MessageBox.Show("Not Mactching Password");
            }
            else
            {
                if (newPassWord != "" && reEnterPass != "")
                {
                    byte[] temp = Encoding.ASCII.GetBytes(newPassWord);
                    byte[] hashData = new MD5CryptoServiceProvider().ComputeHash(temp);
                    string hashPass = "";

                    foreach (byte b in hashData)
                    {
                        hashPass += b;
                    }

                    if (AccountDAO.Instance.UpdateAccountInfo(userName, displayName, passWord, hashPass))
                    {
                        MessageBox.Show("Update Successfully");
                        updateAccountInfo?.Invoke(this, new AccountEvent(AccountDAO.Instance.GetAccountByUserName(userName)));
                    }
                    else
                    {
                        MessageBox.Show("Wrong Password");
                    }
                }
                else
                {
                    if (AccountDAO.Instance.UpdateAccountInfo(userName, displayName, passWord, newPassWord))
                    {
                        MessageBox.Show("Update Successfully");
                        updateAccountInfo?.Invoke(this, new AccountEvent(AccountDAO.Instance.GetAccountByUserName(userName)));
                    }
                    else
                    {
                        MessageBox.Show("Wrong Password");
                    }
                }
            }
        }

        private event EventHandler<AccountEvent> updateAccountInfo;
        public event EventHandler<AccountEvent> UpdateAccount
        {
            add => updateAccountInfo += value;
            remove => updateAccountInfo -= value;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateAccountInfo();
        }
    }

    public class AccountEvent : EventArgs
    {
        private Account account;

        public Account Account
        {
            get => account;
            set => account = value;
        }

        public AccountEvent(Account account) => Account = account;
    }
}