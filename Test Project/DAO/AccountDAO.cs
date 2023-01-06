using System.Data;
using System.Security.Cryptography;
using System.Text;
using Test_Project.DTO;

namespace Test_Project.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get
            {
                instance ??= new AccountDAO();
                return instance;
            }
            private set => instance = value;
        }

        private AccountDAO()
        {
        }

        public bool SuccessLogin(string userName, string passWord)
        {
            byte[] temp = Encoding.ASCII.GetBytes(passWord);
            byte[] hashData = new MD5CryptoServiceProvider().ComputeHash(temp);
            string hashPass = "";

            foreach (byte b in hashData)
            {
                hashPass += b;
            }

            string query = "USP_Login @userName , @passWord";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, hashPass });

            return result.Rows.Count > 0;
        }

        public bool UpdateAccountInfo(string userName, string displayName, string passWord, string newPassWord)
        {
            byte[] temp = Encoding.ASCII.GetBytes(passWord);
            byte[] hashData = new MD5CryptoServiceProvider().ComputeHash(temp);
            string hashPass = "";

            foreach (byte b in hashData)
            {
                hashPass += b;
            }

            int result = DataProvider.Instance.ExecuteNonQuery("EXEC USP_UpdateAccountInfo @userName , @displayName , @passWord , @newPassWord", new object[] { userName, displayName, hashPass, newPassWord });
            
            return result > 0;
        }

        public Account GetAccountByUserName(string userName)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM Account WHERE UserName = '" + userName + "'");

            foreach (DataRow row in data.Rows)
            {
                return new Account(row);
            }

            return null;
        }

        public DataTable GetAccountList()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT UserName AS [Username], Display_Name AS [Name], type AS [Account Type] FROM Account");
        }

        public bool InsertAccount(string userName, string displayName, int type)
        {
            string query = string.Format("INSERT Account (UserName, Display_Name, type, PassWord) VALUES (N'{0}', N'{1}', {2}, N'{3}')", userName, displayName, type, "1962026656160185351301320480154111117132155");
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool EditAccount(string userName, string displayName, int type)
        {
            string query = string.Format("UPDATE Account SET Display_Name = N'{0}', type = {1} WHERE UserName = N'{2}'", displayName, type, userName);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool DeleteAccount(string userName)
        {
            string query = string.Format("DELETE Account WHERE UserName = N'{0}'", userName);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool ResetPassword(string userName)
        {
            string query = string.Format("UPDATE Account SET PassWord = N'1962026656160185351301320480154111117132155' WHERE UserName = N'{0}'", userName);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}