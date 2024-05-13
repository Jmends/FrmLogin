using System.Security.Cryptography;
using System.Text;
namespace FrmLogin
{
    public partial class Form1 : Form
    {
        private Dictionary<string, string> credentials = new Dictionary<string, string>(); //dictionary to hold set usernames and passwords
        
        public Form1()
        {
            InitializeComponent();
            credentials.Add("uber", CalculateMD5Hash("password"));
            credentials.Add("username", CalculateMD5Hash("12345"));
            credentials.Add("JeffyWasHere", CalculateMD5Hash("ihategreenbeans"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login();
        }
        //private void PasswordTxt_KeyDown(object sender, KeyEventArgs e)      need to fix this button click event to get it to work
        //{
        //    if (e.KeyCode == Keys.Enter)       
        //    {
        //        button1.PerformClick();
        //    }
        //}
        private void Login()
        {
            string username = UsrNameTxt.Text;
            string password = CalculateMD5Hash(PasswordTxt.Text);

            if (credentials.ContainsKey(username) && credentials[username] == password)
            {
                MessageBox.Show("Login successful");
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }

        }

        private string CalculateMD5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}
