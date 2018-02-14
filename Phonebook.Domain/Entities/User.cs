using System.Text;

namespace Phonebook.Domain.Entities
{
    public class User
    {
        public User()
        {

        }
        public User(string userName, string password)
        {
            UserName = userName;
            Password = password;
            Active = false;
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }

        public void Activate() => Active = true;
        public void Desactivate() => Active = false;

        private string EncryptPassword(string pass)
        {
            if (string.IsNullOrEmpty(pass)) return "";
            var password = (pass += "|2d331cca-f6c0-40c0-bb43-6e32989c2881");
            var md5 = System.Security.Cryptography.MD5.Create();
            var data = md5.ComputeHash(Encoding.Default.GetBytes(password));
            var sbString = new StringBuilder();
            foreach (var t in data)
                sbString.Append(t.ToString("x2"));

            return sbString.ToString();
        }
    }
}
