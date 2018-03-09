using Flunt.Validations;
using Phonebook.Shared.Entities;
using System.Text;

namespace Phonebook.Domain.Entities
{
    public class User : Entity
    {
        public User()
        {

        }
        public User(string userName, string password)
        {
            UserName = userName;
            Password = password;
            Active = false;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(UserName, 3, "User.UserName", "O Nome de usuário deve possuir no mínimo 3 caracteres")
                .HasMaxLen(UserName, 20, "User.UserName", "O Nome de usuário deve possuir no máximo 20 caracteres"));
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }

        public void Activate() => Active = true;
        public void Deactivate() => Active = false;

        public bool Authenticate(string userName, string password)
        {

            var encryptPassword = EncryptPassword(Password);

            if (UserName == userName && password == encryptPassword)
                return true;

            AddNotification("User", "Usuário ou senha inválidos!");
            return false;
        }

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
